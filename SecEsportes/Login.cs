using Dapper;
using SecEsportes.Modelo;
using SecEsportes.Repositorio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SecEsportes
{
    public partial class Login : Form{

        // Lista os cadastros
        List<Funcao> funcoes;
        List<Modalidade> modalidades;

        public Login(){
            InitializeComponent();
            CenterToScreen();
        }

        private void btnEntrar_Click(object sender, EventArgs e) {
            if (txtUsuario.Text.Trim().Length > 0 && txtSenha.Text.Trim().Length > 0) {
                Usuario usuario = UsuarioRepositorio.Instance.login(txtUsuario.Text, txtSenha.Text);
                if (!(usuario is null)) {
                    this.Hide();
                    Main main = new Main(usuario);
                    main.FormClosed += (s, args) => this.Close();
                    main.Show();
                } else {
                    MessageBox.Show("Nome de usuário e/ou senha inválidos", "Falha no Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void keyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                btnEntrar_Click(null, null);
            }
        }
    }
}
