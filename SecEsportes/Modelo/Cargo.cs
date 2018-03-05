using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecEsportes.Modelo{
    class Cargo{
        public int id { get; }
        public Funcao funcao { get; set; }
        public Pessoa pessoa { get; set; }

        public Cargo(int id, Funcao funcao, Pessoa pessoa){
            this.id = id;
            this.funcao = funcao;
            this.pessoa = pessoa;
        }
    }
}