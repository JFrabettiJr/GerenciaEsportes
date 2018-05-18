using System;

namespace SecEsportes.Modelo{
    /// <summary>
    /// Classe que representa uma equipe de qualquer modalidade
    /// </summary>
    public class Equipe{
        public int id { get; set; }

        public string codigo { get; set; }
        public string nome { get; set; }
        public string urlLogo { get; set; }

        public Equipe(string codigo, string nome){
            this.codigo = codigo;
            this.nome = nome;
        }

        public Equipe() { }

        public override string ToString() {
            return "Código: " + codigo + Environment.NewLine +
                    "Nome: " + nome;
        }
    }
}