using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecEsportes.Modelo{
    /// <summary>
    /// Classe que representa uma pessoa, que pode ser um atleta, um árbito, um técnico, etc
    /// </summary>
    public class Pessoa{
        public int id { get; }
        public string nome { get; set; }
        public DateTime dataNascimento { get; set; }
        public List<Funcao> funcoes { get; set; }

        public Pessoa(int id, string nome, DateTime dataNascimento){
            this.id = id;
            this.nome = nome;
            this.dataNascimento = dataNascimento;
        }
    }
}