using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecEsportes.Modelo{
    public class InformacaoAdicional{
        public int id { get; }
        public Funcao aplicavelAFuncao { get; set; }
        public string descricao { get; set; }
        public Type tipoResposta { get; set; }

        public InformacaoAdicional(int id, Funcao aplicavelAFuncao, string descricao, Type tipoResposta){
            this.id = id;
            this.aplicavelAFuncao = aplicavelAFuncao;
            this.descricao = descricao;
            this.tipoResposta = tipoResposta;
        }
    }
}