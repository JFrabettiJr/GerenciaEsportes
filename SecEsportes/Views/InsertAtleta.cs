using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SecEsportes.Infraestrutura;
using SecEsportes.Modelo;
using SecEsportes.Repositorio;

namespace SecEsportes.Views
{
    public partial class InsertAtleta : Form{
        private List<Atleta_Insert> atletas;
        public List<Atleta_Insert> atletasAInserir;
        private string errorMessage;

        private Usuario usuarioLogado;
        
        #region Inicialização da classe
        public InsertAtleta(Usuario usuarioLogado, int idCompeticao)
        {
            InitializeComponent();
            CenterToScreen();

            this.usuarioLogado = usuarioLogado;

            atletas = PessoaRepositorio.Instance.getAtletasForaCompeticao(idCompeticao, ref errorMessage);
            if (atletas is null) {
                MessageBox.Show("Houve um erro ao tentar listar os registros." + Environment.NewLine + Environment.NewLine + errorMessage, "Contate o Suporte técnico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            atletasAInserir = new List<Atleta_Insert>();
        }
        private void InsertAtleta_Load(object sender, EventArgs e) {
            refreshDataGridView();
        }
        #endregion
        #region Manipulação do grid
        private void refreshDataGridView(){
            dgvAtletas.DataSource = null;
            dgvAtletas.Refresh();

            dgvAtletas.Columns.Clear();

            dgvAtletas.DataSource = atletas;
            
            // Cria duas novas colunas
            dgvAtletas.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = nameof(Pessoa.nome) });
            dgvAtletas.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = nameof(Pessoa.dataNascimento) });

            for (var iCount = 0; iCount < dgvAtletas.Columns.Count; iCount++){
                switch (dgvAtletas.Columns[iCount].DataPropertyName){
                    case nameof(Atleta_Insert.selected):
                        dgvAtletas.Columns[iCount].HeaderText = " ";
                        dgvAtletas.Columns[iCount].Width = 30;
                        break;
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

        private void btnInserir_Click(object sender, EventArgs e) {
            atletasAInserir = atletas.FindAll(match => match.selected == true);
            Close();
        }

        private void btnMarcarTudo_Click(object sender, EventArgs e) {
            for (int iCount = 0; iCount < atletas.Count; iCount++) {
                dgvAtletas.Rows[iCount].Cells[nameof(Atleta_Insert.selected)].Value = true;
            }
        }

        private void btnDesmarcarTudo_Click(object sender, EventArgs e) {
            for (int iCount = 0; iCount < atletas.Count; iCount++) {
                dgvAtletas.Rows[iCount].Cells[nameof(Atleta_Insert.selected)].Value = false;
            }
        }
    }
}