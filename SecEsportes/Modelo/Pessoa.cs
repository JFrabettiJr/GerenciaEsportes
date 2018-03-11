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
        public int id { get; set; }
        public string cpf { get; set; }
        public string nome { get; set; }
        public DateTime dataNascimento { get; set; }
        public List<Funcao> funcoes { get; set; }

        public Pessoa() { }

        public Pessoa(string cpf, string nome, DateTime dataNascimento){
            this.cpf = cpf;
            this.nome = nome;
            this.dataNascimento = dataNascimento;
        }

        public override string ToString() {
            return "CPF: " + cpf + Environment.NewLine +
                    "Nome: " + nome + Environment.NewLine;
        }
    }
}