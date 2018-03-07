using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecEsportes.Modelo.Eventos{
    class Evento_Substituicao : Evento {
        public EquipeCompeticao equipe { get; set; }
        public Atleta entra { get; set; }
        public Atleta sai { get; set; }

        public Evento_Substituicao(int id, string nome, decimal minutosJogados, Atleta entra, Atleta sai) : base(id, nome, minutosJogados){
            this.entra = entra;
            this.sai = sai;
        }
    }
}