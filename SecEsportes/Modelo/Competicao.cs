using System;
using System.Collections.Generic;

namespace SecEsportes.Modelo{
    /// <summary>
    /// Classe que representa uma competição (Exemplos: Municipal de Futsal, Suíço Master, Areião, etc).
    /// </summary>
    public class Competicao{
        public int id { get; set; }
        public string nome { get; set; }
        public DateTime dataInicial { get; set; }
        public DateTime? dataFinal { get; set; }
        public List<EquipeCompeticao> equipes { get; set; }
        public List<Competicao_Partida> partidas { get; set; }
        public Modalidade modalidade { get; set; }
        public int id_Modalidade { get; set;  }
        public int numTimes { get; set; }
        public int numGrupos { get; set; }
        public int numMinimoJogadores { get; set; }
        public MataMataEnum mataMata { get; set; }
        public StatusEnum status { get; set; }
        public bool jogosIdaEVolta { get; set; }
        public bool jogosIdaEVolta_MataMata { get; set; }
        public NomesGruposEnum nomesGrupos { get; set; }
        public List<List<EquipeCompeticao>> grupos { get; set; }

        public Competicao() { }

        public Competicao(string nome, DateTime dataInicial, Modalidade modalidade) {
            this.nome = nome;
            this.dataInicial = dataInicial;
            this.modalidade = modalidade;
        }
    }

    public enum StatusEnum {
        _0_Encerrada,   // Campeonato encerrado
        _1_Aberta,      // As equipes e atletas são inseridos
        _2_Iniciada,    // Campeonato em andamento
        _3_EmPreparacao // São definidos os grupos
    }

    public enum NomesGruposEnum {
        _0_PorNumeracao,
        _1_PorLetras
    }

    public enum MataMataEnum{
        _1_Nao,
        _2_Final,
        _3_SemiFinal,
        _4_QuartasFinal,
        _5_OitavasFinal,
        _6_16AvosFinal,
        _7_32AvosFinal
    }

}