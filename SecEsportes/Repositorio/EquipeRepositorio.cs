using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using SecEsportes.Modelo;
using SecEsportes.Infraestrutura;
using System.Data.SQLite;

namespace SecEsportes.Repositorio {
    public class EquipeRepositorio {
        #region Implementação Singleton
        private static EquipeRepositorio instance = null;
        public static EquipeRepositorio Instance {
            get {
                if (instance == null) {
                    instance = new EquipeRepositorio();
                }
                return instance;
            }
        }
        #endregion

        private EquipeRepositorio() {

        }

        public void CreateTable(SQLiteConnection connection) {
            //Criação da tabela Equipe
            if (connection.GetSchema("Tables", new[] { null, null, "Equipe", null }).Rows.Count == 0) {
                SQLiteCommand command = connection.CreateCommand();

                command.CommandText = "CREATE Table Equipe (" +
                    "id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "codigo NVARCHAR(10) NOT NULL UNIQUE, " +
                    "nome NVARCHAR(100) NOT NULL) ";
                command.ExecuteNonQuery();
            }

            //Criação da tabela Equipe_Competicao
            if (connection.GetSchema("Tables", new[] { null, null, "Equipe_Competicao", null }).Rows.Count == 0) {
                SQLiteCommand command = connection.CreateCommand();

                command.CommandText = "CREATE Table Equipe_Competicao (" +
                    "id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "id_Equipe INTEGER, " +
                    "id_Competicao INTEGER, " +
                    "id_Treinador INTEGER, " +
                    "id_Representante INTEGER, " +
                    "jogos INTEGER, " +
                    "golsPro INTEGER, " +
                    "golsContra INTEGER, " +
                    "vitorias INTEGER, " +
                    "empates INTEGER, " +
                    "derrotas INTEGER, " +
                    "nome NVARCHAR(100) NOT NULL, " +
                    "FOREIGN KEY(id_Equipe) REFERENCES Equipe(id), " +
                    "FOREIGN KEY(id_Competicao) REFERENCES Competicao(id), " +
                    "FOREIGN KEY(id_Treinador) REFERENCES Pessoa(id), " +
                    "FOREIGN KEY(id_Representante) REFERENCES Pessoa(id) " +
                    ") ";
                command.ExecuteNonQuery();
            }

            //Criação da tabela Equipe_ComissaoTecnica
            if (connection.GetSchema("Tables", new[] { null, null, "Equipe_ComissaoTecnica", null }).Rows.Count == 0) {
                SQLiteCommand command = connection.CreateCommand();

                command.CommandText = "CREATE Table Equipe_ComissaoTecnica (" +
                    "id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "id_Equipe INTEGER, " +
                    "id_Competicao INTEGER, " +
                    "id_Funcao INTEGER, " +
                    "id_Pessoa INTEGER, " +
                    "FOREIGN KEY(id_Equipe) REFERENCES Equipe(id), " +
                    "FOREIGN KEY(id_Competicao) REFERENCES Competicao(id), " +
                    "FOREIGN KEY(id_Funcao) REFERENCES Funcao(id), " +
                    "FOREIGN KEY(id_Pessoa) REFERENCES Pessoa(id) " +
                    ") ";
                command.ExecuteNonQuery();
            }

            //Criação da tabela Equipe_Atletas
            if (connection.GetSchema("Tables", new[] { null, null, "Equipe_Atletas", null }).Rows.Count == 0) {
                SQLiteCommand command = connection.CreateCommand();

                command.CommandText = "CREATE Table Equipe_Atletas (" +
                    "id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "id_Equipe INTEGER, " +
                    "id_Competicao INTEGER, " +
                    "id_Funcao INTEGER, " +
                    "id_Atleta INTEGER, " +
                    "numero INTEGER, " +
                    "FOREIGN KEY(id_Equipe) REFERENCES Equipe(id), " +
                    "FOREIGN KEY(id_Competicao) REFERENCES Competicao(id), " +
                    "FOREIGN KEY(id_Funcao) REFERENCES Funcao(id), " +
                    "FOREIGN KEY(id_Atleta) REFERENCES Pessoa(id) " +
                    ") ";
                command.ExecuteNonQuery();
            }
        }
        public Equipe get(int id) {
            string myString = "";
            return get(id, ref myString);
        }
        public Equipe get(int id, ref string messageError) {
            try {
                using (var connection = SQLiteDatabase.Instance.SQLiteDatabaseConnection()) {
                    connection.Open();

                    Equipe equipe = connection.Query<Equipe>(
                        "SELECT * FROM Equipe WHERE id = @id", new { id })
                        .FirstOrDefault();

                    return equipe;
                }
            }
            catch (Exception ex) {
                messageError = ex.Message;
                return null;
            }
        }
        public List<Equipe> get(ref string messageError) {
            try {
                using (var connection = SQLiteDatabase.Instance.SQLiteDatabaseConnection()) {
                    connection.Open();

                    List<Equipe> equipes = connection.Query<Equipe>("SELECT * FROM Equipe").ToList();

                    return equipes;
                }
            }
            catch (Exception ex) {
                messageError = ex.Message;
                return null;
            }
        }
        public int getNumAtletasPorCompeticao(int id_Competicao, int id_Equipe) {
            try {
                using (var connection = SQLiteDatabase.Instance.SQLiteDatabaseConnection()) {
                    connection.Open();

                    string strSQL;
                    strSQL = "SELECT COUNT(1) " +
                                "FROM   Equipe_Atletas EA " +
                                "WHERE  EA.id_Competicao = @id_Competicao " +
                                "       AND EA.id_Equipe = @id_Equipe ";

                    return connection.Query<int>(strSQL,
                        new {
                            id_Competicao,
                            id_Equipe
                        }).First();
                }
            }
            catch (Exception ex) {
                return -1;
            }
        }
        public bool insert(ref Equipe equipe, ref string messageError) {
            try {
                equipe.id = SQLiteDatabase.Instance.SQLiteDatabaseConnection().Query<int>("" +
                    "INSERT INTO Equipe (Codigo, Nome) VALUES (@Codigo, @Nome); select last_insert_rowid()",
                    equipe).First();
                return true;
            }
            catch (Exception ex) {
                messageError = ex.Message;
                return false;
            }
        }
        public bool insertAtletaEmEquipe(int idCompeticao, int idEquipe, Atleta_Insert atleta) {
            try {

                string strSQL;
                strSQL = "INSERT INTO Equipe_Atletas (id_Equipe, id_Competicao, id_Funcao, id_Atleta, numero) " +
                            "VALUES " +
                            "(@id_Equipe, @id_Competicao, @id_Funcao, @id_Atleta, @numero) ";

                SQLiteDatabase.Instance.SQLiteDatabaseConnection().Query(strSQL,
                    new {
                        id_Equipe = idEquipe,
                        id_Competicao = idCompeticao,
                        id_Funcao = atleta.id_funcao,
                        id_Atleta = atleta.id_pessoa,
                        numero = 0
                    });
                return true;
            }
            catch (Exception ex) {
                return false;
            }
        }
        public bool update(Equipe equipe, ref string messageError) {
            try {
                SQLiteDatabase.Instance.SQLiteDatabaseConnection().Query(
                    "UPDATE Equipe SET Codigo = @Codigo, Nome = @Nome WHERE id = @id", equipe);
                return true;
            }
            catch (Exception ex) {
                messageError = ex.Message;
                return false;
            }
        }
        public bool update(EquipeCompeticao equipe, Competicao competicao) {
            try {

                string strSQL;
                strSQL =    "UPDATE Equipe_Competicao " +
                            "SET    id_Treinador = @id_Treinador, " +
                            "       id_Representante = @id_Representante " +
                            "WHERE  id_Equipe = @id_Equipe " +
                            "       AND id_Competicao = @id_Competicao ";

                SQLiteDatabase.Instance.SQLiteDatabaseConnection().Query(strSQL,
                    new {   id_Treinador = equipe.treinador.id_pessoa,
                            id_Representante = equipe.representante.id_pessoa,
                            id_Equipe = equipe.id,
                            id_Competicao = competicao.id
                    });
                return true;
            } catch (Exception ex) { 
                return false;
            }
        }
        public bool delete(Equipe equipe, ref string messageError) {
            try {
                SQLiteDatabase.Instance.SQLiteDatabaseConnection().Query(
                    "DELETE FROM Equipe WHERE id = @id", equipe);
                return true;
            }
            catch (Exception ex) {
                messageError = ex.Message;
                return false;
            }
        }
        public bool deletaAtletaDaEquipe(int id_Competicao, int id_Equipe, Atleta atleta, ref string messageError) {
            try {
                string strSQL;
                strSQL =    "DELETE FROM Equipe_Atletas " +
                            "WHERE  id_Competicao = @id_Competicao " +
                            "       AND id_Equipe = @id_Equipe " +
                            "       AND id_Atleta = @id_Atleta ";

                SQLiteDatabase.Instance.SQLiteDatabaseConnection().Query(strSQL,
                    new {   id_Competicao,
                            id_Equipe,
                            id_Atleta = atleta.id_pessoa
                    });
                return true;
            }catch (Exception ex) {
                messageError = ex.Message;
                return false;
            }
        }
        public List<EquipeCompeticao> getEquipesByCompeticao(int idCompeticao) {
            string myString = String.Empty;
            return getEquipesByCompeticao(idCompeticao, ref myString);
        }
        public EquipeCompeticao getEquipeCompeticao(int id_Equipe, int id_Competicao) {
            string myString = "";
            return getEquipeCompeticao(id_Equipe, id_Competicao, ref myString);
        }
        public EquipeCompeticao getEquipeCompeticao(int id_Equipe, int id_Competicao, ref string messageError) {
            try {
                using (var connection = SQLiteDatabase.Instance.SQLiteDatabaseConnection()) {
                    connection.Open();

                    EquipeCompeticao equipe = connection.Query<EquipeCompeticao>("" +
                        "SELECT * " +
                        "FROM   Equipe_Competicao " +
                        "       INNER JOIN Equipe ON Equipe_Competicao.id_Equipe = Equipe.id " +
                        "WHERE  Equipe_Competicao.id_Equipe = @id_Equipe " +
                        "       AND Equipe_Competicao.id_Competicao = @id_Competicao",
                        new {
                            id_Equipe,
                            id_Competicao
                        }).First();

                    equipe.comissaotecnica = getFuncoesByEquipeCompeticao(id_Competicao, equipe.id);
                    equipe.atletas = getAtletasByEquipeCompeticao(id_Competicao, equipe.id);
                    equipe.representante = PessoaRepositorio.Instance.getCargo(equipe.id_representante);
                    equipe.treinador = PessoaRepositorio.Instance.getCargo(equipe.id_treinador);

                    return equipe;
                }
            } catch (Exception ex) {
                messageError = ex.Message;
                return null;
            }
        }
        public List<EquipeCompeticao> getEquipesByCompeticao(int idCompeticao, ref string messageError) {
            try {
                using (var connection = SQLiteDatabase.Instance.SQLiteDatabaseConnection()) {
                    connection.Open();

                    List<EquipeCompeticao> equipes = connection.Query<EquipeCompeticao>("" +
                        "SELECT * " +
                        "FROM   Equipe_Competicao " +
                        "       INNER JOIN Equipe ON Equipe_Competicao.id_Equipe = Equipe.id " +
                        "WHERE  Equipe_Competicao.id_Competicao = @idCompeticao ",
                        new {
                            idCompeticao
                        }).ToList();

                    for (int iCount = 0; iCount < equipes.Count; iCount++) {
                        equipes[iCount].comissaotecnica = getFuncoesByEquipeCompeticao(idCompeticao, equipes[iCount].id);
                        equipes[iCount].atletas = getAtletasByEquipeCompeticao(idCompeticao, equipes[iCount].id);
                        equipes[iCount].representante = PessoaRepositorio.Instance.getCargo(equipes[iCount].id_representante);
                        equipes[iCount].treinador = PessoaRepositorio.Instance.getCargo(equipes[iCount].id_treinador);
                    }

                    return equipes;
                }
            }
            catch (Exception ex) {
                messageError = ex.Message;
                return null;
            }
        }

        private List<Atleta> getAtletasByEquipeCompeticao(int idCompeticao, int idEquipe) {
            try {
                using (var connection = SQLiteDatabase.Instance.SQLiteDatabaseConnection()) {
                    connection.Open();

                    List<Atleta> atletas = connection.Query<Atleta>("" +
                        "SELECT Equipe_Atletas.id, " +
                        "       Funcao.*, " +
                        "       Pessoa.* " +
                        "FROM   Equipe_Atletas " +
                        "       INNER JOIN Funcao ON Equipe_Atletas.id_Funcao = Funcao.id " +
                        "       INNER JOIN Pessoa ON Equipe_Atletas.id_Pessoa = Pessoa.id " +
                        "WHERE  Equipe_Atletas.id_Equipe = " + idEquipe + " " +
                        "       AND Equipe_Atletas.id_Competicao = " + idCompeticao +
                        "       AND Equipe_Atletas.Codigo = '" + FuncaoRepositorio.Instance.codigoAtleta + "'").ToList();

                    return atletas;
                }
            }
            catch (Exception ex) {
                return null;
            }
        }

        private List<Cargo> getFuncoesByEquipeCompeticao(int idCompeticao, int idEquipe) {
            try {
                using (var connection = SQLiteDatabase.Instance.SQLiteDatabaseConnection()) {
                    connection.Open();

                    List<Cargo> cargos = connection.Query<Cargo>("" +
                        "SELECT Equipe_ComissaoTecnica.id, " +
                        "       Funcao.*, " +
                        "       Pessoa.* " +
                        "FROM   Equipe_ComissaoTecnica " +
                        "       INNER JOIN Funcao ON Equipe_ComissaoTecnica.id_Funcao = Funcao.id " +
                        "       INNER JOIN Pessoa ON Equipe_ComissaoTecnica.id_Pessoa = Pessoa.id " +
                        "WHERE  Equipe_ComissaoTecnica.id_Equipe = " + idEquipe + " " +
                        "       AND Equipe_ComissaoTecnica.id_Competicao = " + idCompeticao).ToList();

                    return cargos;
                }
            }
            catch (Exception ex) {
                return null;
            }
        }

        public List<Equipe_Insert> getEquipesForaCompeticao(ref string errorMessage, int id_Competicao) {
            try {
                using (var connection = SQLiteDatabase.Instance.SQLiteDatabaseConnection()) {
                    connection.Open();

                    string strSQL;
                    strSQL = "SELECT 0 As selected, " +
                                "       * " +
                                "FROM   Equipe " +
                                "WHERE  id NOT IN ( SELECT  Equipe_Competicao.id_Equipe " +
                                "                   FROM    Equipe_Competicao " +
                                "                   WHERE   id_Competicao = @id_Competicao) " +
                                "ORDER BY Equipe.Nome ";

                    List<Equipe_Insert> equipes = connection.Query<Equipe_Insert>(strSQL, new { id_Competicao }).ToList();

                    return equipes;
                }
            }
            catch (Exception ex) {
                errorMessage = ex.Message;
                return null;
            }
        }

    }
}