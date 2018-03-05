using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecEsportes.Modelo{
    class InformacaoAdicionalResposta{
        public int id { get; }
        public InformacaoAdicional informacaoAdicional { get; set; }
        public Pessoa pessoa { get; set; }
        public Object resposta { get; set; }

        public InformacaoAdicionalResposta(int id, InformacaoAdicional informacaoAdicional, Pessoa pessoa, object resposta)
        {
            this.id = id;
            this.informacaoAdicional = informacaoAdicional;
            this.pessoa = pessoa;
            this.resposta = resposta;
        }
    }
}