using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecEsportes.Modelo{
    /// <summary>
    /// Classe que representa a função de uma pesosa (atleta, árbitro, técnico, mesário, etc)
    /// </summary>
    public class Funcao{
        public int id { get; set; }
        public string codigo { get; set; }
        public string descricao { get; set; }

        public Funcao(string codigo, string descricao){
            this.codigo = codigo;
            this.descricao = descricao;
        }

        public Funcao() { }

        public override string ToString()
        {
            return "Código: " + codigo + Environment.NewLine +
                    "Descrição: " + descricao;
        }
    }
}