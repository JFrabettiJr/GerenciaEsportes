using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecEsportes.Modelo{
    public class EquipeCompeticao : Equipe{
        public Cargo treinador { get; set; }
        public int id_treinador { get; set; }
        public Cargo representante { get; set; }
        public int id_representante { get; set; }
        public List<Cargo> comissaotecnica { get; set; }
        public List<Atleta> atletas { get; set; }
        public int pontos { get; set; }
        public int vitorias { get; set; }
        public int jogos { get; set; }
        public int derrotas { get; set; }
        public int empates { get; set; }
        public int golsPro { get; set; }
        public int golsContra { get; set; }

        public EquipeCompeticao() { }

        public EquipeCompeticao(string codigo, string nome, Cargo treinador, Cargo representante) : base(codigo, nome){
            this.treinador = treinador;
            this.representante = representante;
        }
    }
}