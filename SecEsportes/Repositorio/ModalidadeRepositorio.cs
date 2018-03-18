using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using SecEsportes.Modelo;
using SecEsportes.Infraestrutura;
using System.Data.SQLite;

namespace SecEsportes.Repositorio
{
    public class ModalidadeRepositorio {
        #region Implementação Singleton
        private static ModalidadeRepositorio instance = null;
        public static ModalidadeRepositorio Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ModalidadeRepositorio();
                }
                return instance;
            }
        }
        #endregion

        private ModalidadeRepositorio(){

        }

        public void CreateTable(SQLiteConnection connection) {
            //Criação da tabela Modalidades
            if (connection.GetSchema("Tables", new[] { null, null, "Modalidades", null }).Rows.Count == 0) {
                SQLiteCommand command = connection.CreateCommand();

                command.CommandText = "CREATE Table Modalidades (" +
                    "id INTEGER PRIMARY KEY, " +
                    "descricao NVARCHAR(50) NOT NULL) ";
                command.ExecuteNonQuery();

                command = connection.CreateCommand();
                command.CommandText = "INSERT INTO Modalidades (id, descricao) VALUES (1, 'Futebol Suíço') ";
                command.ExecuteNonQuery();

                command = connection.CreateCommand();
                command.CommandText = "INSERT INTO Modalidades (id, descricao) VALUES (2, 'Futebol de Campo') ";
                command.ExecuteNonQuery();

                command = connection.CreateCommand();
                command.CommandText = "INSERT INTO Modalidades (id, descricao) VALUES (3, 'Futsal') ";
                command.ExecuteNonQuery();

                command = connection.CreateCommand();
                command.CommandText = "INSERT INTO Modalidades (id, descricao) VALUES (4, 'Futebol de areia') ";
                command.ExecuteNonQuery();
            }
        }

        public Modalidade get(int id, ref string messageError)
        {
            try {
                using (var connection = SQLiteDatabase.Instance.SQLiteDatabaseConnection()) {
                    connection.Open();

                    Modalidade esporte = connection.Query<Modalidade>(
                        "SELECT * FROM Modalidades WHERE id = @id", new { id })
                        .FirstOrDefault();

                    return esporte;
                }
            }
            catch(Exception ex) {
                messageError = ex.Message;
                return null;
            }
        }
        public Modalidade get(int id) {
            string myString = String.Empty;
            return get(id, ref myString);
        }
        public List<Modalidade> get(){
            try {
                using (var connection = SQLiteDatabase.Instance.SQLiteDatabaseConnection()) {
                    connection.Open();

                    List<Modalidade> esportes = connection.Query<Modalidade>("SELECT * FROM Modalidades").ToList();
                    return esportes;
                }
            }
            catch (Exception ex) {
                return null;
            }
        }
    }
}