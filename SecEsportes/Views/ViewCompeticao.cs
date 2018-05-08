using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SecEsportes.Infraestrutura;
using SecEsportes.Modelo;
using System.Linq;
using SecEsportes.Repositorio;

namespace SecEsportes.Views
{
    public partial class ViewCompeticao : Form
    {
        private Utilidades.WindowMode windowMode;
        private Competicao competicao;
        private List<Atleta_List_Artilheiro> artilheiros;
        private string errorMessage = "";

        #region Inicialização da classe
        public ViewCompeticao(Competicao competicao)
        {
            InitializeComponent();

            // Centraliza o form na tela
            CenterToScreen();

            this.competicao = competicao;
            this.Text += " - " + competicao.nome;

        }
        #endregion

        private void load(object sender, EventArgs e) {
            lblCompeticao.Text = competicao.nome;

            // Cria as abas das partidas
            tcPartidas.Controls.Clear();
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
            for (int numGrupo = 0; numGrupo < competicao.numGrupos; numGrupo++) {
                DataGridView dgvGrupos = CompeticaoViewUtilidades.criaAba(CompeticaoViewUtilidades.getNomeGrupo(competicao.nomesGrupos, numGrupo + 1), numGrupo, tcClassificacao);

                if (numGrupo < competicao.grupos.Count)
                    CompeticaoViewUtilidades.refreshDataGridViewGrupos(dgvGrupos, competicao.grupos[numGrupo]);
                else
                    CompeticaoViewUtilidades.refreshDataGridViewGrupos(dgvGrupos, null);
            }

            // Cria a aba de artilheiros
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
        }

        private void dgvRodadas_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e) {
            if (e.RowIndex > -1) {
                int numRodada;
                numRodada = Convert.ToInt32(((DataGridView)sender).Tag);
                List<Competicao_Partida> partidas = competicao.partidas.FindAll(partidasAEncontrar => partidasAEncontrar.rodada == numRodada);
                Competicao_Partida partida = partidas[e.RowIndex];

                ViewPartida viewPartida = new ViewPartida(competicao, partida);
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

        private static void refreshDataGridViewArtilheiros(DataGridView dataGridView, List<Atleta_List_Artilheiro> artilheiros) {
            dataGridView.DataSource = null;
            dataGridView.Refresh();

            dataGridView.Columns.Clear();

            dataGridView.DataSource = artilheiros;

            if (!(artilheiros is null)) {
                dataGridView.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = nameof(Atleta_List_Artilheiro.nome_Atleta) });
                dataGridView.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = nameof(Atleta_List_Artilheiro.nome_Equipe) });
                dataGridView.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = nameof(Atleta_List_Artilheiro.num_Gols) });
                dataGridView.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = nameof(Atleta_List_Artilheiro.num_Partidas) });
                dataGridView.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = nameof(Atleta_List_Artilheiro.media) });
            }

            for (int iCount = 0; iCount < dataGridView.Columns.Count; iCount++) {
                switch (dataGridView.Columns[iCount].DataPropertyName) {
                    case nameof(Atleta_List_Artilheiro.nome_Atleta):
                        dataGridView.Columns[iCount].HeaderText = "Atleta";
                        dataGridView.Columns[iCount].Name = dataGridView.Columns[iCount].DataPropertyName;
                        dataGridView.Columns[iCount].DisplayIndex = 0;
                        break;
                    case nameof(Atleta_List_Artilheiro.nome_Equipe):
                        dataGridView.Columns[iCount].HeaderText = "Equipe";
                        dataGridView.Columns[iCount].Name = dataGridView.Columns[iCount].DataPropertyName;
                        dataGridView.Columns[iCount].DisplayIndex = 1;
                        break;
                    case nameof(Atleta_List_Artilheiro.num_Gols):
                        dataGridView.Columns[iCount].HeaderText = "Gols";
                        dataGridView.Columns[iCount].Name = dataGridView.Columns[iCount].DataPropertyName;
                        dataGridView.Columns[iCount].DisplayIndex = 2;
                        break;
                    case nameof(Atleta_List_Artilheiro.num_Partidas):
                        dataGridView.Columns[iCount].HeaderText = "Jogos";
                        dataGridView.Columns[iCount].Name = dataGridView.Columns[iCount].DataPropertyName;
                        dataGridView.Columns[iCount].DisplayIndex = 3;
                        break;
                    case nameof(Atleta_List_Artilheiro.media):
                        dataGridView.Columns[iCount].HeaderText = "Média";
                        dataGridView.Columns[iCount].Name = dataGridView.Columns[iCount].DataPropertyName;
                        dataGridView.Columns[iCount].DisplayIndex = 4;
                        break;
                    default:
                        dataGridView.Columns[iCount].Visible = false;
                        break;
                }
            }

            //Preenche os campos que vieram sem preenchimento do data set
            for (int iCount = 0; iCount < dataGridView.Rows.Count; iCount++) {
                //dataGridView.Rows[iCount].Cells["NomeAtleta"].Value = artilheiros[iCount].atleta.numero + " - " + artilheiros[iCount].atleta.pessoa.nome;
                //if (artilheiros[iCount].num_Partidas > 0)
                //    dataGridView.Rows[iCount].Cells["Media"].Value = Convert.ToDouble(artilheiros[iCount].num_Gols / artilheiros[iCount].num_Partidas);
                //else
                //    dataGridView.Rows[iCount].Cells["Media"].Value = "";
            }

            dataGridView.Refresh();
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
                        int numTimesPorGrupo, numTimesRestantes;
                        numTimesPorGrupo = (numPartidasASeremGeradas * 2) / competicao.numGrupos;
                        numTimesRestantes = (numPartidasASeremGeradas * 2) % numTimesPorGrupo;

                        // Define os times que vão para a próxima fase
                        List<List<EquipeCompeticao>> timesProximaFase = new List<List<EquipeCompeticao>>();
                        for (int numGrupo = 0; numGrupo < competicao.numGrupos; numGrupo++) {
                            timesProximaFase.Add(new List<EquipeCompeticao>());

                            timesProximaFase[numGrupo] = new List<EquipeCompeticao>();
                            timesProximaFase[numGrupo] = (from proximaFase in competicao.grupos[numGrupo]
                                                          orderby proximaFase.pontos descending, proximaFase.vitorias descending, proximaFase.golsPro - proximaFase.golsContra descending
                                                          select proximaFase).ToList<EquipeCompeticao>();

                            timesProximaFase[numGrupo].RemoveRange(numTimesPorGrupo, timesProximaFase[numGrupo].Count - numTimesPorGrupo);

                        }

                        // Faz a criação das partidas da fase final
                        Competicao_Partida partida;
                        EquipeCompeticao equipe1, equipe2;

                        switch (numPartidasASeremGeradas) {
                            case 2: // Semi final
                                if (numTimesRestantes == 0) {
                                    if (numTimesPorGrupo == 1) {
                                        equipe1 = timesProximaFase[0][0]; equipe2 = timesProximaFase[1][0]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 1);
                                        CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                                        equipe1 = timesProximaFase[2][0]; equipe2 = timesProximaFase[3][0]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 2);
                                        CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);
                                    }
                                    if (numTimesPorGrupo == 2) {
                                        equipe1 = timesProximaFase[0][0]; equipe2 = timesProximaFase[1][1]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 1);
                                        CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                                        equipe1 = timesProximaFase[0][1]; equipe2 = timesProximaFase[1][0]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 2);
                                        CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);
                                    }
                                    if (numTimesPorGrupo == 4) {
                                        equipe1 = timesProximaFase[0][0]; equipe2 = timesProximaFase[0][3]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 1);
                                        CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                                        equipe1 = timesProximaFase[0][1]; equipe2 = timesProximaFase[0][2]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 2);
                                        CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);
                                    }
                                }
                                break;
                            case 4: // Quartas de final
                                if (numTimesRestantes == 0) {
                                    if (numTimesPorGrupo == 1) {
                                        equipe1 = timesProximaFase[0][0]; equipe2 = timesProximaFase[1][0]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 1);
                                        CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                                        equipe1 = timesProximaFase[2][0]; equipe2 = timesProximaFase[3][0]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 2);
                                        CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                                        equipe1 = timesProximaFase[4][0]; equipe2 = timesProximaFase[5][0]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 3);
                                        CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                                        equipe1 = timesProximaFase[6][0]; equipe2 = timesProximaFase[7][0]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 4);
                                        CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);
                                    }
                                    if (numTimesPorGrupo == 2) {
                                        equipe1 = timesProximaFase[0][0]; equipe2 = timesProximaFase[1][1]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 1);
                                        CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                                        equipe1 = timesProximaFase[0][1]; equipe2 = timesProximaFase[1][0]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 2);
                                        CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                                        equipe1 = timesProximaFase[2][0]; equipe2 = timesProximaFase[3][1]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 3);
                                        CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                                        equipe1 = timesProximaFase[2][1]; equipe2 = timesProximaFase[3][0]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 4);
                                        CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);
                                    }
                                    if (numTimesPorGrupo == 4) {
                                        equipe1 = timesProximaFase[0][0]; equipe2 = timesProximaFase[1][3]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 1);
                                        CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                                        equipe1 = timesProximaFase[1][0]; equipe2 = timesProximaFase[0][3]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 2);
                                        CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                                        equipe1 = timesProximaFase[0][1]; equipe2 = timesProximaFase[1][2]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 3);
                                        CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                                        equipe1 = timesProximaFase[0][2]; equipe2 = timesProximaFase[1][1]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 4);
                                        CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);
                                    }
                                }
                                break;
                            case 8:
                                if (numTimesRestantes == 0) {
                                    if (numTimesPorGrupo == 1) {
                                        equipe1 = timesProximaFase[0][0]; equipe2 = timesProximaFase[1][0]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 1);
                                        CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                                        equipe1 = timesProximaFase[2][0]; equipe2 = timesProximaFase[3][0]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 2);
                                        CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                                        equipe1 = timesProximaFase[4][0]; equipe2 = timesProximaFase[5][0]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 3);
                                        CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                                        equipe1 = timesProximaFase[6][0]; equipe2 = timesProximaFase[7][0]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 4);
                                        CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                                        equipe1 = timesProximaFase[8][0]; equipe2 = timesProximaFase[9][0]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 5);
                                        CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                                        equipe1 = timesProximaFase[10][0]; equipe2 = timesProximaFase[11][0]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 6);
                                        CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                                        equipe1 = timesProximaFase[12][0]; equipe2 = timesProximaFase[13][0]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 7);
                                        CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                                        equipe1 = timesProximaFase[14][0]; equipe2 = timesProximaFase[15][0]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 8);
                                        CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);
                                    }
                                    if (numTimesPorGrupo == 2) {
                                        equipe1 = timesProximaFase[0][0]; equipe2 = timesProximaFase[1][1]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 1);
                                        CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                                        equipe1 = timesProximaFase[0][1]; equipe2 = timesProximaFase[1][0]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 2);
                                        CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                                        equipe1 = timesProximaFase[2][0]; equipe2 = timesProximaFase[3][1]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 3);
                                        CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                                        equipe1 = timesProximaFase[2][1]; equipe2 = timesProximaFase[3][0]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 4);
                                        CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                                        equipe1 = timesProximaFase[4][0]; equipe2 = timesProximaFase[5][1]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 5);
                                        CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                                        equipe1 = timesProximaFase[4][1]; equipe2 = timesProximaFase[5][0]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 6);
                                        CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                                        equipe1 = timesProximaFase[6][0]; equipe2 = timesProximaFase[7][1]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 7);
                                        CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                                        equipe1 = timesProximaFase[6][1]; equipe2 = timesProximaFase[7][0]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 8);
                                        CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);
                                    }
                                    if (numTimesPorGrupo == 4) {
                                        equipe1 = timesProximaFase[0][0]; equipe2 = timesProximaFase[1][3]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 1);
                                        CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                                        equipe1 = timesProximaFase[0][3]; equipe2 = timesProximaFase[1][0]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 2);
                                        CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                                        equipe1 = timesProximaFase[0][1]; equipe2 = timesProximaFase[1][2]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 3);
                                        CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                                        equipe1 = timesProximaFase[0][2]; equipe2 = timesProximaFase[1][1]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 4);
                                        CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                                        equipe1 = timesProximaFase[2][0]; equipe2 = timesProximaFase[3][3]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 5);
                                        CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                                        equipe1 = timesProximaFase[2][3]; equipe2 = timesProximaFase[3][0]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 6);
                                        CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                                        equipe1 = timesProximaFase[2][1]; equipe2 = timesProximaFase[3][2]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 7);
                                        CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                                        equipe1 = timesProximaFase[2][2]; equipe2 = timesProximaFase[3][1]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 8);
                                        CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);
                                    }
                                    if (numTimesPorGrupo == 8) {
                                        equipe1 = timesProximaFase[0][0]; equipe2 = timesProximaFase[1][7]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 1);
                                        CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                                        equipe1 = timesProximaFase[0][1]; equipe2 = timesProximaFase[1][6]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 2);
                                        CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                                        equipe1 = timesProximaFase[0][2]; equipe2 = timesProximaFase[1][5]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 3);
                                        CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                                        equipe1 = timesProximaFase[0][3]; equipe2 = timesProximaFase[1][4]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 4);
                                        CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                                        equipe1 = timesProximaFase[0][4]; equipe2 = timesProximaFase[1][3]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 5);
                                        CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                                        equipe1 = timesProximaFase[0][5]; equipe2 = timesProximaFase[1][2]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 6);
                                        CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                                        equipe1 = timesProximaFase[0][6]; equipe2 = timesProximaFase[1][1]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 7);
                                        CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                                        equipe1 = timesProximaFase[0][7]; equipe2 = timesProximaFase[1][0]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 8);
                                        CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);
                                    }
                                    if (numTimesPorGrupo == 16) {
                                        equipe1 = timesProximaFase[0][0]; equipe2 = timesProximaFase[0][15]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 1);
                                        CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                                        equipe1 = timesProximaFase[0][1]; equipe2 = timesProximaFase[0][14]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 2);
                                        CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                                        equipe1 = timesProximaFase[0][2]; equipe2 = timesProximaFase[0][13]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 3);
                                        CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                                        equipe1 = timesProximaFase[0][3]; equipe2 = timesProximaFase[0][12]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 4);
                                        CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                                        equipe1 = timesProximaFase[0][4]; equipe2 = timesProximaFase[0][11]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 5);
                                        CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                                        equipe1 = timesProximaFase[0][5]; equipe2 = timesProximaFase[0][10]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 6);
                                        CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                                        equipe1 = timesProximaFase[0][6]; equipe2 = timesProximaFase[0][9]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 7);
                                        CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                                        equipe1 = timesProximaFase[0][7]; equipe2 = timesProximaFase[0][8]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 8);
                                        CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);
                                    }
                                }
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
    }
}