using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SecEsportes.Infraestrutura;
using SecEsportes.Modelo;
using SecEsportes.Repositorio;

namespace SecEsportes.Views {
    public partial class InsertEquipe : Form {
        private List<Equipe_Insert> equipes;
        public List<Equipe_Insert> equipesAInserir;
        private string errorMessage;

        #region Inicialização da classe
        public InsertEquipe(int idCompeticao) {
            InitializeComponent();
            CenterToScreen();

            equipes = EquipeRepositorio.Instance.getEquipesForaCompeticao(ref errorMessage, idCompeticao);
            if (equipes is null) {
                MessageBox.Show("Houve um erro ao tentar listar os registros." + Environment.NewLine + Environment.NewLine + errorMessage, "Contate o Suporte técnico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            refreshDataGridView();
            equipesAInserir = new List<Equipe_Insert>();
        }
        #endregion
        #region Manipulação do grid
        private void refreshDataGridView() {
            dgvEquipes.DataSource = null;
            dgvEquipes.Refresh();

            dgvEquipes.DataSource = equipes;

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
            equipesAInserir = equipes.FindAll(match => match.selected == true);
            Close();
        }
    }
}