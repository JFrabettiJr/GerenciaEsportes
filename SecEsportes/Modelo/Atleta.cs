using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecEsportes.Modelo{
    class Atleta : Cargo{

        // Quando o atleta não ter númeração definida ainda, vai com null
        public int? numero { get; set; }

        public Atleta(int id, Funcao funcao, Pessoa pessoa, int? numero) : base(id, funcao, pessoa){
            this.numero = numero;
        }
    }
}