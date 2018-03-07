using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecEsportes.Modelo{
    public class EquipeCompeticao : Equipe{
        public Cargo treinador { get; set; }
        public Cargo representante { get; set; }
        public List<Cargo> comissaotecnica { get; set; }
        public List<Atleta> atletas { get; set; }

        public EquipeCompeticao(int id, string nome, Cargo treinador, Cargo representante) : base(id, nome){
            this.treinador = treinador;
            this.representante = representante;
        }
    }
}