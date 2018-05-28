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

        private Usuario usuarioLogado;

        #region Inicialização da classe
        public EditEquipe(Usuario usuarioLogado, EquipeCompeticao equipe, Competicao competicao) {
            InitializeComponent();

            CenterToScreen();

            this.usuarioLogado = usuarioLogado;

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

            refreshDataGridView(dgvAtletas, equipe.atletas);

            // Carrega os atletas suspensos
            List<Competicao_Suspensao> suspensoes = CompeticaoRepositorio.Instance.getSuspensoesPorEquipe(competicao.id, equipe.id);
            List<Atleta> atletasSuspensos = equipe.atletas.FindAll(find => suspensoes.FindAll(find2 => find2.atleta.pessoa.id == find.pessoa.id).Count > 0);
            refreshDataGridView(dgvAtletasSuspensos, atletasSuspensos, suspensoes);
        }

        private void load(object sender, EventArgs e) {
            equipe.comissaotecnica = EquipeRepositorio.Instance.getFuncoesByEquipeCompeticao(competicao.id, equipe.id);
            equipe.atletas = PessoaRepositorio.Instance.getAtletasByEquipeCompeticao(competicao.id, equipe.id);

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

            if (competicao.status != StatusEnum._1_Aberta && competicao.status != StatusEnum._3_EmPreparacao) {
                cboRepresentante.Enabled = false;
                cboTreinador.Enabled = false;
                btnIncluirAtleta.Enabled = false;
                btnExcluirAtleta.Enabled = false;
            }

            fillFields();
        }
        #endregion
        #region Manipulação do grid
        private void refreshDataGridView(DataGridView dataGridViewAtletas, List<Atleta> atletas) {
            refreshDataGridView(dataGridViewAtletas, atletas, null);
        }
        private void refreshDataGridView(DataGridView dataGridViewAtletas, List<Atleta> atletas, List<Competicao_Suspensao> suspensoes) {
            dataGridViewAtletas.DataSource = null;
            dataGridViewAtletas.Refresh();

            dataGridViewAtletas.Columns.Clear();

            dataGridViewAtletas.DataSource = atletas;

            // Cria duas novas colunas
            dataGridViewAtletas.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = nameof(Pessoa.nome) });
            dataGridViewAtletas.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = nameof(Pessoa.dataNascimento) });
            if (!(suspensoes is null))
                dataGridViewAtletas.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = "JogosSuspenso" });

            for (var iCount = 0; iCount < dataGridViewAtletas.Columns.Count; iCount++) {
                switch (dataGridViewAtletas.Columns[iCount].DataPropertyName) {
                    case nameof(Pessoa.nome):
                        dataGridViewAtletas.Columns[iCount].Name = dataGridViewAtletas.Columns[iCount].DataPropertyName;
                        dataGridViewAtletas.Columns[iCount].HeaderText = "Nome";
                        dataGridViewAtletas.Columns[iCount].Width = 150;
                        dataGridViewAtletas.Columns[iCount].ReadOnly = true;
                        break;
                    case nameof(Pessoa.dataNascimento):
                        dataGridViewAtletas.Columns[iCount].Name = dataGridViewAtletas.Columns[iCount].DataPropertyName;
                        dataGridViewAtletas.Columns[iCount].HeaderText = "Data de nascimento";
                        dataGridViewAtletas.Columns[iCount].Width = 100;
                        dataGridViewAtletas.Columns[iCount].ReadOnly = true;
                        break;
                    case nameof(Atleta.numero):
                        dataGridViewAtletas.Columns[iCount].Name = dataGridViewAtletas.Columns[iCount].DataPropertyName;
                        dataGridViewAtletas.Columns[iCount].HeaderText = "Númeração";
                        dataGridViewAtletas.Columns[iCount].Width = 75;
                        dataGridViewAtletas.Columns[iCount].ValueType = typeof(Int32);
                        if (!(suspensoes is null))
                            dataGridViewAtletas.Columns[iCount].Visible = false;
                        break;
                    case "JogosSuspenso":
                        dataGridViewAtletas.Columns[iCount].Name = dataGridViewAtletas.Columns[iCount].DataPropertyName;
                        dataGridViewAtletas.Columns[iCount].HeaderText = "Jogos de suspenção";
                        dataGridViewAtletas.Columns[iCount].Width = 75;
                        dataGridViewAtletas.Columns[iCount].ValueType = typeof(Int32);
                        break;
                    default:
                        dataGridViewAtletas.Columns[iCount].Visible = false;
                        break;
                }
            }

            //Preenche os campos que vieram sem preenchimento do data set
            for (var iCount = 0; iCount < dataGridViewAtletas.Rows.Count; iCount++) {
                dataGridViewAtletas.Rows[iCount].Cells[nameof(Pessoa.nome)].Value = atletas[iCount].pessoa.nome;
                dataGridViewAtletas.Rows[iCount].Cells[nameof(Pessoa.dataNascimento)].Value = atletas[iCount].pessoa.dataNascimento.ToString("dd/MM/yyyy");

                if (!(suspensoes is null)) {
                    int numJogosSuspenso = suspensoes.Find(find => find.atleta.pessoa.id == atletas[iCount].pessoa.id).numJogosSuspensao;
                    dataGridViewAtletas.Rows[iCount].Cells["JogosSuspenso"].Value = numJogosSuspenso;
                }

            }

            dataGridViewAtletas.Refresh();
        }
        #endregion
        #region CRUD
        private void btnIncluirAtleta_Click(object sender, EventArgs e) {
            insertAtletaForm = new InsertAtleta(usuarioLogado, competicao.id);
            insertAtletaForm.FormClosing += insertEquipeForm_FormClosing;
            insertAtletaForm.ShowDialog();
        }

        private void insertEquipeForm_FormClosing(object sender, FormClosingEventArgs e) {
            foreach (Atleta_Insert atleta in insertAtletaForm.atletasAInserir) {
                equipe.atletas.Add(new Atleta(atleta.id, atleta.funcao, atleta.pessoa, null));
                EquipeRepositorio.Instance.insertAtletaEmEquipe(competicao.id, equipe.id, atleta);
            }
            refreshDataGridView(dgvAtletas, equipe.atletas);
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
                        refreshDataGridView(dgvAtletas, equipe.atletas);
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
                isNumber = int.TryParse(dgvAtletas[nameof(Atleta.numero), iCount].Value.ToString(), out numAtleta);
                if (isNumber && numAtleta > 0) {
                    newEquipe.atletas[iCount].numero = numAtleta;
                    newEquipe.atletas[iCount].numero = numAtleta;
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