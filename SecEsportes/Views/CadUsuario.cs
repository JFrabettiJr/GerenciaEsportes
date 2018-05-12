using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SecEsportes.Infraestrutura;
using SecEsportes.Modelo;
using SecEsportes.Repositorio;

namespace SecEsportes.Views
{
    public partial class CadUsuario : Form
    {
        private Utilidades.WindowMode windowMode;
        private List<Usuario> usuarios;
        private string errorMessage;

        private Usuario usuarioLogado;

        #region Inicialização da classe
        public CadUsuario(Usuario usuarioLogado)
        {
            InitializeComponent();

            // Centraliza o form na tela
            CenterToScreen();

            this.usuarioLogado = usuarioLogado;
            if (!(this.usuarioLogado.username.Equals(UsuarioRepositorio.Instance.usuarioMaster.username))){
                lblSenha.Visible = false;
                txtSenha.Visible = false;
            }

            // Carrega as competições
            usuarios = UsuarioRepositorio.Instance.get(ref errorMessage);
            if (usuarios is null) {
                MessageBox.Show("Houve um erro ao tentar listar os registros." + Environment.NewLine + Environment.NewLine + errorMessage, "Contate o Suporte técnico", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            dgvUsuarios.DataSource = null;
            dgvUsuarios.Refresh();

            dgvUsuarios.DataSource = usuarios;

            for (int iCount = 0; iCount < dgvUsuarios.Columns.Count; iCount++)
            {
                switch (dgvUsuarios.Columns[iCount].DataPropertyName)
                {
                    case nameof(Usuario.username):
                        dgvUsuarios.Columns[iCount].HeaderText = "Nome de usuário";
                        break;
                    case nameof(Usuario.nome):
                        dgvUsuarios.Columns[iCount].HeaderText = "Nome";
                        break;
                    case nameof(Usuario.email):
                        dgvUsuarios.Columns[iCount].HeaderText = "E-mail";
                        break;
                    case nameof(Usuario.ultimoLogin):
                        dgvUsuarios.Columns[iCount].HeaderText = "Ultimo login";
                        break;
                    default:
                        dgvUsuarios.Columns[iCount].Visible = false;
                        break;

                }
            }

            for (int iCount = 0; iCount < dgvUsuarios.Rows.Count; iCount++) {
                dgvUsuarios.Rows[iCount].Cells[nameof(Usuario.ultimoLogin)].Value = usuarios[iCount].ultimoLogin.ToString("dd/MM/yyyy");
            }

            dgvUsuarios.Refresh();
        }
        #endregion
        #region CRUD
        private void btnAdicionar_Click(object sender, EventArgs e){
            txtUsername.Focus();
            clearFields();
            windowMode = Utilidades.WindowMode.ModoDeInsercao;
            windowModeChanged();
        }
        private void btnCancelar_Click(object sender, EventArgs e){
            clearFields();
            windowMode = Utilidades.WindowMode.ModoNormal;
            windowModeChanged();
        }
        private void clearFields() {
            txtUsername.Text = "";
            txtNome.Text = "";
            txtEmail.Text = "";
            txtDtUltimoLogin.Text = "";
            txtSenha.Text = "";
        }
        private void btnSalvar_Click(object sender, EventArgs e){
            Usuario newUsuario;

            // Verifica se vai inserir um novo registro ou então salvá-lo
            if (windowMode == Utilidades.WindowMode.ModoDeInsercao){
                newUsuario = new Usuario(txtUsername.Text, txtEmail.Text, txtNome.Text);
                if (txtSenha.Visible)
                    newUsuario.senha = txtSenha.Text;

                // Tenta inserir a competição
                if (UsuarioRepositorio.Instance.insert(ref newUsuario, ref errorMessage)){
                    usuarios.Add(newUsuario);
                    refreshDataGridView();
                    clearFields();
                } else {
                    MessageBox.Show("Houve um erro ao tentar inserir o registro." + Environment.NewLine + Environment.NewLine + errorMessage, "Contate o Suporte técnico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }else {
                if (dgvUsuarios.SelectedCells.Count > 0) {
                    Usuario oldUsuario;
                    oldUsuario = usuarios[dgvUsuarios.SelectedCells[0].RowIndex];

                    newUsuario = new Usuario();
                    newUsuario.id = oldUsuario.id;
                    newUsuario.username = txtUsername.Text;
                    newUsuario.nome = txtNome.Text;
                    newUsuario.email = txtEmail.Text;
                    newUsuario.ultimoLogin = oldUsuario.ultimoLogin;
                    if (txtSenha.Visible)
                        newUsuario.senha = txtSenha.Text;

                    if ( (!(newUsuario.username.Equals(UsuarioRepositorio.Instance.usuarioMaster.username))) || (oldUsuario.username.Equals(newUsuario.username)) ) {
                        // Salva as alterações do usuário
                        if (UsuarioRepositorio.Instance.update(newUsuario, ref errorMessage)) {
                            usuarios[dgvUsuarios.SelectedCells[0].RowIndex] = newUsuario;
                            refreshDataGridView();
                        } else {
                            fillFields(usuarios[dgvUsuarios.SelectedCells[0].RowIndex]);
                            MessageBox.Show("Houve um erro ao tentar salvar o registro." + Environment.NewLine + Environment.NewLine + errorMessage, "Contate o Suporte técnico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }

            windowMode = Utilidades.WindowMode.ModoNormal;
            windowModeChanged();
        }
        private void btnExcluir_Click(object sender, EventArgs e){
            if (dgvUsuarios.SelectedCells.Count > 0) {
                Usuario usuario;
                usuario = usuarios[dgvUsuarios.SelectedCells[0].RowIndex];

                if (!(usuario.username.Equals(UsuarioRepositorio.Instance.usuarioMaster.username))) {
                    if (MessageBox.Show("Confirma a deleção do registro ?" +
                            Environment.NewLine + Environment.NewLine +
                            usuario.ToString(), "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                        if (UsuarioRepositorio.Instance.delete(usuario, ref errorMessage)) {
                            usuarios.RemoveAt(dgvUsuarios.SelectedCells[0].RowIndex);
                            refreshDataGridView();
                            clearFields();
                        } else {
                            MessageBox.Show("Houve um erro ao tentar deletar o registro." + Environment.NewLine + Environment.NewLine + errorMessage, "Contate o Suporte técnico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
        private void btnAtualizar_Click(object sender, EventArgs e) {
            usuarios = UsuarioRepositorio.Instance.get(ref errorMessage);
            if (usuarios is null) {
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
                    dgvUsuarios.Enabled = true;
                    btnAtualizar.Enabled = true;
                    break;
                case Utilidades.WindowMode.ModoDeEdicao:
                    btnCancelar.Enabled = true;
                    btnSalvar.Enabled = true;
                    btnAdicionar.Enabled = false;
                    btnExcluir.Enabled = false;
                    dgvUsuarios.Enabled = false;
                    btnAtualizar.Enabled = false;
                    break;
                case Utilidades.WindowMode.ModoDeInsercao:
                    btnCancelar.Enabled = true;
                    btnSalvar.Enabled = true;
                    btnAdicionar.Enabled = false;
                    btnExcluir.Enabled = false;
                    dgvUsuarios.Enabled = false;
                    btnAtualizar.Enabled = false;
                    break;
            }
        }
        private void dgvEquipes_RowEnter(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex > -1) {
                if (windowMode == Utilidades.WindowMode.ModoNormal)
                    windowMode = Utilidades.WindowMode.ModoCriacaoForm;

                fillFields(usuarios[e.RowIndex]);
                windowMode = Utilidades.WindowMode.ModoNormal;
            }
        }

        private void fillFields(Usuario usuario) {
            txtUsername.Text = usuario.username;
            txtNome.Text = usuario.nome;
            txtEmail.Text = usuario.email;
            txtDtUltimoLogin.Text = usuario.ultimoLogin.ToString("dd/MM/yyyy");
            if (txtSenha.Visible)
                txtSenha.Text = usuario.senha;
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
        #endregion
    }
}