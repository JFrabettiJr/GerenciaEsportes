using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecEsportes.Modelo.Eventos{
    class Evento_Gol: Evento {
        public EquipeCompeticao equipe { get; set; }
        public Atleta marcouGol { get; set; }
        public Atleta assistencia { get; set; }

        public Evento_Gol(int id, string nome, decimal minutosJogados) : base(id, nome, minutosJogados){
        }
    }
}