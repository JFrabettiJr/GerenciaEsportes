using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecEsportes.Modelo{
    /// <summary>
    /// Classe que representa uma competição (Exemplos: Municipal de Futsal, Suíço Master, Areião, etc).
    /// </summary>
    class Competicao{
        public int id { get; }
        public string nome { get; set; }
        public DateTime dataInicial { get; set; }
        public DateTime? dataFinal { get; set; }
        public List<EquipeCompeticao> equipes { get; set; }
        public Esporte modalidade { get; set; }
    }
}