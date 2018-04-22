using System;
using System.Collections.Generic;

namespace SecEsportes.Modelo {
    /// <summary>
    /// Classe que representa uma competição (Exemplos: Municipal de Futsal, Suíço Master, Areião, etc).
    /// </summary>
    public class Competicao_Partida_Evento {
        public int id { get; set; }

        public int id_Partida { get; set; }

        public int id_Equipe { get; set; }
        public EquipeCompeticao equipe { get; set; }

        public int id_Atleta { get; set; }
        public Atleta atleta { get; set; }

        public tpEventoEnum tpEvento { get; set; }

        public Competicao_Partida_Evento() { }

        public Competicao_Partida_Evento(EquipeCompeticao equipe, Atleta atleta, tpEventoEnum tpEvento) {
            this.equipe = equipe;
            this.atleta = atleta;
            this.tpEvento = tpEvento;
        }
    }

    public enum tpEventoEnum {
        Gol,
        CartaoAmarelo,
        CartaoVermelho
    }

}