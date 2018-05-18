using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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

            dgvEquipes.Columns.Clear();
            dgvEquipes.DataSource = equipes_view;

            dgvEquipes.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = nameof(Equipe.codigo) });
            dgvEquipes.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = nameof(Equipe.nome) });

            for (int iCount = 0; iCount < dgvEquipes.Columns.Count; iCount++){
                switch (dgvEquipes.Columns[iCount].DataPropertyName){
                    case nameof(Equipe.codigo):
                        dgvEquipes.Columns[iCount].HeaderText = "Código";
                        break;
                    case nameof(Equipe.nome):
                        dgvEquipes.Columns[iCount].HeaderText = "Nome";
                        break;
                }
            }

            dgvEquipes.Refresh();

            clearFields();
        }
        #endregion
        #region CRUD
        private void btnAdicionar_Click(object sender, EventArgs e){
            txtCodigo.Focus();
            clearFields();
            windowMode = Utilidades.WindowMode.ModoDeInsercao;
            windowModeChanged();
        }
        private void btnCancelar_Click(object sender, EventArgs e){
            clearFields();
            windowMode = Utilidades.WindowMode.ModoNormal;
            windowModeChanged();
        }
        private void btnSalvar_Click(object sender, EventArgs e){
            Equipe newEquipe;

            if (windowMode == Utilidades.WindowMode.ModoDeInsercao){
                newEquipe = new Equipe(txtCodigo.Text, txtNome.Text);
                newEquipe.urlLogo = pctLogoEquipe.ImageLocation;

                if (EquipeRepositorio.Instance.insert(ref newEquipe, ref errorMessage)){
                    equipes_view.Add(newEquipe);
                    refreshDataGridView();
                    clearFields();
                }else {
                    MessageBox.Show("Houve um erro ao tentar inserir o registro." + Environment.NewLine + Environment.NewLine + errorMessage, "Contate o Suporte técnico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }else {
                if (dgvEquipes.SelectedCells.Count > 0) {

                    Equipe oldEquipe;
                    oldEquipe = equipes_view[dgvEquipes.SelectedCells[0].RowIndex];

                    newEquipe = equipes_view[dgvEquipes.SelectedCells[0].RowIndex];
                    newEquipe.codigo = txtCodigo.Text;
                    newEquipe.nome = txtNome.Text;
                    newEquipe.urlLogo = pctLogoEquipe.ImageLocation;

                    if (EquipeRepositorio.Instance.update(newEquipe, ref errorMessage)) {
                        equipes_view[dgvEquipes.SelectedCells[0].RowIndex] = newEquipe;
                        refreshDataGridView();
                    }else {
                        fillFields(oldEquipe);
                        MessageBox.Show("Houve um erro ao tentar salvar o registro." + Environment.NewLine + Environment.NewLine + errorMessage, "Contate o Suporte técnico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            windowMode = Utilidades.WindowMode.ModoNormal;
            windowModeChanged();
        }

        private void clearFields() {
            txtCodigo.Text = "";
            txtNome.Text = "";
            clearImage();
        }

        private void clearImage() {
            pctLogoEquipe.Image = null;
            pctLogoEquipe.ImageLocation = null;
        }

        private void fillFields(Equipe equipe) {
            txtCodigo.Text = equipe.codigo;
            txtNome.Text = equipe.nome;
            try {
                if (!(equipe.urlLogo is null)) {
                    if (File.Exists(equipe.urlLogo)) {
                        pctLogoEquipe.Image = Image.FromFile(equipe.urlLogo);
                        pctLogoEquipe.ImageLocation = equipe.urlLogo;
                    } else {
                        clearImage();
                        pctLogoEquipe.Image = Properties.Resources.ImagemErro;

                    }
                } else {
                    clearImage();
                }
            } catch (Exception ex) {

            }
        }

        private void btnExcluir_Click(object sender, EventArgs e){
            if (dgvEquipes.SelectedCells.Count > 0) {
                Equipe equipe;
                equipe = equipes_view[dgvEquipes.SelectedCells[0].RowIndex];
                if (MessageBox.Show("Confirma a deleção do registro ?" +
                    Environment.NewLine + Environment.NewLine +
                    equipe.ToString(), "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    if (EquipeRepositorio.Instance.delete(equipe, ref errorMessage)) {
                        equipes_view.RemoveAt(dgvEquipes.SelectedCells[0].RowIndex);
                        refreshDataGridView();
                        clearFields();
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
                fillFields(equipes_view[e.RowIndex]);
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

        private void CadEquipe_DragDrop(object sender, DragEventArgs e) {
            int x = this.PointToClient(new Point(e.X, e.Y)).X;
            int y = this.PointToClient(new Point(e.X, e.Y)).Y;

            if ( (x >= pctLogoEquipe.Location.X) && (x <= pctLogoEquipe.Location.X + pctLogoEquipe.Width) && (y >= pctLogoEquipe.Location.Y) && (y <= pctLogoEquipe.Location.Y + pctLogoEquipe.Height) ) {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                //pictureBox1.Image = Image.FromFile(files[0]);
            }
        }

        private void pctLogoEquipe_MouseDoubleClick(object sender, MouseEventArgs e) {
            try {
                if (dgvEquipes.SelectedCells.Count == 1) {
                    Equipe equipe = equipes_view[dgvEquipes.SelectedCells[0].RowIndex];

                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.Filter = "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF";
                    openFileDialog.Title = String.Format("Escolha o logo da equipe {0}.", "");
                    if (openFileDialog.ShowDialog() == DialogResult.OK) {

                        //Lê o arquivo
                        pctLogoEquipe.Image = Image.FromFile(openFileDialog.FileName);
                        pctLogoEquipe.ImageLocation = openFileDialog.FileName;
                        fields_KeyDown(null, null);
                    }

                }
            }catch(Exception ex) {

            }
        }

        private void pctLogoEquipe_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {

                if (dgvEquipes.SelectedCells.Count == 1) {
                    Equipe equipe = equipes_view[dgvEquipes.SelectedCells[0].RowIndex];

                    // Cria o menu de contexto e suas respectivas configurações para cada equipe do grupo
                    ContextMenu contextMenu = new ContextMenu(); ;
                    MenuItem menuItem;

                    menuItem = new MenuItem("Remover logo");

                    menuItem.Click += (_sender, _e) => {
                        clearImage();
                        fields_KeyDown(null, null);
                    };

                    menuItem.Enabled = (!(equipe.urlLogo is null)) && equipe.urlLogo.Length > 0;
                    contextMenu.MenuItems.Add(menuItem);

                    // Define onde será aberto o menu de contexto
                    contextMenu.Show(pctLogoEquipe, new Point(e.X, e.Y));
                }
            }
        }
    }
}