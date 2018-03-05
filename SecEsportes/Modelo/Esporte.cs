using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecEsportes.Modelo{
    class Esporte{
        public int id { get; }
        public string nome { get; set; }
        public int numeroMinimoDeAtletas { get; set; }
    }
}