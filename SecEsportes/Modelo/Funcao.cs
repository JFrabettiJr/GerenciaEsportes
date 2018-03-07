using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecEsportes.Modelo{
    /// <summary>
    /// Classe que representa a função de uma pesosa (atleta, árbitro, técnico, mesário, etc)
    /// </summary>
    public class Funcao{
        public int id { get; }
        public string descricao { get; set; }
    }
}