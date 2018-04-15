using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SecEsportes.Infraestrutura;
using SecEsportes.Modelo;
using SecEsportes.Repositorio;

namespace SecEsportes.Views {
    public partial class EditEquipe : Form {
        private Utilidades.WindowMode windowMode;
        private EquipeCompeticao equipe;
        private string errorMessage;
        private InsertAtleta insertAtletaForm;
        private Competicao competicao;
        private List<Cargo> representantes;
        private List<Cargo> treinadores;

        #region Inicialização da classe
        public EditEquipe(EquipeCompeticao equipe, Competicao competicao) {
            InitializeComponent();

            CenterToScreen();
            
            this.equipe = equipe;
            this.competicao = competicao;

            Text += " - " + equipe.codigo + " - " + equipe.nome;

            windowMode = Utilidades.WindowMode.ModoNormal;
            windowModeChanged();
        }

        private void fillFields() {
            txtCodigo.Text = equipe.codigo;
            txtNome.Text = equipe.nome;

            cboTreinador.SelectedIndex = (equipe.treinador is null ? -1 : treinadores.FindIndex(treinador => treinador.id_pessoa == equipe.treinador.id_pessoa));
            cboRepresentante.SelectedIndex = (equipe.representante is null ? -1 : representantes.FindIndex(representante => representante.id_pessoa == equipe.representante.id_pessoa));

            refreshDataGridView();

        }

        private void EditEquipe_Load(object sender, EventArgs e) {
            // Carrega os representantes
            representantes = PessoaRepositorio.Instance.getRepresentantesForaCompeticao(competicao.id, equipe.id);
            cboRepresentante.Items.Clear();
            for (int iCount = 0; iCount < representantes.Count; iCount++) {
                cboRepresentante.Items.Add(representantes[iCount].pessoa.nome);
            }

            // Carrega os técnicos
            treinadores = PessoaRepositorio.Instance.getTreinadores(competicao.id, equipe.id);
            cboTreinador.Items.Clear();
            for (int iCount = 0; iCount < treinadores.Count; iCount++) {
                cboTreinador.Items.Add(treinadores[iCount].pessoa.nome);
            }

            fillFields();
        }
        #endregion
        #region Manipulação do grid
        private void refreshDataGridView() {
            dgvAtletas.DataSource = null;
            dgvAtletas.Refresh();

            dgvAtletas.Columns.Clear();

            //dgvAtletas.DataSource = atletas;
            dgvAtletas.DataSource = equipe.atletas;

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
                        dgvAtletas.Columns[iCount].ValueType = typeof(Int32);
                        break;
                    default:
                        dgvAtletas.Columns[iCount].Visible = false;
                        break;
                }
            }

            //Preenche os campos que vieram sem preenchimento do data set
            for (var iCount = 0; iCount < dgvAtletas.Rows.Count; iCount++) {
                //dgvAtletas.Rows[iCount].Cells[nameof(Pessoa.nome)].Value = atletas[iCount].pessoa.nome;
                dgvAtletas.Rows[iCount].Cells[nameof(Pessoa.nome)].Value = equipe.atletas[iCount].pessoa.nome;
                //dgvAtletas.Rows[iCount].Cells[nameof(Pessoa.dataNascimento)].Value = atletas[iCount].pessoa.dataNascimento.ToString("dd/MM/yyyy");
                dgvAtletas.Rows[iCount].Cells[nameof(Pessoa.dataNascimento)].Value = equipe.atletas[iCount].pessoa.dataNascimento.ToString("dd/MM/yyyy");
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
                equipe.atletas.Add(new Atleta(atleta.id, atleta.funcao, atleta.pessoa, null));
                EquipeRepositorio.Instance.insertAtletaEmEquipe(competicao.id, equipe.id, atleta);
            }
            refreshDataGridView();
        }
        private void btnExcluirAtleta_Click(object sender, EventArgs e) {
            if (dgvAtletas.SelectedCells.Count > 0) {
                Atleta atleta;
                atleta = equipe.atletas[dgvAtletas.SelectedCells[0].RowIndex];
                if (MessageBox.Show("Confirma a deleção do registro ?" +
                    Environment.NewLine + Environment.NewLine +
                    atleta.ToString(), "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    if (EquipeRepositorio.Instance.deletaAtletaDaEquipe(competicao.id, equipe.id, atleta, ref errorMessage)) {
                        equipe.atletas.RemoveAt(dgvAtletas.SelectedCells[0].RowIndex);
                        refreshDataGridView();
                    }else {
                        MessageBox.Show("Houve um erro ao tentar salvar o registro." + Environment.NewLine + Environment.NewLine + errorMessage, "Contate o Suporte técnico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void btnSalvar_Click(object sender, EventArgs e) {
            // Salva as alterações da competição
            Cargo treinador = null, representante = null;
            if (cboTreinador.SelectedIndex > -1)
                treinador = treinadores[cboTreinador.SelectedIndex];
            if (cboRepresentante.SelectedIndex > -1)
                representante = representantes[cboRepresentante.SelectedIndex];

            EquipeCompeticao newEquipe = new EquipeCompeticao(equipe.codigo, equipe.nome, treinador, representante);
            newEquipe.id = equipe.id;
            newEquipe.atletas = equipe.atletas;
            
            for (int iCount = 0; iCount < dgvAtletas.Rows.Count; iCount++) {
                int numAtleta = -1;
                bool isNumber;
                isNumber = int.TryParse(dgvAtletas[nameof(Atleta.Numero), iCount].Value.ToString(), out numAtleta);
                if (isNumber && numAtleta > 0) {
                    newEquipe.atletas[iCount].Numero = numAtleta;
                    newEquipe.atletas[iCount].Numero = numAtleta;
                }
            }

            if (EquipeRepositorio.Instance.updateEquipeCompeticao(newEquipe, competicao)) {
                equipe = newEquipe;
            } else {
                MessageBox.Show("Houve um erro ao tentar salvar o registro." + Environment.NewLine + Environment.NewLine + errorMessage, "Contate o Suporte técnico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            fillFields();

            // Um monte de coisa
            windowMode = Utilidades.WindowMode.ModoNormal;
            windowModeChanged();
        }

        private void btnCancelar_Click(object sender, EventArgs e) {
            fillFields();
            windowMode = Utilidades.WindowMode.ModoNormal;
            windowModeChanged();
        }

        private void btnAtualizar_Click(object sender, EventArgs e) {
            fillFields();
        }
        #endregion
        #region Comportamentos do form
        private void windowModeChanged() {
            switch (windowMode) {
                case Utilidades.WindowMode.ModoNormal:
                case Utilidades.WindowMode.ModoCriacaoForm:
                    btnCancelar.Enabled = false;
                    btnSalvar.Enabled = false;
                    dgvAtletas.Enabled = true;
                    btnAtualizar.Enabled = true;
                    break;
                case Utilidades.WindowMode.ModoDeEdicao:
                    btnCancelar.Enabled = true;
                    btnSalvar.Enabled = true;
                    dgvAtletas.Enabled = false;
                    btnAtualizar.Enabled = false;
                    break;
                case Utilidades.WindowMode.ModoDeInsercao:
                    btnCancelar.Enabled = true;
                    btnSalvar.Enabled = true;
                    dgvAtletas.Enabled = false;
                    btnAtualizar.Enabled = false;
                    break;
            }
        }
        private void dgvEquipes_RowEnter(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex > -1) {
                if (windowMode == Utilidades.WindowMode.ModoNormal)
                    windowMode = Utilidades.WindowMode.ModoCriacaoForm;
                windowMode = Utilidades.WindowMode.ModoNormal;
            }
        }
        private void keyDown(object sender, KeyEventArgs e) {
            if (windowMode != Utilidades.WindowMode.ModoDeInsercao && windowMode != Utilidades.WindowMode.ModoCriacaoForm) {
                windowMode = Utilidades.WindowMode.ModoDeEdicao;
                windowModeChanged();
            }
        }
        private void selectedIndexChanged(object sender, EventArgs e) {
            keyDown(null, null);
        }

        private void dgvAtletas_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
            keyDown(null, null);
        }
        #endregion
    }
}