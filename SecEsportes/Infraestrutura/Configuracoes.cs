using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecEsportes.Infraestrutura
{
    public class Configuracoes{
        #region Implementação Singleton
        private static Configuracoes instance = null;

        public static Configuracoes Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Configuracoes();
                }
                return instance;
            }
        }
        #endregion
        #region Propriedades
        public string fileNameDB { get; set; }
        public string fileNameConfig { get; set; }
        public string folderConfig { get; set; }
        #endregion

        private Configuracoes() {
            folderConfig = "Configuracoes";
            fileNameDB = "SecEsportesDatabase.db";
            fileNameConfig = "SecEsportesConfig.txt";
        }
    }
}