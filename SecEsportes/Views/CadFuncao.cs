using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SecEsportes.Infraestrutura;
using SecEsportes.Modelo;
using SecEsportes.Repositorio;

namespace SecEsportes.Views
{
    public partial class CadFuncao : Form
    {
        private Utilidades.WindowMode windowMode;
        private List<Funcao> funcoes;

        #region Inicialização da classe
        public CadFuncao()
        {
            InitializeComponent();
            CenterToScreen();
            funcoes = FuncaoRepositorio.Instance.get();
            refreshDataGridView();
            windowMode = Utilidades.WindowMode.ModoNormal;
            windowModeChanged();
        }
        #endregion
        #region Manipulação do grid
        private void refreshDataGridView()
        {
            dgvFuncoes.DataSource = null;
            dgvFuncoes.Refresh();

            dgvFuncoes.DataSource = funcoes;

            for (var iCount = 0; iCount < dgvFuncoes.Columns.Count; iCount++)
            {
                switch (dgvFuncoes.Columns[iCount].DataPropertyName)
                {
                    case nameof(Funcao.id):
                        dgvFuncoes.Columns[iCount].Visible = false;
                        break;
                    case nameof(Funcao.codigo):
                        dgvFuncoes.Columns[iCount].HeaderText = "Código";
                        break;
                    case nameof(Funcao.descricao):
                        dgvFuncoes.Columns[iCount].HeaderText = "Descrição";
                        break;
                }
            }

            dgvFuncoes.Refresh();
        }
        #endregion
        #region CRUD
        private void btnAdicionar_Click(object sender, EventArgs e){
            txtCdFuncao.Focus();
            windowMode = Utilidades.WindowMode.ModoDeInsercao;
            windowModeChanged();
        }
        private void btnCancelar_Click(object sender, EventArgs e){
            txtCdFuncao.Text = "";
            txtDescFuncao.Text = "";
            windowMode = Utilidades.WindowMode.ModoNormal;
            windowModeChanged();
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Funcao funcao;
            if (windowMode == Utilidades.WindowMode.ModoDeInsercao){
                funcao = new Funcao(txtCdFuncao.Text, txtDescFuncao.Text);
                if (FuncaoRepositorio.Instance.insert(ref funcao)){
                    funcoes.Add(funcao);
                    refreshDataGridView();
                    txtCdFuncao.Text = "";
                    txtDescFuncao.Text = "";
                }
            }
            else {
                funcao = funcoes[dgvFuncoes.SelectedCells[0].RowIndex];
                funcao.codigo = txtCdFuncao.Text;
                funcao.descricao = txtDescFuncao.Text;
                if (FuncaoRepositorio.Instance.update(funcao)) {
                    funcoes[dgvFuncoes.SelectedCells[0].RowIndex] = funcao;
                    refreshDataGridView();
                }
                else {
                    txtCdFuncao.Text = funcoes[dgvFuncoes.SelectedCells[0].RowIndex].codigo;
                    txtDescFuncao.Text = funcoes[dgvFuncoes.SelectedCells[0].RowIndex].descricao;
                }
            }

            windowMode = Utilidades.WindowMode.ModoNormal;
            windowModeChanged();
        }
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Funcao funcao;
            funcao = funcoes[dgvFuncoes.SelectedCells[0].RowIndex];
            if (MessageBox.Show("Confirma a deleção do registro ?" +
                Environment.NewLine + Environment.NewLine +
                funcao.ToString(), "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes){
                if (FuncaoRepositorio.Instance.delete(funcao)){
                    funcoes.RemoveAt(dgvFuncoes.SelectedCells[0].RowIndex);
                    refreshDataGridView();
                    txtCdFuncao.Text = "";
                    txtDescFuncao.Text = "";
                }else{
                    MessageBox.Show("Houve um erro ao tentar realizar a deleção do registro.");
                }
            }
        }
        private void btnAtualizar_Click(object sender, EventArgs e) {
            funcoes = FuncaoRepositorio.Instance.get();
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
                    dgvFuncoes.Enabled = true;
                    btnAtualizar.Enabled = true;
                    break;
                case Utilidades.WindowMode.ModoDeEdicao:
                    btnCancelar.Enabled = true;
                    btnSalvar.Enabled = true;
                    btnAdicionar.Enabled = false;
                    btnExcluir.Enabled = false;
                    dgvFuncoes.Enabled = false;
                    btnAtualizar.Enabled = false;
                    break;
                case Utilidades.WindowMode.ModoDeInsercao:
                    btnCancelar.Enabled = true;
                    btnSalvar.Enabled = true;
                    btnAdicionar.Enabled = false;
                    btnExcluir.Enabled = false;
                    dgvFuncoes.Enabled = false;
                    btnAtualizar.Enabled = false;
                    break;
            }
        }
        private void dgvFuncoes_RowEnter(object sender, DataGridViewCellEventArgs e) {
            txtCdFuncao.Text = funcoes[e.RowIndex].codigo;
            txtDescFuncao.Text = funcoes[e.RowIndex].descricao;
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