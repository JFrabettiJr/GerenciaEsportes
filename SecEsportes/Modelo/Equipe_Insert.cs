using System;

namespace SecEsportes.Modelo{
    /// <summary>
    /// Classe que representa uma Equipe_Insert de qualquer modalidade
    /// </summary>
    public class Equipe_Insert : Equipe{
        public bool selected { get; set; }

        public Equipe_Insert() { }

        public Equipe_Insert(string codigo, string nome){
            this.codigo = codigo;
            this.nome = nome;
        }
    }
}