using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using SecEsportes.Infraestrutura;
using SecEsportes.Modelo;
using SecEsportes.Repositorio;

namespace SecEsportes.Views {
    public partial class CadPessoa : Form {
        private Utilidades.WindowMode windowMode;
        private List<Pessoa> pessoas_view;
        private List<Pessoa> pessoas;
        private List<Funcao> funcoes;
        private string errorMessage;

        private Usuario usuarioLogado;

        #region Inicialização da classe
        public CadPessoa(Usuario usuarioLogado) {
            InitializeComponent();
            CenterToScreen();

            this.usuarioLogado = usuarioLogado;

            pessoas = PessoaRepositorio.Instance.get(ref errorMessage);
            if (pessoas is null) {
                MessageBox.Show("Houve um erro ao tentar listar os registros." + Environment.NewLine + Environment.NewLine + errorMessage, "Contate o Suporte técnico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            pessoas_view = new List<Pessoa>(pessoas);

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
        private void refreshDataGridView() {
            dgvPessoas.DataSource = null;
            dgvPessoas.Refresh();

            dgvPessoas.Columns.Clear();

            dgvPessoas.DataSource = pessoas_view;

            dgvPessoas.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = nameof(Pessoa.cpf) });
            dgvPessoas.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = nameof(Pessoa.nome) });
            dgvPessoas.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = nameof(Pessoa.dataNascimento) });
            dgvPessoas.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = nameof(Pessoa.email) });

            for (int iCount = 0; iCount < dgvPessoas.Columns.Count; iCount++) {
                switch (dgvPessoas.Columns[iCount].DataPropertyName) {
                    case nameof(Pessoa.cpf):
                        dgvPessoas.Columns[iCount].HeaderText = "CPF";
                        dgvPessoas.Columns[iCount].Name = dgvPessoas.Columns[iCount].DataPropertyName;
                        break;
                    case nameof(Pessoa.nome):
                        dgvPessoas.Columns[iCount].HeaderText = "Nome";
                        dgvPessoas.Columns[iCount].Name = dgvPessoas.Columns[iCount].DataPropertyName;
                        break;
                    case nameof(Pessoa.dataNascimento):
                        dgvPessoas.Columns[iCount].HeaderText = "Data de nascimento";
                        dgvPessoas.Columns[iCount].Name = dgvPessoas.Columns[iCount].DataPropertyName;
                        break;
                    case nameof(Pessoa.email):
                        dgvPessoas.Columns[iCount].HeaderText = "E-mail";
                        dgvPessoas.Columns[iCount].Name = dgvPessoas.Columns[iCount].DataPropertyName;
                        break;
                }
            }

            //Preenche os campos que vieram sem preenchimento do data set
            //for (int iCount = 0; iCount < dgvPessoas.Rows.Count; iCount++) {
                
            //}

            dgvPessoas.Refresh();

            clearFields();
        }

        private void fillFields(Pessoa pessoa) {
            txtCPF.Text = pessoa.cpf;
            txtNome.Text = pessoa.nome;
            txtDtNascimento.Text = pessoa.dataNascimento.ToString("dd/MM/yyyy");
            txtEmail.Text = pessoa.email;
            setFuncoesSelecionadas(pessoa.funcoes);

            try {
                if (!(pessoa.urlFoto is null)) {
                    if (File.Exists(pessoa.urlFoto)) {
                        pctFotoAtleta.Image = Image.FromFile(pessoa.urlFoto);
                        pctFotoAtleta.ImageLocation = pessoa.urlFoto;
                    } else {
                        clearImage();
                        pctFotoAtleta.Image = Properties.Resources.ImagemErro;

                    }
                } else {
                    clearImage();
                }
            } catch (Exception ex) {

            }

        }

        private void clearFields() {
            txtCPF.Text = "";
            txtNome.Text = "";
            txtDtNascimento.Text = "";
            txtEmail.Text = "";
            clearSelected(chkLstFuncoes);
            clearImage();
        }
        #endregion
        #region CRUD
        private void btnAdicionar_Click(object sender, EventArgs e) {
            txtCPF.Focus();
            clearFields();
            windowMode = Utilidades.WindowMode.ModoDeInsercao;
            windowModeChanged();
        }
        private void btnCancelar_Click(object sender, EventArgs e) {
            clearFields();
            windowMode = Utilidades.WindowMode.ModoNormal;
            windowModeChanged();
        }
        private void btnSalvar_Click(object sender, EventArgs e) {
            Pessoa Pessoa;
            DateTime dataAniversario;
            if (DateTime.TryParseExact(txtDtNascimento.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.NoCurrentDateDefault, out dataAniversario)) {
                if (windowMode == Utilidades.WindowMode.ModoDeInsercao) {
                    Pessoa = new Pessoa(txtCPF.Text, txtNome.Text, dataAniversario);
                    Pessoa.funcoes = getFuncoesSelecionadas();
                    Pessoa.urlFoto = pctFotoAtleta.ImageLocation;
                    Pessoa.email = txtEmail.Text;
                    if (PessoaRepositorio.Instance.insert(ref Pessoa, ref errorMessage)) {
                        pessoas_view.Add(Pessoa);
                        refreshDataGridView();
                        clearFields();
                    }
                    else {
                        MessageBox.Show("Houve um erro ao tentar inserir o registro." + Environment.NewLine + Environment.NewLine + errorMessage, "Contate o Suporte técnico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else {
                    if (dgvPessoas.SelectedCells.Count > 0) {
                        Pessoa = pessoas_view[dgvPessoas.SelectedCells[0].RowIndex];
                        Pessoa.cpf = txtCPF.Text;
                        Pessoa.nome = txtNome.Text;
                        Pessoa.dataNascimento = dataAniversario;
                        Pessoa.funcoes = getFuncoesSelecionadas();
                        Pessoa.urlFoto = pctFotoAtleta.ImageLocation;
                        Pessoa.email = txtEmail.Text;
                        if (PessoaRepositorio.Instance.update(Pessoa, ref errorMessage)) {
                            pessoas_view[dgvPessoas.SelectedCells[0].RowIndex] = Pessoa;
                            refreshDataGridView();
                        }
                        else {
                            fillFields(pessoas_view[dgvPessoas.SelectedCells[0].RowIndex]);
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
            for (int iCount = 0; iCount < chkLstFuncoes.Items.Count; iCount++) {
                string codFuncao = chkLstFuncoes.Items[iCount].ToString().Substring(0, chkLstFuncoes.Items[iCount].ToString().IndexOf(" - "));
                if (funcoes.Exists(funcao => funcao.codigo.Equals(codFuncao))) {
                    chkLstFuncoes.SetItemChecked(iCount, true);
                }else {
                    chkLstFuncoes.SetItemChecked(iCount, false);
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e) {
            if (dgvPessoas.SelectedCells.Count > 0) {
                Pessoa Pessoa;
                Pessoa = pessoas_view[dgvPessoas.SelectedCells[0].RowIndex];
                if (MessageBox.Show("Confirma a deleção do registro ?" +
                    Environment.NewLine + Environment.NewLine +
                    Pessoa.ToString(), "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    if (PessoaRepositorio.Instance.delete(Pessoa, ref errorMessage)) {
                        pessoas_view.RemoveAt(dgvPessoas.SelectedCells[0].RowIndex);
                        refreshDataGridView();
                        clearFields();
                    }
                    else {
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
                case Utilidades.WindowMode.ModoNormal: case Utilidades.WindowMode.ModoCriacaoForm:
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
            if (e.RowIndex > -1) {
                if (windowMode == Utilidades.WindowMode.ModoNormal)
                    windowMode = Utilidades.WindowMode.ModoCriacaoForm;
                fillFields(pessoas_view[e.RowIndex]);
                windowMode = Utilidades.WindowMode.ModoNormal;
            }
        }
        private void fields_KeyDown(object sender, KeyEventArgs e) {
            if (windowMode != Utilidades.WindowMode.ModoDeInsercao && windowMode != Utilidades.WindowMode.ModoCriacaoForm) {
                windowMode = Utilidades.WindowMode.ModoDeEdicao;
                windowModeChanged();
            }
        }
        private void chkLstFuncoes_ItemCheck(object sender, ItemCheckEventArgs e) {
            fields_KeyDown(sender, null);
        }
        private void clearSelected(CheckedListBox checkedListBox) {
            for(int iCount = 0; iCount < checkedListBox.Items.Count; iCount++) {
                checkedListBox.SetItemChecked(iCount, false);
            }
        }
        #endregion

        private void CadPessoa_Load(object sender, EventArgs e) {
            //Preenche o ComboBox da busca
            cboCamposBusca.Items.Add("Nome");
            cboCamposBusca.Items.Add("E-mail");
            cboCamposBusca.Items.Add("Ano nascimento");
            cboCamposBusca.Items.Add("Função (Código)");

            cboCamposBusca.SelectedIndex = 0;
        }

        private void txtBusca_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                busca();
            }
        }

        private void busca() {
            string textoBusca = txtBusca.Text.ToUpper();

            if (textoBusca.Length == 0) {
                pessoas_view = new List<Pessoa>(pessoas);
            } else {
                switch (cboCamposBusca.SelectedIndex) {
                    case 0: // Nome
                        pessoas_view = pessoas.FindAll(find => find.nome.ToUpper().Contains(textoBusca));
                        break;
                    case 1: // E-mail
                        pessoas_view = pessoas.FindAll(find => find.email.ToUpper().Contains(textoBusca));
                        break;
                    case 2: // Ano Nascimento
                        int anoNascimento;

                        if (Int32.TryParse(textoBusca, out anoNascimento)) {
                            pessoas_view = pessoas.FindAll(find => find.dataNascimento.Year == anoNascimento);
                        }
                        break;
                    case 3: // Função
                        pessoas_view = pessoas.FindAll(findPessoas => findPessoas.funcoes.FindAll(findFuncoes => findFuncoes.codigo.ToUpper() == textoBusca).Count > 0);
                        break;
                }
            }

            refreshDataGridView();
        }

        private void pctFotoAtleta_MouseDoubleClick(object sender, MouseEventArgs e) {
            try {
                if (dgvPessoas.SelectedCells.Count == 1) {
                    Pessoa pessoa = pessoas_view[dgvPessoas.SelectedCells[0].RowIndex];

                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.Filter = "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF";
                    openFileDialog.Title = String.Format("Escolha a foto da pessoa {0}.", "");
                    if (openFileDialog.ShowDialog() == DialogResult.OK) {

                        //Lê o arquivo
                        pctFotoAtleta.Image = Image.FromFile(openFileDialog.FileName);
                        pctFotoAtleta.ImageLocation = openFileDialog.FileName;
                        fields_KeyDown(null, null);
                    }

                }
            } catch (Exception ex) {

            }
        }

        private void clearImage() {
            pctFotoAtleta.Image = null;
            pctFotoAtleta.ImageLocation = null;
        }

        private void pctFotoAtleta_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {

                if (dgvPessoas.SelectedCells.Count == 1) {
                    Pessoa pessoa = pessoas_view[dgvPessoas.SelectedCells[0].RowIndex];

                    // Cria o menu de contexto e suas respectivas configurações para cada equipe do grupo
                    ContextMenu contextMenu = new ContextMenu(); ;
                    MenuItem menuItem;

                    menuItem = new MenuItem("Remover foto");

                    menuItem.Click += (_sender, _e) => {
                        clearImage();
                        fields_KeyDown(null, null);
                    };

                    menuItem.Enabled = (!(pessoa.urlFoto is null)) && pessoa.urlFoto.Length > 0;
                    contextMenu.MenuItems.Add(menuItem);

                    // Define onde será aberto o menu de contexto
                    contextMenu.Show(pctFotoAtleta, new Point(e.X, e.Y));
                }
            }
        }
    }
}