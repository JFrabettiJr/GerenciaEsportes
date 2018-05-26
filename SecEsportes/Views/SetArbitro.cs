using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SecEsportes.Infraestrutura;
using SecEsportes.Modelo;
using SecEsportes.Repositorio;

namespace SecEsportes.Views {
    public partial class SetArbitro : Form {
        private Utilidades.WindowMode windowMode;
        private string errorMessage;
        private Competicao competicao;
        private Competicao_Partida partida;
        private Usuario usuarioLogado;
        public Cargo arbitroSelecionado;

        private List<Cargo> arbitros;
        private List<Cargo> arbitros_view;

        #region Inicialização da classe
        public SetArbitro(Usuario usuarioLogado, Competicao competicao, Competicao_Partida partida) {
            InitializeComponent();

            CenterToScreen();

            this.usuarioLogado = usuarioLogado;
            this.competicao = competicao;
            this.partida = partida;

            arbitros = CompeticaoRepositorio.Instance.getArbitroPorCompeticao(competicao.id);
            if (arbitros is null) {
                MessageBox.Show("Houve um erro ao tentar listar os registros." + Environment.NewLine + Environment.NewLine + errorMessage, "Contate o Suporte técnico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            arbitros_view = new List<Cargo>(arbitros);

            Text += String.Format(" - {0} - {1} | {2} ", partida.equipe1.nome, partida.equipe2.nome, (partida.data is null? "" : ((DateTime)partida.data).ToString("dd/MM/yyyy")));

            windowMode = Utilidades.WindowMode.ModoNormal;
            windowModeChanged();
        }

        private void load(object sender, EventArgs e) {
            refreshDataGridView();

            //Preenche o ComboBox da busca
            cboCamposBusca.Items.Add("Nome");

            cboCamposBusca.SelectedIndex = 0;

        }
        #endregion
        #region Manipulação do grid
        private void refreshDataGridView() {
            dgvArbitros.DataSource = null;
            dgvArbitros.Refresh();

            dgvArbitros.Columns.Clear();

            dgvArbitros.DataSource = arbitros_view;

            // Cria duas novas colunas
            dgvArbitros.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = nameof(Pessoa.nome) });
            dgvArbitros.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = nameof(Pessoa.dataNascimento) });

            for (var iCount = 0; iCount < dgvArbitros.Columns.Count; iCount++) {
                switch (dgvArbitros.Columns[iCount].DataPropertyName) {
                    case nameof(Pessoa.nome):
                        dgvArbitros.Columns[iCount].Name = dgvArbitros.Columns[iCount].DataPropertyName;
                        dgvArbitros.Columns[iCount].HeaderText = "Nome";
                        dgvArbitros.Columns[iCount].Width = 150;
                        dgvArbitros.Columns[iCount].ReadOnly = true;
                        break;
                    case nameof(Pessoa.dataNascimento):
                        dgvArbitros.Columns[iCount].Name = dgvArbitros.Columns[iCount].DataPropertyName;
                        dgvArbitros.Columns[iCount].HeaderText = "Data de nascimento";
                        dgvArbitros.Columns[iCount].Width = 100;
                        dgvArbitros.Columns[iCount].ReadOnly = true;
                        break;
                    default:
                        dgvArbitros.Columns[iCount].Visible = false;
                        break;
                }
            }

            //Preenche os campos que vieram sem preenchimento do data set
            for (var iCount = 0; iCount < dgvArbitros.Rows.Count; iCount++) {
                dgvArbitros.Rows[iCount].Cells[nameof(Pessoa.nome)].Value = arbitros_view[iCount].pessoa.nome;
                dgvArbitros.Rows[iCount].Cells[nameof(Pessoa.dataNascimento)].Value = arbitros_view[iCount].pessoa.dataNascimento.ToString("dd/MM/yyyy");
            }

            dgvArbitros.Refresh();
        }
        #endregion
        #region Comportamentos do form
        private void windowModeChanged() {
            switch (windowMode) {
                case Utilidades.WindowMode.ModoNormal:
                case Utilidades.WindowMode.ModoCriacaoForm:
                    dgvArbitros.Enabled = true;
                    break;
                case Utilidades.WindowMode.ModoDeEdicao:
                    dgvArbitros.Enabled = false;
                    break;
                case Utilidades.WindowMode.ModoDeInsercao:
                    dgvArbitros.Enabled = false;
                    break;
            }
        }
        #endregion
        private void busca() {
            string textoBusca = txtBusca.Text.ToUpper();

            if (textoBusca.Length == 0) {
                arbitros_view = new List<Cargo>(arbitros);
            } else {
                switch (cboCamposBusca.SelectedIndex) {
                    case 0: // Nome
                        arbitros_view = arbitros.FindAll(find => find.pessoa.nome.ToUpper().Contains(textoBusca));
                        break;
                }
            }

            refreshDataGridView();
        }

        private void txtBusca_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                busca();
            }
        }

        private void dgvArbitros_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e) {
            if (e.RowIndex > -1) {
                arbitroSelecionado = arbitros_view[e.RowIndex];
                Close();
            }
        }
    }
}