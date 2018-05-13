﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SecEsportes.Infraestrutura;
using SecEsportes.Modelo;
using System.Linq;
using SecEsportes.Repositorio;
using System.Drawing;

namespace SecEsportes.Views
{
    public partial class ViewCompeticao : Form
    {
        private Utilidades.WindowMode windowMode;
        private Competicao competicao;
        private List<Atleta_List_Artilheiro> artilheiros;
        private string errorMessage = "";

        private Usuario usuarioLogado;

        #region Inicialização da classe
        public ViewCompeticao(Usuario usuarioLogado, Competicao competicao)
        {
            InitializeComponent();

            // Centraliza o form na tela
            CenterToScreen();

            this.usuarioLogado = usuarioLogado;

            this.competicao = competicao;
            this.Text += " - " + competicao.nome;

        }
        #endregion
        private void load(object sender, EventArgs e) {
            lblCompeticao.Text = competicao.nome;

            competicao.partidas = CompeticaoRepositorio.Instance.getPartidasPorCompeticao(competicao.id);

            // Cria as abas das partidas
            tcPartidas.Controls.Clear();
            tcAbas.SelectedTab = tpPartidas;

            int numRodadas = CompeticaoRepositorio.Instance.getNumRodadas(competicao);
            for (int numRodada = 0; numRodada < numRodadas; numRodada++) {
                DataGridView dgvRodadas = CompeticaoViewUtilidades.criaAba("Rodada " + (numRodada + 1).ToString(), numRodada, tcPartidas);
                dgvRodadas.Tag = numRodada + 1;
                dgvRodadas.CellMouseDoubleClick += dgvRodadas_CellMouseDoubleClick;

                List<Competicao_Partida> partidas = competicao.partidas.FindAll(partidasAEncontrar => partidasAEncontrar.rodada == numRodada + 1);
                CompeticaoViewUtilidades.refreshDataGridViewRodadas(dgvRodadas, partidas, competicao, numRodada);
            }

            // Cria as abas das partidas da fase final
            int numAbasAdicionais = 0;
            switch (competicao.mataMata) {
                case MataMataEnum._1_Nao:   numAbasAdicionais = 0;  break;
                case MataMataEnum._2_Final: numAbasAdicionais = 1; break;
                case MataMataEnum._3_SemiFinal: numAbasAdicionais = 2; break;
                case MataMataEnum._4_QuartasFinal: numAbasAdicionais = 3; break;
                case MataMataEnum._5_OitavasFinal: numAbasAdicionais = 4; break;
            }
            // Define o nome da aba e o número da rodada (fase final)
            for (int numAbaAdicional = 0; numAbaAdicional < numAbasAdicionais; numAbaAdicional++) {
                string nomeAba = "";
                int numRodada = 0;
                switch (numAbasAdicionais) {
                    case 1:
                        nomeAba = "Final";
                        numRodada = -1;
                        break;
                    case 2:
                        switch (numAbaAdicional) {
                            case 0:
                                nomeAba = "Semi-Final";
                                numRodada = -2;
                                break;
                            case 1:
                                nomeAba = "Final";
                                numRodada = -1;
                                break;
                        }
                        break;
                    case 3:
                        switch (numAbaAdicional) {
                            case 0:
                                nomeAba = "Quartas de Final";
                                numRodada = -3;
                                break;
                            case 1:
                                nomeAba = "Semi-Final";
                                numRodada = -2;
                                break;
                            case 2:
                                nomeAba = "Final";
                                numRodada = -1;
                                break;
                        }
                        break;
                    case 4:
                        switch (numAbaAdicional) {
                            case 0:
                                nomeAba = "Oitavas de Final";
                                numRodada = -4;
                                break;
                            case 1:
                                nomeAba = "Quartas de Final";
                                numRodada = -3;
                                break;
                            case 2:
                                nomeAba = "Semi-Final";
                                numRodada = -2;
                                break;
                            case 3:
                                nomeAba = "Final";
                                numRodada = -1;
                                break;
                        }
                        break;
                }
                DataGridView dgvRodadas = CompeticaoViewUtilidades.criaAba(nomeAba, numRodada, tcPartidas);
                dgvRodadas.Tag = numRodada;
                dgvRodadas.CellMouseDoubleClick += dgvRodadas_CellMouseDoubleClick;

                List<Competicao_Partida> partidas = competicao.partidas.FindAll(partidasAEncontrar => partidasAEncontrar.rodada == numRodada);

                CompeticaoViewUtilidades.refreshDataGridViewRodadas(dgvRodadas, partidas, competicao, numRodada);
            }


            if (competicao.status == StatusEnum._0_Encerrada)
                btnProximaFase.Enabled = false;
            else
                btnProximaFase.Enabled = true;

            // Cria a abas dos grupos e a classificação
            tcClassificacao.Controls.Clear();
            tcAbas.SelectedTab = tpClassificacao;

            // Seleciona os times até então classificados para a próxima fase
            int numProximaFase = 0;
            int numPartidasASeremGeradas = 0;

            switch (competicao.mataMata) {
                case MataMataEnum._5_OitavasFinal: numProximaFase = -4; numPartidasASeremGeradas = 8; break;
                case MataMataEnum._4_QuartasFinal: numProximaFase = -3; numPartidasASeremGeradas = 4; break;
                case MataMataEnum._3_SemiFinal: numProximaFase = -2; numPartidasASeremGeradas = 2; break;
                case MataMataEnum._2_Final: numProximaFase = -1; numPartidasASeremGeradas = 1; break;
            }

            competicao.equipes = EquipeRepositorio.Instance.getEquipesByCompeticao(competicao.id);
            competicao.grupos = CompeticaoRepositorio.Instance.getGruposPorCompeticao(competicao.id, competicao.equipes);

            List<List<EquipeCompeticao>> timesProximaFase = Utilidades.listaEquipesClassificadas(competicao, numPartidasASeremGeradas, numProximaFase);

            for (int numGrupo = 0; numGrupo < competicao.numGrupos; numGrupo++) {
                DataGridView dgvGrupos = CompeticaoViewUtilidades.criaAba(CompeticaoViewUtilidades.getNomeGrupo(competicao.nomesGrupos, numGrupo + 1), numGrupo, tcClassificacao);

                if (numGrupo < competicao.grupos.Count)
                    CompeticaoViewUtilidades.refreshDataGridViewGrupos(competicao, dgvGrupos, competicao.grupos[numGrupo], timesProximaFase[numGrupo]);
                else
                    CompeticaoViewUtilidades.refreshDataGridViewGrupos(competicao, dgvGrupos, null, null);
            }

            // Cria a aba de artilheiros
            tcAbas.SelectedTab = tpArtilheiros;
            artilheiros = CompeticaoRepositorio.Instance.getArtilheiros(competicao.id);
            refreshDataGridViewArtilheiros(dgvArtilheiros, artilheiros);
            
            // Verifica qual a atual fase da competicao
            if (competicao.status == StatusEnum._0_Encerrada) {
                lblFase.Text = "Campeão: " + competicao.campeao.nome;
            } else {
                string nomeFaseAtual = "";
                switch (competicao.fase_Atual) {
                    case 0: nomeFaseAtual = "Classificatória"; break;
                    case -1: nomeFaseAtual = "Final"; break;
                    case -2: nomeFaseAtual = "Semi-Final"; break;
                    case -3: nomeFaseAtual = "Quartas de Final"; break;
                    case -4: nomeFaseAtual = "Oitava de Final"; break;
                    case -5: nomeFaseAtual = "16 avos de Final"; break;
                    case -6: nomeFaseAtual = "32 avos de Final"; break;
                }
                lblFase.Text = "Fase atual: " + nomeFaseAtual;
            }

            tcAbas.SelectedIndex = 0;

        }

        private void vamosver(Competicao competicao, DataGridView dgvGrupo, List<EquipeCompeticao> dataSource, List<EquipeCompeticao> timesProximaFase) {
            dgvGrupo.DataSource = null;
            dgvGrupo.Refresh();

            dgvGrupo.Columns.Clear();

            if (!(dataSource is null)) {
                dataSource = (from customDS in dataSource
                              orderby customDS.pontos descending, customDS.vitorias descending, customDS.golsPro - customDS.golsContra descending
                              select customDS).ToList<EquipeCompeticao>();
            }

            dgvGrupo.DataSource = dataSource;

            if (!(dataSource is null)) {
                dgvGrupo.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = nameof(EquipeCompeticao.codigo) });
                dgvGrupo.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = nameof(EquipeCompeticao.nome) });
                dgvGrupo.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = nameof(EquipeCompeticao.pontos) });
                dgvGrupo.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = nameof(EquipeCompeticao.vitorias) });
                dgvGrupo.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = nameof(EquipeCompeticao.empates) });
                dgvGrupo.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = nameof(EquipeCompeticao.derrotas) });
                dgvGrupo.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = nameof(EquipeCompeticao.golsPro) });
                dgvGrupo.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = nameof(EquipeCompeticao.golsContra) });

                dgvGrupo.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = "SaldoGols" });
                dgvGrupo.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = "NumPartidas" });
                dgvGrupo.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = "Aproveitamento" });
            }

            for (int iCount = 0; iCount < dgvGrupo.Columns.Count; iCount++) {
                switch (dgvGrupo.Columns[iCount].DataPropertyName) {
                    case nameof(EquipeCompeticao.codigo):
                        dgvGrupo.Columns[iCount].HeaderText = "Código";
                        dgvGrupo.Columns[iCount].Name = dgvGrupo.Columns[iCount].DataPropertyName;
                        dgvGrupo.Columns[iCount].DisplayIndex = 0;
                        break;
                    case nameof(EquipeCompeticao.nome):
                        dgvGrupo.Columns[iCount].HeaderText = "Nome da equipe";
                        dgvGrupo.Columns[iCount].Name = dgvGrupo.Columns[iCount].DataPropertyName;
                        dgvGrupo.Columns[iCount].DisplayIndex = 1;
                        break;
                    case nameof(EquipeCompeticao.pontos):
                        dgvGrupo.Columns[iCount].HeaderText = "Pts.";
                        dgvGrupo.Columns[iCount].Name = dgvGrupo.Columns[iCount].DataPropertyName;
                        dgvGrupo.Columns[iCount].Width = 50;
                        dgvGrupo.Columns[iCount].DisplayIndex = 2;
                        break;
                    case "NumPartidas":
                        dgvGrupo.Columns[iCount].HeaderText = "Partidas";
                        dgvGrupo.Columns[iCount].Name = dgvGrupo.Columns[iCount].DataPropertyName;
                        dgvGrupo.Columns[iCount].Width = 40;
                        dgvGrupo.Columns[iCount].DisplayIndex = 3;
                        break;
                    case nameof(EquipeCompeticao.vitorias):
                        dgvGrupo.Columns[iCount].HeaderText = "V";
                        dgvGrupo.Columns[iCount].Name = dgvGrupo.Columns[iCount].DataPropertyName;
                        dgvGrupo.Columns[iCount].Width = 40;
                        dgvGrupo.Columns[iCount].DisplayIndex = 4;
                        break;
                    case nameof(EquipeCompeticao.empates):
                        dgvGrupo.Columns[iCount].HeaderText = "E";
                        dgvGrupo.Columns[iCount].Name = dgvGrupo.Columns[iCount].DataPropertyName;
                        dgvGrupo.Columns[iCount].Width = 40;
                        dgvGrupo.Columns[iCount].DisplayIndex = 5;
                        break;
                    case nameof(EquipeCompeticao.derrotas):
                        dgvGrupo.Columns[iCount].HeaderText = "D";
                        dgvGrupo.Columns[iCount].Name = dgvGrupo.Columns[iCount].DataPropertyName;
                        dgvGrupo.Columns[iCount].Width = 40;
                        dgvGrupo.Columns[iCount].DisplayIndex = 6;
                        break;
                    case nameof(EquipeCompeticao.golsPro):
                        dgvGrupo.Columns[iCount].HeaderText = "GP";
                        dgvGrupo.Columns[iCount].Name = dgvGrupo.Columns[iCount].DataPropertyName;
                        dgvGrupo.Columns[iCount].Width = 40;
                        dgvGrupo.Columns[iCount].DisplayIndex = 7;
                        break;
                    case nameof(EquipeCompeticao.golsContra):
                        dgvGrupo.Columns[iCount].HeaderText = "GC";
                        dgvGrupo.Columns[iCount].Name = dgvGrupo.Columns[iCount].DataPropertyName;
                        dgvGrupo.Columns[iCount].Width = 40;
                        dgvGrupo.Columns[iCount].DisplayIndex = 8;
                        break;
                    case "SaldoGols":
                        dgvGrupo.Columns[iCount].HeaderText = "SG";
                        dgvGrupo.Columns[iCount].Name = dgvGrupo.Columns[iCount].DataPropertyName;
                        dgvGrupo.Columns[iCount].Width = 40;
                        dgvGrupo.Columns[iCount].DisplayIndex = 9;
                        break;
                    case "Aproveitamento":
                        dgvGrupo.Columns[iCount].HeaderText = " %";
                        dgvGrupo.Columns[iCount].Name = dgvGrupo.Columns[iCount].DataPropertyName;
                        dgvGrupo.Columns[iCount].Width = 50;
                        dgvGrupo.Columns[iCount].DisplayIndex = 10;
                        break;
                    default:
                        dgvGrupo.Columns[iCount].Visible = false;
                        break;
                }
            }

            // Pinta de negrito as equipes classificadas
            DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle(dgvGrupo.DefaultCellStyle);
            dataGridViewCellStyle.Font = new Font(dgvGrupo.Font, FontStyle.Bold);

            //Preenche os campos que vieram sem preenchimento do data set
            for (int iCount = 0; iCount < dgvGrupo.Rows.Count; iCount++) {
                dgvGrupo.Rows[iCount].Cells["NumPartidas"].Value = 5;

                dgvGrupo.Rows[iCount].Cells["SaldoGols"].Value = dataSource[iCount].golsPro - dataSource[iCount].golsContra;

                if (dataSource[iCount].vitorias + dataSource[iCount].derrotas + dataSource[iCount].empates > 0)
                    dgvGrupo.Rows[iCount].Cells["Aproveitamento"].Value = dataSource[iCount].pontos * 100 / ((dataSource[iCount].vitorias + dataSource[iCount].derrotas + dataSource[iCount].empates) * 3);
                else
                    dgvGrupo.Rows[iCount].Cells["Aproveitamento"].Value = 0;

                // Pinta as equipes que irão se classificar
                if (!(timesProximaFase is null)) {
                    if (timesProximaFase.Contains(dataSource[iCount])) {
                        dgvGrupo.Rows[iCount].DefaultCellStyle = dataGridViewCellStyle;
                    }
                }
            }

            dgvGrupo.Refresh();
        }

        private void dgvRodadas_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e) {
            if (e.RowIndex > -1) {
                int numRodada;
                numRodada = Convert.ToInt32(((DataGridView)sender).Tag);
                List<Competicao_Partida> partidas = competicao.partidas.FindAll(partidasAEncontrar => partidasAEncontrar.rodada == numRodada);
                Competicao_Partida partida = partidas[e.RowIndex];

                ViewPartida viewPartida = new ViewPartida(usuarioLogado, competicao, partida);
                viewPartida.Tag = new List<Object>() { (DataGridView)sender, partidas };
                viewPartida.FormClosing += viewPartida_FormClosing;
                viewPartida.ShowDialog();
            }
        }

        private void viewPartida_FormClosing(object sender, FormClosingEventArgs e) {
            DataGridView dgvRodadas = (DataGridView)((List<Object>)((ViewPartida)sender).Tag)[0];
            List<Competicao_Partida> partidas = (List<Competicao_Partida>)((List<Object>)((ViewPartida)sender).Tag)[1];

            load(null, null);
        }

        private static void refreshDataGridViewArtilheiros(DataGridView dgvArtilheiros, List<Atleta_List_Artilheiro> artilheiros) {
            dgvArtilheiros.DataSource = null;
            dgvArtilheiros.Refresh();

            dgvArtilheiros.Columns.Clear();

            dgvArtilheiros.DataSource = artilheiros;

            if (!(artilheiros is null)) {
                dgvArtilheiros.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = nameof(Atleta_List_Artilheiro.nome_Atleta) });
                dgvArtilheiros.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = nameof(Atleta_List_Artilheiro.nome_Equipe) });
                dgvArtilheiros.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = nameof(Atleta_List_Artilheiro.num_Gols) });
                dgvArtilheiros.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = nameof(Atleta_List_Artilheiro.num_Partidas) });
                dgvArtilheiros.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = nameof(Atleta_List_Artilheiro.media) });
            }

            for (int iCount = 0; iCount < dgvArtilheiros.Columns.Count; iCount++) {
                switch (dgvArtilheiros.Columns[iCount].DataPropertyName) {
                    case nameof(Atleta_List_Artilheiro.nome_Atleta):
                        dgvArtilheiros.Columns[iCount].HeaderText = "Atleta";
                        dgvArtilheiros.Columns[iCount].Name = dgvArtilheiros.Columns[iCount].DataPropertyName;
                        dgvArtilheiros.Columns[iCount].DisplayIndex = 0;
                        dgvArtilheiros.Columns[iCount].Width = 150;
                        break;
                    case nameof(Atleta_List_Artilheiro.nome_Equipe):
                        dgvArtilheiros.Columns[iCount].HeaderText = "Equipe";
                        dgvArtilheiros.Columns[iCount].Name = dgvArtilheiros.Columns[iCount].DataPropertyName;
                        dgvArtilheiros.Columns[iCount].DisplayIndex = 1;
                        dgvArtilheiros.Columns[iCount].Width = 100;
                        break;
                    case nameof(Atleta_List_Artilheiro.num_Gols):
                        dgvArtilheiros.Columns[iCount].HeaderText = "Gols";
                        dgvArtilheiros.Columns[iCount].Name = dgvArtilheiros.Columns[iCount].DataPropertyName;
                        dgvArtilheiros.Columns[iCount].DisplayIndex = 2;
                        dgvArtilheiros.Columns[iCount].Width = 50;
                        break;
                    case nameof(Atleta_List_Artilheiro.num_Partidas):
                        dgvArtilheiros.Columns[iCount].HeaderText = "Jogos";
                        dgvArtilheiros.Columns[iCount].Name = dgvArtilheiros.Columns[iCount].DataPropertyName;
                        dgvArtilheiros.Columns[iCount].DisplayIndex = 3;
                        dgvArtilheiros.Columns[iCount].Width = 40;
                        break;
                    case nameof(Atleta_List_Artilheiro.media):
                        dgvArtilheiros.Columns[iCount].HeaderText = "Média";
                        dgvArtilheiros.Columns[iCount].Name = dgvArtilheiros.Columns[iCount].DataPropertyName;
                        dgvArtilheiros.Columns[iCount].DisplayIndex = 4;
                        dgvArtilheiros.Columns[iCount].Width = 50;
                        break;
                    default:
                        dgvArtilheiros.Columns[iCount].Visible = false;
                        break;
                }
            }

            dgvArtilheiros.Refresh();
        }

        private void btnProximaFase_Click(object sender, EventArgs e) {
            int numPartidasRestantes;
            if (competicao.fase_Atual == 0) {
                numPartidasRestantes = competicao.partidas.FindAll(partidas => partidas.encerrada == false && partidas.rodada > competicao.fase_Atual).Count;
            } else {
                numPartidasRestantes = competicao.partidas.FindAll(partidas => partidas.encerrada == false && partidas.rodada == competicao.fase_Atual).Count;
            }

            if (numPartidasRestantes > 0) {
                MessageBox.Show("Por favor verifique" + Environment.NewLine + Environment.NewLine +
                    "Existem ainda " + numPartidasRestantes + " partidas que não foram encerradas nesta fase.",
                    "Não foi possível avançar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else {
                int numProximaFase = 0;
                int numPartidasASeremGeradas = 0;

                // Caso a fase atual seja a fase classificatória
                if (competicao.fase_Atual >= 0) {
                    switch (competicao.mataMata) {
                        case MataMataEnum._5_OitavasFinal: numProximaFase = -4; numPartidasASeremGeradas = 8; break;
                        case MataMataEnum._4_QuartasFinal: numProximaFase = -3; numPartidasASeremGeradas = 4; break;
                        case MataMataEnum._3_SemiFinal: numProximaFase = -2; numPartidasASeremGeradas = 2; break;
                        case MataMataEnum._2_Final: numProximaFase = -1; numPartidasASeremGeradas = 1; break;
                    }

                    // O campeonato é só por pontos corridos
                    if ( (competicao.mataMata == MataMataEnum._1_Nao) && (competicao.grupos.Count == 1) ) {
                        competicao.status = StatusEnum._0_Encerrada;

                        EquipeCompeticao campeao = (from proximaFase in competicao.grupos[0]
                                                    orderby proximaFase.pontos descending, proximaFase.vitorias descending, proximaFase.golsPro - proximaFase.golsContra descending
                                                    select proximaFase).ToList<EquipeCompeticao>().First();

                        competicao.campeao = campeao;
                        competicao.id_Campeao = campeao.id;
                        CompeticaoRepositorio.Instance.update(competicao);
                    } else {
                        int numTimesPorGrupo = 0, numTimesRestantes = 0;
                        List<List<EquipeCompeticao>> timesProximaFase = Utilidades.listaEquipesClassificadas(competicao, numPartidasASeremGeradas, numProximaFase, ref numTimesRestantes, ref numTimesPorGrupo);
                        Utilidades.criaPartidasProximaFase(ref competicao, timesProximaFase, numPartidasASeremGeradas, numTimesRestantes, numTimesPorGrupo , numProximaFase);

                        // Cria as partidas de volta da fase final
                        if (competicao.jogosIdaEVolta_MataMata) {
                            List<Competicao_Partida> partidasIda = competicao.partidas.FindAll(partidasIdaAEncontrar => partidasIdaAEncontrar.rodada == numProximaFase);
                            for (int numPartidaVolta = 0; numPartidaVolta < partidasIda.Count; numPartidaVolta++) {
                                Competicao_Partida partidaDeVolta = new Competicao_Partida(partidasIda[numPartidaVolta].equipe2, partidasIda[numPartidaVolta].equipe1, numProximaFase, partidasIda[numPartidaVolta].numGrupo);
                                CompeticaoRepositorio.Instance.insertPartida(ref competicao, partidaDeVolta);
                            }
                        }
                    }
                } else {
                    // Neste caso, a fase atual já é uma das fases finais

                    numProximaFase = competicao.fase_Atual + 1;

                    // Define os times que vão para a próxima fase
                    List<List<EquipeCompeticao>> timesProximaFase = new List<List<EquipeCompeticao>>();
                    List<EquipeCompeticao> timesClassificadosFaseAnterior = new List<EquipeCompeticao>();

                    List<Competicao_Partida> partidasFaseAnterior = new List<Competicao_Partida>();
                    partidasFaseAnterior = competicao.partidas.FindAll(partidasFinalizadas => partidasFinalizadas.encerrada == true && partidasFinalizadas.rodada == competicao.fase_Atual);

                    // Define os classificados
                    for (int iCount = 0; iCount < partidasFaseAnterior.Count; iCount++) {
                        Competicao_Partida partidaFaseAnterior = partidasFaseAnterior[iCount];
                        EquipeCompeticao equipeVencedora = null;

                        int golsEquipe1, golsEquipe2;
                        if (competicao.jogosIdaEVolta_MataMata) {
                            if (iCount < partidasFaseAnterior.Count / 2) {
                                Competicao_Partida partidaDeVoltaFaseAnterior = partidasFaseAnterior.FindAll(x => x.numGrupo == partidaFaseAnterior.numGrupo && x.rodada == partidaFaseAnterior.rodada).Last();

                                golsEquipe1 = partidaFaseAnterior.eventos.FindAll(eventosAEncontrar => eventosAEncontrar.tpEvento.Equals(tpEventoEnum.Gol) && eventosAEncontrar.equipe.id == partidaFaseAnterior.equipe1.id).Count;
                                golsEquipe2 = partidaFaseAnterior.eventos.FindAll(eventosAEncontrar => eventosAEncontrar.tpEvento.Equals(tpEventoEnum.Gol) && eventosAEncontrar.equipe.id == partidaFaseAnterior.equipe2.id).Count;

                                golsEquipe1 += partidaDeVoltaFaseAnterior.eventos.FindAll(eventosAEncontrar => eventosAEncontrar.tpEvento.Equals(tpEventoEnum.Gol) && eventosAEncontrar.equipe.id == partidaFaseAnterior.equipe1.id).Count;
                                golsEquipe2 += partidaDeVoltaFaseAnterior.eventos.FindAll(eventosAEncontrar => eventosAEncontrar.tpEvento.Equals(tpEventoEnum.Gol) && eventosAEncontrar.equipe.id == partidaFaseAnterior.equipe2.id).Count;

                                // Verifica se a partida empatou e foi para os penaltis
                                if (golsEquipe1 == golsEquipe2) {
                                    int golsPenaltiEquipe1, golsPenaltiEquipe2;
                                    golsPenaltiEquipe1 = partidaDeVoltaFaseAnterior.eventos.FindAll(eventosAEncontrar => eventosAEncontrar.tpEvento.Equals(tpEventoEnum.Gol_Penalti) && eventosAEncontrar.equipe.id == partidasFaseAnterior[iCount].equipe1.id).Count;
                                    golsPenaltiEquipe2 = partidaDeVoltaFaseAnterior.eventos.FindAll(eventosAEncontrar => eventosAEncontrar.tpEvento.Equals(tpEventoEnum.Gol_Penalti) && eventosAEncontrar.equipe.id == partidasFaseAnterior[iCount].equipe2.id).Count;

                                    if (golsPenaltiEquipe1 > golsPenaltiEquipe2) {
                                        equipeVencedora = partidaFaseAnterior.equipe1;
                                    } else {if (golsPenaltiEquipe2 > golsPenaltiEquipe1) {
                                            equipeVencedora = partidaFaseAnterior.equipe2;
                                        }
                                    }
                                } else {
                                    // Não empatou
                                    if (golsEquipe1 > golsEquipe2) {
                                        equipeVencedora = partidaFaseAnterior.equipe1;
                                    } else {if (golsEquipe2 > golsEquipe1) {
                                            equipeVencedora = partidaFaseAnterior.equipe2;
                                        }
                                    }
                                }

                                timesClassificadosFaseAnterior.Add(equipeVencedora);

                            }
                        } else {
                            // Verifica o vencedor
                            golsEquipe1 = partidaFaseAnterior.eventos.FindAll(eventosAEncontrar => eventosAEncontrar.tpEvento.Equals(tpEventoEnum.Gol) && eventosAEncontrar.equipe.id == partidasFaseAnterior[iCount].equipe1.id).Count;
                            golsEquipe2 = partidaFaseAnterior.eventos.FindAll(eventosAEncontrar => eventosAEncontrar.tpEvento.Equals(tpEventoEnum.Gol) && eventosAEncontrar.equipe.id == partidasFaseAnterior[iCount].equipe2.id).Count;

                            // Verifica se a partida empatou e foi para os penaltis
                            if (golsEquipe1 == golsEquipe2) {
                                int golsPenaltiEquipe1, golsPenaltiEquipe2;
                                golsPenaltiEquipe1 = partidaFaseAnterior.eventos.FindAll(eventosAEncontrar => eventosAEncontrar.tpEvento.Equals(tpEventoEnum.Gol_Penalti) && eventosAEncontrar.equipe.id == partidasFaseAnterior[iCount].equipe1.id).Count;
                                golsPenaltiEquipe2 = partidaFaseAnterior.eventos.FindAll(eventosAEncontrar => eventosAEncontrar.tpEvento.Equals(tpEventoEnum.Gol_Penalti) && eventosAEncontrar.equipe.id == partidasFaseAnterior[iCount].equipe2.id).Count;

                                if (golsPenaltiEquipe1 > golsPenaltiEquipe2) {
                                    equipeVencedora = partidaFaseAnterior.equipe1;
                                } else {if (golsPenaltiEquipe2 > golsPenaltiEquipe1) {
                                        equipeVencedora = partidaFaseAnterior.equipe2;
                                    }
                                }
                            } else {
                                // Não empatou
                                if (golsEquipe1 > golsEquipe2) {
                                    equipeVencedora = partidaFaseAnterior.equipe1;
                                } else {if (golsEquipe2 > golsEquipe1) {
                                        equipeVencedora = partidaFaseAnterior.equipe2;
                                    }
                                }
                            }

                            timesClassificadosFaseAnterior.Add(equipeVencedora);
                        }
                    }

                    int numPartidasASeremGeradasProximaFase = 0;

                    // Faz a criação das partidas
                    Competicao_Partida partida;
                    EquipeCompeticao equipe1, equipe2;
                    switch (numProximaFase) {
                        case -1: // Final
                            numPartidasASeremGeradasProximaFase = 1;

                            equipe1 = timesClassificadosFaseAnterior[0];    equipe2 = timesClassificadosFaseAnterior[1];
                            partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 1);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                            break;
                        case -2: // Semi-Final
                            equipe1 = timesClassificadosFaseAnterior[0]; equipe2 = timesClassificadosFaseAnterior[1];
                            partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 1);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                            equipe1 = timesClassificadosFaseAnterior[2]; equipe2 = timesClassificadosFaseAnterior[3];
                            partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 2);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                            numPartidasASeremGeradasProximaFase = 2;
                            break;
                        case -3: // Quartas de Final
                            equipe1 = timesClassificadosFaseAnterior[0]; equipe2 = timesClassificadosFaseAnterior[1];
                            partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 1);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                            equipe1 = timesClassificadosFaseAnterior[2]; equipe2 = timesClassificadosFaseAnterior[3];
                            partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 2);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                            equipe1 = timesClassificadosFaseAnterior[4]; equipe2 = timesClassificadosFaseAnterior[5];
                            partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 3);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                            equipe1 = timesClassificadosFaseAnterior[6]; equipe2 = timesClassificadosFaseAnterior[7];
                            partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 4);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                            numPartidasASeremGeradasProximaFase = 4;
                            break;
                    }

                    // Cria as partidas de volta da fase final
                    if (competicao.jogosIdaEVolta_MataMata) {
                        List<Competicao_Partida> partidasIda = competicao.partidas.FindAll(partidasIdaAEncontrar => partidasIdaAEncontrar.rodada == numProximaFase);
                        for (int numPartidaVolta = 0; numPartidaVolta < partidasIda.Count; numPartidaVolta++) {
                            Competicao_Partida partidaDeVolta = new Competicao_Partida(partidasIda[numPartidaVolta].equipe2, partidasIda[numPartidaVolta].equipe1, numProximaFase, partidasIda[numPartidaVolta].numGrupo);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partidaDeVolta);
                        }
                    }
                }

                competicao.fase_Atual = numProximaFase;
                CompeticaoRepositorio.Instance.update(competicao);

                load(null, null);
            }
        }

        private void btnGerarHTML_Classificacao_Click(object sender, EventArgs e) {
            // Seleciona os times até então classificados para a próxima fase
            int numProximaFase = 0;
            int numPartidasASeremGeradas = 0;

            switch (competicao.mataMata) {
                case MataMataEnum._5_OitavasFinal: numProximaFase = -4; numPartidasASeremGeradas = 8; break;
                case MataMataEnum._4_QuartasFinal: numProximaFase = -3; numPartidasASeremGeradas = 4; break;
                case MataMataEnum._3_SemiFinal: numProximaFase = -2; numPartidasASeremGeradas = 2; break;
                case MataMataEnum._2_Final: numProximaFase = -1; numPartidasASeremGeradas = 1; break;
            }

            competicao.equipes = EquipeRepositorio.Instance.getEquipesByCompeticao(competicao.id);
            competicao.grupos = CompeticaoRepositorio.Instance.getGruposPorCompeticao(competicao.id, competicao.equipes);

            List<List<EquipeCompeticao>> timesProximaFase = Utilidades.listaEquipesClassificadas(competicao, numPartidasASeremGeradas, numProximaFase);

            RelatorioHTML.relatorioGrupos(competicao, false, timesProximaFase);

        }

        private void btnGerarHTML_Artilheiros_Click(object sender, EventArgs e) {
            RelatorioHTML.relatorioArtilheiros(competicao, artilheiros, false);
        }
    }
}