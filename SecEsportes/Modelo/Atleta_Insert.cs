namespace SecEsportes.Modelo{
    public class Atleta_Insert: Atleta{

        public bool selected { get; set; }

        public Atleta_Insert() { }

        public Atleta_Insert(int id, Funcao funcao, Pessoa pessoa, int? numero) : base(id, funcao, pessoa, numero) {
            this.Numero = numero;
        }
    }
}