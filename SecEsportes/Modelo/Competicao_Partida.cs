using System;
using System.Collections.Generic;

namespace SecEsportes.Modelo{
    /// <summary>
    /// Classe que representa uma competição (Exemplos: Municipal de Futsal, Suíço Master, Areião, etc).
    /// </summary>
    public class Competicao_Partida {
        public int id { get; set; }

        public int id_Competicao { get; set; }
        public int numGrupo { get; set; }

        public int id_Equipe1 { get; set; }
        public EquipeCompeticao equipe1 { get; set; }

        public int id_Equipe2 { get; set; }
        public EquipeCompeticao equipe2 { get; set; }

        public List<Competicao_Partida_Evento> eventos { get; set; }
        public DateTime data { get; set; }
        public int rodada { get; set; } /* > 0 Representa o nº da Rodada | < 0 Representa MataMata (-1 Final, -2 SemiFinal, -3 Quartas de final, etc.)*/        

        public Competicao_Partida() { }

        public Competicao_Partida(EquipeCompeticao equipe1, EquipeCompeticao equipe2, int rodada, int numGrupo) {
            this.equipe1 = equipe1;
            this.equipe2 = equipe2;
            this.rodada = rodada;
            this.numGrupo = numGrupo;
        }
    }

}