using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SecEsportes.Infraestrutura;
using SecEsportes.Modelo;
using SecEsportes.Repositorio;

namespace SecEsportes.Views {
    public partial class ViewPartida : Form {
        private Competicao_Partida partida;
        private Competicao competicao;
        private bool partidaIniciada;
        private bool penalidades = false;

        private List<Competicao_Suspensao> atletas_Suspensos_Equipe1;
        private List<Competicao_Suspensao> atletas_Suspensos_Equipe2;

        private Usuario usuarioLogado;

        #region Inicialização da classe
        public ViewPartida(Usuario usuarioLogado, Competicao competicao, Competicao_Partida partida, bool partidaIniciada = false) {
            InitializeComponent();

            // Centraliza o form na tela
            CenterToScreen();

            this.usuarioLogado = usuarioLogado;

            this.competicao = competicao;
            this.partida = partida;
            this.partidaIniciada = partidaIniciada;
        }
        #endregion

        private void load(object sender, EventArgs e) {
            lblCompeticao.Text = competicao.nome;

            lblTime1.Text = partida.equipe1.nome;
            lblTecnico1.Text = "Técnico: " + partida.equipe1.treinador.pessoa.nome;
            lblRepresentante1.Text = "Representante: " + partida.equipe1.representante.pessoa.nome;
            partida.equipe1.atletas = PessoaRepositorio.Instance.getAtletasByEquipeCompeticao(competicao.id, partida.equipe1.id);
            atletas_Suspensos_Equipe1 = CompeticaoRepositorio.Instance.getSuspensoesPorEquipe(competicao.id, partida.equipe1.id);

            lblTime2.Text = partida.equipe2.nome;
            lblTecnico2.Text = "Técnico: " + partida.equipe2.treinador.pessoa.nome;
            lblRepresentante2.Text = "Representante: " + partida.equipe2.representante.pessoa.nome;
            partida.equipe2.atletas = PessoaRepositorio.Instance.getAtletasByEquipeCompeticao(competicao.id, partida.equipe2.id);
            atletas_Suspensos_Equipe2 = CompeticaoRepositorio.Instance.getSuspensoesPorEquipe(competicao.id, partida.equipe2.id);

            fillFields();
        }

        private void fillFields() {
            lblPlacarTime1.Text = partida.eventos.FindAll(eventosAEncontrar => eventosAEncontrar.equipe.id == partida.equipe1.id && eventosAEncontrar.tpEvento.Equals(tpEventoEnum.Gol)).Count.ToString();
            lblPlacarTime1_Penalti.Text = partida.eventos.FindAll(eventosAEncontrar => eventosAEncontrar.equipe.id == partida.equipe1.id && eventosAEncontrar.tpEvento.Equals(tpEventoEnum.Gol_Penalti)).Count.ToString();
            refreshDataGridViewAtletas(dgvEquipe1, partida.equipe1, partida.equipe1.atletas, atletas_Suspensos_Equipe1);

            lblPlacarTime2.Text = partida.eventos.FindAll(eventosAEncontrar => eventosAEncontrar.equipe.id == partida.equipe2.id && eventosAEncontrar.tpEvento.Equals(tpEventoEnum.Gol)).Count.ToString();
            lblPlacarTime2_Penalti.Text = partida.eventos.FindAll(eventosAEncontrar => eventosAEncontrar.equipe.id == partida.equipe2.id && eventosAEncontrar.tpEvento.Equals(tpEventoEnum.Gol_Penalti)).Count.ToString();
            refreshDataGridViewAtletas(dgvEquipe2, partida.equipe2, partida.equipe2.atletas, atletas_Suspensos_Equipe2);

            if (partidaIniciada) {
                btnEncerrarPartida.Enabled = true;
                btnIniciarPartida.Enabled = false;
            }
            if (partida.encerrada) {
                btnEncerrarPartida.Enabled = false;
                btnIniciarPartida.Enabled = false;
                btnDisputaPenaltis.Enabled = false;
            }
            if (!(partidaIniciada) && !(partida.encerrada)) {
                btnEncerrarPartida.Enabled = false;
                btnIniciarPartida.Enabled = true;
            }

            if (partida.rodada > 0)
                btnDisputaPenaltis.Visible = false;
            else
                btnDisputaPenaltis.Visible = true;
        }

        public void refreshDataGridViewAtletas(DataGridView dgvAtletas, EquipeCompeticao equipe, List<Atleta> atletas, List<Competicao_Suspensao> suspensoes) {
            dgvAtletas.DataSource = null;
            dgvAtletas.Refresh();

            dgvAtletas.Columns.Clear();

            dgvAtletas.DataSource = atletas;

            if (!(atletas is null)) {
                dgvAtletas.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = "NomeAtleta" });
                dgvAtletas.Columns.Add(new DataGridViewImageColumn(true) { DataPropertyName = "Gol" });
                dgvAtletas.Columns.Add(new DataGridViewImageColumn(true) { DataPropertyName = "CartaoAmarelo" });
                dgvAtletas.Columns.Add(new DataGridViewImageColumn(true) { DataPropertyName = "CartaoVermelho" });
                dgvAtletas.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = "Disponivel" });
            }

            for (var iCount = 0; iCount < dgvAtletas.Columns.Count; iCount++) {
                switch (dgvAtletas.Columns[iCount].DataPropertyName) {
                    case "NomeAtleta":
                        dgvAtletas.Columns[iCount].HeaderText = "Atleta";
                        dgvAtletas.Columns[iCount].Name = dgvAtletas.Columns[iCount].DataPropertyName;
                        dgvAtletas.Columns[iCount].DisplayIndex = iCount;
                        dgvAtletas.Columns[iCount].Width = 185;
                        break;
                    case "Gol":
                        dgvAtletas.Columns[iCount].HeaderText = "G";
                        dgvAtletas.Columns[iCount].Name = dgvAtletas.Columns[iCount].DataPropertyName;
                        dgvAtletas.Columns[iCount].DisplayIndex = iCount;
                        dgvAtletas.Columns[iCount].Width = 25;
                        ((DataGridViewImageColumn)dgvAtletas.Columns[iCount]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                        break;
                    case "CartaoAmarelo":
                        dgvAtletas.Columns[iCount].HeaderText = "CA";
                        dgvAtletas.Columns[iCount].Name = dgvAtletas.Columns[iCount].DataPropertyName;
                        dgvAtletas.Columns[iCount].DisplayIndex = iCount;
                        dgvAtletas.Columns[iCount].Width = 25;
                        ((DataGridViewImageColumn)dgvAtletas.Columns[iCount]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                        break;
                    case "CartaoVermelho":
                        dgvAtletas.Columns[iCount].HeaderText = "CV";
                        dgvAtletas.Columns[iCount].Name = dgvAtletas.Columns[iCount].DataPropertyName;
                        dgvAtletas.Columns[iCount].DisplayIndex = iCount;
                        dgvAtletas.Columns[iCount].Width = 25;
                        ((DataGridViewImageColumn)dgvAtletas.Columns[iCount]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                        break;
                    default:
                        dgvAtletas.Columns[iCount].Name = dgvAtletas.Columns[iCount].DataPropertyName;
                        dgvAtletas.Columns[iCount].Visible = false;
                        break;
                }
            }

            StringBuilder golsEquipe = new StringBuilder();

            //Preenche os campos que vieram sem preenchimento do data set
            for (int iCount = 0; iCount < dgvAtletas.Rows.Count; iCount++) {
                dgvAtletas.Rows[iCount].Cells["NomeAtleta"].Value = atletas[iCount].numero + " - " + atletas[iCount].pessoa.nome;

                int gols, CA, CV;
                gols = partida.eventos.FindAll(eventosAEncontrar => eventosAEncontrar.atleta.pessoa.id.Equals(atletas[iCount].pessoa.id) && eventosAEncontrar.tpEvento == tpEventoEnum.Gol).Count;
                CA = partida.eventos.FindAll(eventosAEncontrar => eventosAEncontrar.atleta.pessoa.id.Equals(atletas[iCount].pessoa.id) && eventosAEncontrar.tpEvento == tpEventoEnum.CartaoAmarelo).Count;
                CV = partida.eventos.FindAll(eventosAEncontrar => eventosAEncontrar.atleta.pessoa.id.Equals(atletas[iCount].pessoa.id) && eventosAEncontrar.tpEvento == tpEventoEnum.CartaoVermelho).Count;

                if (gols > 0) {
                    dgvAtletas.Rows[iCount].Cells["Gol"].Value = Properties.Resources.partida_gol_ico;
                    golsEquipe.AppendFormat("{0}{1}, ", atletas[iCount].pessoa.nome, (gols > 1 ? "(" + gols + ")" : ""));

                } else
                    dgvAtletas.Rows[iCount].Cells["Gol"].Value = Properties.Resources.nothing_ico;

                if (CA == 1)
                    dgvAtletas.Rows[iCount].Cells["CartaoAmarelo"].Value = Properties.Resources.partida_amarelo_ico;
                else if (CA == 2)
                    dgvAtletas.Rows[iCount].Cells["CartaoAmarelo"].Value = Properties.Resources.partida_amarelos_ico;
                else
                    dgvAtletas.Rows[iCount].Cells["CartaoAmarelo"].Value = Properties.Resources.nothing_ico;

                if (CV > 0)
                    dgvAtletas.Rows[iCount].Cells["CartaoVermelho"].Value = Properties.Resources.partida_vermelho_ico;
                else
                    dgvAtletas.Rows[iCount].Cells["CartaoVermelho"].Value = Properties.Resources.nothing_ico;

                if ( (suspensoes.FindAll(find => find.atleta.pessoa.id == atletas[iCount].pessoa.id).Count > 0) || (CV > 0)) {
                    dgvAtletas.Rows[iCount].Cells["Disponivel"].Value = "N";
                    dgvAtletas.Rows[iCount].DefaultCellStyle.ForeColor = Color.Red;
                } else
                    dgvAtletas.Rows[iCount].Cells["Disponivel"].Value = "S";

            }

            if (golsEquipe.Length >= 2)
                golsEquipe.Remove(golsEquipe.Length - 2, 2);
            if (dgvAtletas.Tag.ToString() == "1")
                lblGols1.Text = "Gols: " + golsEquipe.ToString();
            else if (dgvAtletas.Tag.ToString() == "2")
                lblGols2.Text = "Gols: " + golsEquipe.ToString();

            dgvAtletas.Refresh();
        }

        private void dgvEquipe_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
            if (partidaIniciada && !(partida.encerrada)) {
                if (e.RowIndex > -1) {
                    if (e.Button == MouseButtons.Right) {
                        // Identifica a equipe
                        DataGridView dgvEquipe = (DataGridView)sender;
                        int numEquipe = Convert.ToInt32(dgvEquipe.Tag);
                        EquipeCompeticao equipe = null;
                        switch (numEquipe) {
                            case 1:
                                equipe = partida.equipe1;
                                break;
                            case 2:
                                equipe = partida.equipe2;
                                break;
                        }

                        // Identifica se o atleta não está suspenso
                        DataGridView dataGridView = (DataGridView)sender;
                        bool atletaSuspenso;
                        if (dataGridView["disponivel", e.RowIndex].Value.ToString() == "N")
                            atletaSuspenso = true;
                        else
                            atletaSuspenso = false;

                        // Cria o menu de contexto
                        ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
                        ToolStripMenuItem toolStripMenuItem;

                        if (penalidades) {
                            toolStripMenuItem = new ToolStripMenuItem("Gol de pênalti");
                            toolStripMenuItem.Click += mnuNewEvento;
                            toolStripMenuItem.Tag = new List<Object>() { tpEventoEnum.Gol_Penalti, numEquipe, equipe.atletas[e.RowIndex] };
                            toolStripMenuItem.Enabled = !atletaSuspenso;
                            contextMenuStrip.Items.Add(toolStripMenuItem);
                        } else {
                            toolStripMenuItem = new ToolStripMenuItem("Gol");
                            toolStripMenuItem.Tag = new List<Object>() { tpEventoEnum.Gol, numEquipe, equipe.atletas[e.RowIndex] };
                            toolStripMenuItem.Click += mnuNewEvento;
                            toolStripMenuItem.Image = Properties.Resources.partida_gol_png;
                            toolStripMenuItem.Enabled = !atletaSuspenso;
                            contextMenuStrip.Items.Add(toolStripMenuItem);

                            toolStripMenuItem = new ToolStripMenuItem("Cartão Amarelo");
                            toolStripMenuItem.Tag = new List<Object>() { tpEventoEnum.CartaoAmarelo, numEquipe, equipe.atletas[e.RowIndex] };
                            toolStripMenuItem.Click += mnuNewEvento;
                            toolStripMenuItem.Image = Properties.Resources.partida_amarelo_png;
                            toolStripMenuItem.Enabled = !atletaSuspenso;
                            contextMenuStrip.Items.Add(toolStripMenuItem);

                            toolStripMenuItem = new ToolStripMenuItem("Cartão Vermelho");
                            toolStripMenuItem.Tag = new List<Object>() { tpEventoEnum.CartaoVermelho, numEquipe, equipe.atletas[e.RowIndex] };
                            toolStripMenuItem.Click += mnuNewEvento;
                            toolStripMenuItem.Image = Properties.Resources.partida_vermelho_png;
                            toolStripMenuItem.Enabled = !atletaSuspenso;
                            contextMenuStrip.Items.Add(toolStripMenuItem);
                        }

                        // Exibe o menu de contexto
                        contextMenuStrip.Show(this, this.PointToClient(MousePosition));
                    }
                }
            }
        }

        private void mnuNewEvento(object sender, EventArgs e) {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            tpEventoEnum tpEvento = (tpEventoEnum)((List<Object>)menuItem.Tag)[0];
            int numEquipe = (int)((List<Object>)menuItem.Tag)[1];
            Atleta atleta = (Atleta)((List<Object>)menuItem.Tag)[2];

            EquipeCompeticao equipe = null;

            if (numEquipe == 1)
                equipe = partida.equipe1;
            else
                equipe = partida.equipe2;

            Competicao_Partida_Evento evento = new Competicao_Partida_Evento(equipe, atleta, tpEvento);
            partida.eventos.Add(evento);
            CompeticaoRepositorio.Instance.insertEvento(ref partida, evento);
            fillFields();

        }

        private void btnIniciarPartida_Click(object sender, EventArgs e) {
            partidaIniciada = true;
            fillFields();
        }

        private void ViewPartida_FormClosing(object sender, FormClosingEventArgs e) {
            if (partidaIniciada && !(partida.encerrada)) {
                e.Cancel = true;
            }
        }

        private void btnEncerrarPartida_Click(object sender, EventArgs e) {
            int golsEquipe1 = 0, golsEquipe2 = 0;

            //Verifica se terá que ter desempate
            if (partida.rodada < 0) {
                if (penalidades) {
                    int golsPenaltiEquipe1, golsPenaltiEquipe2;
                    golsPenaltiEquipe1 = partida.eventos.FindAll(eventos => eventos.tpEvento.Equals(tpEventoEnum.Gol_Penalti) && eventos.equipe.id == partida.equipe1.id).Count;
                    golsPenaltiEquipe2 = partida.eventos.FindAll(eventos => eventos.tpEvento.Equals(tpEventoEnum.Gol_Penalti) && eventos.equipe.id == partida.equipe2.id).Count;

                    if (golsPenaltiEquipe1 == golsPenaltiEquipe2) {
                        return;
                    }

                } else {
                    golsEquipe1 = partida.eventos.FindAll(eventosAEncontrar => eventosAEncontrar.tpEvento.Equals(tpEventoEnum.Gol) && eventosAEncontrar.equipe.id.Equals(partida.equipe1.id)).Count;
                    golsEquipe2 = partida.eventos.FindAll(eventosAEncontrar => eventosAEncontrar.tpEvento.Equals(tpEventoEnum.Gol) && eventosAEncontrar.equipe.id.Equals(partida.equipe2.id)).Count;

                    // Se for mata-mata só vai para os penaltis no segundo jogo
                    if (competicao.jogosIdaEVolta_FaseFinal) {
                        // Verifica se é o jogo de volta
                        Competicao_Partida partidaIda = competicao.partidas.Find(x => x.encerrada && x.rodada == partida.rodada && x.numGrupo == partida.numGrupo && x.equipe1.id == partida.equipe2.id && x.equipe2.id == partida.equipe1.id && x.id != partida.id);
                        if (!(partidaIda is null)) {
                            golsEquipe1 += partidaIda.eventos.FindAll(eventos => eventos.tpEvento.Equals(tpEventoEnum.Gol) && eventos.equipe.id == partida.equipe1.id).Count;
                            golsEquipe2 += partidaIda.eventos.FindAll(eventos => eventos.tpEvento.Equals(tpEventoEnum.Gol) && eventos.equipe.id == partida.equipe2.id).Count;

                            if (golsEquipe1 == golsEquipe2) {
                                btnDisputaPenaltis.Enabled = true;
                                btnDisputaPenaltis_Click(null, null);
                                return;
                            }

                        }
                    } else {
                        if (golsEquipe1 == golsEquipe2) {
                            btnDisputaPenaltis.Enabled = true;
                            btnDisputaPenaltis_Click(null, null);
                            return;
                        }
                    }                    
                }
            }

            partidaIniciada = false;
            partida.encerrada = true;
            CompeticaoRepositorio.Instance.updatePartida(ref competicao, partida);

            fillFields();
        }

        private void btnDisputaPenaltis_Click(object sender, EventArgs e) {
            lblPlacarTime1_Penalti.Visible = true;
            lblPlacarTime2_Penalti.Visible = true;
            
            penalidades = true;
            btnEncerrarPartida.Enabled = true;
        }   
    }
}