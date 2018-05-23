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
        public string urlFoto { get; set; }
        public string email { get; set; }

        public Pessoa() {
            urlFoto = "";
            email = "";
            funcoes = new List<Funcao>();
        }

        public Pessoa(string cpf, string nome, DateTime dataNascimento){
            this.cpf = cpf;
            this.nome = nome;
            this.dataNascimento = dataNascimento;
            urlFoto = "";
            email = "";
            funcoes = new List<Funcao>();
        }

        public override string ToString() {
            return "CPF: " + cpf + Environment.NewLine +
                    "Nome: " + nome + Environment.NewLine;
        }
    }
}