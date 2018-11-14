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
                    "faseFinal INTEGER, " +
                    "jogosIdaEVolta INTEGER, " +
                    "jogosIdaEVolta_FaseFinal INTEGER, " +
                    "status INTEGER, " +
                    "nomesGrupos INTEGER, " +
                    "numMinimoJogadores INTEGER, " +
                    "id_Campeao INTEGER, " +
                    "fase_Atual INTEGER, " +
                    "zerarCartoesFaseFinal INTEGER, " +
                    "tpSuspensao INTEGER, " +
                    "FOREIGN KEY(id_Modalidade) REFERENCES modalidade(id) " +
                    "FOREIGN KEY(id_Campeao) REFERENCES Equipe_Competicao(id) " +
                    ") ";
                command.ExecuteNonQuery();
            }

            //Criação da tabela Competicao_Grupos
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

            //Criação da tabela Competicao_Partida
            if (connection.GetSchema("Tables", new[] { null, null, "Competicao_Partida", null }).Rows.Count == 0) {
                SQLiteCommand command = connection.CreateCommand();

                command.CommandText = "CREATE TABLE Competicao_Partida( " +
                                        "    id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                        "    id_Competicao INTEGER, " +
                                        "    id_Equipe1 INTEGER, " +
                                        "    id_Equipe2 INTEGER, " +
                                        "    id_Arbitro INTEGER, " +
                                        "    Data DATETIME, " +
                                        "    Rodada INT, /* > 0 Representa o nº da Rodada | < 0 Representa FaseFinal (-1 Final, -2 SemiFinal, -3 Quartas de final, etc.)*/ " +
                                        "    numGrupo INT, " +
                                        "    encerrada INT, " +
                                        "    FOREIGN KEY(id_Competicao) REFERENCES Competicao(id), " +
                                        "    FOREIGN KEY(id_Equipe1) REFERENCES Equipe_Competicao(id_Equipe), " +
                                        "    FOREIGN KEY(id_Equipe2) REFERENCES Equipe_Competicao(id_Equipe) " +
                                        ")";
                command.ExecuteNonQuery();
            }

            //Criação da tabela Competicao_Partida_Evento
            if (connection.GetSchema("Tables", new[] { null, null, "Competicao_Partida_Evento", null }).Rows.Count == 0) {
                SQLiteCommand command = connection.CreateCommand();

                command.CommandText =   "CREATE TABLE Competicao_Partida_Evento( " +
                                        "    id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                        "    id_Partida INTEGER, " +
                                        "    id_Equipe INTEGER, " +
                                        "    id_Atleta INTEGER, " +
                                        "    tpEvento INTEGER, " +
                                        "    FOREIGN KEY(id_Partida) REFERENCES Competicao_Partida(id), " +
                                        "    FOREIGN KEY(id_Equipe) REFERENCES Equipe_Competicao(id_Equipe), " +
                                        "    FOREIGN KEY(id_Atleta) REFERENCES Pessoa(id) " +
                                        ") ";
                command.ExecuteNonQuery();
            }

            //Criação da tabela Competicao_Arbitragem
            if (connection.GetSchema("Tables", new[] { null, null, "Competicao_Arbitragem", null }).Rows.Count == 0) {
                SQLiteCommand command = connection.CreateCommand();

                command.CommandText = "CREATE TABLE Competicao_Arbitragem( " +
                                        "    id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                        "    id_Competicao INTEGER, " +
                                        "    id_Arbitro INTEGER, " +
                                        "    FOREIGN KEY(id_Competicao) REFERENCES Competicao(id), " +
                                        "    FOREIGN KEY(id_Arbitro) REFERENCES Pessoa(id) " +
                                        ") ";
                command.ExecuteNonQuery();
            }

            //Criação da tabela Competicao_Suspensao
            if (connection.GetSchema("Tables", new[] { null, null, "Competicao_Suspensao", null }).Rows.Count == 0) {
                SQLiteCommand command = connection.CreateCommand();

                command.CommandText = "CREATE TABLE Competicao_Suspensao( " +
                                        "    id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                        "    id_Competicao INTEGER, " +
                                        "    id_Equipe INTEGER, " +
                                        "    id_Atleta INTEGER, " +
                                        "    numJogosSuspensao INTEGER, " +
                                        "    FOREIGN KEY(id_Competicao) REFERENCES Competicao(id), " +
                                        "    FOREIGN KEY(id_Equipe) REFERENCES Equipe_Competicao(id_Equipe), " +
                                        "    FOREIGN KEY(id_Atleta) REFERENCES Pessoa(id) " +
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

                    competicao.modalidade = ModalidadeRepositorio.Instance.get(competicao.id_Modalidade);
                    competicao.campeao = EquipeRepositorio.Instance.getEquipeCompeticao(competicao.id_Campeao, competicao.id);

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
                        competicoes[iCount].modalidade = ModalidadeRepositorio.Instance.get(competicoes[iCount].id_Modalidade);
                        competicoes[iCount].campeao = EquipeRepositorio.Instance.getEquipeCompeticao(competicoes[iCount].id_Campeao, competicoes[iCount].id);
                    }

                    return competicoes;
                }
            } catch (Exception ex) {
                messageError = ex.Message;
                return null;
            }
        }
        public List<Competicao_Partida> getPartidasPorCompeticao(int id_Competicao) {
            try {
                using (var connection = SQLiteDatabase.Instance.SQLiteDatabaseConnection()) {
                    connection.Open();

                    string strSQL;
                    strSQL =    "SELECT * " +
                                "FROM   Competicao_Partida " +
                                "WHERE  id_Competicao = @id_Competicao ";

                    List<Competicao_Partida> partidas = connection.Query<Competicao_Partida>(strSQL,
                        new {
                            id_Competicao
                        }).ToList();

                    foreach (Competicao_Partida partida in partidas) {
                        partida.equipe1 = EquipeRepositorio.Instance.getEquipeCompeticao(partida.id_Equipe1, id_Competicao);
                        partida.equipe2 = EquipeRepositorio.Instance.getEquipeCompeticao(partida.id_Equipe2, id_Competicao);
                        partida.eventos = getEventosPorPartida(partida.id, id_Competicao);
                        partida.arbitro = PessoaRepositorio.Instance.getCargo(partida.id_Arbitro);
                    }
                        

                    return partidas;
                }
            } catch (Exception ex) {
                return null;
            }
        }
        public List<Cargo> getArbitroPorCompeticao(int id_Competicao) {
            try {
                using (var connection = SQLiteDatabase.Instance.SQLiteDatabaseConnection()) {
                    connection.Open();

                    List<Cargo> arbitros = new List<Cargo>();
                    Funcao funcaoArbitro = null;

                    string strSQL;
                    strSQL =    "SELECT id_Arbitro " +
                                "FROM   Competicao_Arbitragem " +
                                "WHERE  id_Competicao = @id_Competicao ";

                    List<int> idArbitros = connection.Query<int>(strSQL,
                        new { id_Competicao }).ToList();

                    for (int iCount = 0; iCount < idArbitros.Count; iCount++) {
                        Pessoa pessoaArbitro = PessoaRepositorio.Instance.get(idArbitros[iCount]);
                        if (funcaoArbitro is null)
                            funcaoArbitro = pessoaArbitro.funcoes.Find(find => find.codigo.Equals(FuncaoRepositorio.Instance.codigoArbitro));

                        arbitros.Add(new Cargo(pessoaArbitro.id, funcaoArbitro, pessoaArbitro));
                    }

                    return arbitros;
                }
            } catch (Exception ex) {
                return null;
            }
        }
        private List<Competicao_Partida_Evento> getEventosPorPartida(int id_Partida, int id_Competicao) {
            try {
                using (var connection = SQLiteDatabase.Instance.SQLiteDatabaseConnection()) {
                    connection.Open();

                    string strSQL;
                    strSQL =    "SELECT * " +
                                "FROM   Competicao_Partida_Evento " +
                                "WHERE  id_Partida = @id_Partida ";

                    List<Competicao_Partida_Evento> eventos = connection.Query<Competicao_Partida_Evento>(strSQL,
                        new {   id_Partida
                        }).ToList();

                    foreach (Competicao_Partida_Evento evento in eventos) {
                        evento.atleta = PessoaRepositorio.Instance.getAtleta(evento.id_Atleta);
                        evento.equipe = EquipeRepositorio.Instance.getEquipeCompeticao(evento.id_Equipe, id_Competicao);
                    }

                    return eventos;
                }
            } catch (Exception ex) {
                return null;
            }
        }
        public List<List<EquipeCompeticao>> getGruposPorCompeticao(int id_competicao, List<EquipeCompeticao> equipesNaCompeticao) {
            try {
                using (var connection = SQLiteDatabase.Instance.SQLiteDatabaseConnection()) {
                    connection.Open();

                    List<List<EquipeCompeticao>> grupos = new List<List<EquipeCompeticao>>();

                    string strSQL;
                    strSQL = "SELECT COUNT(DISTINCT numGrupo) FROM Competicao_Grupos WHERE id_competicao = @id_competicao ";

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
                            EquipeCompeticao equipeNoGrupo = equipesNaCompeticao.Find(find => find.id == idEquipes[numEquipe]);
                            grupos[numGrupo].Add(equipeNoGrupo);
                            //grupos[numGrupo].Add(EquipeRepositorio.Instance.getEquipeCompeticao(idEquipes[numEquipe], id_competicao));
                        }
                    }

                    return grupos;
                }
            } catch (Exception ex) {
                return null;
            }
        }
        public int getNumRodadas(Competicao competicao) {
            try {
                using (var connection = SQLiteDatabase.Instance.SQLiteDatabaseConnection()) {
                    connection.Open();

                    string strSQL;
                    strSQL = "SELECT MAX(rodada) FROM Competicao_Partida WHERE id_Competicao = @id_Competicao ";

                    int partidaJaExistente = connection.Query<int>(strSQL,
                        new {
                            id_Competicao = competicao.id,
                        }).First();

                    return partidaJaExistente;
                }
            } catch (Exception ex) {
                return -1;
            }
        }
        public List<Atleta_List_Artilheiro> getArtilheiros(int id_Competicao) {
            try {
                using (var connection = SQLiteDatabase.Instance.SQLiteDatabaseConnection()) {
                    connection.Open();

                    string strSQL;
                    strSQL =    "SELECT Competicao_Partida_Evento.id_Atleta, " +
                                "       Equipe.nome AS nome_Equipe, " +
                                "		(SELECT COUNT(1) FROM Competicao_Partida WHERE encerrada = 1 AND(id_Equipe1 = Equipe.id OR id_Equipe2 = Equipe.id)) AS num_Partidas, " +
                                "       COUNT(1) AS num_Gols " +
                                "FROM   Competicao_Partida_Evento " +
                                "       INNER JOIN Competicao_Partida ON Competicao_Partida_Evento.id_Partida = Competicao_Partida.id " +
                                "       INNER JOIN Competicao ON Competicao_Partida.id_Competicao = Competicao.id " +
                                "       INNER JOIN Equipe ON Competicao_Partida_Evento.id_Equipe = Equipe.id " +
                                "WHERE  Competicao.id = @id_Competicao " +
                                "       AND Competicao_Partida_Evento.tpEvento = @tpEvento " +
                                "GROUP " +
                                "BY     Competicao_Partida_Evento.id_Atleta, " +
                                "       Equipe.nome " +
                                "ORDER " +
                                "BY     num_Gols DESC, num_Partidas ASC; ";

                    List<Atleta_List_Artilheiro> artilheiros = connection.Query<Atleta_List_Artilheiro>(strSQL,
                        new {   id_Competicao,
                                tpEvento = tpEventoEnum.Gol
                        }).ToList();

                    foreach(Atleta_List_Artilheiro artilheiro in artilheiros){
                        artilheiro.atleta = PessoaRepositorio.Instance.getAtletaByCompeticao(artilheiro.id_Atleta, id_Competicao);
                        artilheiro.nome_Atleta = artilheiro.atleta.pessoa.nome;
                        if (artilheiro.num_Partidas > 0)
                            artilheiro.media = Convert.ToDouble(artilheiro.num_Gols) / Convert.ToDouble(artilheiro.num_Partidas);
                        else
                            artilheiro.media = 0;
                    }

                    return artilheiros;
                }
            } catch (Exception ex) {
                return null;
            }
        }
        public bool partidaJaExiste(Competicao competicao, Competicao_Partida partida) {
            try {
                using (var connection = SQLiteDatabase.Instance.SQLiteDatabaseConnection()) {
                    connection.Open();

                    string strSQL;
                    strSQL =    "SELECT COUNT(1) as Existe " +
                                "FROM   Competicao_Partida " +
                                "WHERE  id_Competicao = @id_Competicao " +
                                "       AND (   (id_Equipe1 = @id_Equipe1 AND id_Equipe2 = @id_Equipe2) OR " +
                                "               (id_Equipe1 = @id_Equipe2 AND id_Equipe2 = @id_Equipe1) ) ";

                    int partidaJaExistente = connection.Query<int>(strSQL,
                        new {
                            id_Competicao = competicao.id,
                            id_Equipe1 = partida.equipe1.id,
                            id_Equipe2 = partida.equipe2.id
                        }).First();

                    return partidaJaExistente > 0;
                }
            } catch (Exception ex) {
                return true;
            }
        }
        public int getnumPartidas(Competicao competicao) {
            int numPartidas;
            try {
                SQLiteConnection connection = SQLiteDatabase.Instance.SQLiteDatabaseConnection();
                connection.Open();

                string strSQL;
                strSQL = "SELECT COUNT(1) as NumPartidas " +
                            "FROM   Competicao_Partida " +
                            "WHERE  id_Competicao = @id_Competicao";

                numPartidas = connection.Query<int>(strSQL,
                    new {
                        id_Competicao = competicao.id
                    }).First();

            } catch (Exception ex) {
                return -1;
            }

            return numPartidas;
        }
        public int getNumPartidasEncerradas(Competicao competicao) {
            int numPartidasEncerradas;

            try {
                SQLiteConnection connection = SQLiteDatabase.Instance.SQLiteDatabaseConnection();
                connection.Open();

                string strSQL;
                strSQL = "SELECT COUNT(1) as PartidasEncerradas " +
                            "FROM   Competicao_Partida " +
                            "WHERE  id_Competicao = @id_Competicao" +
                            "       AND encerrada = 1 ";

                numPartidasEncerradas = connection.Query<int>(strSQL,
                    new {
                        id_Competicao = competicao.id
                    }).First();


            } catch (Exception ex) {
                return -1;
            }

            return numPartidasEncerradas;
        }
        public int getNumPartidasRestantes(Competicao competicao) {
            int numPartidasRestantes;

            try {
                SQLiteConnection connection = SQLiteDatabase.Instance.SQLiteDatabaseConnection();
                connection.Open();

                string strSQL;
                if (competicao.fase_Atual == 0)
                    strSQL = "SELECT COUNT(1) as NumPartida " +
                                "FROM   Competicao_Partida " +
                                "WHERE  id_Competicao = @id_Competicao" +
                                "       AND encerrada = 0 " +
                                "       AND rodada > @faseAtual ";
                else
                    strSQL = "SELECT COUNT(1) AS NumPartida " +
                                "FROM   Competicao_Partida " +
                                "WHERE  id_Competicao = @id_Competicao" +
                                "       AND encerrada = 0 " +
                                "       AND rodada = @faseAtual ";

                numPartidasRestantes = connection.Query<int>(strSQL,
                    new {
                        id_Competicao = competicao.id,
                        faseAtual = competicao.fase_Atual
                    }).First();


            } catch (Exception ex) {
                return -1;
            }

            return numPartidasRestantes;
        }
        public bool insert(ref Competicao competicao, ref string messageError) {
            try {
                competicao.id = SQLiteDatabase.Instance.SQLiteDatabaseConnection().Query<int>("" +
                    "INSERT INTO Competicao " +
                    "(Nome, dataInicial, dataFinal, id_Modalidade, numTimes, numGrupos, faseFinal, jogosIdaEVolta, jogosIdaEvolta_FaseFinal, status, nomesGrupos, numMinimoJogadores, id_Campeao, fase_Atual, zerarCartoesFaseFinal, tpSuspensao) " +
                    "VALUES " +
                    "(@Nome, @dataInicial, @dataFinal, @id_Modalidade, @numTimes, @numGrupos, @faseFinal, @jogosIdaEVolta, @jogosIdaEVolta_faseFinal, @status, @nomesGrupos, @numMinimoJogadores, @id_Campeao, @fase_Atual, @zerarCartoesFaseFinal, @tpSuspensao); " +
                    "select last_insert_rowid()",
                    new {
                        competicao.nome,
                        competicao.dataInicial,
                        competicao.dataFinal,
                        id_Modalidade = competicao.modalidade.id,
                        competicao.numTimes,
                        competicao.numGrupos,
                        competicao.faseFinal,
                        jogosIdaEVolta = (competicao.jogosIdaEVolta == true ? 1 : 0),
                        jogosIdaEVolta_FaseFinal = (competicao.jogosIdaEVolta_FaseFinal == true ? 1 : 0),
                        competicao.status,
                        competicao.nomesGrupos,
                        competicao.numMinimoJogadores,
                        id_Campeao = (competicao.campeao is null ? 0 : competicao.campeao.id),
                        competicao.fase_Atual,
                        competicao.zerarCartoesFaseFinal,
                        competicao.tpSuspensao
                    }).First();
                return true;
            } catch (Exception ex) {
                messageError = ex.Message;
                return false;
            }
        }
        public bool insertEquipeEmCompeticao(int idCompeticao, Equipe equipe) {
            try {
                SQLiteDatabase.Instance.SQLiteDatabaseConnection().Query("" +
                    "INSERT INTO Equipe_Competicao " +
                    "(id_Equipe, id_Competicao, id_Treinador, id_Representante, jogos, golsPro, golsContra, vitorias, empates, derrotas, pontos, nome) " +
                    "VALUES " +
                    "(@idEquipe, @idCompeticao, @idTreinador, @idRepresentante, @jogos, @golsPro, @golsContra, @vitorias, @empates, @derrotas, @pontos, @nome); ",
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
                        pontos = 0,
                        nome = ""
                    });
                return true;
            } catch (Exception ex) {
                return false;
            }
        }
        public bool deletaPartidas(ref Competicao competicao) {
            try {

                string strSQL;
                strSQL = "DELETE FROM Competicao_Partida WHERE id_Competicao = @id_Competicao";

                SQLiteDatabase.Instance.SQLiteDatabaseConnection().Query(strSQL,
                    new {
                        id_Competicao = competicao.id
                    });

                competicao.partidas = new List<Competicao_Partida>();

                return true;
            } catch (Exception ex) {
                return false;
            }
        }
        public bool insertPartida(ref Competicao competicao, Competicao_Partida partida) {
            try {

                string strSQL;
                strSQL =    "INSERT INTO Competicao_Partida " +
                            "(id_Competicao, id_Equipe1, id_Equipe2, id_Arbitro, Data, Rodada, numGrupo, encerrada) " +
                            "VALUES " +
                            "(@id_Competicao, @id_Equipe1, @id_Equipe2, @id_Arbitro, @Data, @Rodada, @numGrupo, @encerrada); " +
                            "SELECT last_insert_rowid()";

                int idPartida = 0;

                int id_Arbitro;
                if (partida.arbitro is null)
                    id_Arbitro = 0;
                else
                    id_Arbitro = partida.arbitro.pessoa.id;
                
                idPartida = SQLiteDatabase.Instance.SQLiteDatabaseConnection().Query<int>(strSQL,
                    new {
                        id_Competicao = competicao.id,
                        id_Equipe1 = partida.equipe1.id,
                        id_Equipe2 = partida.equipe2.id,
                        id_Arbitro,
                        Data = string.IsNullOrEmpty(partida.data.ToString())? DateTime.Now : partida.data,
                        Rodada = partida.rodada,
                        partida.numGrupo,
                        partida.encerrada
                    }).First<int>();

                partida.id = idPartida;
                competicao.partidas.Add(partida);

                return true;
            } catch (Exception ex) {
                return false;
            }
        }
        public bool insertEvento(ref Competicao_Partida partida, Competicao_Partida_Evento evento) {
            try {

                string strSQL;
                strSQL =    "INSERT INTO Competicao_Partida_Evento " +
                            "(id_Partida, id_Equipe, id_Atleta, tpEvento) " +
                            "VALUES " +
                            "(@id_Partida, @id_Equipe, @id_Atleta, @tpEvento) ";

                SQLiteDatabase.Instance.SQLiteDatabaseConnection().Query(strSQL,
                    new {   id_Partida = partida.id,
                            id_Equipe = evento.equipe.id,
                            id_Atleta = evento.atleta.pessoa.id,
                            evento.tpEvento
                    });

                if (evento.tpEvento == tpEventoEnum.CartaoAmarelo) {
                    strSQL =    "UPDATE Equipe_Atletas " +
                                "SET    numCartoesAcumulados = numCartoesAcumulados + 1 " +
                                "WHERE  id_Equipe = @id_Equipe " +
                                "       AND id_Competicao = @id_Competicao " +
                                "       AND id_Atleta = @id_Atleta; " +
                                " " +
                                "SELECT numCartoesAcumulados " +
                                "FROM   Equipe_Atletas " +
                                "WHERE  id_Equipe = @id_Equipe " +
                                "       AND id_Competicao = @id_Competicao " +
                                "       AND id_Atleta = @id_Atleta; ";

                    if (partida.equipe1.id == evento.equipe.id)
                        partida.equipe1.atletas.Find(find => find.pessoa.id == evento.atleta.pessoa.id).numCartoesAcumulados = 
                            SQLiteDatabase.Instance.SQLiteDatabaseConnection().Query<int>(strSQL,
                            new {
                                id_Equipe = evento.equipe.id,
                                id_Competicao = partida.id_Competicao,
                                id_Atleta = evento.atleta.pessoa.id
                            }).First<int>();
                    else if (partida.equipe2.id == evento.equipe.id)
                        partida.equipe2.atletas.Find(find => find.pessoa.id == evento.atleta.pessoa.id).numCartoesAcumulados =
                            SQLiteDatabase.Instance.SQLiteDatabaseConnection().Query<int>(strSQL,
                            new {
                                id_Equipe = evento.equipe.id,
                                id_Competicao = partida.id_Competicao,
                                id_Atleta = evento.atleta.pessoa.id
                            }).First<int>();

                    //Verifica se foi o 2º cartão amarelo
                    if (partida.eventos.FindAll(find => find.atleta.pessoa.id == evento.atleta.pessoa.id && find.tpEvento == tpEventoEnum.CartaoAmarelo).Count > 1) {

                        //Verifica se já foi inserido o cartão vermelho
                        if (partida.eventos.FindAll(find => find.atleta.pessoa.id == evento.atleta.pessoa.id && find.tpEvento == tpEventoEnum.CartaoVermelho).Count == 0)
                            partida.eventos.Add(new Competicao_Partida_Evento(evento.equipe, evento.atleta, tpEventoEnum.CartaoVermelho));
                    }

                }

                return true;
            } catch (Exception ex) {
                return false;
            }
        }
        public bool update(Competicao competicao) {
            string myString = "";
            return update(competicao, ref myString);
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
                            "       faseFinal = @faseFinal, " +
                            "       jogosIdaEVolta = @jogosIdaEVolta, " +
                            "       jogosIdaEVolta_FaseFinal = @jogosIdaEVolta_FaseFinal, " +
                            "       status = @status, " +
                            "       nomesGrupos = @nomesGrupos, " +
                            "       numMinimoJogadores = @numMinimoJogadores, " +
                            "       id_Campeao = @id_Campeao, " +
                            "       fase_Atual = @fase_Atual, " +
                            "       zerarCartoesFaseFinal = @zerarCartoesFaseFinal, " +
                            "       tpSuspensao = @tpSuspensao " + 
                            "WHERE id = @id";

                SQLiteDatabase.Instance.SQLiteDatabaseConnection().Query(strSQL,
                    new {
                        competicao.nome,
                        competicao.dataInicial,
                        competicao.dataFinal,
                        id_Modalidade = competicao.modalidade.id,
                        competicao.numTimes,
                        competicao.numGrupos,
                        competicao.faseFinal,
                        jogosIdaEVolta = (competicao.jogosIdaEVolta == true ? 1 : 0),
                        jogosIdaEVolta_FaseFinal = (competicao.jogosIdaEVolta_FaseFinal == true ? 1 : 0),
                        competicao.status,
                        competicao.nomesGrupos,
                        competicao.numMinimoJogadores,
                        id_Campeao = (competicao.campeao is null ? 0 : competicao.campeao.id),
                        competicao.fase_Atual,
                        competicao.zerarCartoesFaseFinal,
                        competicao.tpSuspensao,
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
        public bool updatePartida(ref Competicao competicao, Competicao_Partida partida) {
            try {
                string strSQL;

                // Define a partida como finalizada
                strSQL =    "UPDATE Competicao_Partida " +
                            "SET    encerrada = @encerrada, " +
                            "       data = @data, " +
                            "       id_Arbitro = @id_Arbitro " +
                            "WHERE  id = @id_Partida ";

                int id_Arbitro;
                if (partida.arbitro is null)
                    id_Arbitro = 0;
                else
                    id_Arbitro = partida.arbitro.pessoa.id;

                SQLiteDatabase.Instance.SQLiteDatabaseConnection().Query(strSQL,
                    new {   partida.encerrada,
                            partida.data,
                            id_Arbitro,
                            id_Partida = partida.id
                    });

                if (partida.encerrada) {
                    int golsEquipe1, golsEquipe2;
                    golsEquipe1 = partida.eventos.FindAll(gols => gols.equipe.id.Equals(partida.equipe1.id) && gols.tpEvento.Equals(tpEventoEnum.Gol)).Count;
                    golsEquipe2 = partida.eventos.FindAll(gols => gols.equipe.id.Equals(partida.equipe2.id) && gols.tpEvento.Equals(tpEventoEnum.Gol)).Count;

                    // Se for os jogos da fase de classificação, atribui a pontuação
                    if (partida.rodada > 0) {
                        // Atualiza as informações das equipes
                        strSQL = "UPDATE Equipe_Competicao " +
                                    "SET    jogos = jogos + 1, " +
                                    "       golsPro = golsPro + @golsPro, " +
                                    "       golsContra = golsContra + @golsContra, " +
                                    "       vitorias = vitorias + @vitorias, " +
                                    "       empates = empates + @empates, " +
                                    "       derrotas = derrotas + @derrotas, " +
                                    "       pontos = pontos + @pontos " +
                                    "WHERE  id_Equipe = @id_Equipe " +
                                    "       AND id_Competicao = @id_Competicao ";

                        int vitorias, empates, derrotas, pontos;

                        // Atualiza a equipe 1
                        vitorias = (golsEquipe1 > golsEquipe2 ? 1 : 0);
                        derrotas = (golsEquipe2 > golsEquipe1 ? 1 : 0);
                        empates = (golsEquipe2 == golsEquipe1 ? 1 : 0);
                        pontos = (vitorias == 1 ? 3 : (empates == 1 ? 1 : 0));
                        SQLiteDatabase.Instance.SQLiteDatabaseConnection().Query(strSQL,
                            new {
                                golsPro = golsEquipe1,
                                golsContra = golsEquipe2,
                                vitorias,
                                empates,
                                derrotas,
                                pontos,
                                id_Equipe = partida.equipe1.id,
                                id_Competicao = competicao.id
                            });

                        // Atualiza a equipe 2
                        vitorias = (golsEquipe2 > golsEquipe1 ? 1 : 0);
                        derrotas = (golsEquipe1 > golsEquipe2 ? 1 : 0);
                        empates = (golsEquipe2 == golsEquipe1 ? 1 : 0);
                        pontos = (vitorias == 1 ? 3 : (empates == 1 ? 1 : 0));
                        SQLiteDatabase.Instance.SQLiteDatabaseConnection().Query(strSQL,
                            new {
                                golsPro = golsEquipe2,
                                golsContra = golsEquipe1,
                                vitorias,
                                empates,
                                derrotas,
                                pontos,
                                id_Equipe = partida.equipe2.id,
                                id_Competicao = competicao.id
                            });
                    }

                    // Verifica se é a final e atribui o campeão
                    if (competicao.fase_Atual == -1) {
                        if (competicao.jogosIdaEVolta_FaseFinal) {
                            Competicao_Partida partidaIda = competicao.partidas.Find(x => x.encerrada && x.rodada == partida.rodada && x.numGrupo == partida.numGrupo && x.equipe1.id == partida.equipe2.id && x.equipe2.id == partida.equipe1.id && x.id != partida.id);
                            golsEquipe1 += partidaIda.eventos.FindAll(eventos => eventos.tpEvento.Equals(tpEventoEnum.Gol) && eventos.equipe.id == partida.equipe1.id).Count;
                            golsEquipe2 += partidaIda.eventos.FindAll(eventos => eventos.tpEvento.Equals(tpEventoEnum.Gol) && eventos.equipe.id == partida.equipe2.id).Count;
                        }
                        competicao.status = StatusEnum._0_Encerrada;

                        // Verifica aqu se empatou e foi para os penaltis
                        if (golsEquipe1 == golsEquipe2) {
                            int golsPenalti1, golsPenalti2;
                            golsPenalti1 = partida.eventos.FindAll(x => x.equipe.id == partida.equipe1.id && x.tpEvento == tpEventoEnum.Gol_Penalti).Count;
                            golsPenalti2 = partida.eventos.FindAll(x => x.equipe.id == partida.equipe2.id && x.tpEvento == tpEventoEnum.Gol_Penalti).Count;

                            if (golsPenalti1 > golsPenalti2) {
                                competicao.campeao = partida.equipe1;
                            } else {
                                if (golsPenalti2 > golsPenalti1) {
                                    competicao.campeao = partida.equipe2;
                                }
                            }
                        } else {

                            // Não foi para os penaltis
                            if (golsEquipe1 > golsEquipe2) {
                                competicao.campeao = partida.equipe1;
                            } else {
                                if (golsEquipe2 > golsEquipe1) {
                                    competicao.campeao = partida.equipe2;
                                }
                            }
                        }
                        competicao.id_Campeao = competicao.campeao.id;
                        update(competicao);
                    }

                    // Verifica se algum atleta foi suspenso
                    verificaSuspensoes(competicao, partida);

                }

                return true;
            } catch (Exception ex) {
                return false;
            }
        }

        public void verificaSuspensoes(Competicao competicao, Competicao_Partida partida) {
            // Verifica os atletas que já cumpriram suspensão
            verificaSuspensoesCumpridas(competicao, partida);

            // Verifica os atletas suspensos por vermelho
            List<Atleta> suspensosCV_Equipe1 = new List<Atleta>(), suspensosCV_Equipe2 = new List<Atleta>();
            suspensosCV_Equipe1.AddRange(partida.equipe1.atletas.FindAll(find => partida.eventos.FindAll(find2 => find2.atleta.pessoa.id == find.pessoa.id && find2.tpEvento == tpEventoEnum.CartaoVermelho).Count > 0));
            suspensosCV_Equipe2.AddRange(partida.equipe2.atletas.FindAll(find => partida.eventos.FindAll(find2 => find2.atleta.pessoa.id == find.pessoa.id && find2.tpEvento == tpEventoEnum.CartaoVermelho).Count > 0));

            // Verifica os atletas suspensos por amarelo
            int numCartoesSuspensao = 0;
            switch (competicao.tpSuspensao) {
                case SuspensaoEnum._1_2CA_1Jogo_2CAe1CV_2Jogos: case SuspensaoEnum._3_2CA_1Jogo: numCartoesSuspensao = 2; break;
                case SuspensaoEnum._2_3CA_1Jogo_3CAe1CV_2Jogos: case SuspensaoEnum._4_3CA_1Jogo: numCartoesSuspensao = 3; break;
            }

            List<Atleta> suspensosCA_Equipe1 = new List<Atleta>(), suspensosCA_Equipe2 = new List<Atleta>();
            suspensosCA_Equipe1.AddRange(partida.equipe1.atletas.FindAll(find => find.numCartoesAcumulados >= numCartoesSuspensao));
            suspensosCA_Equipe2.AddRange(partida.equipe2.atletas.FindAll(find => find.numCartoesAcumulados >= numCartoesSuspensao));

            // Verifica os atletas suspensos por amarelo e vermelho
            List<Atleta> suspensosCAeCV_Equipe1 = new List<Atleta>(), suspensosCAeCV_Equipe2 = new List<Atleta>();
            suspensosCAeCV_Equipe1.AddRange(suspensosCV_Equipe1.FindAll(find => suspensosCA_Equipe1.FindAll(find2 => find2.pessoa.id == find.pessoa.id).Count > 0));
            suspensosCAeCV_Equipe2.AddRange(suspensosCV_Equipe2.FindAll(find => suspensosCA_Equipe2.FindAll(find2 => find2.pessoa.id == find.pessoa.id).Count > 0));

            // Remove da lista de suspensos por amarelo ou vermelho e mantém apenas na lista de suspensos por amarelo e vermelho
            suspensosCA_Equipe1.RemoveAll(find => suspensosCAeCV_Equipe1.FindAll(find2 => find2.pessoa.id == find.pessoa.id).Count > 0);
            suspensosCA_Equipe2.RemoveAll(find => suspensosCAeCV_Equipe2.FindAll(find2 => find2.pessoa.id == find.pessoa.id).Count > 0);
            suspensosCV_Equipe1.RemoveAll(find => suspensosCAeCV_Equipe1.FindAll(find2 => find2.pessoa.id == find.pessoa.id).Count > 0);
            suspensosCV_Equipe2.RemoveAll(find => suspensosCAeCV_Equipe2.FindAll(find2 => find2.pessoa.id == find.pessoa.id).Count > 0);

            // Cria as suspensões para quem está suspenso por amarelos e vermelho
            int numJogosSuspensao = 0;
            switch (competicao.tpSuspensao) {
                case SuspensaoEnum._1_2CA_1Jogo_2CAe1CV_2Jogos: case SuspensaoEnum._2_3CA_1Jogo_3CAe1CV_2Jogos: numJogosSuspensao = 2;  break;
                case SuspensaoEnum._3_2CA_1Jogo:                case SuspensaoEnum._4_3CA_1Jogo: numJogosSuspensao = 1;                 break;
            }

            foreach (Atleta suspenso_CAeCV in suspensosCAeCV_Equipe1) {
                Competicao_Suspensao suspensao = new Competicao_Suspensao(competicao, partida.equipe1, suspenso_CAeCV, numJogosSuspensao);
                insertSuspensao(ref suspensao);
            }

            foreach (Atleta suspenso_CAeCV in suspensosCAeCV_Equipe2) {
                Competicao_Suspensao suspensao = new Competicao_Suspensao(competicao, partida.equipe2, suspenso_CAeCV, numJogosSuspensao);
                insertSuspensao(ref suspensao);
            }

            // Cria as suspensões para quem está suspenso por amarelos
            foreach (Atleta suspenso_CA in suspensosCA_Equipe1) {
                Competicao_Suspensao suspensao = new Competicao_Suspensao(competicao, partida.equipe1, suspenso_CA, 1);
                insertSuspensao(ref suspensao);
            }

            foreach (Atleta suspenso_CA in suspensosCA_Equipe2) {
                Competicao_Suspensao suspensao = new Competicao_Suspensao(competicao, partida.equipe2, suspenso_CA, 1);
                insertSuspensao(ref suspensao);
            }

            // Cria as suspensões para quem está suspenso por vermelho
            foreach (Atleta suspenso_CV in suspensosCV_Equipe1) {
                Competicao_Suspensao suspensao = new Competicao_Suspensao(competicao, partida.equipe1, suspenso_CV, 1);
                insertSuspensao(ref suspensao);
            }

            foreach (Atleta suspenso_CV in suspensosCV_Equipe2) {
                Competicao_Suspensao suspensao = new Competicao_Suspensao(competicao, partida.equipe2, suspenso_CV, 1);
                insertSuspensao(ref suspensao);
            }

        }

        public void verificaSuspensoesCumpridas(Competicao competicao, Competicao_Partida partida) {
            try {
                string strSQL;
                strSQL =    "UPDATE Competicao_Suspensao " +
                            "SET    numJogosSuspensao = numJogosSuspensao - 1 " +
                            "WHERE  id_Competicao = @id_Competicao " +
                            "       AND (id_Equipe = @id_Equipe1 OR id_Equipe = @id_Equipe2) ";

                SQLiteDatabase.Instance.SQLiteDatabaseConnection().Query<Competicao_Suspensao>(strSQL,
                new {
                    id_Competicao = competicao.id,
                    id_Equipe1 = partida.equipe1.id,
                    id_Equipe2 = partida.equipe2.id
                });


            } catch (Exception ex) {
                
            }
        }

        public void zeraSuspensao(Competicao competicao) {
            try {
                string strSQL;
                strSQL =    "UPDATE Competicao_Suspensao " +
                            "SET    numJogosSuspensao = 0 " +
                            "WHERE  id_Competicao = @id_Competicao ";

                SQLiteDatabase.Instance.SQLiteDatabaseConnection().Query<Competicao_Suspensao>(strSQL,
                new {
                    id_Competicao = competicao.id
                });


            } catch (Exception ex) {

            }
        }

        public List<Competicao_Suspensao> getSuspensoesPorEquipe(int id_Competicao, int id_Equipe) {
            try {

                List<Competicao_Suspensao> suspensoes;

                string strSQL;
                strSQL =    "SELECT * " +
                            "FROM   Competicao_Suspensao " +
                            "WHERE  id_Competicao = @id_Competicao " +
                            "       AND id_Equipe = @id_Equipe" +
                            "       AND numJogosSuspensao > 0 ";

                suspensoes = SQLiteDatabase.Instance.SQLiteDatabaseConnection().Query<Competicao_Suspensao>(strSQL,
                new {
                    id_Competicao,
                    id_Equipe
                }).ToList();

                foreach (Competicao_Suspensao suspensao in suspensoes) {
                    suspensao.atleta = PessoaRepositorio.Instance.getAtleta(suspensao.id_Atleta);
                    suspensao.equipe = EquipeRepositorio.Instance.getEquipeCompeticao(suspensao.id_Equipe, suspensao.id_Competicao);
                }

                return suspensoes;
            } catch (Exception ex) {
                return null;
            }
        }

        public bool insertSuspensao(ref Competicao_Suspensao suspensao) {
            try {

                string strSQL;
                strSQL =    "INSERT INTO Competicao_Suspensao " +
                            "   (id_Competicao, id_Equipe, id_Atleta, numJogosSuspensao) " +
                            "VALUES " +
                            "   (@id_Competicao, @id_Equipe, @id_Atleta, @numJogosSuspensao); " +
                            " " +
                            "select last_insert_rowid()";

                suspensao.id = SQLiteDatabase.Instance.SQLiteDatabaseConnection().Query<int>(strSQL,
                new {
                    id_Competicao = suspensao.id_Competicao,
                    id_Equipe = suspensao.id_Equipe,
                    id_Atleta = suspensao.atleta.pessoa.id,
                    numJogosSuspensao = suspensao.numJogosSuspensao
                }).First();

                return true;
            } catch (Exception ex) {
                return false;
            }
        }

        public bool updateSuspensao(Competicao_Suspensao suspensao) {
            try {

                string strSQL;
                strSQL =    "UPDATE Competicao_Suspensao " +
                            "SET    id_Competicao = @id_Competicao, " +
                            "       id_Equipe = @id_Equipe, " +
                            "       id_Atleta = @id_Atleta, " +
                            "       numJogosSuspensao = @numJogosSuspensao " +
                            "WHERE  id = @id ";

                suspensao.id = SQLiteDatabase.Instance.SQLiteDatabaseConnection().Query<int>(strSQL,
                new {
                    id_Competicao = suspensao.id_Competicao,
                    id_Equipe = suspensao.id_Equipe,
                    id_Atleta = suspensao.atleta.pessoa.id,
                    numJogosSuspensao = suspensao.numJogosSuspensao,
                    id = suspensao.id
                }).First();

                return true;
            } catch (Exception ex) {
                return false;
            }
        }

        public bool insertArbitro(ref Competicao competicao, Cargo arbitro) {
            try {

                string strSQL;
                strSQL = "INSERT INTO Competicao_Arbitragem " +
                            "(id_Competicao, id_Arbitro) " +
                            "VALUES " +
                            "(@id_Competicao, @id_Arbitro) ";

                SQLiteDatabase.Instance.SQLiteDatabaseConnection().Query(strSQL,
                new {
                    id_Competicao = competicao.id,
                    id_Arbitro = arbitro.pessoa.id
                });

                if (competicao.arbitros.FindAll(find => find.pessoa.id == arbitro.pessoa.id).Count == 0)
                    competicao.arbitros.Add(arbitro);

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
        public bool deleteEquipeDaCompeticao(EquipeCompeticao equipe, int idCompeticao, ref string messageError) {
            try {
                SQLiteDatabase.Instance.SQLiteDatabaseConnection().Query(
                    "DELETE FROM Equipe_Atletas WHERE id_Equipe = @idEquipe AND id_Competicao = @idCompeticao",
                    new
                    {
                        idEquipe = equipe.id,
                        idCompeticao
                    });

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

        public bool deleteGrupos(ref Competicao competicao) {
            try {

                string strSQL;
                strSQL = "DELETE FROM Competicao_Grupos " +
                            "WHERE  id_Competicao = @id_Competicao ";

                SQLiteDatabase.Instance.SQLiteDatabaseConnection().Query(strSQL,
                    new {
                        id_Competicao = competicao.id
                    });

                competicao.grupos = new List<List<EquipeCompeticao>>();

                return true;
            } catch (Exception ex) {
                return false;
            }
        }

        public bool deleteArbitroDaCompeticao(ref Competicao competicao, Cargo arbitro) {
            try {

                string strSQL;
                strSQL =    "DELETE FROM Competicao_Arbitragem " +
                            "WHERE  id_Competicao = @id_Competicao " +
                            "       AND id_Arbitro = @id_Arbitro ";

                SQLiteDatabase.Instance.SQLiteDatabaseConnection().Query(strSQL,
                new {
                    id_Competicao = competicao.id,
                    id_Arbitro = arbitro.pessoa.id
                });

                competicao.arbitros.Remove(arbitro);

                return true;
            } catch (Exception ex) {
                return false;
            }
        }

    }
}