using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecEsportes.Infraestrutura{
    public static class FileManagement{

        public static string currentPath = System.IO.Directory.GetCurrentDirectory();

        public static bool fileExists(string fileName){
            return System.IO.File.Exists(fileName);
        }

        public static bool folderExists(string folder){
            return System.IO.Directory.Exists(folder);
        }

        public static void createFolder(string folder){
            System.IO.Directory.CreateDirectory(folder);
        }
    }
}
