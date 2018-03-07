using System;
using System.Collections.Generic;

namespace SecEsportes.Modelo{
    /// <summary>
    /// Classe que representa uma competição (Exemplos: Municipal de Futsal, Suíço Master, Areião, etc).
    /// </summary>
    public class Competicao{
        public int id { get; }
        public string nome { get; set; }
        public DateTime dataInicial { get; set; }
        public DateTime? dataFinal { get; set; }
        public List<EquipeCompeticao> equipes { get; set; }
        public Esporte modalidade { get; set; }
        public int numGrupos { get; set; }
        public int timesPorGrupo { get; set; }
        public MataMataEnum mataMata { get; set; }
        public bool mataMataDoisJogos { get; set; }
    }

    public enum MataMataEnum{
        _16AvosFinal,
        _OitavasFinal,
        _QuartasFinal,
        _SemiFinal,
        _Final
    }

}