using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SecEsportes.Infraestrutura;
using SecEsportes.Modelo;
using SecEsportes.Repositorio;

namespace SecEsportes.Views
{
    public partial class EditCompeticao : Form
    {
        private Utilidades.WindowMode windowMode;
        private List<EquipeCompeticao> equipes;
        private List<Modalidade> modalidades;
        private Competicao competicao;
        private string errorMessage;
        private InsertEquipe insertEquipeForm;

        #region Inicialização da classe
        public EditCompeticao(Competicao competicao)
        {
            windowMode = Utilidades.WindowMode.ModoCriacaoForm;
            InitializeComponent();

            // Centraliza a tela
            CenterToScreen();

            this.competicao = competicao;
            
            clearFields();
            fillFields();
        }
        #endregion
        #region Manipulação do grid
        private void refreshDataGridView()
        {
            dgvEquipes.DataSource = null;
            dgvEquipes.Refresh();

            dgvEquipes.DataSource = equipes;

            for (var iCount = 0; iCount < dgvEquipes.Columns.Count; iCount++)
            {
                switch (dgvEquipes.Columns[iCount].DataPropertyName)
                {
                    case nameof(EquipeCompeticao.nome):
                        dgvEquipes.Columns[iCount].HeaderText = "Nome da equipe";
                        break;
                    case nameof(EquipeCompeticao.codigo):
                        dgvEquipes.Columns[iCount].HeaderText = "Código";
                        break;
                    case nameof(EquipeCompeticao.representante):
                        dgvEquipes.Columns[iCount].HeaderText = "Representante";
                        break;
                    case nameof(EquipeCompeticao.treinador):
                        dgvEquipes.Columns[iCount].HeaderText = "Treinador";
                        break;
                    default:
                        dgvEquipes.Columns[iCount].Visible = false;
                        break;
                }
            }

            dgvEquipes.Refresh();
        }
        #endregion
        #region CRUD
        private void btnAdicionar_Click(object sender, EventArgs e){
            clearFields();
            txtNome.Focus();
            windowMode = Utilidades.WindowMode.ModoDeInsercao;
            windowModeChanged();
        }
        private void btnCancelar_Click(object sender, EventArgs e){
            clearFields();
            fillFields();
            windowMode = Utilidades.WindowMode.ModoNormal;
            windowModeChanged();
        }
        private void btnSalvar_Click(object sender, EventArgs e){
            Modalidade modalidade = ModalidadeRepositorio.Instance.get(Convert.ToInt32(cboModalidades.SelectedItem.ToString().Substring(0, cboModalidades.SelectedItem.ToString().IndexOf(" - "))));

            DateTime dataInicio = new DateTime(), dataFim_aux = new DateTime();
            DateTime? dataFim = null;
            DateTime.TryParseExact(txtDtInicio.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.NoCurrentDateDefault, out dataInicio);
            if (txtDtFim.MaskCompleted) {
                DateTime.TryParseExact(txtDtFim.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.NoCurrentDateDefault, out dataFim_aux);
                dataFim = dataFim_aux;
            }

            Competicao newCompeticao = new Competicao(txtNome.Text, dataInicio, modalidade);
            newCompeticao.id = competicao.id;
            newCompeticao.dataInicial = dataInicio;
            if (!(dataFim is null)) {
                newCompeticao.dataFinal = dataFim;
            }
            newCompeticao.modalidade = modalidade;
            newCompeticao.numTimes = Convert.ToInt32(txtNumTimes.Text);
            newCompeticao.numGrupos = Convert.ToInt32(txtNumGrupos.Text);
            switch (cboMataMata.SelectedIndex) {
                case 0:
                    newCompeticao.mataMata = MataMataEnum._1_Nao;
                    break;
                case 1:
                    newCompeticao.mataMata = MataMataEnum._2_Final;
                    break;
                case 2:
                    newCompeticao.mataMata = MataMataEnum._3_SemiFinal;
                    break;
                case 3:
                    newCompeticao.mataMata = MataMataEnum._4_QuartasFinal;
                    break;
                case 4:
                    newCompeticao.mataMata = MataMataEnum._5_OitavasFinal;
                    break;
                case 5:
                    newCompeticao.mataMata = MataMataEnum._6_16AvosFinal;
                    break;
                case 6:
                    newCompeticao.mataMata = MataMataEnum._7_32AvosFinal;
                    break;
            }
            newCompeticao.jogosIdaEVolta = chkIdaEVolta.Checked;
            newCompeticao.jogosIdaEVolta_MataMata = chkIdaEVoltaMataMata.Checked;

            if (CompeticaoRepositorio.Instance.update(newCompeticao, ref errorMessage)) {
                competicao = newCompeticao;
            }else {
                fillFields();
                MessageBox.Show("Houve um erro ao tentar salvar o registro." + Environment.NewLine + Environment.NewLine + errorMessage, "Contate o Suporte técnico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            windowMode = Utilidades.WindowMode.ModoNormal;
            windowModeChanged();
        }

        private void btnExcluir_Click(object sender, EventArgs e){
            if (dgvEquipes.SelectedCells.Count > 0) {
                EquipeCompeticao equipe;
                equipe = equipes[dgvEquipes.SelectedCells[0].RowIndex];
                if (MessageBox.Show("Confirma a deleção do registro ?" +
                    Environment.NewLine + Environment.NewLine +
                    equipe.ToString(), "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    if (CompeticaoRepositorio.Instance.deleteEquipe(equipe, ref errorMessage)) {
                        equipes.RemoveAt(dgvEquipes.SelectedCells[0].RowIndex);
                        refreshDataGridView();
                        clearFields();
                    }else {
                        MessageBox.Show("Houve um erro ao tentar salvar o registro." + Environment.NewLine + Environment.NewLine + errorMessage, "Contate o Suporte técnico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void btnAtualizar_Click(object sender, EventArgs e) {
            equipes = EquipeRepositorio.Instance.getEquipesByCompeticao(competicao.id);
            if (equipes is null) {
                MessageBox.Show("Houve um erro ao tentar listar os registros." + Environment.NewLine + Environment.NewLine + errorMessage, "Contate o Suporte técnico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            refreshDataGridView();
        }
        private void btnIniciarCompeticao_Click(object sender, EventArgs e) {
            /*  Requisitos para poder iniciar o campeonato
             *      - Ter o numero de times conforme definido na competição
             *      - Ter o número de jogadores mínimos em cada equipe
             *      - O número de grupos deve ser maior que 0
             */
        }
        private void btnIncluirEquipes_Click(object sender, EventArgs e) {
            insertEquipeForm = new InsertEquipe(competicao.id);
            insertEquipeForm.FormClosing += insertEquipeForm_FormClosing;
            insertEquipeForm.Show();
        }

        private void insertEquipeForm_FormClosing(object sender, FormClosingEventArgs e) {
            for (int iCount = 0; iCount < insertEquipeForm.equipesAInserir.Count; iCount++) {
                equipes.Add(new EquipeCompeticao(insertEquipeForm.equipesAInserir[iCount].codigo, insertEquipeForm.equipesAInserir[iCount].nome, null, null));
                CompeticaoRepositorio.Instance.insertEquipeEmCompeticao(competicao.id, insertEquipeForm.equipesAInserir[iCount]);
            }
            refreshDataGridView();
        }
        private void btnExcluirEquipe_Click(object sender, EventArgs e) {
            if (dgvEquipes.SelectedCells.Count > 0) {
                EquipeCompeticao equipe;
                equipe = equipes[dgvEquipes.SelectedCells[0].RowIndex];
                if (MessageBox.Show("Confirma a deleção do registro ?" +
                    Environment.NewLine + Environment.NewLine +
                    equipe.ToString(), "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    if (EquipeRepositorio.Instance.deleteEquipeDaCompeticao(equipe, competicao.id, ref errorMessage)) {
                        equipes.RemoveAt(dgvEquipes.SelectedCells[0].RowIndex);
                        refreshDataGridView();
                    }
                    else {
                        MessageBox.Show("Houve um erro ao tentar salvar o registro." + Environment.NewLine + Environment.NewLine + errorMessage, "Contate o Suporte técnico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        #endregion
        #region Comportamentos do form
        private void clearFields(){
            txtNome.Text = "";
            txtDtInicio.Text = "";
            txtDtFim.Text = "";
            cboModalidades.SelectedIndex = -1;
            txtNumTimes.Text = "0";
            txtNumGrupos.Text = "0";
            cboMataMata.SelectedIndex = -1;
            chkIdaEVolta.Checked = false;
            chkIdaEVoltaMataMata.Checked = false;
            cboNomeacaoGrupos.SelectedIndex = -1;
            txtStatus.Text = "";
        }
        private void fillFields() {
            // Carrega as equipes
            equipes = EquipeRepositorio.Instance.getEquipesByCompeticao(competicao.id, ref errorMessage);
            if (equipes is null) {
                MessageBox.Show("Houve um erro ao tentar listar os registros." + Environment.NewLine + Environment.NewLine + errorMessage, "Contate o Suporte técnico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Carrega o combobox das modalidades
            modalidades = ModalidadeRepositorio.Instance.get();
            cboModalidades.Items.Clear();
            for (int iCount = 0; iCount < modalidades.Count; iCount++) {
                cboModalidades.Items.Add(modalidades[iCount].id + " - " + modalidades[iCount].descricao);
            }

            // Carrega o combobox das opções de mata-mata (conferir o MataMataEnum da classe Competicao)
            cboMataMata.Items.Clear();
            cboMataMata.Items.Add("Não");               //_1_Nao,
            cboMataMata.Items.Add("Final");             //_2_Final,
            cboMataMata.Items.Add("Semi-Final");        //_3_SemiFinal,
            cboMataMata.Items.Add("Quartas de Final");  //_4_QuartasFinal,
            cboMataMata.Items.Add("Oitavas de Final");  //_5_OitavasFinal,
            cboMataMata.Items.Add("16 avos de Final");  //_6_16AvosFinal,
            cboMataMata.Items.Add("32 avos de Final");  //_7_32AvosFinal

            // Carrega o combobox das opções de nomeação dos grupos
            cboNomeacaoGrupos.Items.Clear();
            cboNomeacaoGrupos.Items.Add("Por numeração");
            cboNomeacaoGrupos.Items.Add("Por letras");

            // Preenche os campos
            txtNome.Text = competicao.nome;
            txtDtInicio.Text = competicao.dataInicial.ToString("dd/MM/yyyy");
            if (!(competicao.dataFinal is null)) {
                txtDtFim.Text = ((DateTime)competicao.dataFinal).ToString("dd/MM/yyyy");
            }
            cboModalidades.SelectedIndex = modalidades.FindIndex(modalidade => modalidade.id == competicao.modalidade.id);
            txtNumTimes.Text = competicao.numTimes.ToString();
            txtNumGrupos.Text = competicao.numGrupos.ToString();
            switch (competicao.mataMata) {
                case MataMataEnum._1_Nao:
                    cboMataMata.SelectedIndex = 0;
                    break;
                case MataMataEnum._2_Final:
                    cboMataMata.SelectedIndex = 1;
                    break;
                case MataMataEnum._3_SemiFinal:
                    cboMataMata.SelectedIndex = 2;
                    break;
                case MataMataEnum._4_QuartasFinal:
                    cboMataMata.SelectedIndex = 3;
                    break;
                case MataMataEnum._5_OitavasFinal:
                    cboMataMata.SelectedIndex = 4;
                    break;
                case MataMataEnum._6_16AvosFinal:
                    cboMataMata.SelectedIndex = 5;
                    break;
                case MataMataEnum._7_32AvosFinal:
                    cboMataMata.SelectedIndex = 6;
                    break;
            }
            switch (competicao.status) {
                case StatusEnum._0_Encerrada:
                    txtStatus.Text = "Competição encerrada";
                    break;
                case StatusEnum._1_Aberta:
                    txtStatus.Text = "Competição aberta";
                    break;
                case StatusEnum._2_Iniciada:
                    txtStatus.Text = "Competição iniciada";
                    break;
                default:
                    txtStatus.Text = "";
                    break;
            }
            chkIdaEVolta.Checked = competicao.jogosIdaEVolta;
            chkIdaEVoltaMataMata.Checked = competicao.jogosIdaEVolta_MataMata;

            // Recarrega o DataGrid View das Equipes
            refreshDataGridView();
            windowMode = Utilidades.WindowMode.ModoNormal;
            windowModeChanged();
        }
        private void windowModeChanged() {
            switch (windowMode) {
                case Utilidades.WindowMode.ModoNormal: case Utilidades.WindowMode.ModoCriacaoForm:
                    btnCancelar.Enabled = false;
                    btnSalvar.Enabled = false;
                    dgvEquipes.Enabled = true;
                    btnAtualizar.Enabled = true;
                    break;
                case Utilidades.WindowMode.ModoDeEdicao:
                    btnCancelar.Enabled = true;
                    btnSalvar.Enabled = true;
                    dgvEquipes.Enabled = false;
                    btnAtualizar.Enabled = false;
                    break;
                case Utilidades.WindowMode.ModoDeInsercao:
                    btnCancelar.Enabled = true;
                    btnSalvar.Enabled = true;
                    dgvEquipes.Enabled = false;
                    btnAtualizar.Enabled = false;
                    break;
            }
        }
        private void dgvEquipes_RowEnter(object sender, DataGridViewCellEventArgs e) {

        }
        private void fields_KeyDown(object sender, KeyEventArgs e) {
            if (windowMode != Utilidades.WindowMode.ModoDeInsercao && windowMode != Utilidades.WindowMode.ModoCriacaoForm) {
                windowMode = Utilidades.WindowMode.ModoDeEdicao;
                windowModeChanged();
            }
        }
        private void checkBox_CheckedChange(object sender, EventArgs e) {
            fields_KeyDown(sender, null);
        }
        private void comboBox_SelectedIndexChanged(object sender, EventArgs e) {
            fields_KeyDown(sender, null);
        }
        #endregion
    }
}