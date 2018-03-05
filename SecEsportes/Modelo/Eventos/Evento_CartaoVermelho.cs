using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecEsportes.Modelo.Eventos{
    class Evento_CartaoVermelho : Evento {
        public EquipeCompeticao equipe { get; set; }
        public Atleta atletaExpulso { get; set; }

        public Evento_CartaoVermelho(int id, string nome, decimal minutosJogados) : base(id, nome, minutosJogados){
        }
    }
}