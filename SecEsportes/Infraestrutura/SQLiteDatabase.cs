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

            //Criação da tabela função
            if (connection.GetSchema("Tables", new[] { null, null, "Funcao", null }).Rows.Count == 0){
                SQLiteCommand command = connection.CreateCommand();

                command.CommandText = "CREATE Table Funcao (" +
                    "id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "codigo NVARCHAR(10) NOT NULL UNIQUE, " +
                    "descricao NVARCHAR(100) NOT NULL) ";
                command.ExecuteNonQuery();
            }

            //Criação da tabela Equipe
            if (connection.GetSchema("Tables", new[] { null, null, "Equipe", null }).Rows.Count == 0) {
                SQLiteCommand command = connection.CreateCommand();

                command.CommandText = "CREATE Table Equipe (" +
                    "id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "codigo NVARCHAR(10) NOT NULL UNIQUE, " +
                    "nome NVARCHAR(100) NOT NULL) ";
                command.ExecuteNonQuery();
            }

            connection.Close();

        }

    }
}