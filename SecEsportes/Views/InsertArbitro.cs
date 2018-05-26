using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SecEsportes.Infraestrutura;
using SecEsportes.Modelo;
using SecEsportes.Repositorio;

namespace SecEsportes.Views {
    public partial class InsertArbitro : Form {
        private List<Pessoa_Insert> arbitros_view;
        private List<Pessoa_Insert> arbitros;
        public List<Pessoa_Insert> arbitrosAInserir;
        private string errorMessage;

        private Usuario usuarioLogado;

        #region Inicialização da classe
        public InsertArbitro(Usuario usuarioLogado, int idCompeticao) {
            InitializeComponent();
            CenterToScreen();

            this.usuarioLogado = usuarioLogado;

            arbitros = PessoaRepositorio.Instance.getArbitrosForaCompeticao(idCompeticao, ref errorMessage);
            if (arbitros is null) {
                MessageBox.Show("Houve um erro ao tentar listar os registros." + Environment.NewLine + Environment.NewLine + errorMessage, "Contate o Suporte técnico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            arbitros_view = new List<Pessoa_Insert>(arbitros);

            arbitrosAInserir = new List<Pessoa_Insert>();
        }
        private void InsertArbitro_Load(object sender, EventArgs e) {
            refreshDataGridView();

            //Preenche o ComboBox da busca
            cboCamposBusca.Items.Add("Nome");
            cboCamposBusca.Items.Add("Ano nascimento");

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
            dgvArbitros.Columns.Add(new DataGridViewColumn(new DataGridViewCheckBoxCell()) { DataPropertyName = nameof(Atleta_Insert.selected) });
            dgvArbitros.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = nameof(Pessoa.nome) });
            dgvArbitros.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = nameof(Pessoa.dataNascimento) });

            for (var iCount = 0; iCount < dgvArbitros.Columns.Count; iCount++) {
                switch (dgvArbitros.Columns[iCount].DataPropertyName) {
                    case nameof(Atleta_Insert.selected):
                        dgvArbitros.Columns[iCount].HeaderText = " ";
                        dgvArbitros.Columns[iCount].Width = 30;
                        break;
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

        private void btnInserir_Click(object sender, EventArgs e) {
            arbitrosAInserir = arbitros_view.FindAll(match => match.selected == true);
            Close();
        }

        private void btnMarcarTudo_Click(object sender, EventArgs e) {
            for (int iCount = 0; iCount < arbitros_view.Count; iCount++) {
                dgvArbitros.Rows[iCount].Cells[nameof(Atleta_Insert.selected)].Value = true;
            }
        }

        private void btnDesmarcarTudo_Click(object sender, EventArgs e) {
            for (int iCount = 0; iCount < arbitros_view.Count; iCount++) {
                dgvArbitros.Rows[iCount].Cells[nameof(Atleta_Insert.selected)].Value = false;
            }
        }

        private void txtBusca_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                busca();
            }
        }

        private void busca() {
            string textoBusca = txtBusca.Text.ToUpper();

            if (textoBusca.Length == 0) {
                arbitros_view = new List<Pessoa_Insert>(arbitros);
            } else {
                switch (cboCamposBusca.SelectedIndex) {
                    case 0: // Nome
                        arbitros_view = arbitros.FindAll(find => find.pessoa.nome.ToUpper().Contains(textoBusca));
                        break;
                    case 1: // Ano Nascimento
                        int anoNascimento;

                        if (Int32.TryParse(textoBusca, out anoNascimento)) {
                            arbitros_view = arbitros.FindAll(find => find.pessoa.dataNascimento.Year == anoNascimento);
                        }
                        break;
                }
            }

            refreshDataGridView();
        }

    }
}