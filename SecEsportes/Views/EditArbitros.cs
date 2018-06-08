using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SecEsportes.Infraestrutura;
using SecEsportes.Modelo;
using SecEsportes.Repositorio;

namespace SecEsportes.Views {
    public partial class EditArbitros : Form {
        private Utilidades.WindowMode windowMode;
        private string errorMessage;
        private InsertArbitro insertArbitroForm;
        private Competicao competicao;

        private Usuario usuarioLogado;

        #region Inicialização da classe
        public EditArbitros(Usuario usuarioLogado, Competicao competicao) {
            InitializeComponent();

            CenterToScreen();

            this.usuarioLogado = usuarioLogado;

            this.competicao = competicao;

            windowMode = Utilidades.WindowMode.ModoNormal;
            windowModeChanged();
        }

        private void fillFields() {
            refreshDataGridView();
        }

        private void load(object sender, EventArgs e) {
            btnAtualizar_Click(null, null);

            toolTip1.SetToolTip(btnAtualizar, btnAtualizar.Tag.ToString());
            toolTip1.SetToolTip(btnIncluirArbitro, btnIncluirArbitro.Tag.ToString());
            toolTip1.SetToolTip(btnExcluirArbitro, btnExcluirArbitro.Tag.ToString());
        }
        #endregion
        #region Manipulação do grid
        private void refreshDataGridView() {
            dgvArbitros.DataSource = null;
            dgvArbitros.Refresh();

            dgvArbitros.Columns.Clear();

            //dgvAtletas.DataSource = atletas;
            dgvArbitros.DataSource = competicao.arbitros;

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
                dgvArbitros.Rows[iCount].Cells[nameof(Pessoa.nome)].Value = competicao.arbitros[iCount].pessoa.nome;
                dgvArbitros.Rows[iCount].Cells[nameof(Pessoa.dataNascimento)].Value = competicao.arbitros[iCount].pessoa.dataNascimento.ToString("dd/MM/yyyy");
            }

            dgvArbitros.Refresh();
        }
        #endregion
        #region CRUD
        private void btnIncluirArbitro_Click(object sender, EventArgs e) {
            insertArbitroForm = new InsertArbitro(usuarioLogado, competicao.id);

            insertArbitroForm.FormClosing += (_sender, _e) => {
                foreach (Pessoa_Insert arbitro in insertArbitroForm.arbitrosAInserir) {
                    competicao.arbitros.Add(new Cargo(arbitro.pessoa.id, arbitro.funcao, arbitro.pessoa));
                    CompeticaoRepositorio.Instance.insertArbitro(ref competicao, arbitro);
                }

                refreshDataGridView();
            };

            insertArbitroForm.ShowDialog();
        }

        private void btnExcluirArbitro_Click(object sender, EventArgs e) {
            if (dgvArbitros.SelectedCells.Count > 0) {

                Cargo arbitro;
                arbitro = competicao.arbitros[dgvArbitros.SelectedCells[0].RowIndex];

                if (MessageBox.Show("Confirma a deleção do registro ?" +
                    Environment.NewLine + Environment.NewLine +
                    arbitro.ToString(), "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    if (CompeticaoRepositorio.Instance.deleteArbitroDaCompeticao(ref competicao, arbitro)) {
                        refreshDataGridView();
                    }else {
                        MessageBox.Show("Houve um erro ao tentar salvar o registro." + Environment.NewLine + Environment.NewLine + errorMessage, "Contate o Suporte técnico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e) {
            if (competicao.status != StatusEnum._1_Aberta && competicao.status != StatusEnum._3_EmPreparacao) {
                btnExcluirArbitro.Enabled = false;
                btnIncluirArbitro.Enabled = false;
            }

            fillFields();
        }
        #endregion
        #region Comportamentos do form
        private void windowModeChanged() {
            switch (windowMode) {
                case Utilidades.WindowMode.ModoNormal:
                case Utilidades.WindowMode.ModoCriacaoForm:
                    dgvArbitros.Enabled = true;
                    btnAtualizar.Enabled = true;
                    break;
                case Utilidades.WindowMode.ModoDeEdicao:
                    dgvArbitros.Enabled = false;
                    btnAtualizar.Enabled = false;
                    break;
                case Utilidades.WindowMode.ModoDeInsercao:
                    dgvArbitros.Enabled = false;
                    btnAtualizar.Enabled = false;
                    break;
            }
        }
        private void dgvArbitros_RowEnter(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex > -1) {
                if (windowMode == Utilidades.WindowMode.ModoNormal)
                    windowMode = Utilidades.WindowMode.ModoCriacaoForm;
                windowMode = Utilidades.WindowMode.ModoNormal;
            }
        }
        #endregion

        private void btn_EnableChanged(object sender, EventArgs e) {
            PictureBox pictureBox = (PictureBox)sender;
            Utilidades.enabled_Change(pictureBox.Enabled, pictureBox);
        }

    }
}