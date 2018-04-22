using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SecEsportes.Infraestrutura;
using SecEsportes.Modelo;
using SecEsportes.Repositorio;

namespace SecEsportes.Views {
    public partial class ViewPartida : Form {
        private Competicao_Partida partida;
        private Competicao competicao;
        private bool partidaIniciada;
        private string errorMessage = "";

        #region Inicialização da classe
        public ViewPartida(Competicao competicao, Competicao_Partida partida) {
            InitializeComponent();

            // Centraliza o form na tela
            CenterToScreen();

            this.competicao = competicao;
            this.partida = partida;
            partidaIniciada = false;
        }
        #endregion

        private void load(object sender, EventArgs e) {
            lblCompeticao.Text = competicao.nome;

            lblTime1.Text = partida.equipe1.nome;
            lblTecnico1.Text = "Técnico: " + partida.equipe1.treinador.pessoa.nome;
            lblRepresentante1.Text = "Representante: " + partida.equipe1.representante.pessoa.nome;
            lblPlacarTime1.Text = partida.eventos.FindAll(eventosAEncontrar => eventosAEncontrar.equipe.id == partida.equipe1.id && eventosAEncontrar.tpEvento.Equals(tpEventoEnum.Gol)).Count.ToString();
            refreshDataGridViewAtletas(dgvEquipe1, partida.equipe1, partida.equipe1.atletas);

            lblTime2.Text = partida.equipe2.nome;
            lblTecnico2.Text = "Técnico: " + partida.equipe2.treinador.pessoa.nome;
            lblRepresentante2.Text = "Representante: " + partida.equipe2.representante.pessoa.nome;
            lblPlacarTime2.Text = partida.eventos.FindAll(eventosAEncontrar => eventosAEncontrar.equipe.id == partida.equipe2.id && eventosAEncontrar.tpEvento.Equals(tpEventoEnum.Gol)).Count.ToString();
            refreshDataGridViewAtletas(dgvEquipe2, partida.equipe2, partida.equipe2.atletas);

            if (partidaIniciada) {
                btnEncerrarPartida.Enabled = true;
                btnIniciarPartida.Enabled = false;
            }
            if (partida.encerrada) {
                btnEncerrarPartida.Enabled = false;
                btnIniciarPartida.Enabled = false;
            }
            if(!(partidaIniciada) && !(partida.encerrada)) {
                btnEncerrarPartida.Enabled = false;
                btnIniciarPartida.Enabled = true;
            }
        }

        public void refreshDataGridViewAtletas(DataGridView dgvAtletas, EquipeCompeticao equipe, List<Atleta> atletas) {
            dgvAtletas.DataSource = null;
            dgvAtletas.Refresh();

            dgvAtletas.Columns.Clear();

            dgvAtletas.DataSource = atletas;

            if (!(atletas is null)) {
                dgvAtletas.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = "NomeAtleta" });
                dgvAtletas.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = "Gol" });
                dgvAtletas.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = "CartaoAmarelo" });
                dgvAtletas.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = "CartaoVermelho" });
            }

            for (var iCount = 0; iCount < dgvAtletas.Columns.Count; iCount++) {
                switch (dgvAtletas.Columns[iCount].DataPropertyName) {
                    case "NomeAtleta":
                        dgvAtletas.Columns[iCount].HeaderText = "Atleta";
                        dgvAtletas.Columns[iCount].Name = dgvAtletas.Columns[iCount].DataPropertyName;
                        dgvAtletas.Columns[iCount].DisplayIndex = 0;
                        dgvAtletas.Columns[iCount].Width = 185;
                        break;
                    case "Gol":
                        dgvAtletas.Columns[iCount].HeaderText = "G";
                        dgvAtletas.Columns[iCount].Name = dgvAtletas.Columns[iCount].DataPropertyName;
                        dgvAtletas.Columns[iCount].DisplayIndex = 1;
                        dgvAtletas.Columns[iCount].Width = 25;
                        break;
                    case "CartaoAmarelo":
                        dgvAtletas.Columns[iCount].HeaderText = "CA";
                        dgvAtletas.Columns[iCount].Name = dgvAtletas.Columns[iCount].DataPropertyName;
                        dgvAtletas.Columns[iCount].DisplayIndex = 2;
                        dgvAtletas.Columns[iCount].Width = 25;
                        break;
                    case "CartaoVermelho":
                        dgvAtletas.Columns[iCount].HeaderText = "CV";
                        dgvAtletas.Columns[iCount].Name = dgvAtletas.Columns[iCount].DataPropertyName;
                        dgvAtletas.Columns[iCount].DisplayIndex = 3;
                        dgvAtletas.Columns[iCount].Width = 25;
                        break;
                    default:
                        dgvAtletas.Columns.RemoveAt(iCount);
                        iCount--;
                        break;
                }
            }

            //Preenche os campos que vieram sem preenchimento do data set
            for (var iCount = 0; iCount < dgvAtletas.Rows.Count; iCount++) {
                dgvAtletas.Rows[iCount].Cells["NomeAtleta"].Value = atletas[iCount].numero + " - " + atletas[iCount].pessoa.nome;
                dgvAtletas.Rows[iCount].Cells["Gol"].Value = partida.eventos.FindAll(eventosAEncontrar => eventosAEncontrar.atleta.pessoa.id.Equals(atletas[iCount].pessoa.id) && eventosAEncontrar.tpEvento == tpEventoEnum.Gol).Count.ToString();
                dgvAtletas.Rows[iCount].Cells["CartaoAmarelo"].Value = partida.eventos.FindAll(eventosAEncontrar => eventosAEncontrar.atleta.pessoa.id.Equals(atletas[iCount].pessoa.id) && eventosAEncontrar.tpEvento == tpEventoEnum.CartaoAmarelo).Count.ToString();
                dgvAtletas.Rows[iCount].Cells["CartaoVermelho"].Value = partida.eventos.FindAll(eventosAEncontrar => eventosAEncontrar.atleta.pessoa.id.Equals(atletas[iCount].pessoa.id) && eventosAEncontrar.tpEvento == tpEventoEnum.CartaoVermelho).Count.ToString();
            }

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

                        // Cria o menu de contexto
                        ContextMenu contextMenu = new ContextMenu();
                        MenuItem menuItem;

                        menuItem = new MenuItem("Gol");
                        menuItem.Click += mnuNewEvento;
                        menuItem.Tag = new List<Object>() { tpEventoEnum.Gol, numEquipe, equipe.atletas[e.RowIndex]};
                        contextMenu.MenuItems.Add(menuItem);

                        menuItem = new MenuItem("Cartão Amarelo");
                        menuItem.Tag = new List<Object>() { tpEventoEnum.CartaoAmarelo, numEquipe, equipe.atletas[e.RowIndex] };
                        menuItem.Click += mnuNewEvento;
                        contextMenu.MenuItems.Add(menuItem);

                        menuItem = new MenuItem("Cartão Vermelho");
                        menuItem.Tag = new List<Object>() { tpEventoEnum.CartaoVermelho, numEquipe, equipe.atletas[e.RowIndex] };
                        menuItem.Click += mnuNewEvento;
                        contextMenu.MenuItems.Add(menuItem);


                        // Exibe o menu de contexto
                        contextMenu.Show(dgvEquipe, new System.Drawing.Point(dgvEquipe.RowHeadersWidth, dgvEquipe.ColumnHeadersHeight));
                    }
                }
            }
        }

        private void mnuNewEvento(object sender, EventArgs e) {
            MenuItem menuItem = (MenuItem)sender;
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
            CompeticaoRepositorio.Instance.insertEvento(partida, evento);
            load(null, null);

        }

        private void btnIniciarPartida_Click(object sender, EventArgs e) {
            partidaIniciada = true;
            load(null, null);
        }

        private void ViewPartida_FormClosing(object sender, FormClosingEventArgs e) {
            if (partidaIniciada && !(partida.encerrada)) {
                e.Cancel = true;
            }
        }

        private void btnEncerrarPartida_Click(object sender, EventArgs e) {
            partidaIniciada = false;
            partida.encerrada = true;
            partida.data = DateTime.Now;;
            CompeticaoRepositorio.Instance.updatePartida(ref competicao, partida);

            if (competicao.fase_Atual == -1) {
                competicao.status = StatusEnum._0_Encerrada;
                CompeticaoRepositorio.Instance.update(competicao, ref errorMessage);
            }

            load(null, null);
        }
    }
}