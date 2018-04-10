namespace SecEsportes.Modelo{
    public class Cargo{
        public int id { get; }
        public Funcao funcao { get; set; }
        public Pessoa pessoa { get; set; }

        public int id_funcao { get; set; }
        public int id_pessoa { get; set; }

        public Cargo() { }

        public Cargo(int id, Funcao funcao, Pessoa pessoa){
            this.id = id;
            this.funcao = funcao;
            this.pessoa = pessoa;
        }

        public override string ToString() {
            return pessoa.nome;
        }
    }
}