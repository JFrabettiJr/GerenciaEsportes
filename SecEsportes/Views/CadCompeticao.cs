using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SecEsportes.Infraestrutura;
using SecEsportes.Modelo;
using SecEsportes.Repositorio;

namespace SecEsportes.Views
{
    public partial class CadCompeticao : Form
    {
        private Utilidades.WindowMode windowMode;
        private List<Competicao> competicoes;
        private List<Modalidade> modalidades;
        private string errorMessage;

        #region Inicialização da classe
        public CadCompeticao()
        {
            InitializeComponent();

            // Centraliza o form na tela
            CenterToScreen();

            // Carrega as competições
            competicoes = CompeticaoRepositorio.Instance.get(ref errorMessage);
            if (competicoes is null) {
                MessageBox.Show("Houve um erro ao tentar listar os registros." + Environment.NewLine + Environment.NewLine + errorMessage, "Contate o Suporte técnico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Carrega o combobox das modalidades
            modalidades = ModalidadeRepositorio.Instance.get();
            cboModalidades.Items.Clear();
            for (int iCount = 0; iCount < modalidades.Count; iCount++) {
                cboModalidades.Items.Add(modalidades[iCount].id + " - " + modalidades[iCount].descricao);
            }

            // Recarrega o DataGridView com as competições cadastradas
            refreshDataGridView();
            windowMode = Utilidades.WindowMode.ModoNormal;
            windowModeChanged();
        }
        #endregion
        #region Manipulação do grid
        private void refreshDataGridView()
        {
            dgvCompeticoes.DataSource = null;
            dgvCompeticoes.Refresh();

            dgvCompeticoes.DataSource = competicoes;

            for (var iCount = 0; iCount < dgvCompeticoes.Columns.Count; iCount++)
            {
                switch (dgvCompeticoes.Columns[iCount].DataPropertyName)
                {
                    case nameof(Competicao.nome):
                        dgvCompeticoes.Columns[iCount].HeaderText = "Nome";
                        break;
                    case nameof(Competicao.dataInicial):
                        dgvCompeticoes.Columns[iCount].HeaderText = "Data de início";
                        break;
                    case nameof(Competicao.modalidade):
                        dgvCompeticoes.Columns[iCount].HeaderText = "Modalidade";
                        break;
                    default:
                        dgvCompeticoes.Columns[iCount].Visible = false;
                        break;

                }
            }

            dgvCompeticoes.Refresh();
        }
        #endregion
        #region CRUD
        private void btnAdicionar_Click(object sender, EventArgs e){
            txtNome.Focus();
            txtNome.Text = "";
            txtDtInicio.Text = "";
            cboModalidades.SelectedIndex = -1;
            windowMode = Utilidades.WindowMode.ModoDeInsercao;
            windowModeChanged();
        }
        private void btnCancelar_Click(object sender, EventArgs e){
            txtNome.Text = "";
            txtDtInicio.Text = "";
            cboModalidades.SelectedIndex = -1;
            windowMode = Utilidades.WindowMode.ModoNormal;
            windowModeChanged();
        }
        private void btnSalvar_Click(object sender, EventArgs e){
            Competicao competicao;

            // Cria a variável para converter a Data
            DateTime dataInicio = new DateTime();
            DateTime.TryParseExact(txtDtInicio.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.NoCurrentDateDefault, out dataInicio);

            // Recupera a modalidade selecionada
            Modalidade modalidade = ModalidadeRepositorio.Instance.get(Convert.ToInt32(cboModalidades.SelectedItem.ToString().Substring(0, cboModalidades.SelectedItem.ToString().IndexOf(" - "))));

            // Verifica se vai inserir um novo registro ou então salvá-lo
            if (windowMode == Utilidades.WindowMode.ModoDeInsercao){
                competicao = new Competicao(txtNome.Text, dataInicio, modalidade);
                competicao.status = StatusEnum._1_Aberta;

                // Tenta inserir a competição
                if (CompeticaoRepositorio.Instance.insert(ref competicao, ref errorMessage)){
                    competicoes.Add(competicao);
                    refreshDataGridView();
                    txtNome.Text = "";
                    txtDtInicio.Text = "";
                    cboModalidades.SelectedIndex = -1;
                }else {
                    MessageBox.Show("Houve um erro ao tentar inserir o registro." + Environment.NewLine + Environment.NewLine + errorMessage, "Contate o Suporte técnico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }else {
                if (dgvCompeticoes.SelectedCells.Count > 0) {
                    competicao = competicoes[dgvCompeticoes.SelectedCells[0].RowIndex];
                    competicao.nome = txtNome.Text;
                    competicao.dataInicial = dataInicio;
                    competicao.modalidade = modalidade;
                    competicao.status = StatusEnum._1_Aberta;

                    // Salva as alterações da competição
                    if (CompeticaoRepositorio.Instance.update(competicao, ref errorMessage)) {
                        competicoes[dgvCompeticoes.SelectedCells[0].RowIndex] = competicao;
                        refreshDataGridView();
                    }else {
                        txtNome.Text = competicoes[dgvCompeticoes.SelectedCells[0].RowIndex].nome;
                        txtDtInicio.Text = competicoes[dgvCompeticoes.SelectedCells[0].RowIndex].dataInicial.ToString("dd/MM/yyyy");
                        cboModalidades.SelectedIndex = -1;
                        MessageBox.Show("Houve um erro ao tentar salvar o registro." + Environment.NewLine + Environment.NewLine + errorMessage, "Contate o Suporte técnico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            windowMode = Utilidades.WindowMode.ModoNormal;
            windowModeChanged();
        }
        private void btnExcluir_Click(object sender, EventArgs e){
            if (dgvCompeticoes.SelectedCells.Count > 0) {
                Competicao competicao;
                competicao = competicoes[dgvCompeticoes.SelectedCells[0].RowIndex];
                if (MessageBox.Show("Confirma a deleção do registro ?" +
                    Environment.NewLine + Environment.NewLine +
                    competicao.ToString(), "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    if (CompeticaoRepositorio.Instance.delete(competicao, ref errorMessage)) {
                        competicoes.RemoveAt(dgvCompeticoes.SelectedCells[0].RowIndex);
                        refreshDataGridView();
                        txtNome.Text = "";
                        txtNome.Text = "";
                    }else{
                        MessageBox.Show("Houve um erro ao tentar deletar o registro." + Environment.NewLine + Environment.NewLine + errorMessage, "Contate o Suporte técnico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void btnAtualizar_Click(object sender, EventArgs e) {
            competicoes = CompeticaoRepositorio.Instance.get(ref errorMessage);
            if (competicoes is null) {
                MessageBox.Show("Houve um erro ao tentar listar os registros." + Environment.NewLine + Environment.NewLine + errorMessage, "Contate o Suporte técnico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            refreshDataGridView();
        }
        #endregion
        #region Comportamentos do form
        private void windowModeChanged() {
            switch (windowMode) {
                case Utilidades.WindowMode.ModoNormal: case Utilidades.WindowMode.ModoCriacaoForm:
                    btnCancelar.Enabled = false;
                    btnSalvar.Enabled = false;
                    btnAdicionar.Enabled = true;
                    btnExcluir.Enabled = true;
                    dgvCompeticoes.Enabled = true;
                    btnAtualizar.Enabled = true;
                    break;
                case Utilidades.WindowMode.ModoDeEdicao:
                    btnCancelar.Enabled = true;
                    btnSalvar.Enabled = true;
                    btnAdicionar.Enabled = false;
                    btnExcluir.Enabled = false;
                    dgvCompeticoes.Enabled = false;
                    btnAtualizar.Enabled = false;
                    break;
                case Utilidades.WindowMode.ModoDeInsercao:
                    btnCancelar.Enabled = true;
                    btnSalvar.Enabled = true;
                    btnAdicionar.Enabled = false;
                    btnExcluir.Enabled = false;
                    dgvCompeticoes.Enabled = false;
                    btnAtualizar.Enabled = false;
                    break;
            }
        }
        private void dgvEquipes_RowEnter(object sender, DataGridViewCellEventArgs e) {
            if (windowMode == Utilidades.WindowMode.ModoNormal)
                windowMode = Utilidades.WindowMode.ModoCriacaoForm;
            txtNome.Text = competicoes[e.RowIndex].nome;
            txtDtInicio.Text = competicoes[e.RowIndex].dataInicial.ToString("dd/MM/yyyy");
            //cboModalidades.SelectedIndex = modalidades.FindIndex(modalidade => modalidade.id == competicoes[e.RowIndex].modalidade.id);
            windowMode = Utilidades.WindowMode.ModoNormal;
        }
        private void fields_KeyDown(object sender, KeyEventArgs e) {
            if (windowMode != Utilidades.WindowMode.ModoDeInsercao && windowMode != Utilidades.WindowMode.ModoCriacaoForm) {
                windowMode = Utilidades.WindowMode.ModoDeEdicao;
                windowModeChanged();
            }
        }
        private void cboModalidades_SelectedIndexChanged(object sender, EventArgs e) {
            fields_KeyDown(null, null);
        }
        private void dgvCompeticoes_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e) {
            Competicao competicao = competicoes[e.RowIndex];
            new EditCompeticao(competicao).ShowDialog();
        }
        #endregion
    }
}