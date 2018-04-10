using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using SecEsportes.Modelo;
using SecEsportes.Infraestrutura;
using System.Data.SQLite;

namespace SecEsportes.Repositorio {
    public class CompeticaoRepositorio {
        #region Implementação Singleton
        private static CompeticaoRepositorio instance = null;
        public static CompeticaoRepositorio Instance {
            get {
                if (instance == null) {
                    instance = new CompeticaoRepositorio();
                }
                return instance;
            }
        }
        #endregion

        private CompeticaoRepositorio() {

        }

        public void CreateTable(SQLiteConnection connection) {
            //Criação da tabela Competicao
            if (connection.GetSchema("Tables", new[] { null, null, "Competicao", null }).Rows.Count == 0) {
                SQLiteCommand command = connection.CreateCommand();

                command.CommandText = "CREATE Table Competicao (" +
                    "id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "nome NVARCHAR(100) NOT NULL, " +
                    "dataInicial DATETIME NOT NULL, " +
                    "dataFinal DATETIME NULL, " +
                    "id_Modalidade INTEGER, " +
                    "numTimes INTEGER, " +
                    "numGrupos INTEGER, " +
                    "mataMata INTEGER, " +
                    "jogosIdaEVolta INTEGER, " +
                    "jogosIdaEVolta_MataMata INTEGER, " +
                    "status INTEGER, " +
                    "nomesGrupos INTEGER, " +
                    "FOREIGN KEY(id_Modalidade) REFERENCES modalidade(id) " +
                    ") ";
                command.ExecuteNonQuery();
            }

            //Criação da tabela Competicoes
            if (connection.GetSchema("Tables", new[] { null, null, "Competicao_Grupos", null }).Rows.Count == 0) {
                SQLiteCommand command = connection.CreateCommand();

                command.CommandText = "CREATE Table Competicao_Grupos (" +
                    "id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "id_Competicao INTEGER, " +
                    "id_Equipe INTEGER, " +
                    "numGrupo INTEGER, " +
                    "FOREIGN KEY(id_Competicao) REFERENCES Competicao(id), " +
                    "FOREIGN KEY(id_Equipe) REFERENCES Equipe_Competicao(id_Equipe) " +
                    ") ";
                command.ExecuteNonQuery();
            }

        }
        public Competicao get(int id) {
            string myString = String.Empty;
            return get(id, ref myString);
        }
        public Competicao get(int id, ref string messageError) {
            try {
                using (var connection = SQLiteDatabase.Instance.SQLiteDatabaseConnection()) {
                    connection.Open();

                    Competicao competicao = connection.Query<Competicao>(
                        "SELECT * FROM Competicao WHERE id = @id", new { id })
                        .FirstOrDefault();

                    competicao.equipes = EquipeRepositorio.Instance.getEquipesByCompeticao(competicao.id);
                    competicao.grupos = new List<List<EquipeCompeticao>>();

                    return competicao;
                }
            } catch (Exception ex) {
                messageError = ex.Message;
                return null;
            }
        }
        public List<Competicao> get() {
            string myString = String.Empty;
            return get(ref myString);
        }
        public List<Competicao> get(ref string messageError) {
            try {
                using (var connection = SQLiteDatabase.Instance.SQLiteDatabaseConnection()) {
                    connection.Open();

                    List<Competicao> competicoes = connection.Query<Competicao>("SELECT * FROM Competicao").ToList();
                    for (int iCount = 0; iCount < competicoes.Count; iCount++) {
                        competicoes[iCount].equipes = EquipeRepositorio.Instance.getEquipesByCompeticao(competicoes[iCount].id);
                        competicoes[iCount].modalidade = ModalidadeRepositorio.Instance.get(competicoes[iCount].id_Modalidade);
                        competicoes[iCount].grupos = getGruposPorCompeticao(competicoes[iCount].id);
                    }

                    return competicoes;
                }
            } catch (Exception ex) {
                messageError = ex.Message;
                return null;
            }
        }

        private List<List<EquipeCompeticao>> getGruposPorCompeticao(int id_competicao) {
            try {
                using (var connection = SQLiteDatabase.Instance.SQLiteDatabaseConnection()) {
                    connection.Open();

                    List<List<EquipeCompeticao>> grupos = new List<List<EquipeCompeticao>>();

                    string strSQL;
                    strSQL = "SELECT count(1) FROM Competicao_Grupos WHERE id_competicao = @id_competicao GROUP BY numGrupo ";

                    int numGrupos = connection.Query<int>(strSQL,
                        new {   id_competicao
                    }).First();

                    // Percorre todos os grupos
                    for (int numGrupo = 0; numGrupo < numGrupos; numGrupo++) {
                        strSQL =    "SELECT id_Equipe " +
                                    "FROM   Competicao_Grupos " +
                                    "WHERE  id_competicao = @id_competicao " +
                                    "       AND numGrupo = @numGrupo ";

                        List<int> idEquipes = connection.Query<int>(strSQL, 
                            new {   id_competicao,
                                    numGrupo }).ToList();

                        grupos.Add(new List<EquipeCompeticao>());

                        // Adiciona todas as equipes no grupo
                        for (int numEquipe = 0; numEquipe < idEquipes.Count; numEquipe++) {
                            grupos[numGrupo].Add(EquipeRepositorio.Instance.getEquipeCompeticao(idEquipes[numEquipe], id_competicao));
                        }
                    }

                    return grupos;
                }
            } catch (Exception ex) {
                return null;
            }
        }

        public bool insert(ref Competicao competicao, ref string messageError) {
            try {
                competicao.id = SQLiteDatabase.Instance.SQLiteDatabaseConnection().Query<int>("" +
                    "INSERT INTO Competicao " +
                    "(Nome, dataInicial, dataFinal, id_Modalidade, numTimes, numGrupos, mataMata, jogosIdaEVolta, jogosIdaEvolta_MataMata, status, nomesGrupos) " +
                    "VALUES " +
                    "(@Nome, @dataInicial, @dataFinal, @id_Modalidade, @numTimes, @numGrupos, @mataMata, @jogosIdaEVolta, @jogosIdaEVolta_MataMata, @status, @nomesGrupos); " +
                    "select last_insert_rowid()",
                    new {
                        competicao.nome,
                        competicao.dataInicial,
                        competicao.dataFinal,
                        id_Modalidade = competicao.modalidade.id,
                        competicao.numTimes,
                        competicao.numGrupos,
                        competicao.mataMata,
                        jogosIdaEVolta = (competicao.jogosIdaEVolta == true ? 1 : 0),
                        jogosIdaEVolta_MataMata = (competicao.jogosIdaEVolta_MataMata == true ? 1 : 0),
                        competicao.status,
                        competicao.nomesGrupos
                    }).First();
                return true;
            } catch (Exception ex) {
                messageError = ex.Message;
                return false;
            }
        }
        public bool insertEquipeEmCompeticao(int idCompeticao, Equipe_Insert equipe) {
            try {
                SQLiteDatabase.Instance.SQLiteDatabaseConnection().Query("" +
                    "INSERT INTO Equipe_Competicao " +
                    "(id_Equipe, id_Competicao, id_Treinador, id_Representante, jogos, golsPro, golsContra, vitorias, empates, derrotas, nome) " +
                    "VALUES " +
                    "(@idEquipe, @idCompeticao, @idTreinador, @idRepresentante, @jogos, @golsPro, @golsContra, @vitorias, @empates, @derrotas, @nome); ",
                    new {
                        idEquipe = equipe.id,
                        idCompeticao,
                        idTreinador = -1,
                        idRepresentante = -1,
                        jogos = 0,
                        golsPro = 0,
                        golsContra = 0,
                        vitorias = 0,
                        empates = 0,
                        derrotas = 0,
                        nome = ""
                    });
                return true;
            } catch (Exception ex) {
                return false;
            }
        }
        public bool update(Competicao competicao, ref string messageError) {
            try {

                string strSQL;
                strSQL = "UPDATE Competicao " +
                            "SET    Nome = @Nome, " +
                            "       dataInicial = @dataInicial, " +
                            "       dataFinal = @dataFinal, " +
                            "       id_Modalidade = @id_Modalidade, " +
                            "       numTimes = @numTimes," +
                            "       numGrupos = @numGrupos, " +
                            "       mataMata = @mataMata, " +
                            "       jogosIdaEVolta = @jogosIdaEVolta, " +
                            "       jogosIdaEVolta_MataMata = @jogosIdaEVolta_MataMata, " +
                            "       status = @status, " +
                            "       nomesGrupos = @nomesGrupos " +
                            "WHERE id = @id";

                SQLiteDatabase.Instance.SQLiteDatabaseConnection().Query(strSQL,
                    new {
                        competicao.nome,
                        competicao.dataInicial,
                        competicao.dataFinal,
                        id_Modalidade = competicao.modalidade.id,
                        competicao.numTimes,
                        competicao.numGrupos,
                        competicao.mataMata,
                        jogosIdaEVolta = (competicao.jogosIdaEVolta == true ? 1 : 0),
                        jogosIdaEVolta_MataMata = (competicao.jogosIdaEVolta_MataMata == true ? 1 : 0),
                        competicao.status,
                        competicao.nomesGrupos,
                        competicao.id
                    });
                return true;
            } catch (Exception ex) {
                messageError = ex.Message;
                return false;
            }
        }
        public bool updateGrupos(int id_Competicao, int numGrupo, int id_Equipe) {
            try {

                string strSQL;
                strSQL = "INSERT INTO Competicao_Grupos " +
                            "(id_Competicao, id_Equipe, numGrupo) " +
                            "VALUES " +
                            "(@id_Competicao, @id_Equipe, @numGrupo) ";

                SQLiteDatabase.Instance.SQLiteDatabaseConnection().Query(strSQL,
                    new {
                        id_Competicao,
                        id_Equipe,
                        numGrupo
                    });
                return true;
            } catch (Exception ex) {
                return false;
            }
        }
        public bool delete(Competicao competicao, ref string messageError) {
            try {
                SQLiteDatabase.Instance.SQLiteDatabaseConnection().Query(
                    "DELETE FROM Competicao WHERE id = @id", competicao);
                return true;
            } catch (Exception ex) {
                messageError = ex.Message;
                return false;
            }
        }
        public bool deleteEquipe(EquipeCompeticao equipe, ref string messageError) {
            try {
                SQLiteDatabase.Instance.SQLiteDatabaseConnection().Query(
                    "DELETE FROM Equipe_Competicao WHERE id = @id", equipe);
                return true;
            } catch (Exception ex) {
                messageError = ex.Message;
                return false;
            }
        }
        public bool deleteEquipeDaCompeticao(EquipeCompeticao equipe, int idCompeticao, ref string messageError) {
            try {
                SQLiteDatabase.Instance.SQLiteDatabaseConnection().Query(
                    "DELETE FROM Equipe_Competicao WHERE id_Equipe = @idEquipe AND id_Competicao = @idCompeticao",
                    new {
                        idEquipe = equipe.id,
                        idCompeticao
                    });
                return true;
            } catch (Exception ex) {
                messageError = ex.Message;
                return false;
            }
        }

        public bool deleteEquipeDoGrupo(int id_Competicao, int numGrupo, int id_Equipe) {
            try {

                string strSQL;
                strSQL = "DELETE FROM Competicao_Grupos " +
                            "WHERE  id_Competicao = @id_Competicao " +
                            "       AND id_Equipe = @id_Equipe " +
                            "       AND numGrupo = @numGrupo ";

                SQLiteDatabase.Instance.SQLiteDatabaseConnection().Query(strSQL,
                    new {
                        id_Competicao,
                        id_Equipe,
                        numGrupo
                    });
                return true;
            } catch (Exception ex) {
                return false;
            }
        }

        public bool deleteGrupos(int id_Competicao) {
            try {

                string strSQL;
                strSQL = "DELETE FROM Competicao_Grupos " +
                            "WHERE  id_Competicao = @id_Competicao ";

                SQLiteDatabase.Instance.SQLiteDatabaseConnection().Query(strSQL,
                    new {
                        id_Competicao
                    });
                return true;
            } catch (Exception ex) {
                return false;
            }
        }
    }
}