﻿namespace SecEsportes.Modelo{
    public class Atleta : Cargo{

        // Quando o atleta não ter númeração definida ainda, vai com null
        public int? numero { get; set; }

        public int numCartoesAcumulados { get; set; }

        public Atleta() { }

        public Atleta(int id, Funcao funcao, Pessoa pessoa, int? numero) : base(id, funcao, pessoa){
            this.numero = numero;
        }
    }
}