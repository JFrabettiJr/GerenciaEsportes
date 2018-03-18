using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using SecEsportes.Modelo;
using SecEsportes.Infraestrutura;
using System.Data.SQLite;

namespace SecEsportes.Repositorio
{
    public class EquipeRepositorio {
        #region Implementação Singleton
        private static EquipeRepositorio instance = null;
        public static EquipeRepositorio Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EquipeRepositorio();
                }
                return instance;
            }
        }
        #endregion

        private EquipeRepositorio(){

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
                    "idEquipe INTEGER, " +
                    "idCompeticao INTEGER, " +
                    "idTreinador INTEGER, " +
                    "idRepresentante INTEGER, " +
                    "jogos INTEGER, " +
                    "golsPro INTEGER, " +
                    "golsContra INTEGER, " +
                    "vitorias INTEGER, " +
                    "empates INTEGER, " +
                    "derrotas INTEGER, " +
                    "nome NVARCHAR(100) NOT NULL" +
                    ") ";
                command.ExecuteNonQuery();
            }

            //Criação da tabela Equipe_ComissaoTecnica
            if (connection.GetSchema("Tables", new[] { null, null, "Equipe_ComissaoTecnica", null }).Rows.Count == 0) {
                SQLiteCommand command = connection.CreateCommand();

                command.CommandText = "CREATE Table Equipe_ComissaoTecnica (" +
                    "id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "idEquipe INTEGER, " +
                    "idCompeticao INTEGER, " +
                    "idFuncao INTEGER, " +
                    "idPessoa INTEGER) ";
                command.ExecuteNonQuery();
            }

            //Criação da tabela Equipe_Atletas
            if (connection.GetSchema("Tables", new[] { null, null, "Equipe_Atletas", null }).Rows.Count == 0) {
                SQLiteCommand command = connection.CreateCommand();

                command.CommandText = "CREATE Table Equipe_Atletas (" +
                    "id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "idEquipe INTEGER, " +
                    "idCompeticao INTEGER, " +
                    "idFuncao INTEGER, " +
                    "idAtleta INTEGER) ";
                command.ExecuteNonQuery();
            }
        }

        public Equipe get(int id, ref string messageError)
        {
            try {
                using (var connection = SQLiteDatabase.Instance.SQLiteDatabaseConnection()) {
                    connection.Open();

                    Equipe equipe = connection.Query<Equipe>(
                        "SELECT * FROM Equipe WHERE id = @id", new { id })
                        .FirstOrDefault();

                    return equipe;
                }
            }
            catch(Exception ex) {
                messageError = ex.Message;
                return null;
            }
        }
        public List<Equipe> get(ref string messageError)
        {
            try {
                using (var connection = SQLiteDatabase.Instance.SQLiteDatabaseConnection()) {
                    connection.Open();

                    List<Equipe> equipes = connection.Query<Equipe>("SELECT * FROM Equipe").ToList();

                    return equipes;
                }
            }catch (Exception ex) {
                messageError = ex.Message;
                return null;
            }
        }
        public bool insert(ref Equipe equipe, ref string messageError) {
            try{
                equipe.id = SQLiteDatabase.Instance.SQLiteDatabaseConnection().Query<int>("" +
                    "INSERT INTO Equipe (Codigo, Nome) VALUES (@Codigo, @Nome); select last_insert_rowid()",
                    equipe).First();
                return true;
            }catch (Exception ex){
                messageError = ex.Message;
                return false;
            }
        }
        public bool update(Equipe equipe, ref string messageError) {
            try{
                SQLiteDatabase.Instance.SQLiteDatabaseConnection().Query(
                    "UPDATE Equipe SET Codigo = @Codigo, Nome = @Nome WHERE id = @id", equipe);
                return true;
            }catch (Exception ex){
                messageError = ex.Message;
                return false;
            }
        }
        public bool delete(Equipe equipe, ref string messageError) {
            try{
                SQLiteDatabase.Instance.SQLiteDatabaseConnection().Query(
                    "DELETE FROM Equipe WHERE id = @id", equipe);
                return true;
            }catch (Exception ex){
                messageError = ex.Message;
                return false;
            }
        }
        public List<EquipeCompeticao> getEquipesByCompeticao(int idCompeticao) {
            string myString = String.Empty;
            return getEquipesByCompeticao(idCompeticao, ref myString);
        }

        public List<EquipeCompeticao> getEquipesByCompeticao(int idCompeticao, ref string messageError) {
            try {
                using (var connection = SQLiteDatabase.Instance.SQLiteDatabaseConnection()) {
                    connection.Open();

                    List<EquipeCompeticao> equipes = connection.Query<EquipeCompeticao>("" +
                        "SELECT * " +
                        "FROM Equipe_Competicao " +
                        "WHERE Equipe_Competicao.ID IN (" +
                        "   SELECT IDFuncao FROM PessoaFuncoes WHERE IDPessoa = " + idCompeticao + " " +
                        ") ").ToList();

                    for (int iCount = 0; iCount < equipes.Count; iCount++) {
                        equipes[iCount].comissaotecnica = getFuncoesByEquipeCompeticao(idCompeticao, equipes[iCount].id);
                        equipes[iCount].atletas = getAtletasByEquipeCompeticao(idCompeticao, equipes[iCount].id);
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
                        "       Funcao.*, Pessoa.* " +
                        "FROM   Equipe_Atletas " +
                        "       INNER JOIN Funcao ON Equipe_Atletas.idFuncao = Funcao.id " +
                        "       INNER JOIN Pessoa ON Equipe_Atletas.idPessoa = Pessoa.id " +
                        "WHERE  Equipe_Atletas.idEquipe = " + idEquipe + " " +
                        "       AND Equipe_Atletas.idCompeticao = " + idCompeticao +
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
                        "       Funcao.*, Pessoa.* " +
                        "FROM   Equipe_ComissaoTecnica " +
                        "       INNER JOIN Funcao ON Equipe_ComissaoTecnica.idFuncao = Funcao.id " +
                        "       INNER JOIN Pessoa ON Equipe_ComissaoTecnica.idPessoa = Pessoa.id " +
                        "WHERE  Equipe_ComissaoTecnica.idEquipe = " + idEquipe + " " +
                        "       AND Equipe_ComissaoTecnica.idCompeticao = " + idCompeticao).ToList();

                    return cargos;
                }
            }
            catch (Exception ex) {
                return null;
            }
        }
    }
}