using System;
using System.Collections.Generic;

namespace SecEsportes.Modelo {
    /// <summary>
    /// Classe que representa uma competição (Exemplos: Municipal de Futsal, Suíço Master, Areião, etc).
    /// </summary>
    public class Competicao_Suspensao {
        public int id { get; set; }

        public int id_Competicao { get; set; }

        public int id_Equipe { get; set; }
        public EquipeCompeticao equipe { get; set; }

        public int id_Atleta { get; set; }
        public Atleta atleta { get; set; }

        public int numJogosSuspensao { get; set; }

        public Competicao_Suspensao() { }

        public Competicao_Suspensao(Competicao competicao, EquipeCompeticao equipe, Atleta atleta, int numJogosSuspensao) {
            this.atleta = atleta;
            this.numJogosSuspensao = numJogosSuspensao;
            this.equipe = equipe;

            this.id_Atleta = atleta.pessoa.id;
            this.id_Competicao = competicao.id;
            this.id_Equipe = equipe.id;

        }
    }

}