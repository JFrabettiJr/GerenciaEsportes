using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using Dapper;
using SecEsportes.Repositorio;

namespace SecEsportes.Infraestrutura {
    public class SQLiteDatabase {

        private Configuracoes configuracoes = Configuracoes.Instance;

        #region Implementação Singleton
        private static SQLiteDatabase instance = null;
        public static SQLiteDatabase Instance {
            get {
                if (instance == null) {
                    instance = new SQLiteDatabase();
                }
                return instance;
            }
        }
        #endregion

        private SQLiteDatabase() {

        }

        public static string SQLiteDatabaseFile {
            get { return Environment.CurrentDirectory + "\\" + Configuracoes.Instance.folderConfig + "\\" + Configuracoes.Instance.fileNameDB; }
        }

        public SQLiteConnection SQLiteDatabaseConnection() {
            return new SQLiteConnection("Data Source=" + SQLiteDatabaseFile);
        }

        private void createSQLiteDatabase() {
            string pathDatabase = FileManagement.currentPath + "\\" + configuracoes.folderConfig + "\\" + configuracoes.fileNameDB;

            if (!FileManagement.fileExists(pathDatabase)) {
                SQLiteConnection.CreateFile(pathDatabase);
            }
        }

        public void loadDatabase() {
            createSQLiteDatabase();
            createTables();
        }

        public void createTables() {
            SQLiteConnection connection = SQLiteDatabaseConnection();
            connection.OpenAndReturn();

            FuncaoRepositorio.Instance.CreateTable(connection);
            EquipeRepositorio.Instance.CreateTable(connection);
            PessoaRepositorio.Instance.CreateTable(connection);
            ModalidadeRepositorio.Instance.CreateTable(connection);
            CompeticaoRepositorio.Instance.CreateTable(connection);

            UsuarioRepositorio.Instance.CreateTable(connection);

            connection.Close();

        }
    }
}