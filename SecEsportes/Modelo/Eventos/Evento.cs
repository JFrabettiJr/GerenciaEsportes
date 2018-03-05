using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecEsportes.Modelo.Eventos{
    /// <summary>
    /// Classe que representa os eventos (cartão amarelo, cartão vermelho, substituição, penalti, falta, gol)
    /// </summary>
    class Evento{
        public int id { get; }
        public string nome { get; set; }
        public decimal minutosJogados { get; set; }
        
        public Evento(int id, string nome, decimal minutosJogados){
            this.id = id;
            this.nome = nome;
            this.minutosJogados = minutosJogados;
        }
    }
}