using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecEsportes.Modelo{
    /// <summary>
    /// Classe que representa uma equipe de qualquer modalidade
    /// </summary>
    class Equipe{
        public int id { get;}
        public string nome { get; }

        public Equipe(int id, string nome){
            this.id = id;
            this.nome = nome;
        }
    }
}