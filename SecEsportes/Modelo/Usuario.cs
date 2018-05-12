using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecEsportes.Modelo {
    public class Usuario {

        public int id { get; set; }
        public string username { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public DateTime ultimoLogin { get; set; }

        public Usuario() { }

        public Usuario(string username, string email, string nome) {
            this.username = username;
            this.nome = nome;
            this.email = email;
        }
    }
}
