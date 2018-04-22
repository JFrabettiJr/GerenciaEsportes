using Dapper;
using SecEsportes.Modelo;
using SecEsportes.Repositorio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SecEsportes
{
    public partial class Form1 : Form{

        // Lista os cadastros
        List<Funcao> funcoes;
        List<Modalidade> modalidades;

        public Form1(){
            InitializeComponent();
            CenterToScreen();
            //Infraestrutura.SQLiteDatabase.Instance.SQLiteDatabaseConnection().Query("delete from competicao_partida where rodada = -1; delete from Competicao_Partida_Evento where id_Partida = 15;");
        }

        private void btnCadEquipes_Click(object sender, EventArgs e){
            new Views.CadEquipe().ShowDialog();
        }

        private void btnCadPessoa_Click(object sender, EventArgs e) {
            new Views.CadPessoa().ShowDialog();
        }

        private void btnCadFuncao_Click(object sender, EventArgs e) {
            new Views.CadFuncao().ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e) {
            new Views.CadCompeticao().ShowDialog();
        }

        private void btnIncluirTestes_Click(object sender, EventArgs e) {

            // Cria os treinadores, representantes e as equipes de competicao
            Pessoa treinador;
            Pessoa representante;

            string myString = "";

            // Cria as equipes e os atletas
            Equipe equipe;
            EquipeCompeticao equipeCompeticao;
            Cargo cargoTreinador, cargoRepresentante;
            Atleta atleta;

            Competicao competicao;

            funcoes = FuncaoRepositorio.Instance.get();
            modalidades = ModalidadeRepositorio.Instance.get();

            // Cria a competição
            Modalidade modalidade = modalidades.Find(modalidadeAEncontrar => modalidadeAEncontrar.descricao.ToUpper().Equals("FUTSAL"));

            competicao = new Competicao("Copa do mundo de 2014", new DateTime(2014, 06, 01), modalidade);
            competicao.dataFinal = new DateTime(2014, 07, 01);
            competicao.jogosIdaEVolta = false;
            competicao.jogosIdaEVolta_MataMata = false;
            competicao.mataMata = MataMataEnum._3_SemiFinal;
            competicao.nomesGrupos = NomesGruposEnum._0_PorNumeracao;
            competicao.numGrupos = 2;
            competicao.numTimes = 8;
            competicao.status = StatusEnum._1_Aberta;
            competicao.numMinimoJogadores = 5;
            CompeticaoRepositorio.Instance.insert(ref competicao, ref myString);

            // Cria a equipe do Brasil
            equipeCompeticao = criaEquipe("Bra", "Brasil", competicao);

            // Cria os atletas do Brasil
            criaAtleta("99972041077", "Jefferson", 1, equipeCompeticao, competicao);
            criaAtleta("89233100006", "Daniel Alves", 2, equipeCompeticao, competicao);
            criaAtleta("06517774025", "Thiago Silva", 3, equipeCompeticao, competicao);
            criaAtleta("22587513065", "David Luiz", 4, equipeCompeticao, competicao);
            criaAtleta("15169928068", "Fernandinho", 5, equipeCompeticao, competicao);
            criaAtleta("40187484503", "Marcelo", 6, equipeCompeticao, competicao);
            criaAtleta("52030240494", "Hulk", 7, equipeCompeticao, competicao);
            criaAtleta("54015067673", "Paulinho", 8, equipeCompeticao, competicao);
            criaAtleta("35331412254", "Fred", 9, equipeCompeticao, competicao);
            criaAtleta("01426201575", "Neymar", 10, equipeCompeticao, competicao);
            criaAtleta("77730243083", "Oscar", 11, equipeCompeticao, competicao);
            criaAtleta("32638865842", "Julio Cesar", 12, equipeCompeticao, competicao);
            criaAtleta("17105184213", "Dante", 13, equipeCompeticao, competicao);
            criaAtleta("07407243395", "Maxwell", 14, equipeCompeticao, competicao);
            criaAtleta("87304342200", "Henrique", 15, equipeCompeticao, competicao);
            criaAtleta("77707537246", "Ramires", 16, equipeCompeticao, competicao);
            criaAtleta("53578084735", "Luiz Gustavo", 17, equipeCompeticao, competicao);
            criaAtleta("50187045780", "Hernanes", 18, equipeCompeticao, competicao);

            // Cria a comissão técnica do Brasil
            criaTreinador("37280137229", "Tite", equipeCompeticao, competicao);
            criaRepresentante("65370480796", "Michel Temer", equipeCompeticao, competicao);


            // Cria a equipe do Alemanha
            equipeCompeticao = criaEquipe("Ale", "Alemanha", competicao);

            //Cria as pessoas da Alemanha
            criaAtleta("45677262196", "Neuer", 1, equipeCompeticao, competicao);
            criaAtleta("76810742875", "Ginter", 2, equipeCompeticao, competicao);
            criaAtleta("38234011812", "Howedes", 3, equipeCompeticao, competicao);
            criaAtleta("76021377109", "Hummels", 4, equipeCompeticao, competicao);
            criaAtleta("02181680639", "Khedira", 5, equipeCompeticao, competicao);
            criaAtleta("64658660806", "Schweinsteiger", 6, equipeCompeticao, competicao);
            criaAtleta("48047427601", "Ozil", 7, equipeCompeticao, competicao);
            criaAtleta("53243463300", "Schurrle", 8, equipeCompeticao, competicao);
            criaAtleta("32476830542", "Podolski", 9, equipeCompeticao, competicao);
            criaAtleta("76462344865", "Klose", 10, equipeCompeticao, competicao);
            criaAtleta("86532854310", "Zieler", 11, equipeCompeticao, competicao);
            criaAtleta("81422468135", "Muller", 12, equipeCompeticao, competicao);
            criaAtleta("42177624886", "Draxler", 13, equipeCompeticao, competicao);
            criaAtleta("48135780710", "Durm", 14, equipeCompeticao, competicao);
            criaAtleta("63200223456", "Lahm", 15, equipeCompeticao, competicao);
            criaAtleta("67152361193", "Mertesacker", 16, equipeCompeticao, competicao);
            criaAtleta("11375087606", "Kroos", 17, equipeCompeticao, competicao);
            criaAtleta("64441558600", "Gotze", 18, equipeCompeticao, competicao);

            criaTreinador("71005721858", "Joachim Löw", equipeCompeticao, competicao);
            criaRepresentante("36037846502", "Frank-Walter Steinmeier", equipeCompeticao, competicao);


            // Cria a equipe do Inglaterra
            equipeCompeticao = criaEquipe("Ing", "Inglaterra", competicao);

            // Cria as pessoas da Inglaterra
            criaAtleta("53101543533", "Hart", 1, equipeCompeticao, competicao);
            criaAtleta("06442443051", "Johnson", 2, equipeCompeticao, competicao);
            criaAtleta("13074475030", "Baines", 3, equipeCompeticao, competicao);
            criaAtleta("41474884717", "Gerrard", 4, equipeCompeticao, competicao);
            criaAtleta("36184610899", "Cahill", 5, equipeCompeticao, competicao);
            criaAtleta("52241328600", "Jagielka", 6, equipeCompeticao, competicao);
            criaAtleta("44040807359", "Wilshere", 7, equipeCompeticao, competicao);
            criaAtleta("67548035500", "Lampard", 8, equipeCompeticao, competicao);
            criaAtleta("06301503708", "Sturridge", 9, equipeCompeticao, competicao);
            criaAtleta("23687262251", "Rooney", 10, equipeCompeticao, competicao);
            criaAtleta("60706348290", "Welbeck", 11, equipeCompeticao, competicao);
            criaAtleta("43773311400", "Smalling", 12, equipeCompeticao, competicao);
            criaAtleta("72534801635", "Foster", 13, equipeCompeticao, competicao);
            criaAtleta("07602781210", "Henderson", 14, equipeCompeticao, competicao);
            criaAtleta("25230318686", "Jones", 15, equipeCompeticao, competicao);
            criaAtleta("27865808380", "Milner", 16, equipeCompeticao, competicao);
            criaAtleta("87255716130", "Lambert", 17, equipeCompeticao, competicao);
            criaAtleta("83285786540", "Sterling", 18, equipeCompeticao, competicao);

            criaTreinador("26208166454", "Gareth Southgate", equipeCompeticao, competicao);
            criaRepresentante("56264767336", "Elizabeth II", equipeCompeticao, competicao);

            
            // Cria a equipe do Japão
            equipeCompeticao = criaEquipe("Ita", "Itália", competicao);

            // Cria as pessoas da Japão
            criaAtleta("48735155566", "Buffon", 1, equipeCompeticao, competicao);
            criaAtleta("12255853841", "De Scglio", 2, equipeCompeticao, competicao);
            criaAtleta("40373707274", "Chielini", 3, equipeCompeticao, competicao);
            criaAtleta("52884778250", "Darmian", 4, equipeCompeticao, competicao);
            criaAtleta("62524737314", "Motta", 5, equipeCompeticao, competicao);
            criaAtleta("23686424550", "Candreva", 6, equipeCompeticao, competicao);
            criaAtleta("82187374807", "Abate", 7, equipeCompeticao, competicao);
            criaAtleta("60787720232", "Marchisio", 8, equipeCompeticao, competicao);
            criaAtleta("03744083608", "Balotelli", 9, equipeCompeticao, competicao);
            criaAtleta("11263205100", "Cassano", 10, equipeCompeticao, competicao);
            criaAtleta("24703118025", "Cerci", 11, equipeCompeticao, competicao);
            criaAtleta("18766844886", "Sirigu", 12, equipeCompeticao, competicao);
            criaAtleta("47518514893", "Perin", 13, equipeCompeticao, competicao);
            criaAtleta("72244722120", "Aquilani", 14, equipeCompeticao, competicao);
            criaAtleta("34423110717", "Barzagli", 15, equipeCompeticao, competicao);
            criaAtleta("14086755521", "De Rossi", 16, equipeCompeticao, competicao);
            criaAtleta("16077427640", "Immobile", 17, equipeCompeticao, competicao);
            criaAtleta("46604718026", "Parolo", 18, equipeCompeticao, competicao);

            criaTreinador("60371558018", "Cesare Prandelli", equipeCompeticao, competicao);
            criaRepresentante("12561048500", "Sergio Mattarella", equipeCompeticao, competicao);


            // Cria a equipe do Argentina
            equipeCompeticao = criaEquipe("Arg", "Argentina", competicao);

            // Cria as pessoas da Argentina
            criaAtleta("78341182343", "Romero", 1, equipeCompeticao, competicao);
            criaAtleta("63157165046", "Garay", 2, equipeCompeticao, competicao);
            criaAtleta("30867800020", "Campagnaro", 3, equipeCompeticao, competicao);
            criaAtleta("10034140875", "Zabaleta", 4, equipeCompeticao, competicao);
            criaAtleta("34234114731", "Gago", 5, equipeCompeticao, competicao);
            criaAtleta("07318175750", "Biglia", 6, equipeCompeticao, competicao);
            criaAtleta("46755738352", "Di María", 7, equipeCompeticao, competicao);
            criaAtleta("33126638147", "Pérez", 8, equipeCompeticao, competicao);
            criaAtleta("27405236294", "Higuaín", 9, equipeCompeticao, competicao);
            criaAtleta("33717263803", "Messi", 10, equipeCompeticao, competicao);
            criaAtleta("55568758204", "Maxi Rodriguez", 11, equipeCompeticao, competicao);
            criaAtleta("02825665380", "Orión", 12, equipeCompeticao, competicao);
            criaAtleta("67781150090", "Fernández", 13, equipeCompeticao, competicao);
            criaAtleta("56120684336", "Mascherano", 14, equipeCompeticao, competicao);
            criaAtleta("61361561130", "Demichelis", 15, equipeCompeticao, competicao);
            criaAtleta("15743310432", "Rojo", 16, equipeCompeticao, competicao);
            criaAtleta("88433361503", "Palacio", 17, equipeCompeticao, competicao);
            criaAtleta("05426170215", "Aguero", 18, equipeCompeticao, competicao);

            criaTreinador("11033454273", "Jorge Sampaoli", equipeCompeticao, competicao);
            criaRepresentante("46225256580", "Mauricio Macri", equipeCompeticao, competicao);


            // Cria a equipe do Espanha
            equipeCompeticao = criaEquipe("Esp", "Espanha", competicao);

            // Cria as pessoas da Espanha
            criaAtleta("81422072576", "Casillas", 1, equipeCompeticao, competicao);
            criaAtleta("67568660796", "Albiol", 2, equipeCompeticao, competicao);
            criaAtleta("85217821361", "Piqué", 3, equipeCompeticao, competicao);
            criaAtleta("44773016000", "Martinéz", 4, equipeCompeticao, competicao);
            criaAtleta("82046703464", "Juanfran", 5, equipeCompeticao, competicao);
            criaAtleta("40430738528", "Iniesta", 6, equipeCompeticao, competicao);
            criaAtleta("11443800147", "Villa", 7, equipeCompeticao, competicao);
            criaAtleta("71770753486", "Xavi", 8, equipeCompeticao, competicao);
            criaAtleta("31776527321", "Torres", 9, equipeCompeticao, competicao);
            criaAtleta("01140084429", "Fàbregas", 10, equipeCompeticao, competicao);
            criaAtleta("63271337110", "Pedro", 11, equipeCompeticao, competicao);
            criaAtleta("13437483137", "de Gea", 12, equipeCompeticao, competicao);
            criaAtleta("44684506657", "Mata", 13, equipeCompeticao, competicao);
            criaAtleta("04821246287", "Xabi Alonso", 14, equipeCompeticao, competicao);
            criaAtleta("50058372806", "Sergio Ramos", 15, equipeCompeticao, competicao);
            criaAtleta("21313752045", "Busquets", 16, equipeCompeticao, competicao);
            criaAtleta("20768051177", "Koke", 17, equipeCompeticao, competicao);
            criaAtleta("64787581414", "Jordi Alba", 18, equipeCompeticao, competicao);

            criaTreinador("00600512800", "Julen Lopetegui", equipeCompeticao, competicao);
            criaRepresentante("67067024633", "Mariano Rajoy", equipeCompeticao, competicao);


            // Cria a equipe do Holanda
            equipeCompeticao = criaEquipe("Hol", "Holanda", competicao);

            // Cria as pessoas da Holanda
            criaAtleta("28615184640", "Cillessen", 1, equipeCompeticao, competicao);
            criaAtleta("21861618697", "Vlaar", 2, equipeCompeticao, competicao);
            criaAtleta("60646342860", "De Vrij", 3, equipeCompeticao, competicao);
            criaAtleta("24405366608", "Indi", 4, equipeCompeticao, competicao);
            criaAtleta("54106284111", "Blind", 5, equipeCompeticao, competicao);
            criaAtleta("33811653210", "de Guzmán", 6, equipeCompeticao, competicao);
            criaAtleta("85487615209", "Janmaat", 7, equipeCompeticao, competicao);
            criaAtleta("22785276655", "De Jong", 8, equipeCompeticao, competicao);
            criaAtleta("03887376200", "Van Persie", 9, equipeCompeticao, competicao);
            criaAtleta("47377336013", "Sneijder", 10, equipeCompeticao, competicao);
            criaAtleta("34602708536", "Robben", 11, equipeCompeticao, competicao);
            criaAtleta("17231566391", "Verhaegh", 12, equipeCompeticao, competicao);
            criaAtleta("74028554306", "Veltman", 13, equipeCompeticao, competicao);
            criaAtleta("07771220495", "Kongolo", 14, equipeCompeticao, competicao);
            criaAtleta("00368862704", "Kuyt", 15, equipeCompeticao, competicao);
            criaAtleta("08234616455", "Clasie", 16, equipeCompeticao, competicao);
            criaAtleta("61871756626", "Lens", 17, equipeCompeticao, competicao);
            criaAtleta("58608423332", "Huntelaar", 18, equipeCompeticao, competicao);

            criaTreinador("88888888888", "Ronald Koeman", equipeCompeticao, competicao);
            criaRepresentante("88888888880", "Guilherme Alexandre", equipeCompeticao, competicao);


            // Cria a equipe do França
            equipeCompeticao = criaEquipe("Fra", "França", competicao);

            // Cria as pessoas da França
            criaAtleta("88558273405", "Lloris", 1, equipeCompeticao, competicao);
            criaAtleta("32277365270", "Debuchy", 2, equipeCompeticao, competicao);
            criaAtleta("20875544207", "Evra", 3, equipeCompeticao, competicao);
            criaAtleta("74613558212", "Varane", 4, equipeCompeticao, competicao);
            criaAtleta("55318634460", "Sakho", 5, equipeCompeticao, competicao);
            criaAtleta("48742517060", "Cabaye", 6, equipeCompeticao, competicao);
            criaAtleta("63708110099", "Cabella", 7, equipeCompeticao, competicao);
            criaAtleta("71403367337", "Valbuena", 8, equipeCompeticao, competicao);
            criaAtleta("28805043761", "Giroud", 9, equipeCompeticao, competicao);
            criaAtleta("16702150830", "Benzema", 10, equipeCompeticao, competicao);
            criaAtleta("41840167238", "Grizeman", 11, equipeCompeticao, competicao);
            criaAtleta("72105785280", "Mavuba", 12, equipeCompeticao, competicao);
            criaAtleta("88577035093", "Mangala", 13, equipeCompeticao, competicao);
            criaAtleta("38023285076", "Matuidi", 14, equipeCompeticao, competicao);
            criaAtleta("72518826203", "Sagna", 15, equipeCompeticao, competicao);
            criaAtleta("03723458165", "Ruffier", 16, equipeCompeticao, competicao);
            criaAtleta("40641653735", "Digne", 17, equipeCompeticao, competicao);
            criaAtleta("51458410358", "Sissoko", 18, equipeCompeticao, competicao);

            criaTreinador("02721281399", "Didier Deschamps", equipeCompeticao, competicao);
            criaRepresentante("17220074271", "Emmanuel Macron", equipeCompeticao, competicao);
        }

        public void criaTreinador(string cpf, string nome, EquipeCompeticao equipeCompeticao = null, Competicao competicao = null) {
            string myString = "";

            Pessoa treinador = new Pessoa(cpf, nome, new DateTime(2000, 01, 01));
            treinador.funcoes = funcoes.FindAll(funcao => funcao.codigo == FuncaoRepositorio.Instance.codigoTreinador);

            PessoaRepositorio.Instance.insert(ref treinador, ref myString);

            if ((!(equipeCompeticao is null)) && (!(competicao is null))) {
                Cargo cargoTreinador = new Cargo(treinador.id, funcoes.Find(funcao => funcao.codigo.Equals(FuncaoRepositorio.Instance.codigoTreinador)), treinador);
                cargoTreinador.id_pessoa = treinador.id;

                equipeCompeticao.treinador = cargoTreinador;
                equipeCompeticao.id_treinador = treinador.id;

                EquipeRepositorio.Instance.updateEquipeCompeticao(equipeCompeticao, competicao);
            }
        }
        public void criaRepresentante(string cpf, string nome, EquipeCompeticao equipeCompeticao = null, Competicao competicao = null) {
            string myString = "";

            Pessoa representante = new Pessoa(cpf, nome, new DateTime(2000, 01, 01));
            representante.funcoes = funcoes.FindAll(funcao => funcao.codigo == FuncaoRepositorio.Instance.codigoRepresentante);

            PessoaRepositorio.Instance.insert(ref representante, ref myString);

            if ((!(equipeCompeticao is null)) && (!(competicao is null))) {
                Cargo cargoRepresentante = new Cargo(representante.id, funcoes.Find(funcao => funcao.codigo.Equals(FuncaoRepositorio.Instance.codigoRepresentante)), representante);
                cargoRepresentante.id_pessoa = representante.id;

                equipeCompeticao.representante = cargoRepresentante;
                equipeCompeticao.id_representante = representante.id;

                EquipeRepositorio.Instance.updateEquipeCompeticao(equipeCompeticao, competicao);
            }
        }

        public EquipeCompeticao criaEquipe(string codigo, string nome, Competicao competicao = null) {
            string myString = "";

            Equipe equipe = new Equipe(codigo, nome);
            EquipeRepositorio.Instance.insert(ref equipe, ref myString);

            if (!(competicao is null)) {
                CompeticaoRepositorio.Instance.insertEquipeEmCompeticao(competicao.id, equipe);
                EquipeCompeticao equipeCompeticao = new EquipeCompeticao(equipe.codigo, equipe.nome, null, null);
                equipeCompeticao.id = equipe.id;
                return equipeCompeticao;
            }

            return null;
        }

        public void criaAtleta(string cpf, string nome, int numero, Equipe equipe = null, Competicao competicao = null) {
            string myString = "";

            Pessoa pessoa = new Pessoa(cpf, nome, new DateTime(2000, 01, 01));
            pessoa.funcoes = funcoes.FindAll(funcao => funcao.codigo == FuncaoRepositorio.Instance.codigoAtleta);
            PessoaRepositorio.Instance.insert(ref pessoa, ref myString);

            if ((!(equipe is null)) && (!(competicao is null))) {
                Atleta atleta = PessoaRepositorio.Instance.getAtletas().Find(atletaAEncontrar => atletaAEncontrar.pessoa.cpf.Equals(pessoa.cpf));
                atleta.numero = numero;
                EquipeRepositorio.Instance.insertAtletaEmEquipe(competicao.id, equipe.id, atleta);
            }            
        }

    }
}
