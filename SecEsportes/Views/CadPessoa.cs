using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SecEsportes.Infraestrutura;
using SecEsportes.Modelo;
using SecEsportes.Repositorio;

namespace SecEsportes.Views
{
    public partial class CadPessoa : Form
    {
        private Utilidades.WindowMode windowMode;
        private List<Pessoa> pessoas;
        private List<Funcao> funcoes;
        private string errorMessage;

        #region Inicialização da classe
        public CadPessoa()
        {
            InitializeComponent();
            CenterToScreen();
            pessoas = PessoaRepositorio.Instance.get(ref errorMessage);
            if (pessoas is null) {
                MessageBox.Show("Houve um erro ao tentar listar os registros." + Environment.NewLine + Environment.NewLine + errorMessage, "Contate o Suporte técnico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            funcoes = FuncaoRepositorio.Instance.get(ref errorMessage);
            refreshDataGridView();
            loadFuncoes();
            windowMode = Utilidades.WindowMode.ModoNormal;
            windowModeChanged();
        }

        private void loadFuncoes() {
            for (int iCount = 0; iCount < funcoes.Count; iCount++) {
                chkLstFuncoes.Items.Add(funcoes[iCount].codigo + " - " + funcoes[iCount].descricao);
            }
        }
        #endregion
        #region Manipulação do grid
        private void refreshDataGridView()
        {
            dgvPessoas.DataSource = null;
            dgvPessoas.Refresh();

            dgvPessoas.DataSource = pessoas;

            for (var iCount = 0; iCount < dgvPessoas.Columns.Count; iCount++)
            {
                switch (dgvPessoas.Columns[iCount].DataPropertyName)
                {
                    case nameof(Pessoa.id):
                        dgvPessoas.Columns[iCount].Visible = false;
                        break;
                    case nameof(Pessoa.cpf):
                        dgvPessoas.Columns[iCount].HeaderText = "CPF";
                        break;
                    case nameof(Pessoa.nome):
                        dgvPessoas.Columns[iCount].HeaderText = "Nome";
                        break;
                    case nameof(Pessoa.dataNascimento):
                        dgvPessoas.Columns[iCount].HeaderText = "Data de nascimento";
                        break;
                }
            }

            dgvPessoas.Refresh();
        }
        #endregion
        #region CRUD
        private void btnAdicionar_Click(object sender, EventArgs e){
            txtCPF.Focus();
            txtCPF.Text = "";
            txtNome.Text = "";
            txtDtNascimento.Text = "";
            chkLstFuncoes.ClearSelected();
            windowMode = Utilidades.WindowMode.ModoDeInsercao;
            windowModeChanged();
        }
        private void btnCancelar_Click(object sender, EventArgs e){
            txtCPF.Text = "";
            txtNome.Text = "";
            txtDtNascimento.Text = "";
            chkLstFuncoes.ClearSelected();
            windowMode = Utilidades.WindowMode.ModoNormal;
            windowModeChanged();
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Pessoa Pessoa;
            DateTime dataAniversario;
            if (DateTime.TryParseExact(txtDtNascimento.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.NoCurrentDateDefault, out dataAniversario)) {
                if (windowMode == Utilidades.WindowMode.ModoDeInsercao) {
                    Pessoa = new Pessoa(txtCPF.Text, txtNome.Text, dataAniversario);
                    Pessoa.funcoes = getFuncoesSelecionadas();
                    if (PessoaRepositorio.Instance.insert(ref Pessoa, ref errorMessage)) {
                        pessoas.Add(Pessoa);
                        refreshDataGridView();
                        txtCPF.Text = "";
                        txtNome.Text = "";
                        txtDtNascimento.Text = "";
                        chkLstFuncoes.ClearSelected();
                    }else {
                        MessageBox.Show("Houve um erro ao tentar inserir o registro." + Environment.NewLine + Environment.NewLine + errorMessage, "Contate o Suporte técnico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }else {
                    if (dgvPessoas.SelectedCells.Count > 0) {
                        Pessoa = pessoas[dgvPessoas.SelectedCells[0].RowIndex];
                        Pessoa.cpf = txtCPF.Text;
                        Pessoa.nome = txtNome.Text;
                        Pessoa.dataNascimento = dataAniversario;
                        Pessoa.funcoes = getFuncoesSelecionadas();
                        if (PessoaRepositorio.Instance.update(Pessoa, ref errorMessage)) {
                            pessoas[dgvPessoas.SelectedCells[0].RowIndex] = Pessoa;
                            refreshDataGridView();
                        }else {
                            txtCPF.Text = pessoas[dgvPessoas.SelectedCells[0].RowIndex].cpf;
                            txtNome.Text = pessoas[dgvPessoas.SelectedCells[0].RowIndex].nome;
                            txtDtNascimento.Text = pessoas[dgvPessoas.SelectedCells[0].RowIndex].dataNascimento.ToString("dd/MM/yyyy");
                            MessageBox.Show("Houve um erro ao tentar salvar o registro." + Environment.NewLine + Environment.NewLine + errorMessage, "Contate o Suporte técnico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    
                }

                windowMode = Utilidades.WindowMode.ModoNormal;
                windowModeChanged();
            }
        }

        private List<Funcao> getFuncoesSelecionadas() {
            List<Funcao> selecionadas = new List<Funcao>();
            for (int iCount = 0; iCount < chkLstFuncoes.CheckedItems.Count; iCount++) {
                string strFuncao = chkLstFuncoes.CheckedItems[iCount].ToString();
                Funcao funcao = new Funcao(strFuncao.Substring(0, strFuncao.IndexOf(" - ")), strFuncao.Substring(strFuncao.IndexOf(" - ") + 3));
                selecionadas.Add(funcao);
            }
            return selecionadas;
        }

        private void setFuncoesSelecionadas(List<Funcao> funcoes) {
            for(int iCount = 0; iCount < chkLstFuncoes.Items.Count; iCount++) {
                string codFuncao = chkLstFuncoes.Items[iCount].ToString().Substring(0, chkLstFuncoes.Items[iCount].ToString().IndexOf(" - "));
                if (funcoes.Exists(funcao => funcao.codigo.Equals(codFuncao))) {
                    chkLstFuncoes.SetItemChecked(iCount, true);
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvPessoas.SelectedCells.Count > 0) {
                Pessoa Pessoa;
                Pessoa = pessoas[dgvPessoas.SelectedCells[0].RowIndex];
                if (MessageBox.Show("Confirma a deleção do registro ?" +
                    Environment.NewLine + Environment.NewLine +
                    Pessoa.ToString(), "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    if (PessoaRepositorio.Instance.delete(Pessoa, ref errorMessage)) {
                        pessoas.RemoveAt(dgvPessoas.SelectedCells[0].RowIndex);
                        refreshDataGridView();
                        txtCPF.Text = "";
                        txtNome.Text = "";
                        txtDtNascimento.Text = "";
                        chkLstFuncoes.ClearSelected();
                    }else {
                        MessageBox.Show("Houve um erro ao tentar salvar o registro." + Environment.NewLine + Environment.NewLine + errorMessage, "Contate o Suporte técnico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void btnAtualizar_Click(object sender, EventArgs e) {
            pessoas = PessoaRepositorio.Instance.get(ref errorMessage);
            if (pessoas is null) {
                MessageBox.Show("Houve um erro ao tentar listar os registros." + Environment.NewLine + Environment.NewLine + errorMessage, "Contate o Suporte técnico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            refreshDataGridView();
        }
        #endregion
        #region Comportamentos do form
        private void windowModeChanged() {
            switch (windowMode) {
                case Utilidades.WindowMode.ModoNormal:
                    btnCancelar.Enabled = false;
                    btnSalvar.Enabled = false;
                    btnAdicionar.Enabled = true;
                    btnExcluir.Enabled = true;
                    dgvPessoas.Enabled = true;
                    btnAtualizar.Enabled = true;
                    break;
                case Utilidades.WindowMode.ModoDeEdicao:
                    btnCancelar.Enabled = true;
                    btnSalvar.Enabled = true;
                    btnAdicionar.Enabled = false;
                    btnExcluir.Enabled = false;
                    dgvPessoas.Enabled = false;
                    btnAtualizar.Enabled = false;
                    break;
                case Utilidades.WindowMode.ModoDeInsercao:
                    btnCancelar.Enabled = true;
                    btnSalvar.Enabled = true;
                    btnAdicionar.Enabled = false;
                    btnExcluir.Enabled = false;
                    dgvPessoas.Enabled = false;
                    btnAtualizar.Enabled = false;
                    break;
            }
        }
        private void dgvPessoas_RowEnter(object sender, DataGridViewCellEventArgs e) {
            txtCPF.Text = pessoas[e.RowIndex].cpf;
            txtNome.Text = pessoas[e.RowIndex].nome;
            txtDtNascimento.Text = pessoas[e.RowIndex].dataNascimento.ToString("dd/MM/yyyy");
            setFuncoesSelecionadas(pessoas[e.RowIndex].funcoes);
        }
        private void fields_KeyDown(object sender, KeyEventArgs e) {
            if (windowMode != Utilidades.WindowMode.ModoDeInsercao) {
                windowMode = Utilidades.WindowMode.ModoDeEdicao;
                windowModeChanged();
            }
        }
        private void chkLstFuncoes_ItemCheck(object sender, ItemCheckEventArgs e) {
            fields_KeyDown(sender, null);
        }
        #endregion
    }
}