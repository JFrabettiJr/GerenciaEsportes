using Dapper;
using SecEsportes.Modelo;
using SecEsportes.Repositorio;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace SecEsportes
{
    public partial class Main : Form{

        // Lista os cadastros
        List<Funcao> funcoes;
        List<Modalidade> modalidades;

        private Usuario usuarioLogado;

        public Main(Usuario usuarioLogado) {
            InitializeComponent();
            CenterToScreen();
            this.usuarioLogado = usuarioLogado;
        }

        private void btnCadEquipes_Click(object sender, EventArgs e){
            new Views.CadEquipe(usuarioLogado).ShowDialog();
        }

        private void btnCadPessoa_Click(object sender, EventArgs e) {
            new Views.CadPessoa(usuarioLogado).ShowDialog();
        }

        private void btnCadFuncao_Click(object sender, EventArgs e) {
            new Views.CadFuncao(usuarioLogado).ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e) {
            new Views.CadCompeticao(usuarioLogado).ShowDialog();
        }

        private void btnCadUsuario_Click(object sender, EventArgs e) {
            new Views.CadUsuario(usuarioLogado).ShowDialog();
        }

        private void btnIncluirTestes_Click(object sender, EventArgs e) {
            

            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;

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

                competicao = new Competicao("Municipal", new DateTime(2014, 06, 01), modalidade);
                competicao.dataFinal = new DateTime(2018, 07, 01);
                competicao.jogosIdaEVolta = false;
                competicao.jogosIdaEVolta_FaseFinal = false;
                competicao.faseFinal = FaseFinalEnum._4_QuartasFinal;
                competicao.nomesGrupos = NomesGruposEnum._0_PorNumeracao;
                competicao.numGrupos = 2;
                competicao.numTimes = 12;
                competicao.status = StatusEnum._1_Aberta;
                competicao.numMinimoJogadores = 5;
                competicao.arbitros = new List<Cargo>();
                competicao.tpSuspensao = SuspensaoEnum._2_3CA_1Jogo_3CAe1CV_2Jogos;
                competicao.zerarCartoesFaseFinal = true;
                CompeticaoRepositorio.Instance.insert(ref competicao, ref myString);

                // Cria a equipe do Brasil - Virou Bar sem lona
                equipeCompeticao = criaEquipe("BSL", "Bar sem Lona", competicao);

                // Cria os atletas do Brasil - Virou Bar sem lona
                criaAtleta("99972041077", "Jefferson", 1, equipeCompeticao, competicao);
                criaAtleta("89233100006", "Daniel", 2, equipeCompeticao, competicao);
                criaAtleta("06517774025", "Thiago", 3, equipeCompeticao, competicao);
                criaAtleta("22587513065", "David", 4, equipeCompeticao, competicao);
                criaAtleta("15169928068", "Fernandinho", 5, equipeCompeticao, competicao);
                criaAtleta("40187484503", "Marcelo", 6, equipeCompeticao, competicao);
                criaAtleta("52030240494", "Hulk Magrelo", 7, equipeCompeticao, competicao);
                criaAtleta("54015067673", "Paulinho", 8, equipeCompeticao, competicao);
                criaAtleta("35331412254", "Frederico", 9, equipeCompeticao, competicao);
                criaAtleta("01426201575", "Gabriel", 10, equipeCompeticao, competicao);
                criaAtleta("77730243083", "Oscar", 11, equipeCompeticao, competicao);
                criaAtleta("32638865842", "Julio Cesar", 12, equipeCompeticao, competicao);
                criaAtleta("17105184213", "Dante", 13, equipeCompeticao, competicao);
                criaAtleta("07407243395", "Maxw", 14, equipeCompeticao, competicao);
                criaAtleta("87304342200", "Henrique", 15, equipeCompeticao, competicao);
                criaAtleta("77707537246", "Ramires", 16, equipeCompeticao, competicao);
                criaAtleta("53578084735", "Luiz Gustavo", 17, equipeCompeticao, competicao);
                criaAtleta("50187045780", "Lopes", 18, equipeCompeticao, competicao);

                // Cria a comissão técnica do Brasil - Virou Bar sem lona
                criaTreinador("37280137229", "Marcelao", equipeCompeticao, competicao);
                criaRepresentante("65370480796", "Michel", equipeCompeticao, competicao);

                 
                // Cria a equipe do Alemanha - Virou Real Madruga
                equipeCompeticao = criaEquipe("RLM", "Real Madruga", competicao);

                //Cria as pessoas da Alemanha
                criaAtleta("45677262196", "Nilton", 1, equipeCompeticao, competicao);
                criaAtleta("76810742875", "Gin", 2, equipeCompeticao, competicao);
                criaAtleta("38234011812", "Helinho", 3, equipeCompeticao, competicao);
                criaAtleta("76021377109", "Humberto", 4, equipeCompeticao, competicao);
                criaAtleta("02181680639", "Kaio", 5, equipeCompeticao, competicao);
                criaAtleta("64658660806", "Souza", 6, equipeCompeticao, competicao);
                criaAtleta("48047427601", "Orson", 7, equipeCompeticao, competicao);
                criaAtleta("53243463300", "Silva", 8, equipeCompeticao, competicao);
                criaAtleta("32476830542", "Polaco", 9, equipeCompeticao, competicao);
                criaAtleta("76462344865", "Kleber", 10, equipeCompeticao, competicao);
                criaAtleta("86532854310", "Zinho", 11, equipeCompeticao, competicao);
                criaAtleta("81422468135", "Maicon", 12, equipeCompeticao, competicao);
                criaAtleta("42177624886", "Diego", 13, equipeCompeticao, competicao);
                criaAtleta("48135780710", "Dom", 14, equipeCompeticao, competicao);
                criaAtleta("63200223456", "Lan", 15, equipeCompeticao, competicao);
                criaAtleta("67152361193", "Milton", 16, equipeCompeticao, competicao);
                criaAtleta("11375087606", "Luciao", 17, equipeCompeticao, competicao);
                criaAtleta("64441558600", "Gabrielzinho", 18, equipeCompeticao, competicao);

                criaTreinador("71005721858", "Joachim", equipeCompeticao, competicao);
                criaRepresentante("36037846502", "Frank", equipeCompeticao, competicao);


                // Cria a equipe do Inglaterra
                equipeCompeticao = criaEquipe("BIG", "Bigode Grosso", competicao);

                // Cria as pessoas da Inglaterra
                criaAtleta("53101543533", "Alan", 1, equipeCompeticao, competicao);
                criaAtleta("06442443051", "Juninho", 2, equipeCompeticao, competicao);
                criaAtleta("13074475030", "Bento", 3, equipeCompeticao, competicao);
                criaAtleta("41474884717", "Gustavo", 4, equipeCompeticao, competicao);
                criaAtleta("36184610899", "Chiquinho", 5, equipeCompeticao, competicao);
                criaAtleta("52241328600", "Junior", 6, equipeCompeticao, competicao);
                criaAtleta("44040807359", "Lipao", 7, equipeCompeticao, competicao);
                criaAtleta("67548035500", "Leandro", 8, equipeCompeticao, competicao);
                criaAtleta("06301503708", "Peu", 9, equipeCompeticao, competicao);
                criaAtleta("23687262251", "Diego", 10, equipeCompeticao, competicao);
                criaAtleta("60706348290", "Joao", 11, equipeCompeticao, competicao);
                criaAtleta("43773311400", "Pixoxo", 12, equipeCompeticao, competicao);
                criaAtleta("72534801635", "Danilo", 13, equipeCompeticao, competicao);
                criaAtleta("07602781210", "Murilo", 14, equipeCompeticao, competicao);
                criaAtleta("25230318686", "Jonas", 15, equipeCompeticao, competicao);
                criaAtleta("27865808380", "Pedro", 16, equipeCompeticao, competicao);
                criaAtleta("87255716130", "Raphael", 17, equipeCompeticao, competicao);
                criaAtleta("83285786540", "Gilberto", 18, equipeCompeticao, competicao);

                criaTreinador("26208166454", "Carlos", equipeCompeticao, competicao);
                criaRepresentante("56264767336", "Carlinhos", equipeCompeticao, competicao);


                // Cria a equipe do Japão
                equipeCompeticao = criaEquipe("AS", "Água Santa", competicao);

                // Cria as pessoas da Japão
                criaAtleta("48735155566", "Beto", 1, equipeCompeticao, competicao);
                criaAtleta("12255853841", "Dario", 2, equipeCompeticao, competicao);
                criaAtleta("40373707274", "Caio", 3, equipeCompeticao, competicao);
                criaAtleta("52884778250", "Damiao", 4, equipeCompeticao, competicao);
                criaAtleta("62524737314", "Motta", 5, equipeCompeticao, competicao);
                criaAtleta("23686424550", "Celso", 6, equipeCompeticao, competicao);
                criaAtleta("82187374807", "Anderson", 7, equipeCompeticao, competicao);
                criaAtleta("60787720232", "Manoel", 8, equipeCompeticao, competicao);
                criaAtleta("03744083608", "Balotelli", 9, equipeCompeticao, competicao);
                criaAtleta("11263205100", "Cassiano", 10, equipeCompeticao, competicao);
                criaAtleta("24703118025", "Glauber", 11, equipeCompeticao, competicao);
                criaAtleta("18766844886", "Sergio", 12, equipeCompeticao, competicao);
                criaAtleta("47518514893", "Periquito", 13, equipeCompeticao, competicao);
                criaAtleta("72244722120", "Aquiles", 14, equipeCompeticao, competicao);
                criaAtleta("34423110717", "Borota", 15, equipeCompeticao, competicao);
                criaAtleta("14086755521", "De Rossi", 16, equipeCompeticao, competicao);
                criaAtleta("16077427640", "Italo", 17, equipeCompeticao, competicao);
                criaAtleta("46604718026", "Paulo", 18, equipeCompeticao, competicao);

                criaTreinador("60371558018", "Cesar", equipeCompeticao, competicao);
                criaRepresentante("12561048500", "Sergio", equipeCompeticao, competicao);


                // Cria a equipe do Argentina
                equipeCompeticao = criaEquipe("APP", "Atlético Paineiras", competicao);

                // Cria as pessoas da Argentina
                criaAtleta("78341182343", "Romero", 1, equipeCompeticao, competicao);
                criaAtleta("63157165046", "Gaston", 2, equipeCompeticao, competicao);
                criaAtleta("30867800020", "Lazinho", 3, equipeCompeticao, competicao);
                criaAtleta("10034140875", "Teobaldo", 4, equipeCompeticao, competicao);
                criaAtleta("34234114731", "Gago", 5, equipeCompeticao, competicao);
                criaAtleta("07318175750", "Big Phil", 6, equipeCompeticao, competicao);
                criaAtleta("46755738352", "Di María", 7, equipeCompeticao, competicao);
                criaAtleta("33126638147", "Perez", 8, equipeCompeticao, competicao);
                criaAtleta("27405236294", "Porco", 9, equipeCompeticao, competicao);
                criaAtleta("33717263803", "Mazinho", 10, equipeCompeticao, competicao);
                criaAtleta("55568758204", "Maxi", 11, equipeCompeticao, competicao);
                criaAtleta("02825665380", "Roberto", 12, equipeCompeticao, competicao);
                criaAtleta("67781150090", "Fernandez", 13, equipeCompeticao, competicao);
                criaAtleta("56120684336", "Mascherano", 14, equipeCompeticao, competicao);
                criaAtleta("61361561130", "Demi Maia", 15, equipeCompeticao, competicao);
                criaAtleta("15743310432", "Ruiz", 16, equipeCompeticao, competicao);
                criaAtleta("88433361503", "Palacio", 17, equipeCompeticao, competicao);
                criaAtleta("05426170215", "Almeida", 18, equipeCompeticao, competicao);

                criaTreinador("11033454273", "Jorge", equipeCompeticao, competicao);
                criaRepresentante("46225256580", "Mauricio", equipeCompeticao, competicao);


                // Cria a equipe do Espanha
                equipeCompeticao = criaEquipe("OJC", "O Jegue da Chapada", competicao);

                // Cria as pessoas da Espanha
                criaAtleta("81422072576", "Caio", 1, equipeCompeticao, competicao);
                criaAtleta("67568660796", "Almeida", 2, equipeCompeticao, competicao);
                criaAtleta("85217821361", "Peru", 3, equipeCompeticao, competicao);
                criaAtleta("44773016000", "Martin", 4, equipeCompeticao, competicao);
                criaAtleta("82046703464", "Josefe", 5, equipeCompeticao, competicao);
                criaAtleta("40430738528", "Iniesta", 6, equipeCompeticao, competicao);
                criaAtleta("11443800147", "Vinicius", 7, equipeCompeticao, competicao);
                criaAtleta("71770753486", "Chaves", 8, equipeCompeticao, competicao);
                criaAtleta("31776527321", "Téo", 9, equipeCompeticao, competicao);
                criaAtleta("01140084429", "Fernando", 10, equipeCompeticao, competicao);
                criaAtleta("63271337110", "Pedro", 11, equipeCompeticao, competicao);
                criaAtleta("13437483137", "Danilo", 12, equipeCompeticao, competicao);
                criaAtleta("44684506657", "Marquinhos", 13, equipeCompeticao, competicao);
                criaAtleta("04821246287", "Leonardo", 14, equipeCompeticao, competicao);
                criaAtleta("50058372806", "Sergio", 15, equipeCompeticao, competicao);
                criaAtleta("21313752045", "Bebe", 16, equipeCompeticao, competicao);
                criaAtleta("20768051177", "Oliver", 17, equipeCompeticao, competicao);
                criaAtleta("64787581414", "Romero", 18, equipeCompeticao, competicao);

                criaTreinador("00600512800", "Julio", equipeCompeticao, competicao);
                criaRepresentante("67067024633", "Mariano", equipeCompeticao, competicao);


                // Cria a equipe do Holanda
                equipeCompeticao = criaEquipe("BW", "Bairro Willians", competicao);

                // Cria as pessoas da Holanda
                criaAtleta("28615184640", "Cesar", 1, equipeCompeticao, competicao);
                criaAtleta("21861618697", "Vitor", 2, equipeCompeticao, competicao);
                criaAtleta("60646342860", "Dilsinho", 3, equipeCompeticao, competicao);
                criaAtleta("24405366608", "Ignacio", 4, equipeCompeticao, competicao);
                criaAtleta("54106284111", "Batoré", 5, equipeCompeticao, competicao);
                criaAtleta("33811653210", "Gustavinho", 6, equipeCompeticao, competicao);
                criaAtleta("85487615209", "Johannes", 7, equipeCompeticao, competicao);
                criaAtleta("22785276655", "Julio", 8, equipeCompeticao, competicao);
                criaAtleta("03887376200", "Vinicius", 9, equipeCompeticao, competicao);
                criaAtleta("47377336013", "Serginho", 10, equipeCompeticao, competicao);
                criaAtleta("34602708536", "Xoxo", 11, equipeCompeticao, competicao);
                criaAtleta("17231566391", "Pedro", 12, equipeCompeticao, competicao);
                criaAtleta("74028554306", "Liminha", 13, equipeCompeticao, competicao);
                criaAtleta("07771220495", "Miron", 14, equipeCompeticao, competicao);
                criaAtleta("00368862704", "Juliano", 15, equipeCompeticao, competicao);
                criaAtleta("08234616455", "Bruno", 16, equipeCompeticao, competicao);
                criaAtleta("61871756626", "Marcio", 17, equipeCompeticao, competicao);
                criaAtleta("58608423332", "Oliveira", 18, equipeCompeticao, competicao);

                criaTreinador("88888888888", "Ronald", equipeCompeticao, competicao);
                criaRepresentante("88888888880", "Guilherme Alexandre", equipeCompeticao, competicao);


                // Cria a equipe do França
                equipeCompeticao = criaEquipe("TIG", "Tigers", competicao);

                // Cria as pessoas da França
                criaAtleta("88558273405", "Luiz", 1, equipeCompeticao, competicao);
                criaAtleta("32277365270", "Danilo", 2, equipeCompeticao, competicao);
                criaAtleta("20875544207", "Evandro", 3, equipeCompeticao, competicao);
                criaAtleta("74613558212", "Vinicius", 4, equipeCompeticao, competicao);
                criaAtleta("55318634460", "Souza", 5, equipeCompeticao, competicao);
                criaAtleta("48742517060", "Caio", 6, equipeCompeticao, competicao);
                criaAtleta("63708110099", "Luizinho", 7, equipeCompeticao, competicao);
                criaAtleta("71403367337", "Portuga", 8, equipeCompeticao, competicao);
                criaAtleta("28805043761", "Gian", 9, equipeCompeticao, competicao);
                criaAtleta("16702150830", "Badu", 10, equipeCompeticao, competicao);
                criaAtleta("41840167238", "Gerson", 11, equipeCompeticao, competicao);
                criaAtleta("72105785280", "Matheus", 12, equipeCompeticao, competicao);
                criaAtleta("88577035093", "Brener", 13, equipeCompeticao, competicao);
                criaAtleta("38023285076", "Marcos", 14, equipeCompeticao, competicao);
                criaAtleta("72518826203", "Nilton", 15, equipeCompeticao, competicao);
                criaAtleta("03723458165", "Rodolfinho", 16, equipeCompeticao, competicao);
                criaAtleta("40641653735", "Do", 17, equipeCompeticao, competicao);
                criaAtleta("51458410358", "Junior", 18, equipeCompeticao, competicao);

                criaTreinador("02721281399", "Diogo", equipeCompeticao, competicao);
                criaRepresentante("17220074271", "Emmanuel", equipeCompeticao, competicao);


                // Cria a equipe do Camarões
                equipeCompeticao = criaEquipe("RED", "Leão Vermelhos", competicao);

                // Cria os atletas do Camarões
                criaAtleta("03138834671", "Felipe", 1, equipeCompeticao, competicao);
                criaAtleta("03138326709", "Alvaro", 2, equipeCompeticao, competicao);
                criaAtleta("37183873102", "Rogerio", 3, equipeCompeticao, competicao);
                criaAtleta("10647041669", "Djair", 4, equipeCompeticao, competicao);
                criaAtleta("40830672508", "Nilson", 5, equipeCompeticao, competicao);
                criaAtleta("76427726293", "Song", 6, equipeCompeticao, competicao);
                criaAtleta("48022277525", "Narciso", 7, equipeCompeticao, competicao);
                criaAtleta("23655426461", "Matheus", 8, equipeCompeticao, competicao);
                criaAtleta("04730452143", "Evandro", 9, equipeCompeticao, competicao);
                criaAtleta("35757467614", "Anselomo", 10, equipeCompeticao, competicao);
                criaAtleta("66536670221", "Reinaldo", 11, equipeCompeticao, competicao);

                // Cria a comissão técnica do Camarões
                criaTreinador("22672133115", "Vollu", equipeCompeticao, competicao);
                criaRepresentante("50361627572", "Michel", equipeCompeticao, competicao);


                // Cria a equipe do Croácia
                equipeCompeticao = criaEquipe("MAG", "Margarita Futebol Clube", competicao);

                // Cria os atletas do Croácia
                criaAtleta("06437263733", "Paulo", 1, equipeCompeticao, competicao);
                criaAtleta("75486152809", "Vitinho", 2, equipeCompeticao, competicao);
                criaAtleta("22655751515", "Pirulito", 3, equipeCompeticao, competicao);
                criaAtleta("25335077840", "Seba", 4, equipeCompeticao, competicao);
                criaAtleta("74251577213", "Carlinhos", 5, equipeCompeticao, competicao);
                criaAtleta("03284337644", "Lorenzo", 6, equipeCompeticao, competicao);
                criaAtleta("04854288736", "Rato", 7, equipeCompeticao, competicao);
                criaAtleta("04361866759", "João Paulo", 8, equipeCompeticao, competicao);
                criaAtleta("23533852300", "Matheuzinho", 9, equipeCompeticao, competicao);
                criaAtleta("63243410622", "Guidaum", 10, equipeCompeticao, competicao);
                criaAtleta("38586833029", "Srna", 11, equipeCompeticao, competicao);

                // Cria a comissão técnica do Croácia
                criaTreinador("27401734150", "Niko", equipeCompeticao, competicao);
                criaRepresentante("27145547848", "Kiko", equipeCompeticao, competicao);


                // Cria a equipe do México
                equipeCompeticao = criaEquipe("Fen", "Fenomenautas FC", competicao);

                // Cria os atletas do México
                criaAtleta("88852601368", "Corona", 1, equipeCompeticao, competicao);
                criaAtleta("82582310492", "Rodriguez", 2, equipeCompeticao, competicao);
                criaAtleta("03616318807", "Souza", 3, equipeCompeticao, competicao);
                criaAtleta("63450333321", "Márquez", 4, equipeCompeticao, competicao);
                criaAtleta("18858017420", "Reyes", 5, equipeCompeticao, competicao);
                criaAtleta("03210566712", "Herrera", 6, equipeCompeticao, competicao);
                criaAtleta("61608000869", "Layun", 7, equipeCompeticao, competicao);
                criaAtleta("57526480170", "Fabiano", 8, equipeCompeticao, competicao);
                criaAtleta("81745654186", "Jimenez", 9, equipeCompeticao, competicao);
                criaAtleta("10836704681", "Giovanni Santos", 10, equipeCompeticao, competicao);
                criaAtleta("15408238814", "Pepita", 11, equipeCompeticao, competicao);

                // Cria a comissão técnica do México
                criaTreinador("87075850393", "Miguel", equipeCompeticao, competicao);
                criaRepresentante("15704868320", "Luis", equipeCompeticao, competicao);


                // Cria a equipe do Austrália
                equipeCompeticao = criaEquipe("SJ", "São José FC", competicao);

                // Cria os atletas do Austrália
                criaAtleta("48687235887", "Ryan", 1, equipeCompeticao, competicao);
                criaAtleta("40816614210", "Fransergio", 2, equipeCompeticao, competicao);
                criaAtleta("88027405858", "Davidon", 3, equipeCompeticao, competicao);
                criaAtleta("62784753328", "Caio Martins", 4, equipeCompeticao, competicao);
                criaAtleta("74048031449", "Mil", 5, equipeCompeticao, competicao);
                criaAtleta("80618508180", "Kiko", 6, equipeCompeticao, competicao);
                criaAtleta("47634623180", "Leandro", 7, equipeCompeticao, competicao);
                criaAtleta("76214517425", "Bruno", 8, equipeCompeticao, competicao);
                criaAtleta("81330410157", "Tomas", 9, equipeCompeticao, competicao);
                criaAtleta("40864635125", "Joselito", 10, equipeCompeticao, competicao);
                criaAtleta("17303015337", "Oscar", 11, equipeCompeticao, competicao);

                // Cria a comissão técnica do Austrália
                criaTreinador("66184237160", "Angelo", equipeCompeticao, competicao);
                criaRepresentante("56162856330", "Lula", equipeCompeticao, competicao);


                // Cria a equipe do Chile
                // equipeCompeticao = criaEquipe("Chi", "Chile", competicao);

                // Cria os atletas do Chile
                //criaAtleta("00828557810", "Bravo", 1, equipeCompeticao, competicao);
                //criaAtleta("38263752205", "Mena", 2, equipeCompeticao, competicao);
                //criaAtleta("65771566705", "Albornoz", 3, equipeCompeticao, competicao);
                //criaAtleta("50461231000", "Isla", 4, equipeCompeticao, competicao);
                //criaAtleta("68785273171", "Silva", 5, equipeCompeticao, competicao);
                //criaAtleta("10583610587", "Carmina", 6, equipeCompeticao, competicao);
                //criaAtleta("14681847682", "Sanchez", 7, equipeCompeticao, competicao);
                //criaAtleta("65002760350", "Vidal", 8, equipeCompeticao, competicao);
                //criaAtleta("85576345797", "Pinilla", 9, equipeCompeticao, competicao);
                //criaAtleta("14543783018", "Valdivia", 10, equipeCompeticao, competicao);
                //criaAtleta("77523111467", "Vargas", 11, equipeCompeticao, competicao);

                // Cria a comissão técnica do Chile
                //criaTreinador("87204753496", "Jorge Sampaoli", equipeCompeticao, competicao);
                //criaRepresentante("77736281572", "Michel Temer", equipeCompeticao, competicao);


                // Cria a equipe do Colombia
                //equipeCompeticao = criaEquipe("Col", "Colombia", competicao);

                // Cria os atletas do Colombia
                //criaAtleta("77655517606", "Ospina", 1, equipeCompeticao, competicao);
                //criaAtleta("38757478872", "Zapata", 2, equipeCompeticao, competicao);
                //criaAtleta("03166022643", "Yepes", 3, equipeCompeticao, competicao);
                //criaAtleta("51388164469", "Arias", 4, equipeCompeticao, competicao);
                //criaAtleta("67341348496", "Carbonero", 5, equipeCompeticao, competicao);
                //criaAtleta("34550670347", "Sanchez", 6, equipeCompeticao, competicao);
                //criaAtleta("84524038442", "Armero", 7, equipeCompeticao, competicao);
                //criaAtleta("11576381552", "Aguilar", 8, equipeCompeticao, competicao);
                //criaAtleta("33256713572", "Gutiérrez", 9, equipeCompeticao, competicao);
                //criaAtleta("68377727242", "James", 10, equipeCompeticao, competicao);
                //criaAtleta("21843108593", "Quadrado", 11, equipeCompeticao, competicao);

                //// Cria a comissão técnica do Colombia
                //criaTreinador("28472777570", "José Pékerman", equipeCompeticao, competicao);
                //criaRepresentante("56603530104", "Michel Temer", equipeCompeticao, competicao);


                //// Cria a equipe do Costa do Marfim
                //equipeCompeticao = criaEquipe("CDM", "Costa do Marfim", competicao);

                //// Cria os atletas do Costa do Marfim
                //criaAtleta("02002806004", "Barry", 1, equipeCompeticao, competicao);
                //criaAtleta("85047683842", "Viera", 2, equipeCompeticao, competicao);
                //criaAtleta("61407145320", "Boka", 3, equipeCompeticao, competicao);
                //criaAtleta("08306377532", "K. Touré", 4, equipeCompeticao, competicao);
                //criaAtleta("47056538312", "Zokora", 5, equipeCompeticao, competicao);
                //criaAtleta("07682613254", "Boly", 6, equipeCompeticao, competicao);
                //criaAtleta("27756664426", "Akpa-Akpro", 7, equipeCompeticao, competicao);
                //criaAtleta("02034740238", "Kaliu", 8, equipeCompeticao, competicao);
                //criaAtleta("73101667879", "Tioté", 9, equipeCompeticao, competicao);
                //criaAtleta("01426201575", "Gervinho", 10, equipeCompeticao, competicao);
                //criaAtleta("82823323481", "Droga", 11, equipeCompeticao, competicao);

                // Cria a comissão técnica do Costa do Marfim
                //criaTreinador("13076844083", "Sabri Lamouchi", equipeCompeticao, competicao);
                //criaRepresentante("88268541814", "Michel Temer", equipeCompeticao, competicao);


                //// Cria a equipe do Grécia
                //equipeCompeticao = criaEquipe("Gre", "Grécia", competicao);

                //// Cria os atletas do Grécia
                //criaAtleta("26503783876", "Karnezis", 1, equipeCompeticao, competicao);
                //criaAtleta("36013810877", "Maniatis", 2, equipeCompeticao, competicao);
                //criaAtleta("36075351752", "Tzavelas", 3, equipeCompeticao, competicao);
                //criaAtleta("73854350848", "Manolas", 4, equipeCompeticao, competicao);
                //criaAtleta("51626808007", "Moras", 5, equipeCompeticao, competicao);
                //criaAtleta("16714100841", "Tziolis", 6, equipeCompeticao, competicao);
                //criaAtleta("56621883358", "Samaras", 7, equipeCompeticao, competicao);
                //criaAtleta("52264813300", "Kone", 8, equipeCompeticao, competicao);
                //criaAtleta("48220808110", "Mitroglou", 9, equipeCompeticao, competicao);
                //criaAtleta("21637852207", "Karagounis", 10, equipeCompeticao, competicao);
                //criaAtleta("23335257200", "Vyntra", 11, equipeCompeticao, competicao);

                //// Cria a comissão técnica do Grécia
                //criaTreinador("25014613713", "Fernando Santos", equipeCompeticao, competicao);
                //criaRepresentante("56088252766", "Michel Temer", equipeCompeticao, competicao);

                // Cria os árbitros
                criaArbitro(competicao, "45857133017", "Noumandiez Doué");
                criaArbitro(competicao, "22366188676", "Sandro Ricci");
                criaArbitro(competicao, "75323575034", "Emerson de Carvalho");
                criaArbitro(competicao, "73188654472", "Marcelo Van Gasse");
                criaArbitro(competicao, "65758883565", "Pedro Proença");
                criaArbitro(competicao, "72447750080", "Bertino Miranda");

                MessageBox.Show("Dados de teste criados");

            }).Start();
        }

        public void criaArbitro(Competicao competicao, string cpf, string nome) {
            string myString = "";

            Pessoa arbitro = new Pessoa(cpf, nome, new DateTime(2000, 01, 01));
            arbitro.funcoes = funcoes.FindAll(funcao => funcao.codigo == FuncaoRepositorio.Instance.codigoArbitro);

            PessoaRepositorio.Instance.insert(ref arbitro, ref myString);

            Cargo cargoArbitro = new Cargo(arbitro.id, funcoes.Find(funcao => funcao.codigo.Equals(FuncaoRepositorio.Instance.codigoArbitro)), arbitro);

            CompeticaoRepositorio.Instance.insertArbitro(ref competicao, cargoArbitro);
        }

        public void criaTreinador(string cpf, string nome, EquipeCompeticao equipeCompeticao = null, Competicao competicao = null) {
            string myString = "";

            Pessoa treinador = new Pessoa(cpf, nome, new DateTime(2000, 01, 01));
            treinador.funcoes = funcoes.FindAll(funcao => funcao.codigo == FuncaoRepositorio.Instance.codigoTreinador);

            PessoaRepositorio.Instance.insert(ref treinador, ref myString);

            if ((!(equipeCompeticao is null)) && (!(competicao is null))) {
                Cargo cargoTreinador = new Cargo(treinador.id, funcoes.Find(funcao => funcao.codigo.Equals(FuncaoRepositorio.Instance.codigoTreinador)), treinador);

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


        private void Main_Load(object sender, EventArgs e)
        {

        }
    }
}
