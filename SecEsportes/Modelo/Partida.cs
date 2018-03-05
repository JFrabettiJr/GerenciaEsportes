using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecEsportes.Modelo{
    class Partida{
        public int id { get; }
        public EquipeCompeticao equipeMandante { get; set; }
        public EquipeCompeticao equipeVisitante { get; set; }
        
        // Número dos atletas que pontuaram... caso foi gol contra, deve ser pontuado com -
        public List<int> pontuacaoMandante { get; set; }
        public List<int> pontuacaoVisitante { get; set; }
    }
}
