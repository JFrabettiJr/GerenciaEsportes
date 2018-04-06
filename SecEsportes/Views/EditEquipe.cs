using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SecEsportes.Infraestrutura;
using SecEsportes.Modelo;
using SecEsportes.Repositorio;

namespace SecEsportes.Views {
    public partial class EditEquipe : Form {
        private Utilidades.WindowMode windowMode;
        private List<Atleta> atletas;
        private Equipe equipe;
        private string errorMessage;
        private InsertAtleta insertAtletaForm;
        private Competicao competicao;

        #region Inicialização da classe
        public EditEquipe(Equipe equipe, Competicao competicao) {
            InitializeComponent();

            CenterToScreen();

            Text += " - " + equipe.codigo + " - " + equipe.nome;
            this.equipe = equipe;
            this.competicao = competicao;
            txtCodigo.Text = equipe.codigo;
            txtNome.Text = equipe.nome;

            atletas = PessoaRepositorio.Instance.getAtletasPorEquipeCompeticao(competicao.id, equipe.id, ref errorMessage);
            if (atletas is null) {
                MessageBox.Show("Houve um erro ao tentar listar os registros." + Environment.NewLine + Environment.NewLine + errorMessage, "Contate o Suporte técnico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            windowMode = Utilidades.WindowMode.ModoNormal;
            windowModeChanged();


        }
        private void EditEquipe_Load(object sender, EventArgs e) {
            refreshDataGridView();
        }
        #endregion
        #region Manipulação do grid
        private void refreshDataGridView() {
            dgvAtletas.DataSource = null;
            dgvAtletas.Refresh();

            dgvAtletas.Columns.Clear();

            dgvAtletas.DataSource = atletas;

            // Cria duas novas colunas
            dgvAtletas.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = nameof(Pessoa.nome) });
            dgvAtletas.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = nameof(Pessoa.dataNascimento) });

            for (var iCount = 0; iCount < dgvAtletas.Columns.Count; iCount++) {
                switch (dgvAtletas.Columns[iCount].DataPropertyName) {
                    case nameof(Pessoa.nome):
                        dgvAtletas.Columns[iCount].Name = dgvAtletas.Columns[iCount].DataPropertyName;
                        dgvAtletas.Columns[iCount].HeaderText = "Nome";
                        dgvAtletas.Columns[iCount].Width = 150;
                        dgvAtletas.Columns[iCount].ReadOnly = true;
                        break;
                    case nameof(Pessoa.dataNascimento):
                        dgvAtletas.Columns[iCount].Name = dgvAtletas.Columns[iCount].DataPropertyName;
                        dgvAtletas.Columns[iCount].HeaderText = "Data de nascimento";
                        dgvAtletas.Columns[iCount].Width = 100;
                        dgvAtletas.Columns[iCount].ReadOnly = true;
                        break;
                    case nameof(Atleta.Numero):
                        dgvAtletas.Columns[iCount].Name = dgvAtletas.Columns[iCount].DataPropertyName;
                        dgvAtletas.Columns[iCount].HeaderText = "Númeração";
                        dgvAtletas.Columns[iCount].Width = 75;
                        break;
                    default:
                        dgvAtletas.Columns[iCount].Visible = false;
                        break;
                }
            }

            //Preenche os campos que vieram sem preenchimento do data set
            for (var iCount = 0; iCount < dgvAtletas.Rows.Count; iCount++) {
                dgvAtletas.Rows[iCount].Cells[nameof(Pessoa.nome)].Value = atletas[iCount].pessoa.nome;
                dgvAtletas.Rows[iCount].Cells[nameof(Pessoa.dataNascimento)].Value = atletas[iCount].pessoa.dataNascimento.ToString("dd/MM/yyyy");
            }

            dgvAtletas.Refresh();
        }
        #endregion
        #region CRUD
        private void btnIncluirAtleta_Click(object sender, EventArgs e) {
            insertAtletaForm = new InsertAtleta(competicao.id);
            insertAtletaForm.FormClosing += insertEquipeForm_FormClosing;
            insertAtletaForm.ShowDialog();
        }

        private void insertEquipeForm_FormClosing(object sender, FormClosingEventArgs e) {
            foreach (Atleta_Insert atleta in insertAtletaForm.atletasAInserir) {
                atletas.Add(new Atleta(atleta.id, atleta.funcao, atleta.pessoa, null));
                EquipeRepositorio.Instance.insertAtletaEmEquipe(competicao.id, equipe.id, atleta);
            }
            refreshDataGridView();
        }
        #endregion
        #region Comportamentos do form
        private void windowModeChanged() {
            switch (windowMode) {
                case Utilidades.WindowMode.ModoNormal:
                    //btnCancelar.Enabled = false;
                    //btnSalvar.Enabled = false;
                    //btnAdicionar.Enabled = true;
                    //btnExcluir.Enabled = true;
                    dgvAtletas.Enabled = true;
                    //btnAtualizar.Enabled = true;
                    break;
                case Utilidades.WindowMode.ModoDeEdicao:
                    //btnCancelar.Enabled = true;
                    //Salvar.Enabled = true;
                    //Adicionar.Enabled = false;
                    //Excluir.Enabled = false;
                    dgvAtletas.Enabled = false;
                    //btnAtualizar.Enabled = false;
                    break;
                case Utilidades.WindowMode.ModoDeInsercao:
                    //btnCancelar.Enabled = true;
                    //tnSalvar.Enabled = true;
                    //tnAdicionar.Enabled = false;
                    //tnExcluir.Enabled = false;
                    dgvAtletas.Enabled = false;
                    //btnAtualizar.Enabled = false;
                    break;
            }
        }
        private void dgvEquipes_RowEnter(object sender, DataGridViewCellEventArgs e) {

        }
        private void fields_KeyDown(object sender, KeyEventArgs e) {
            if (windowMode != Utilidades.WindowMode.ModoDeInsercao) {
                windowMode = Utilidades.WindowMode.ModoDeEdicao;
                windowModeChanged();
            }
        }
        #endregion
    }
}