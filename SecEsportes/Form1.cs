using SecEsportes.Modelo;
using SecEsportes.Repositorio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            competicao = new Competicao("Copa do mundo de 2002", new DateTime(2002, 06, 01), modalidade);
            competicao.dataFinal = new DateTime(2002, 07, 01);
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
            criaAtleta("11111111111", "São Marcos", 1, equipeCompeticao, competicao);
            criaAtleta("11111111110", "Cafú", 2, equipeCompeticao, competicao);
            criaAtleta("11111111101", "Lúcio", 3, equipeCompeticao, competicao);
            criaAtleta("11111111011", "Roque Junior", 4, equipeCompeticao, competicao);
            criaAtleta("11111110111", "Edmílson", 5, equipeCompeticao, competicao);

            // Cria a comissão técnica do Brasil
            criaTreinador("22222222222", "Tite", equipeCompeticao, competicao);
            criaRepresentante("22222222220", "Michel Temer", equipeCompeticao, competicao);


            // Cria a equipe do Alemanha
            equipeCompeticao = criaEquipe("Ale", "Alemanha", competicao);

            //Cria as pessoas da Alemanha
            criaAtleta("11111101111", "Oliver Kahn", 1, equipeCompeticao, competicao);
            criaAtleta("11111011111", "Linke", 2, equipeCompeticao, competicao);
            criaAtleta("11110111111", "Ramelow", 3, equipeCompeticao, competicao);
            criaAtleta("11101111111", "Metzelder", 4, equipeCompeticao, competicao);
            criaAtleta("11011111111", "Frings", 5, equipeCompeticao, competicao);

            criaTreinador("33333333333", "Joachim Löw", equipeCompeticao, competicao);
            criaRepresentante("33333333330", "Frank-Walter Steinmeier", equipeCompeticao, competicao);


            // Cria a equipe do Inglaterra
            equipeCompeticao = criaEquipe("Ing", "Inglaterra", competicao);

            // Cria as pessoas da Inglaterra
            criaAtleta("10111101111", "James", 1, equipeCompeticao, competicao);
            criaAtleta("01111111111", "Rio Ferdinand", 2, equipeCompeticao, competicao);
            criaAtleta("21111111111", "Ashley Cole", 3, equipeCompeticao, competicao);
            criaAtleta("12111111111", "Beckham", 4, equipeCompeticao, competicao);
            criaAtleta("11211111111", "Joe Cole", 5, equipeCompeticao, competicao);

            criaTreinador("44444444444", "Gareth Southgate", equipeCompeticao, competicao);
            criaRepresentante("44444444440", "Elizabeth II", equipeCompeticao, competicao);

            
            // Cria a equipe do Japão
            equipeCompeticao = criaEquipe("Jap", "Japão", competicao);

            // Cria as pessoas da Japão
            criaAtleta("11112101111", "Nakamura", 1, equipeCompeticao, competicao);
            criaAtleta("11111121111", "Nagatomo", 2, equipeCompeticao, competicao);
            criaAtleta("11111111211", "Morioka", 3, equipeCompeticao, competicao);
            criaAtleta("11111111112", "Ryota", 4, equipeCompeticao, competicao);
            criaAtleta("11111111113", "Kobayashi", 5, equipeCompeticao, competicao);

            criaTreinador("55555555555", "Akira Nishino", equipeCompeticao, competicao);
            criaRepresentante("55555555550", "Akihito", equipeCompeticao, competicao);


            // Cria a equipe do Argentina
            equipeCompeticao = criaEquipe("Arg", "Argentina", competicao);

            // Cria as pessoas da Argentina
            criaAtleta("11111101131", "Burgos", 1, equipeCompeticao, competicao);
            criaAtleta("11111111311", "Sorin", 2, equipeCompeticao, competicao);
            criaAtleta("11111113111", "Messi", 3, equipeCompeticao, competicao);
            criaAtleta("11111131111", "Crespo", 4, equipeCompeticao, competicao);
            criaAtleta("11111311111", "Simeone", 5, equipeCompeticao, competicao);

            criaTreinador("66666666666", "Jorge Sampaoli", equipeCompeticao, competicao);
            criaRepresentante("66666666660", "Mauricio Macri", equipeCompeticao, competicao);


            // Cria a equipe do Espanha
            equipeCompeticao = criaEquipe("Esp", "Espanha", competicao);

            // Cria as pessoas da Espanha
            criaAtleta("11113101111", "Casillas", 1, equipeCompeticao, competicao);
            criaAtleta("11131111111", "Luque", 2, equipeCompeticao, competicao);
            criaAtleta("11311111111", "Valeron", 3, equipeCompeticao, competicao);
            criaAtleta("13111111111", "Albelda", 4, equipeCompeticao, competicao);
            criaAtleta("31111111111", "Busquets", 5, equipeCompeticao, competicao);

            criaTreinador("77777777777", "Julen Lopetegui", equipeCompeticao, competicao);
            criaRepresentante("77777777770", "Mariano Rajoy", equipeCompeticao, competicao);


            // Cria a equipe do Holanda
            equipeCompeticao = criaEquipe("Hol", "Holanda", competicao);

            // Cria as pessoas da Holanda
            criaAtleta("41111101111", "Van der Sar", 1, equipeCompeticao, competicao);
            criaAtleta("14111111111", "van Dijk", 2, equipeCompeticao, competicao);
            criaAtleta("11411111111", "De Jong", 3, equipeCompeticao, competicao);
            criaAtleta("11141111111", "Robben", 4, equipeCompeticao, competicao);
            criaAtleta("11114111111", "Babel", 5, equipeCompeticao, competicao);

            criaTreinador("88888888888", "Ronald Koeman", equipeCompeticao, competicao);
            criaRepresentante("88888888880", "Guilherme Alexandre", equipeCompeticao, competicao);


            // Cria a equipe do França
            equipeCompeticao = criaEquipe("Fra", "França", competicao);

            // Cria as pessoas da França
            criaAtleta("11111401111", "Ramé", 1, equipeCompeticao, competicao);
            criaAtleta("11111141111", "Vieira", 2, equipeCompeticao, competicao);
            criaAtleta("11111114111", "Zidane", 3, equipeCompeticao, competicao);
            criaAtleta("11111111411", "Henry", 4, equipeCompeticao, competicao);
            criaAtleta("11111111141", "Thuram", 5, equipeCompeticao, competicao);

            criaTreinador("99999999999", "Didier Deschamps", equipeCompeticao, competicao);
            criaRepresentante("99999999990", "Emmanuel Macron", equipeCompeticao, competicao);
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
                Atleta atleta = FuncaoRepositorio.Instance.getAtletas().Find(atletaAEncontrar => atletaAEncontrar.pessoa.cpf.Equals(pessoa.cpf));
                atleta.Numero = numero;
                EquipeRepositorio.Instance.insertAtletaEmEquipe(competicao.id, equipe.id, atleta);
            }            
        }

    }
}
