using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecEsportes.Modelo{
    public class Modalidade{
        public int id { get; }
        public string descricao { get; set; }
        public int numeroMinimoDeAtletas { get; set; }

        public override string ToString() {
            return descricao;
        }
    }
}