using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SecEsportes.Infraestrutura;
using SecEsportes.Modelo;
using SecEsportes.Repositorio;

namespace SecEsportes.Views {
    public partial class InsertEquipe : Form {
        private List<Equipe_Insert> equipes_view;
        private List<Equipe_Insert> equipes;
        public List<Equipe_Insert> equipesAInserir;
        private string errorMessage;

        private Usuario usuarioLogado;

        #region Inicialização da classe
        public InsertEquipe(Usuario usuarioLogado, int idCompeticao) {
            InitializeComponent();
            CenterToScreen();

            this.usuarioLogado = usuarioLogado;

            equipes = EquipeRepositorio.Instance.getEquipesForaCompeticao(ref errorMessage, idCompeticao);
            if (equipes is null) {
                MessageBox.Show("Houve um erro ao tentar listar os registros." + Environment.NewLine + Environment.NewLine + errorMessage, "Contate o Suporte técnico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            equipes_view = new List<Equipe_Insert>(equipes);

            refreshDataGridView();
            equipesAInserir = new List<Equipe_Insert>();
        }
        #endregion
        #region Manipulação do grid
        private void refreshDataGridView() {
            dgvEquipes.DataSource = null;
            dgvEquipes.Refresh();

            dgvEquipes.DataSource = equipes_view;

            for (var iCount = 0; iCount < dgvEquipes.Columns.Count; iCount++) {
                switch (dgvEquipes.Columns[iCount].DataPropertyName) {
                    case nameof(Equipe.id):
                        dgvEquipes.Columns[iCount].Visible = false;
                        break;
                    case nameof(Equipe.codigo):
                        dgvEquipes.Columns[iCount].HeaderText = "Código";
                        dgvEquipes.Columns[iCount].ReadOnly = true;
                        break;
                    case nameof(Equipe.nome):
                        dgvEquipes.Columns[iCount].HeaderText = "Nome";
                        dgvEquipes.Columns[iCount].ReadOnly = true;
                        break;
                    case nameof(Equipe_Insert.selected):
                        dgvEquipes.Columns[iCount].HeaderText = " ";
                        dgvEquipes.Columns[iCount].Width = 30;
                        break;
                }
            }

            dgvEquipes.Refresh();
        }
        #endregion

        private void btnInserir_Click(object sender, EventArgs e) {
            equipesAInserir = equipes_view.FindAll(match => match.selected == true);
            Close();
        }

        private void btnMarcarTudo_Click(object sender, EventArgs e) {
            for (int iCount = 0; iCount < equipes_view.Count; iCount++) {
                dgvEquipes.Rows[iCount].Cells[nameof(Equipe_Insert.selected)].Value = true;
            }
        }

        private void btnDesmarcarTudo_Click(object sender, EventArgs e) {
            for (int iCount = 0; iCount < equipes_view.Count; iCount++) {
                dgvEquipes.Rows[iCount].Cells[nameof(Equipe_Insert.selected)].Value = false;
            }
        }

        private void busca() {
            string textoBusca = txtBusca.Text.ToUpper();

            if (textoBusca.Length == 0) {
                equipes_view = new List<Equipe_Insert>(equipes);
            } else {
                switch (cboCamposBusca.SelectedIndex) {
                    case 0: // Nome
                        equipes_view = equipes.FindAll(find => find.nome.ToUpper().Contains(textoBusca));
                        break;
                    case 1: // Código
                        equipes_view = equipes.FindAll(find => find.codigo.ToUpper().Contains(textoBusca));
                        break;
                }
            }

            refreshDataGridView();
        }

        private void InsertEquipe_Load(object sender, EventArgs e) {
            //Preenche o ComboBox da busca
            cboCamposBusca.Items.Add("Nome");
            cboCamposBusca.Items.Add("Código");
            cboCamposBusca.SelectedIndex = 0;

            toolTip1.SetToolTip(btnDesmarcarTudo, btnDesmarcarTudo.Tag.ToString());
            toolTip1.SetToolTip(btnInserir, btnInserir.Tag.ToString());
            toolTip1.SetToolTip(btnMarcarTudo, btnMarcarTudo.Tag.ToString());
        }

        private void txtBusca_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                busca();
            }
        }
    }
}