﻿using Dapper;
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
                    "numMinimoJogadores INTEGER, " +
                    "id_Campeao INTEGER, " +
                    "fase_Atual INTEGER, " + 
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
                                        "    Data DATETIME, " +
                                        "    Rodada INT, /* > 0 Representa o nº da Rodada | < 0 Representa MataMata (-1 Final, -2 SemiFinal, -3 Quartas de final, etc.)*/ " +
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
                    competicao.modalidade = ModalidadeRepositorio.Instance.get(competicao.id_Modalidade);
                    competicao.grupos = getGruposPorCompeticao(competicao.id);
                    competicao.partidas = getPartidasPorCompeticao(competicao.id);
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
                        competicoes[iCount].equipes = EquipeRepositorio.Instance.getEquipesByCompeticao(competicoes[iCount].id);
                        competicoes[iCount].modalidade = ModalidadeRepositorio.Instance.get(competicoes[iCount].id_Modalidade);
                        competicoes[iCount].grupos = getGruposPorCompeticao(competicoes[iCount].id);
                        competicoes[iCount].partidas = getPartidasPorCompeticao(competicoes[iCount].id);
                        competicoes[iCount].campeao = EquipeRepositorio.Instance.getEquipeCompeticao(competicoes[iCount].id_Campeao, competicoes[iCount].id);
                    }

                    return competicoes;
                }
            } catch (Exception ex) {
                messageError = ex.Message;
                return null;
            }
        }
        private List<Competicao_Partida> getPartidasPorCompeticao(int id_Competicao) {
            try {
                using (var connection = SQLiteDatabase.Instance.SQLiteDatabaseConnection()) {
                    connection.Open();

                    string strSQL;
                    strSQL =    "SELECT *" +
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
                    }

                    return partidas;
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
        private List<List<EquipeCompeticao>> getGruposPorCompeticao(int id_competicao) {
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
                            grupos[numGrupo].Add(EquipeRepositorio.Instance.getEquipeCompeticao(idEquipes[numEquipe], id_competicao));
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
                    strSQL =    "SELECT	id_Atleta, " +
                                "       Equipe.nome AS nome_Equipe, " +
                                "       (SELECT COUNT(1) FROM Competicao_Partida WHERE encerrada = 1 AND (id_Equipe1 = Equipe.id OR id_Equipe2 = Equipe.id)) AS num_Partidas, " +
                                "       COUNT(1) AS num_Gols " +
                                "FROM 	Competicao_Partida_Evento " +
                                "		INNER JOIN Competicao_Partida ON Competicao_Partida_Evento.id_Partida = Competicao_Partida.id " +
                                "		INNER JOIN Equipe_Competicao ON Competicao_Partida_Evento.id_Equipe = Equipe_Competicao.id_Equipe " +
                                "		INNER JOIN Equipe ON Equipe_Competicao.id_Equipe = Equipe.id " +
                                "WHERE 	tpEvento = @tpEvento " +
                                "		AND Competicao_Partida.id_Competicao = @id_Competicao " +
                                "GROUP BY Competicao_Partida_Evento.id_Atleta, Competicao_Partida_Evento.id_Equipe, Equipe.nome " +
                                "ORDER BY num_Gols DESC, num_Partidas ASC; ";

                    List<Atleta_List_Artilheiro> artilheiros = connection.Query<Atleta_List_Artilheiro>(strSQL,
                        new {   tpEvento = tpEventoEnum.Gol,
                                id_Competicao
                        }).ToList();

                    foreach(Atleta_List_Artilheiro artilheiro in artilheiros){
                        artilheiro.atleta = PessoaRepositorio.Instance.getAtleta(artilheiro.id_Atleta, id_Competicao);
                        artilheiro.nome_Atleta = artilheiro.atleta.numero + " - " + artilheiro.atleta.pessoa.nome;
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
        public bool insert(ref Competicao competicao, ref string messageError) {
            try {
                competicao.id = SQLiteDatabase.Instance.SQLiteDatabaseConnection().Query<int>("" +
                    "INSERT INTO Competicao " +
                    "(Nome, dataInicial, dataFinal, id_Modalidade, numTimes, numGrupos, mataMata, jogosIdaEVolta, jogosIdaEvolta_MataMata, status, nomesGrupos, numMinimoJogadores, id_Campeao, fase_Atual) " +
                    "VALUES " +
                    "(@Nome, @dataInicial, @dataFinal, @id_Modalidade, @numTimes, @numGrupos, @mataMata, @jogosIdaEVolta, @jogosIdaEVolta_MataMata, @status, @nomesGrupos, @numMinimoJogadores, @id_Campeao, @fase_Atual); " +
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
                        competicao.nomesGrupos,
                        competicao.numMinimoJogadores,
                        id_Campeao = (competicao.campeao is null ? 0 : competicao.campeao.id),
                        competicao.fase_Atual
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
                strSQL = "INSERT INTO Competicao_Partida " +
                            "(id_Competicao, id_Equipe1, id_Equipe2, Data, Rodada, numGrupo, encerrada) " +
                            "VALUES " +
                            "(@id_Competicao, @id_Equipe1, @id_Equipe2, @Data, @Rodada, @numGrupo, @encerrada); " +
                            "SELECT last_insert_rowid()";

                int idPartida = 0;

                idPartida = SQLiteDatabase.Instance.SQLiteDatabaseConnection().Query<int>(strSQL,
                    new {
                        id_Competicao = competicao.id,
                        id_Equipe1 = partida.equipe1.id,
                        id_Equipe2 = partida.equipe2.id,
                        Data = partida.data,
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
        public bool insertEvento(Competicao_Partida partida, Competicao_Partida_Evento evento) {
            try {

                string strSQL;
                strSQL = "INSERT INTO Competicao_Partida_Evento " +
                            "(id_Partida, id_Equipe, id_Atleta, tpEvento) " +
                            "VALUES " +
                            "(@id_Partida, @id_Equipe, @id_Atleta, @tpEvento) ";

                SQLiteDatabase.Instance.SQLiteDatabaseConnection().Query(strSQL,
                    new {   id_Partida = partida.id,
                            id_Equipe = evento.equipe.id,
                            id_Atleta = evento.atleta.pessoa.id,
                            tpEvento = tpEventoEnum.Gol
                    });
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
                            "       mataMata = @mataMata, " +
                            "       jogosIdaEVolta = @jogosIdaEVolta, " +
                            "       jogosIdaEVolta_MataMata = @jogosIdaEVolta_MataMata, " +
                            "       status = @status, " +
                            "       nomesGrupos = @nomesGrupos, " +
                            "       numMinimoJogadores = @numMinimoJogadores, " +
                            "       id_Campeao = @id_Campeao, " +
                            "       fase_Atual = @fase_Atual " + 
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
                        competicao.numMinimoJogadores,
                        id_Campeao = (competicao.campeao is null ? 0 : competicao.campeao.id),
                        competicao.fase_Atual,
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
                strSQL = "UPDATE Competicao_Partida " +
                            "SET    encerrada = @encerrada, " +
                            "       data = @data " +
                            "WHERE  id = @id_Partida ";

                SQLiteDatabase.Instance.SQLiteDatabaseConnection().Query(strSQL,
                    new {   partida.encerrada,
                            partida.data,
                            id_Partida = partida.id
                    });

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
                if ( (competicao.fase_Atual == -1) && (competicao.partidas.FindAll(partidas => partidas.rodada == partida.rodada && partidas.encerrada == false).Count == 0)) {
                    competicao.status = StatusEnum._0_Encerrada;
                    competicao.campeao = (golsEquipe1 > golsEquipe2 ? partida.equipe1 : (golsEquipe2 > golsEquipe1 ? partida.equipe2 : null));
                    competicao.id_Campeao = competicao.campeao.id;
                    update(competicao);
                }

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