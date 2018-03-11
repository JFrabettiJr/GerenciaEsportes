using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using Dapper;

namespace SecEsportes.Infraestrutura
{
    public class SQLiteDatabase{

        private Configuracoes configuracoes = Configuracoes.Instance;

        #region Implementação Singleton
        private static SQLiteDatabase instance = null;
        public static SQLiteDatabase Instance{
            get{
                if (instance == null){
                    instance = new SQLiteDatabase();
                }
                return instance;
            }
        }
        #endregion

        private SQLiteDatabase(){

        }

        public static string SQLiteDatabaseFile
        {
            get { return Environment.CurrentDirectory + "\\" + Configuracoes.Instance.folderConfig + "\\" + Configuracoes.Instance.fileNameDB; }
        }

        public SQLiteConnection SQLiteDatabaseConnection()
        {
            return new SQLiteConnection("Data Source=" + SQLiteDatabaseFile);
        }

        private void createSQLiteDatabase(){   
            string pathDatabase = FileManagement.currentPath + "\\" + configuracoes.folderConfig + "\\" + configuracoes.fileNameDB;

            if (!FileManagement.fileExists(pathDatabase)){
                SQLiteConnection.CreateFile(pathDatabase);
            }
        }

        public void loadDatabase(){
            createSQLiteDatabase();
            createTables();
        }

        public void createTables(){
            SQLiteConnection connection = SQLiteDatabaseConnection();
            connection.OpenAndReturn();

            createFuncao(connection);
            createEquipe(connection);
            createPessoa(connection);

            connection.Close();

        }

        private void createFuncao(SQLiteConnection connection) {
            //Criação da tabela função
            if (connection.GetSchema("Tables", new[] { null, null, "Funcao", null }).Rows.Count == 0) {
                SQLiteCommand command = connection.CreateCommand();

                command.CommandText = "CREATE Table Funcao (" +
                    "id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "codigo NVARCHAR(10) NOT NULL UNIQUE, " +
                    "descricao NVARCHAR(100) NOT NULL) ";
                command.ExecuteNonQuery();
            }
        }

        private void createEquipe(SQLiteConnection connection) {
            //Criação da tabela Equipe
            if (connection.GetSchema("Tables", new[] { null, null, "Equipe", null }).Rows.Count == 0) {
                SQLiteCommand command = connection.CreateCommand();

                command.CommandText = "CREATE Table Equipe (" +
                    "id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "codigo NVARCHAR(10) NOT NULL UNIQUE, " +
                    "nome NVARCHAR(100) NOT NULL) ";
                command.ExecuteNonQuery();
            }
        }

        private void createPessoa(SQLiteConnection connection) {
            //Criação da tabela PessoaFuncoes
            if (connection.GetSchema("Tables", new[] { null, null, "Pessoa", null }).Rows.Count == 0) {
                SQLiteCommand command = connection.CreateCommand();

                command.CommandText = "CREATE Table Pessoa (" +
                    "id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "cpf NVARCHAR(11) NOT NULL UNIQUE, " +
                    "nome NVARCHAR(100) NOT NULL," +
                    "dataNascimento DateTime) ";
                command.ExecuteNonQuery();
            }

            //Criação da tabela PessoaFuncoes
            if (connection.GetSchema("Tables", new[] { null, null, "PessoaFuncoes", null }).Rows.Count == 0) {
                SQLiteCommand command = connection.CreateCommand();

                command.CommandText = "CREATE Table PessoaFuncoes (" +
                    "id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "idPessoa INTEGER NOT NULL, " +
                    "idFuncao INTEGER NOT NULL )";
                command.ExecuteNonQuery();
            }

        }


    }
}