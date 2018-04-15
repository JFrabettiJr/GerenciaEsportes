﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecEsportes.Modelo;
using SecEsportes.Infraestrutura;
using System.Data.SQLite;

namespace SecEsportes.Repositorio {
    public class PessoaRepositorio {
        #region Implementação Singleton
        private static PessoaRepositorio instance = null;
        public static PessoaRepositorio Instance {
            get {
                if (instance == null) {
                    instance = new PessoaRepositorio();
                }
                return instance;
            }
        }
        #endregion

        private PessoaRepositorio() {

        }

        public void CreateTable(SQLiteConnection connection) {
            //Criação da tabela PessoaFuncoes
            if (connection.GetSchema("Tables", new[] { null, null, "Pessoa", null }).Rows.Count == 0) {
                SQLiteCommand command = connection.CreateCommand();

                command.CommandText = "CREATE Table Pessoa (" +
                    "id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "cpf NVARCHAR(11) NOT NULL UNIQUE, " +
                    "nome NVARCHAR(100) NOT NULL," +
                    "dataNascimento DateTime " +
                    ") ";
                command.ExecuteNonQuery();
            }

            //Criação da tabela PessoaFuncoes
            if (connection.GetSchema("Tables", new[] { null, null, "Pessoa_Funcoes", null }).Rows.Count == 0) {
                SQLiteCommand command = connection.CreateCommand();

                command.CommandText = "CREATE Table Pessoa_Funcoes (" +
                    "id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "id_Pessoa INTEGER NOT NULL, " +
                    "id_Funcao INTEGER NOT NULL, " +
                    "FOREIGN KEY(id_Pessoa) REFERENCES pessoa(id), " +
                    "FOREIGN KEY(id_Funcao) REFERENCES funcao(id) " +
                    ")";
                command.ExecuteNonQuery();
            }

        }
        public Pessoa get(int id) {
            string auxString = "";
            return get(id, ref auxString);
        }
        public Pessoa get(int id, ref string messageError) {
            try {
                using (var connection = SQLiteDatabase.Instance.SQLiteDatabaseConnection()) {
                    connection.Open();

                    Pessoa pessoa = connection.Query<Pessoa>(
                        "SELECT * FROM pessoa WHERE id = @id", new { id })
                        .FirstOrDefault();

                    pessoa.funcoes = FuncaoRepositorio.Instance.getFuncaoByPessoa(pessoa.id);

                    return pessoa;
                }
            } catch (Exception ex) {
                messageError = ex.Message;
                return null;
            }
        }
        public List<Pessoa> get() {
            string myString = "";
            return get(ref myString);
        }
        public List<Pessoa> get(ref string messageError) {
            try {
                using (var connection = SQLiteDatabase.Instance.SQLiteDatabaseConnection()) {
                    connection.Open();

                    List<Pessoa> pessoas = connection.Query<Pessoa>("SELECT * FROM pessoa").ToList();
                    foreach (Pessoa pessoa in pessoas) {
                        pessoa.funcoes = FuncaoRepositorio.Instance.getFuncaoByPessoa(pessoa.id);
                    }

                    return pessoas;
                }
            } catch (Exception ex) {
                messageError = ex.Message;
                return null;
            }
        }
        public List<Atleta> getAtletasByEquipeCompeticao(int id_Competicao, int id_Equipe) {
            string myString = "";
            return getAtletasByEquipeCompeticao(id_Competicao, id_Equipe, ref myString);
        }
        public List<Atleta> getAtletasByEquipeCompeticao(int id_Competicao, int id_Equipe, ref string errorMessage) {
            try {
                using (var connection = SQLiteDatabase.Instance.SQLiteDatabaseConnection()) {
                    connection.Open();

                    string strSQL;
                    strSQL = "SELECT	pessoa.id as id_pessoa, EA.id_funcao, EA.Numero " +
                                "FROM   Equipe_Atletas AS EA " +
                                "       INNER JOIN Pessoa ON Pessoa.id = EA.id_Atleta " +
                                "WHERE  EA.id_Competicao = @id_Competicao " +
                                "       AND EA.id_Equipe = @id_Equipe; ";

                    List<Atleta> atletas = connection.Query<Atleta>(strSQL,
                        new {
                            id_Competicao,
                            id_Equipe
                        }).ToList();
                    foreach (Atleta atleta in atletas) {
                        atleta.funcao = FuncaoRepositorio.Instance.get(atleta.id_funcao);
                        atleta.pessoa = PessoaRepositorio.Instance.get(atleta.id_pessoa);
                    }

                    return atletas;
                }
            } catch (Exception ex) {
                errorMessage = ex.Message;
                return null;
            }
        }
        public Cargo getCargo(int id_Pessoa) {
            try {
                using (var connection = SQLiteDatabase.Instance.SQLiteDatabaseConnection()) {
                    connection.Open();

                    string strSQL;
                    strSQL = "SELECT pessoa.id AS id_pessoa, Pessoa_Funcoes.id_Funcao " +
                                "FROM   pessoa " +
                                "       INNER JOIN Pessoa_Funcoes ON Pessoa.id = Pessoa_Funcoes.id_Pessoa " +
                                "WHERE  Pessoa.id = @id_Pessoa ";

                    Cargo cargo = connection.Query<Cargo>(strSQL,
                        new {
                            id_Pessoa
                        }).First();

                    cargo.funcao = FuncaoRepositorio.Instance.get(cargo.id_funcao);
                    cargo.pessoa = PessoaRepositorio.Instance.get(cargo.id_pessoa);

                    return cargo;
                }
            } catch (Exception ex) {
                return null;
            }
        }
        public List<Cargo> getRepresentantesForaCompeticao(int id_Competicao, int id_Equipe) {
            try {
                using (var connection = SQLiteDatabase.Instance.SQLiteDatabaseConnection()) {
                    connection.Open();

                    string strSQL;
                    strSQL = "SELECT pessoa.id AS id_pessoa, Pessoa_Funcoes.id_Funcao " +
                                "FROM   pessoa " +
                                "       INNER JOIN Pessoa_Funcoes ON Pessoa.id = Pessoa_Funcoes.id_Pessoa " +
                                "WHERE  Pessoa_Funcoes.id_Funcao IN (   SELECT  id " +
                                "                                       FROM    Funcao " +
                                "                                       WHERE   codigo = @codigoRepresentante) " +
                                "       AND Pessoa_Funcoes.id_Pessoa NOT IN (   SELECT  id_Representante " +
                                "                                               FROM    Equipe_Competicao " +
                                "                                               WHERE   id_Competicao = @id_Competicao " +
                                "                                                       AND id_Equipe <> @id_Equipe) ";

                    List<Cargo> representantes = connection.Query<Cargo>(strSQL,
                        new {
                            FuncaoRepositorio.Instance.codigoRepresentante,
                            id_Competicao,
                            id_Equipe
                        }).ToList();

                    foreach (Cargo representante in representantes) {
                        representante.funcao = FuncaoRepositorio.Instance.get(representante.id_funcao);
                        representante.pessoa = PessoaRepositorio.Instance.get(representante.id_pessoa);
                    }

                    return representantes;
                }
            } catch (Exception ex) {
                return null;
            }
        }
        public List<Cargo> getTreinadores(int id_Competicao, int id_Equipe) {
            try {
                using (var connection = SQLiteDatabase.Instance.SQLiteDatabaseConnection()) {
                    connection.Open();

                    string strSQL;
                    strSQL = "SELECT pessoa.id AS id_pessoa, Pessoa_Funcoes.id_Funcao " +
                                "FROM   pessoa " +
                                "       INNER JOIN Pessoa_Funcoes ON Pessoa.id = Pessoa_Funcoes.id_Pessoa " +
                                "WHERE  Pessoa_Funcoes.id_Funcao IN (   SELECT  id " +
                                "                                       FROM    Funcao " +
                                "                                       WHERE   codigo = @codigoTreinador) " +
                                "       AND Pessoa_Funcoes.id_Pessoa NOT IN (   SELECT  id_Treinador " +
                                "                                               FROM    Equipe_Competicao " +
                                "                                               WHERE   id_Competicao = @id_Competicao " +
                                "                                                       AND id_Equipe <> @id_Equipe) ";

                    List<Cargo> treinadores = connection.Query<Cargo>(strSQL,
                        new {
                            FuncaoRepositorio.Instance.codigoTreinador,
                            id_Competicao,
                            id_Equipe
                        }).ToList();

                    foreach (Cargo representante in treinadores) {
                        representante.funcao = FuncaoRepositorio.Instance.get(representante.id_funcao);
                        representante.pessoa = PessoaRepositorio.Instance.get(representante.id_pessoa);
                    }

                    return treinadores;
                }
            } catch (Exception ex) {
                return null;
            }
        }
        public bool insert(ref Pessoa pessoa, ref string messageError) {
            try {
                SQLiteConnection connection = SQLiteDatabase.Instance.SQLiteDatabaseConnection();
                pessoa.id = connection.Query<int>("" +
                    "INSERT INTO pessoa (CPF, Nome, DataNascimento) VALUES (@CPF, @Nome, @DataNascimento); select last_insert_rowid()",
                    pessoa).First();

                // Insere as funções
                for (int iCount = 0; iCount < pessoa.funcoes.Count; iCount++) {
                    pessoa.funcoes[iCount].id = connection.Query<int>("SELECT id FROM Funcao WHERE codigo = '" + pessoa.funcoes[iCount].codigo + "'").First();
                    connection.Query("INSERT INTO Pessoa_Funcoes (id_Pessoa, id_Funcao) VALUES (" + pessoa.id + ", " + pessoa.funcoes[iCount].id + ") ");
                }

                return true;
            } catch (Exception ex) {
                messageError = ex.Message;
                return false;
            }
        }
        public bool update(Pessoa pessoa, ref string messageError) {
            try {
                SQLiteConnection connection = SQLiteDatabase.Instance.SQLiteDatabaseConnection();
                connection.Query(
                    "UPDATE pessoa SET CPF = @CPF, Nome = @Nome, DataNascimento = @DataNascimento WHERE id = @id", pessoa);

                // Atualiza as funções
                string funcoesStr = "";
                for (int iCount = 0; iCount < pessoa.funcoes.Count; iCount++) {
                    pessoa.funcoes[iCount].id = connection.Query<int>("SELECT id FROM Funcao WHERE codigo = '" + pessoa.funcoes[iCount].codigo + "'").First();
                    funcoesStr += pessoa.funcoes[iCount].id.ToString() + ", ";
                    if (connection.Query("SELECT 1 FROM Pessoa_Funcoes WHERE id_Pessoa = " + pessoa.id + " AND id_Funcao = " + pessoa.funcoes[iCount].id + " ").Count() == 0) {
                        connection.Query("INSERT INTO Pessoa_Funcoes (id_Pessoa, id_Funcao) VALUES (" + pessoa.id + ", " + pessoa.funcoes[iCount].id + ") ");
                    }
                }

                // Deleta as funções que não são mais utilizadas
                if (funcoesStr.Length > 0) {
                    funcoesStr = funcoesStr.Substring(0, funcoesStr.Length - 2);
                    connection.Query("DELETE FROM Pessoa_Funcoes WHERE id_Pessoa = " + pessoa.id + " AND id_Funcao NOT IN (" + funcoesStr + ") ");
                }

                return true;
            } catch (Exception ex) {
                messageError = ex.Message;
                return false;
            }
        }
        public bool delete(Pessoa pessoa, ref string messageError) {
            try {
                SQLiteConnection connection = SQLiteDatabase.Instance.SQLiteDatabaseConnection();
                connection.Query(
                    "DELETE FROM pessoa WHERE id = @id", pessoa);

                connection.Query(
                    "DELETE FROM Pessoa_Funcoes WHERE id_Pessoa = @id", pessoa);

                return true;
            } catch (Exception ex) {
                messageError = ex.Message;
                return false;
            }
        }
    }
}