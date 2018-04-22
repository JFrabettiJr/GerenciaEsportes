namespace SecEsportes.Modelo{
    public class Atleta_List_Artilheiro{

        public string nome_Equipe { get; set; }
        public int num_Gols { get; set; }
        public int num_Partidas { get; set; }
        public int id_Atleta { get; set; }
        public string nome_Atleta { get; set; }
        public double media { get; set; }
        public Atleta atleta { get; set; }

        public Atleta_List_Artilheiro() { }

        public Atleta_List_Artilheiro(Atleta atleta, string nome_Equipe, int num_Gols, int num_Partidas) {
            this.atleta = atleta;
            this.nome_Equipe = nome_Equipe;
            this.num_Gols = num_Gols;
            this.num_Partidas = num_Partidas;
        }
    }
}