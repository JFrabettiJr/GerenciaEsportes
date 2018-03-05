using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

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

        public string createSQLiteDatabase(){   
            string pathDatabase = FileManagement.currentPath + "\\" + configuracoes.folderConfig + "\\" + configuracoes.fileNameDB;

            if (FileManagement.fileExists(pathDatabase)){
                return pathDatabase;
            }else{
                FileManagement.createFolder(FileManagement.currentPath + "\\" + configuracoes.folderConfig);
                SQLiteConnection.CreateFile(pathDatabase);
                return pathDatabase;
            }
        }
    }
}