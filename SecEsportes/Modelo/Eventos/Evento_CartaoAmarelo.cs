using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecEsportes.Modelo.Eventos{
    class Evento_CartaoAmarelo : Evento {
        public EquipeCompeticao equipe { get; set; }
        public Atleta atletaAmarelado { get; set; }

        public Evento_CartaoAmarelo(int id, string nome, decimal minutosJogados, Atleta atletaAmarelado) : base(id, nome, minutosJogados){
            this.atletaAmarelado = atletaAmarelado;
        }
    }
}