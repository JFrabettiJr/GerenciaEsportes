﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SecEsportes.Infraestrutura;
using SecEsportes.Modelo;
using SecEsportes.Repositorio;

namespace SecEsportes.Views
{
    public partial class CadEquipe : Form
    {
        private Utilidades.WindowMode windowMode;
        private List<Equipe> equipes_view;
        private List<Equipe> equipes;
        private string errorMessage;

        private Usuario usuarioLogado;

        #region Inicialização da classe
        public CadEquipe(Usuario usuarioLogado)
        {
            InitializeComponent();
            CenterToScreen();

            this.usuarioLogado = usuarioLogado;

            equipes = EquipeRepositorio.Instance.get(ref errorMessage);
            if (equipes is null) {
                MessageBox.Show("Houve um erro ao tentar listar os registros." + Environment.NewLine + Environment.NewLine + errorMessage, "Contate o Suporte técnico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            equipes_view = new List<Equipe>(equipes);

            refreshDataGridView();
            windowMode = Utilidades.WindowMode.ModoNormal;
            windowModeChanged();
        }
        #endregion
        #region Manipulação do grid
        private void refreshDataGridView(){
            dgvEquipes.DataSource = null;
            dgvEquipes.Refresh();

            dgvEquipes.DataSource = equipes_view;

            for (int iCount = 0; iCount < dgvEquipes.Columns.Count; iCount++){
                switch (dgvEquipes.Columns[iCount].DataPropertyName){
                    case nameof(Equipe.id):
                        dgvEquipes.Columns[iCount].Visible = false;
                        break;
                    case nameof(Equipe.codigo):
                        dgvEquipes.Columns[iCount].HeaderText = "Código";
                        break;
                    case nameof(Equipe.nome):
                        dgvEquipes.Columns[iCount].HeaderText = "Nome";
                        break;
                }
            }

            dgvEquipes.Refresh();
        }
        #endregion
        #region CRUD
        private void btnAdicionar_Click(object sender, EventArgs e){
            txtCodigo.Focus();
            txtCodigo.Text = "";
            txtNome.Text = "";
            windowMode = Utilidades.WindowMode.ModoDeInsercao;
            windowModeChanged();
        }
        private void btnCancelar_Click(object sender, EventArgs e){
            txtCodigo.Text = "";
            txtNome.Text = "";
            windowMode = Utilidades.WindowMode.ModoNormal;
            windowModeChanged();
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Equipe equipe;
            if (windowMode == Utilidades.WindowMode.ModoDeInsercao){
                equipe = new Equipe(txtCodigo.Text, txtNome.Text);
                if (EquipeRepositorio.Instance.insert(ref equipe, ref errorMessage)){
                    equipes_view.Add(equipe);
                    refreshDataGridView();
                    txtCodigo.Text = "";
                    txtNome.Text = "";
                }else {
                    MessageBox.Show("Houve um erro ao tentar inserir o registro." + Environment.NewLine + Environment.NewLine + errorMessage, "Contate o Suporte técnico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }else {
                if (dgvEquipes.SelectedCells.Count > 0) {
                    equipe = equipes_view[dgvEquipes.SelectedCells[0].RowIndex];
                    equipe.codigo = txtCodigo.Text;
                    equipe.nome = txtNome.Text;
                    if (EquipeRepositorio.Instance.update(equipe, ref errorMessage)) {
                        equipes_view[dgvEquipes.SelectedCells[0].RowIndex] = equipe;
                        refreshDataGridView();
                    }else {
                        txtCodigo.Text = equipes_view[dgvEquipes.SelectedCells[0].RowIndex].codigo;
                        txtNome.Text = equipes_view[dgvEquipes.SelectedCells[0].RowIndex].nome;
                        MessageBox.Show("Houve um erro ao tentar salvar o registro." + Environment.NewLine + Environment.NewLine + errorMessage, "Contate o Suporte técnico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            windowMode = Utilidades.WindowMode.ModoNormal;
            windowModeChanged();
        }
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvEquipes.SelectedCells.Count > 0) {
                Equipe equipe;
                equipe = equipes_view[dgvEquipes.SelectedCells[0].RowIndex];
                if (MessageBox.Show("Confirma a deleção do registro ?" +
                    Environment.NewLine + Environment.NewLine +
                    equipe.ToString(), "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    if (EquipeRepositorio.Instance.delete(equipe, ref errorMessage)) {
                        equipes_view.RemoveAt(dgvEquipes.SelectedCells[0].RowIndex);
                        refreshDataGridView();
                        txtCodigo.Text = "";
                        txtNome.Text = "";
                    }else{
                        MessageBox.Show("Houve um erro ao tentar deletar o registro." + Environment.NewLine + Environment.NewLine + errorMessage, "Contate o Suporte técnico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void btnAtualizar_Click(object sender, EventArgs e) {
            equipes = EquipeRepositorio.Instance.get(ref errorMessage);
            if (equipes is null) {
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
                    dgvEquipes.Enabled = true;
                    btnAtualizar.Enabled = true;
                    break;
                case Utilidades.WindowMode.ModoDeEdicao:
                    btnCancelar.Enabled = true;
                    btnSalvar.Enabled = true;
                    btnAdicionar.Enabled = false;
                    btnExcluir.Enabled = false;
                    dgvEquipes.Enabled = false;
                    btnAtualizar.Enabled = false;
                    break;
                case Utilidades.WindowMode.ModoDeInsercao:
                    btnCancelar.Enabled = true;
                    btnSalvar.Enabled = true;
                    btnAdicionar.Enabled = false;
                    btnExcluir.Enabled = false;
                    dgvEquipes.Enabled = false;
                    btnAtualizar.Enabled = false;
                    break;
            }
        }
        private void dgvEquipes_RowEnter(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex > -1) {
                txtCodigo.Text = equipes_view[e.RowIndex].codigo;
                txtNome.Text = equipes_view[e.RowIndex].nome;
            }
        }
        private void fields_KeyDown(object sender, KeyEventArgs e) {
            if (windowMode != Utilidades.WindowMode.ModoDeInsercao) {
                windowMode = Utilidades.WindowMode.ModoDeEdicao;
                windowModeChanged();
            }
        }
        #endregion

        private void busca() {
            string textoBusca = txtBusca.Text.ToUpper();

            if (textoBusca.Length == 0) {
                equipes_view = new List<Equipe>(equipes);
            } else {
                switch (cboCamposBusca.SelectedIndex) {
                    case 0: // Nome
                        equipes_view = equipes.FindAll(find => find.nome.ToUpper().Contains(textoBusca));
                        break;
                    case 1: // Código
                        equipes_view = equipes.FindAll(find => find.codigo.ToUpper().Contains(textoBusca));
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

        private void CadEquipe_Load(object sender, EventArgs e) {
            //Preenche o ComboBox da busca
            cboCamposBusca.Items.Add("Nome");
            cboCamposBusca.Items.Add("Código");

            cboCamposBusca.SelectedIndex = 0;
        }
    }
}