using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SecEsportes.Infraestrutura;
using SecEsportes.Modelo;
using SecEsportes.Repositorio;

namespace SecEsportes.Views {
    public partial class EditCompeticao : Form {
        private Utilidades.WindowMode windowMode;
        private List<EquipeCompeticao> equipes;
        private List<Modalidade> modalidades;
        private Competicao competicao;
        private string errorMessage;
        private InsertEquipe insertEquipeForm;

        #region Inicialização da classe
        public EditCompeticao(Competicao competicao) {
            windowMode = Utilidades.WindowMode.ModoCriacaoForm;
            InitializeComponent();

            // Centraliza a tela
            CenterToScreen();

            Text += " - " + competicao.nome;

            this.competicao = competicao;
        }
        #endregion
        #region Manipulação do grid
        private void refreshDataGridView() {
            dgvEquipes.DataSource = null;
            dgvEquipes.Refresh();

            dgvEquipes.Columns.Clear();

            dgvEquipes.DataSource = equipes;

            dgvEquipes.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = "QtdAtletas" });

            for (var iCount = 0; iCount < dgvEquipes.Columns.Count; iCount++) {
                switch (dgvEquipes.Columns[iCount].DataPropertyName) {
                    case nameof(EquipeCompeticao.nome):
                        dgvEquipes.Columns[iCount].HeaderText = "Nome da equipe";
                        dgvEquipes.Columns[iCount].Name = dgvEquipes.Columns[iCount].DataPropertyName;
                        break;
                    case nameof(EquipeCompeticao.codigo):
                        dgvEquipes.Columns[iCount].HeaderText = "Código";
                        dgvEquipes.Columns[iCount].Name = dgvEquipes.Columns[iCount].DataPropertyName;
                        break;
                    case nameof(EquipeCompeticao.representante):
                        dgvEquipes.Columns[iCount].HeaderText = "Representante";
                        dgvEquipes.Columns[iCount].Name = dgvEquipes.Columns[iCount].DataPropertyName;
                        break;
                    case nameof(EquipeCompeticao.treinador):
                        dgvEquipes.Columns[iCount].HeaderText = "Treinador";
                        dgvEquipes.Columns[iCount].Name = dgvEquipes.Columns[iCount].DataPropertyName;
                        break;
                    case "QtdAtletas":
                        dgvEquipes.Columns[iCount].HeaderText = "Atletas";
                        dgvEquipes.Columns[iCount].Name = dgvEquipes.Columns[iCount].DataPropertyName;
                        break;
                    default:
                        dgvEquipes.Columns[iCount].Visible = false;
                        dgvEquipes.Columns[iCount].DisplayIndex = 5;
                        break;
                }
            }

            //Preenche os campos que vieram sem preenchimento do data set
            for (var iCount = 0; iCount < dgvEquipes.Rows.Count; iCount++) {
                dgvEquipes.Rows[iCount].Cells["QtdAtletas"].Value = EquipeRepositorio.Instance.getNumAtletasPorCompeticao(competicao.id, equipes[iCount].id);
            }

            dgvEquipes.Refresh();
        }
        #endregion
        #region CRUD
        private void btnAdicionar_Click(object sender, EventArgs e) {
            clearFields();
            txtNome.Focus();
            windowMode = Utilidades.WindowMode.ModoDeInsercao;
            windowModeChanged();
        }
        private void btnCancelar_Click(object sender, EventArgs e) {
            clearFields();
            fillFields();
            windowMode = Utilidades.WindowMode.ModoNormal;
            windowModeChanged();
        }
        private void btnSalvar_Click(object sender, EventArgs e) {
            Modalidade modalidade = ModalidadeRepositorio.Instance.get(Convert.ToInt32(cboModalidades.SelectedItem.ToString().Substring(0, cboModalidades.SelectedItem.ToString().IndexOf(" - "))));

            DateTime dataInicio = new DateTime(), dataFim_aux = new DateTime();
            DateTime? dataFim = null;
            DateTime.TryParseExact(txtDtInicio.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.NoCurrentDateDefault, out dataInicio);
            if (txtDtFim.MaskCompleted) {
                DateTime.TryParseExact(txtDtFim.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.NoCurrentDateDefault, out dataFim_aux);
                dataFim = dataFim_aux;
            }

            Competicao newCompeticao = competicao;
            newCompeticao.id = competicao.id;
            newCompeticao.dataInicial = dataInicio;
            newCompeticao.grupos = competicao.grupos;

            if (!(dataFim is null)) {
                newCompeticao.dataFinal = dataFim;
            }

            newCompeticao.modalidade = modalidade;
            newCompeticao.numTimes = Convert.ToInt32(txtNumTimes.Text);
            newCompeticao.numGrupos = Convert.ToInt32(txtNumGrupos.Text);
            newCompeticao.numMinimoJogadores = Convert.ToInt32(txtNumMinJogadores.Text);

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
            }

            switch (cboNomeacaoGrupos.SelectedIndex) {
                case 0:
                    newCompeticao.nomesGrupos = NomesGruposEnum._0_PorNumeracao;
                    break;
                case 1:
                    newCompeticao.nomesGrupos = NomesGruposEnum._1_PorLetras;
                    break;
            }

            newCompeticao.jogosIdaEVolta = chkIdaEVolta.Checked;
            newCompeticao.jogosIdaEVolta_MataMata = chkIdaEVoltaMataMata.Checked;

            newCompeticao.status = competicao.status;

            if (CompeticaoRepositorio.Instance.update(newCompeticao, ref errorMessage)) {
                competicao = newCompeticao;
            } else {
                fillFields();
                MessageBox.Show("Houve um erro ao tentar salvar o registro." + Environment.NewLine + Environment.NewLine + errorMessage, "Contate o Suporte técnico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            windowMode = Utilidades.WindowMode.ModoNormal;
            windowModeChanged();

            load(null, null);
        }

        private void btnAtualizar_Click(object sender, EventArgs e) {
            clearFields();
            fillFields();

            // Verifica qual o modo que a competição está para avaliar qual será a visualizaçao
            int posicaoInicial, tamanhoTotal = 0;
            posicaoInicial = dgvEquipes.Location.Y;
            if (dgvEquipes.Visible)
                tamanhoTotal += dgvEquipes.Size.Height;
            if (tabs.Visible)
                tamanhoTotal += tabs.Size.Height;

            // Bloqueia os campos para edição
            bloqueiaCampos(false);


            btnGerarPartidas.Enabled = false;
            btnVisaoGeral.Enabled = false;

            if (competicao.status == StatusEnum._1_Aberta) {
                // Competição aberta

                // Reajusta o DataGridView com as equipes
                dgvEquipes.Location = new System.Drawing.Point(dgvEquipes.Location.X, posicaoInicial);
                dgvEquipes.Size = new System.Drawing.Size(dgvEquipes.Size.Width, tamanhoTotal);

                // Deixa visível os botões/informações
                dgvEquipes.Visible = true;
                btnIncluirEquipes.Enabled = true;
                btnExcluirEquipe.Enabled = true;

                // Deixa invisível os botões/informações
                tabs.Visible = false;
                btnGerarGrupos.Enabled = false;
            } else {
                // Competição em preparação, encerrada ou iniciada

                // Deixa visível os botões/informações
                tabs.Visible = true;

                // Deixa invisível os botões/informações
                btnIncluirEquipes.Enabled = false;
                btnExcluirEquipe.Enabled = false;

                // Cria a abas e os grupos
                tabs.Controls.Clear();
                for (int numGrupo = 0; numGrupo < competicao.numGrupos; numGrupo++) {
                    DataGridView dataGridView = CompeticaoViewUtilidades.criaAba(CompeticaoViewUtilidades.getNomeGrupo(competicao.nomesGrupos, numGrupo + 1), numGrupo, tabs, dgvGrupoEquipes_CellMouseClick);

                    if (numGrupo < competicao.grupos.Count)
                        CompeticaoViewUtilidades.refreshDataGridViewGrupos(dataGridView, competicao.grupos[numGrupo]);
                    else
                        CompeticaoViewUtilidades.refreshDataGridViewGrupos(dataGridView, null);
                }

                if (competicao.status == StatusEnum._3_EmPreparacao) {
                    // Competição em preparação

                    // Deixa visível os botões/informações
                    dgvEquipes.Visible = true;
                    btnGerarGrupos.Enabled = true;
                    btnGerarPartidas.Enabled = true;

                    // Reajusta a lista de equipes
                    dgvEquipes.Location = new System.Drawing.Point(dgvEquipes.Location.X, posicaoInicial);
                    dgvEquipes.Size = new System.Drawing.Size(dgvEquipes.Size.Width, tamanhoTotal / 2);

                    // Reajusta as abas com os grupos
                    tabs.Location = new System.Drawing.Point(tabs.Location.X, posicaoInicial + dgvEquipes.Size.Height + 5);
                    tabs.Size = new System.Drawing.Size(tabs.Size.Width, tamanhoTotal / 2);

                    dgvEquipes.CellMouseClick -= dgvEquipes_CellMouseClick;
                    dgvEquipes.CellMouseClick += dgvEquipes_CellMouseClick;

                } else {
                    // Competição encerrada ou iniciada

                    // Bloqueia os campos para edição
                    bloqueiaCampos(true);

                    // Deleta o evento que seria acionado no clique do DataGridView dos grupos
                    for (int iCount = 0; iCount < tabs.Controls.Count; iCount++) {
                        TabPage tabPage = (TabPage)tabs.Controls[iCount];
                        ((DataGridView)tabPage.Controls[0]).CellMouseClick -= dgvGrupoEquipes_CellMouseClick;
                    }
                    
                    // Reajusta as abas com os grupos
                    tabs.Location = new System.Drawing.Point(tabs.Location.X, posicaoInicial);
                    tabs.Size = new System.Drawing.Size(tabs.Size.Width, tamanhoTotal);

                    // Deixa invisível os botões/informações
                    dgvEquipes.Visible = false;
                    btnGerarGrupos.Enabled = false;
                    btnVisaoGeral.Enabled = true;
                }

            }
        }

        private void bloqueiaCampos(bool bloqueia) {
            tlp1.Enabled = !bloqueia;
            tlp2.Enabled = !bloqueia;
        }

        private void dgvEquipes_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
            if (e.RowIndex > -1 && e.ColumnIndex > -1) {
                if (e.Button == MouseButtons.Right) {

                    // Cria o menu de contexto e suas respectivas configurações
                    ContextMenu contextMenu = new ContextMenu();
                    for (var iCount = 0; iCount < tabs.Controls.Count; iCount++) {
                        MenuItem menuItem = new MenuItem("Enviar " + equipes[e.RowIndex].codigo + " - " + equipes[e.RowIndex].nome + " para o " + tabs.Controls[iCount].Text);
                        menuItem.Click += menuAdicionarGrupo_click;
                        menuItem.Tag = equipes[e.RowIndex].id.ToString() + "|-|" + iCount.ToString();
                        contextMenu.MenuItems.Add(menuItem);
                    }
                    
                    // Define onde será aberto o menu de contexto
                    int x, y;
                    x = dgvEquipes.RowHeadersWidth;
                    y = (dgvEquipes[e.ColumnIndex, e.RowIndex].Size.Height * e.RowIndex) + dgvEquipes.ColumnHeadersHeight;
                    contextMenu.Show(dgvEquipes, new System.Drawing.Point(x, y));

                }
            }
        }

        private void menuAdicionarGrupo_click(object sender, EventArgs e) {
            string tagMenuItem = ((MenuItem)sender).Tag.ToString();
            int idEquipe = Convert.ToInt32(tagMenuItem.Substring(0, tagMenuItem.IndexOf("|-|")));
            int idGrupo = Convert.ToInt32(tagMenuItem.Substring(idEquipe.ToString().Length + 3));
            int? idGrupoInserido = null;

            bool insereEmGrupo = true;

            int numTimesPorGrupo = competicao.numTimes / competicao.numGrupos;
            int numTimesRestantes = competicao.numTimes % competicao.numGrupos;

            // Verifica se o grupo já tem o número suficiente de times
            if ( (numTimesRestantes == 0 && competicao.grupos[idGrupo].Count >= numTimesPorGrupo) || 
                (competicao.grupos[idGrupo].Count >= (numTimesRestantes / competicao.numGrupos) + numTimesPorGrupo) ) {
                insereEmGrupo = false;
            }

            if (insereEmGrupo) {
                // Verifica se o clube já está em algum grupo
                for (int numGrupo = 0; numGrupo < tabs.Controls.Count; numGrupo++) {
                    if (!(competicao.grupos[numGrupo].Find(equipeAEncontrar => equipeAEncontrar.id == idEquipe) is null)) {
                        insereEmGrupo = false;
                        idGrupoInserido = numGrupo;
                    }
                }
            }

            if (insereEmGrupo) {
                // Identifica a equipe e a adiciona ao grupo
                EquipeCompeticao equipe = equipes.Find(equipeAEncontrar => equipeAEncontrar.id == idEquipe);
                enviarParaGrupo(idGrupo, equipe);
            }

            tabs.SelectedIndex = (idGrupoInserido == null ? idGrupo : idGrupoInserido.Value);

        }

        private void enviarParaGrupo(int idGrupo, EquipeCompeticao equipe) {
            competicao.grupos[idGrupo].Add(equipe);

            // Atualiza o DataSource dos grupos
            DataGridView dgvGrupo = (DataGridView)tabs.Controls[idGrupo].Controls[0];

            CompeticaoViewUtilidades.refreshDataGridViewGrupos(dgvGrupo, competicao.grupos[idGrupo]);

            CompeticaoRepositorio.Instance.updateGrupos(competicao.id, idGrupo, equipe.id);
        }        
        private void btnAvancar_Click(object sender, EventArgs e) {
            Competicao newCompeticao;

            switch (competicao.status) {
                case StatusEnum._0_Encerrada:
                    break;
                case StatusEnum._1_Aberta:  // Aberta >> Em preparação

                    // Verifica se foi definida o numero minimo de atletas
                    if (competicao.numMinimoJogadores <= 0) {
                        MessageBox.Show("Por favor verifique" + Environment.NewLine + Environment.NewLine +
                            "É necessário definir o número mínimo de atletas por equipe",
                            "Não foi possível avançar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Mais de 1 equipe
                    if (dgvEquipes.Rows.Count <= 1 || competicao.numTimes <= 1) {
                        MessageBox.Show("Por favor verifique" + Environment.NewLine + Environment.NewLine +
                            "É necessário pelo menos 2 equipes para realizar o campeonato",
                            "Não foi possível avançar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Mais de 0 grupo
                    if (competicao.numGrupos == 0) {
                        MessageBox.Show("Por favor verifique" + Environment.NewLine + Environment.NewLine +
                            "É necessário pelo menos 1 grupo para realizar o campeonato",
                            "Não foi possível avançar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Verifica o número de equipes
                    if (dgvEquipes.Rows.Count != competicao.numTimes) {
                        MessageBox.Show("Por favor verifique" + Environment.NewLine + Environment.NewLine +
                            "O número de equipes definidas na competição e o número de times inseridos é diferente.",
                            "Não foi possível avançar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    foreach (EquipeCompeticao equipe in equipes) {
                        // Verifica se toda equipe tem o numero minimo de jogadores
                        if (equipe.atletas.Count < competicao.numMinimoJogadores) {
                            MessageBox.Show("Por favor verifique" + Environment.NewLine + Environment.NewLine +
                            "Existem equipes que não tem o número mínimo de jogadores para a competição",
                            "Não foi possível avançar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    newCompeticao = competicao;
                    newCompeticao.status = StatusEnum._3_EmPreparacao;

                    competicao.grupos = new List<List<EquipeCompeticao>>();
                    for (int iCount = 0; iCount < newCompeticao.numGrupos; iCount++) {
                        newCompeticao.grupos.Add(new List<EquipeCompeticao>());
                    }

                    if (CompeticaoRepositorio.Instance.update(newCompeticao, ref errorMessage)) {
                        competicao = newCompeticao;
                    } else {
                        MessageBox.Show("Houve um erro ao tentar salvar o registro." + Environment.NewLine + Environment.NewLine + errorMessage, "Contate o Suporte técnico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    load(null, null);

                    break;
                case StatusEnum._2_Iniciada:    // Iniciada >> Encerrada
                    int numPartidasRestantes;
                    if (competicao.fase_Atual == 0) {
                        numPartidasRestantes = competicao.partidas.FindAll(partidas => partidas.encerrada == false && partidas.rodada > competicao.fase_Atual).Count;
                    } else {
                        numPartidasRestantes = competicao.partidas.FindAll(partidas => partidas.encerrada == false && partidas.rodada == competicao.fase_Atual).Count;
                    }
                    
                    if (numPartidasRestantes > 0) {
                        MessageBox.Show("Por favor verifique" + Environment.NewLine + Environment.NewLine +
                            "Existem ainda " + numPartidasRestantes + " que não foram encerradas nesta fase.",
                            "Não foi possível avançar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }

                    newCompeticao = competicao;
                    newCompeticao.status = StatusEnum._0_Encerrada;

                    if (CompeticaoRepositorio.Instance.update(newCompeticao, ref errorMessage)) {
                        competicao = newCompeticao;
                    } else {
                        MessageBox.Show("Houve um erro ao tentar salvar o registro." + Environment.NewLine + Environment.NewLine + errorMessage, "Contate o Suporte técnico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    load(null, null);
                    break;

                case StatusEnum._3_EmPreparacao:    // Em preparação >> Iniciada
                    foreach (EquipeCompeticao equipe in equipes) {
                        // Verifica se toda equipe tem representante e treinador
                        if (equipe.treinador is null || equipe.representante is null) {
                            MessageBox.Show("Por favor verifique" + Environment.NewLine + Environment.NewLine +
                            "Existem equipes que não tem treinador ou representante definido",
                            "Não foi possível avançar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Verifica se todos os jogadores tem número
                        foreach (Atleta atleta in equipe.atletas) {
                            if (atleta.numero is null || atleta.numero < 1) {
                                MessageBox.Show("Por favor verifique" + Environment.NewLine + Environment.NewLine +
                                "Existem equipes que têm atletas sem a numeração definida",
                                "Não foi possível avançar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }

                    }

                    // Verifica se todas as equipes têm grupo
                    int numTotalEquipes = dgvEquipes.Rows.Count, numTotalEquipesEmGrupo = 0;
                    for (int iCount = 0; iCount < tabs.Controls.Count; iCount++) {
                        TabPage tabPage = ((TabPage)tabs.Controls[0]);
                        numTotalEquipesEmGrupo += ((DataGridView)(tabPage.Controls[0])).Rows.Count;
                    }

                    if (numTotalEquipesEmGrupo != numTotalEquipes) {
                        MessageBox.Show("Por favor verifique" + Environment.NewLine + Environment.NewLine +
                                "O número total de equipes que estão em um grupo e o número de equipes é diferente.",
                                "Não foi possível avançar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Verifica se já foram criadas as partidas
                    int numCorretoPartidas = 0;
                    for (int iCount = 0; iCount < competicao.grupos.Count; iCount++) {
                        numCorretoPartidas += (competicao.grupos[iCount].Count - (competicao.grupos[iCount].Count % 2 == 1 ? 0 : 1)) * competicao.grupos[iCount].Count / 2;
                    }
                    if (competicao.jogosIdaEVolta)
                        numCorretoPartidas *= 2;

                    if (numCorretoPartidas != competicao.partidas.Count) {
                        MessageBox.Show("Por favor verifique" + Environment.NewLine + Environment.NewLine +
                                "Não foram criadas todas as partidas que tinham que ser criadas. Clique em Gerar partidas e tente novamente.",
                                "Não foi possível avançar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    newCompeticao = competicao;
                    newCompeticao.status = StatusEnum._2_Iniciada;

                    if (CompeticaoRepositorio.Instance.update(newCompeticao, ref errorMessage)) {
                        competicao = newCompeticao;
                    } else {
                        MessageBox.Show("Houve um erro ao tentar salvar o registro." + Environment.NewLine + Environment.NewLine + errorMessage, "Contate o Suporte técnico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    load(null, null);
                    break;
            }

        }
        private void btnIncluirEquipes_Click(object sender, EventArgs e) {
            // Função responsável por chamar o form responsável por selecionar as equipes que serão selecionadas

            insertEquipeForm = new InsertEquipe(competicao.id);
            insertEquipeForm.FormClosing += insertEquipeForm_FormClosing;
            insertEquipeForm.ShowDialog();
        }

        private void insertEquipeForm_FormClosing(object sender, FormClosingEventArgs e) {
            // Função responsável por incluir as equipes que foram selecionadas na tela de inclusão de equipes na competição

            for (int iCount = 0; iCount < insertEquipeForm.equipesAInserir.Count; iCount++) {
                equipes.Add(new EquipeCompeticao(insertEquipeForm.equipesAInserir[iCount].codigo, insertEquipeForm.equipesAInserir[iCount].nome, null, null));
                Equipe equipe = insertEquipeForm.equipesAInserir[iCount];
                CompeticaoRepositorio.Instance.insertEquipeEmCompeticao(competicao.id, equipe);
            }
            refreshDataGridView();
        }
        private void btnExcluirEquipe_Click(object sender, EventArgs e) {
            // Função responsável por excluir uma equipe da competição

            if (dgvEquipes.SelectedCells.Count > 0) {
                EquipeCompeticao equipe;
                equipe = equipes[dgvEquipes.SelectedCells[0].RowIndex];
                if (MessageBox.Show("Confirma a deleção do registro ?" +
                    Environment.NewLine + Environment.NewLine +
                    equipe.ToString(), "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    if (CompeticaoRepositorio.Instance.deleteEquipeDaCompeticao(equipe, competicao.id, ref errorMessage)) {
                        equipes.RemoveAt(dgvEquipes.SelectedCells[0].RowIndex);
                        refreshDataGridView();
                    } else {
                        MessageBox.Show("Houve um erro ao tentar salvar o registro." + Environment.NewLine + Environment.NewLine + errorMessage, "Contate o Suporte técnico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        #endregion
        #region Comportamentos do form
        private void clearFields() {
            txtNome.Text = "";
            txtDtInicio.Text = "";
            txtDtFim.Text = "";
            cboModalidades.SelectedIndex = -1;
            txtNumTimes.Text = "0";
            txtNumMinJogadores.Text = "0";
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

            competicao = CompeticaoRepositorio.Instance.get(competicao.id);

            // Carrega o combobox das opções de mata-mata (conferir o MataMataEnum da classe Competicao)
            cboMataMata.Items.Clear();
            cboMataMata.Items.Add("Não");               //_1_Nao,
            cboMataMata.Items.Add("Final");             //_2_Final,
            cboMataMata.Items.Add("Semi-Final");        //_3_SemiFinal,
            cboMataMata.Items.Add("Quartas de Final");  //_4_QuartasFinal,
            cboMataMata.Items.Add("Oitavas de Final");  //_5_OitavasFinal,

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
            txtNumMinJogadores.Text = competicao.numMinimoJogadores.ToString();

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
            }

            switch (competicao.status) {
                case StatusEnum._0_Encerrada:
                    txtStatus.Text = "Competição encerrada";

                    btnAvancar.Text = "";
                    btnAvancar.Enabled = false;
                    btnVoltar.Text = "Reabrir";
                    btnVoltar.Enabled = true;
                    break;
                case StatusEnum._1_Aberta:
                    txtStatus.Text = "Competição aberta";

                    btnAvancar.Text = "Preparar";
                    btnAvancar.Enabled = true;
                    btnVoltar.Text = "";
                    btnVoltar.Enabled = false;
                    break;
                case StatusEnum._2_Iniciada:
                    txtStatus.Text = "Competição iniciada";

                    btnAvancar.Text = "Encerrar";
                    btnAvancar.Enabled = true;
                    btnVoltar.Text = "Voltar";
                    btnVoltar.Enabled = true;
                    break;
                case StatusEnum._3_EmPreparacao:
                    txtStatus.Text = "Competição em preparação";

                    btnAvancar.Text = "Iniciar";
                    btnAvancar.Enabled = true;
                    btnVoltar.Text = "Voltar";
                    btnVoltar.Enabled = true;
                    break;
                default:
                    txtStatus.Text = "";
                    btnAvancar.Text = "";
                    break;
            }

            switch (competicao.nomesGrupos) {
                case NomesGruposEnum._0_PorNumeracao:
                    cboNomeacaoGrupos.SelectedIndex = 0;
                    break;
                case NomesGruposEnum._1_PorLetras:
                    cboNomeacaoGrupos.SelectedIndex = 1;
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
                case Utilidades.WindowMode.ModoNormal:
                case Utilidades.WindowMode.ModoCriacaoForm:
                    btnCancelar.Enabled = false;
                    btnSalvar.Enabled = false;
                    dgvEquipes.Enabled = true;
                    btnAtualizar.Enabled = true;
                    btnAvancar.Enabled = true;
                    btnVoltar.Enabled = true;
                    break;
                case Utilidades.WindowMode.ModoDeEdicao:
                    btnCancelar.Enabled = true;
                    btnSalvar.Enabled = true;
                    dgvEquipes.Enabled = false;
                    btnAtualizar.Enabled = false;
                    btnAvancar.Enabled = false;
                    btnVoltar.Enabled = false;
                    break;
                case Utilidades.WindowMode.ModoDeInsercao:
                    btnCancelar.Enabled = true;
                    btnSalvar.Enabled = true;
                    dgvEquipes.Enabled = false;
                    btnAtualizar.Enabled = false;
                    btnAvancar.Enabled = false;
                    btnVoltar.Enabled = false;
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

        private void dgvEquipes_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e) {
            if (e.RowIndex > -1) {
                EquipeCompeticao equipe = equipes[e.RowIndex];
                EditEquipe formEditEquipe = new EditEquipe(equipe, competicao);
                formEditEquipe.FormClosing += formEditEquipe_FormClosing;
                formEditEquipe.ShowDialog();
            }
        }

        private void formEditEquipe_FormClosing(object sender, FormClosingEventArgs e) {
            btnAtualizar_Click(null, null);
        }

        private void load(object sender, EventArgs e) {
            btnAtualizar_Click(null, null);
        }

        private void btnGerarGrupos_Click(object sender, EventArgs e) {
            // O número de grupos precisa ser maior que 0
            // O número de times definidos precisa ser maior que 0
            // O número de times inseridos precisa ser igual o número de times definidos

            if (competicao.numGrupos > 0 && competicao.numTimes > 0 && competicao.numTimes == equipes.Count) {

                competicao.grupos = new List<List<EquipeCompeticao>>();
                CompeticaoRepositorio.Instance.deleteGrupos(competicao.id);

                List<EquipeCompeticao> equipes_Sorteio = new List<EquipeCompeticao>(equipes);
                int numTimesPorGrupo = competicao.numTimes / competicao.numGrupos;
                int numTimesRestantes = competicao.numTimes % competicao.numGrupos;

                tabs.Controls.Clear();

                for (var numGrupo = 0; numGrupo < competicao.numGrupos; numGrupo++) {
                    DataGridView dataGridView = CompeticaoViewUtilidades.criaAba(CompeticaoViewUtilidades.getNomeGrupo(competicao.nomesGrupos, numGrupo + 1), numGrupo, tabs, dgvGrupoEquipes_CellMouseClick);

                    competicao.grupos.Add(new List<EquipeCompeticao>());

                    // Faz o sorteio das equipes
                    for (int jCount = 0; jCount < numTimesPorGrupo; jCount++) {
                        int numSorteado = new Random().Next(equipes_Sorteio.Count - 1);
                        enviarParaGrupo(numGrupo, equipes_Sorteio[numSorteado]);
                        equipes_Sorteio.RemoveAt(numSorteado);
                    }

                    //Atualiza o DataGridView com as equipes daquele grupo
                    CompeticaoViewUtilidades.refreshDataGridViewGrupos(dataGridView, competicao.grupos[numGrupo]);
                }
            }
        }

        private void dgvGrupoEquipes_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
            if (e.RowIndex > -1 && e.ColumnIndex > -1) {
                if (e.Button == MouseButtons.Right) {

                    DataGridView dataGridView = (DataGridView)sender;
                    int indiceGrupo = Convert.ToInt32(dataGridView.Tag);

                    // Cria o menu de contexto e suas respectivas configurações para cada equipe do grupo
                    ContextMenu contextMenu = new ContextMenu();
                    MenuItem menuItem = new MenuItem("Excluir " + competicao.grupos[indiceGrupo][e.RowIndex].codigo + " - " + competicao.grupos[indiceGrupo][e.RowIndex].nome + " do " + tabs.Controls[indiceGrupo].Text);
                    menuItem.Click += excluirDoGrupo;
                    menuItem.Tag = competicao.grupos[indiceGrupo][e.RowIndex].id.ToString() + "|-|" + indiceGrupo.ToString();
                    contextMenu.MenuItems.Add(menuItem);

                    // Define onde será aberto o menu de contexto
                    contextMenu.Show(dataGridView, new System.Drawing.Point(dataGridView.RowHeadersWidth, dataGridView.ColumnHeadersHeight));

                }
            }
        }

        private void excluirDoGrupo(object sender, EventArgs e) {
            string tagMenuItem = ((MenuItem)sender).Tag.ToString();
            int idEquipe = Convert.ToInt32(tagMenuItem.Substring(0, tagMenuItem.IndexOf("|-|")));
            int idGrupo = Convert.ToInt32(tagMenuItem.Substring(idEquipe.ToString().Length + 3));

            // Identifica a equipe e a remove do grupo
            EquipeCompeticao equipe = competicao.grupos[idGrupo].Find(equipeAEncontrar => equipeAEncontrar.id == idEquipe);
            competicao.grupos[idGrupo].Remove(equipe);

            CompeticaoRepositorio.Instance.deleteEquipeDoGrupo(competicao.id, idGrupo, equipe.id);

            // Atualiza o DataSource dos grupos
            DataGridView dgvGrupo = (DataGridView)tabs.Controls[idGrupo].Controls[0];
            CompeticaoViewUtilidades.refreshDataGridViewGrupos(dgvGrupo, competicao.grupos[idGrupo]);

        }

        private void btnVoltar_Click(object sender, EventArgs e) {
            Competicao newCompeticao;

            switch (competicao.status) { // Encerrada >> Iniciada
                case StatusEnum._0_Encerrada:
                    newCompeticao = competicao;
                    newCompeticao.status = StatusEnum._2_Iniciada;

                    if (CompeticaoRepositorio.Instance.update(newCompeticao, ref errorMessage)) {
                        competicao = newCompeticao;
                    } else {
                        MessageBox.Show("Houve um erro ao tentar salvar o registro." + Environment.NewLine + Environment.NewLine + errorMessage, "Contate o Suporte técnico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    load(null, null);

                    break;
                case StatusEnum._1_Aberta:
                     break;
                case StatusEnum._2_Iniciada: // Iniciada >> Em preparação

                    if (competicao.partidas.FindAll(x => x.encerrada).Count > 0) {
                        MessageBox.Show("Por favor verifique" + Environment.NewLine + Environment.NewLine +
                                        "Já existem partidas encerradas nesta competição, não é possível voltar para em preparação.",
                                        "Não foi possível avançar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    } else {
                        newCompeticao = competicao;
                        newCompeticao.status = StatusEnum._3_EmPreparacao;

                        if (CompeticaoRepositorio.Instance.update(newCompeticao, ref errorMessage)) {
                            competicao = newCompeticao;

                            // Deleta as partidas até então criadas
                            CompeticaoRepositorio.Instance.deletaPartidas(ref competicao);
                        } else {
                            MessageBox.Show("Houve um erro ao tentar salvar o registro." + Environment.NewLine + Environment.NewLine + errorMessage, "Contate o Suporte técnico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        load(null, null);
                    }
                    break;

                case StatusEnum._3_EmPreparacao: // Em preparação >> Aberta
                    newCompeticao = competicao;
                    newCompeticao.status = StatusEnum._1_Aberta;

                    if (CompeticaoRepositorio.Instance.update(newCompeticao, ref errorMessage)) {
                        competicao = newCompeticao;
                    } else {
                        MessageBox.Show("Houve um erro ao tentar salvar o registro." + Environment.NewLine + Environment.NewLine + errorMessage, "Contate o Suporte técnico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    load(null, null);
                    break;
            }
        }

        private void btnGerarPartidas_Click(object sender, EventArgs e) {
            // Verifica se todas as equipes têm grupo
            int numTotalEquipes = dgvEquipes.Rows.Count, numTotalEquipesEmGrupo = 0;
            for (int iCount = 0; iCount < tabs.Controls.Count; iCount++) {
                TabPage tabPage = ((TabPage)tabs.Controls[0]);
                numTotalEquipesEmGrupo += ((DataGridView)(tabPage.Controls[0])).Rows.Count;
            }

            if (numTotalEquipesEmGrupo != numTotalEquipes) {
                MessageBox.Show("Por favor verifique" + Environment.NewLine + Environment.NewLine +
                        "O número total de equipes que estão em um grupo e o número de equipes é diferente.",
                        "Não foi possível gerar as partidas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Deleta as partidas até então criadas
            CompeticaoRepositorio.Instance.deletaPartidas(ref competicao);

            // Faz a criação das partidas pelos grupos
            for (int numGrupo = 0; numGrupo < competicao.grupos.Count; numGrupo++) {
                List<EquipeCompeticao> grupo = competicao.grupos[numGrupo];
                int timesNoGrupo = grupo.Count;

                // Define o número de rodas únicas
                int numRodadasUnicas = timesNoGrupo - (timesNoGrupo % 2 == 1 ? 0 : 1);

                int timesASobrarPorRodada = timesNoGrupo % 2;

                // Partidas
                List<Competicao_Partida> partidas = new List<Competicao_Partida>();
                for (int numRodada = 0; numRodada < numRodadasUnicas; numRodada++) {

                    List<EquipeCompeticao> timesRodada = reorganiza(new List<EquipeCompeticao>(grupo));

                    // Faz o sorteio das rodadas
                    while (timesRodada.Count > timesASobrarPorRodada) {

                        Competicao_Partida partida = null;
                        EquipeCompeticao equipe1;
                        EquipeCompeticao equipe2;

                        Random random = new Random();
                        bool repeat = false;
                        do {
                            int index1;

                            index1 = random.Next(0, timesRodada.Count);
                            equipe1 = timesRodada[index1];
                            timesRodada.Remove(equipe1);

                            equipe2 = encontraAdversario(equipe1, timesRodada, partidas);
                            if (equipe2 is null) {
                                partidas.RemoveAll(x => x.rodada == numRodada + 1);
                                timesRodada = new List<EquipeCompeticao>(grupo);
                                repeat = true;
                            } else {
                                timesRodada.Remove(equipe2);

                                partida = new Competicao_Partida(equipe1, equipe2, numRodada + 1, numGrupo);

                                if (partidaJaExiste(partidas, partida)) {
                                    timesRodada.Add(equipe1);
                                    timesRodada.Add(equipe2);
                                    repeat = true;
                                } else {
                                    repeat = false;
                                }
                            }
                        } while (repeat);

                        Console.WriteLine("Rodada: " + numRodada + ". Partida entre " + equipe1.nome + " x " + equipe2.nome);
                        partidas.Add(partida);
                    }
                    Console.WriteLine("Rodada: " + numRodada + " finalizada.");

                }

                foreach (Competicao_Partida partida in partidas) {
                    CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);
                }

            }

            if (competicao.jogosIdaEVolta) {
                // Cria as partidas de volta
                int numRodadasIda = CompeticaoRepositorio.Instance.getNumRodadas(competicao);
                int numPartidas = competicao.partidas.Count;

                for (int numPartida = 0; numPartida < numPartidas; numPartida++) {
                    Competicao_Partida partida = competicao.partidas[numPartida];

                    Competicao_Partida partidaDeVolta = new Competicao_Partida(partida.equipe2, partida.equipe1, partida.rodada + numRodadasIda, partida.numGrupo);

                    CompeticaoRepositorio.Instance.insertPartida(ref competicao, partidaDeVolta);
                }
            }
        }
        
        public EquipeCompeticao encontraAdversario(EquipeCompeticao equipe1, List<EquipeCompeticao> equipesRestantes, List<Competicao_Partida> partidas) {
            foreach(EquipeCompeticao equipe in equipesRestantes) {
                if (equipe.id != equipe1.id) {
                    if (partidas.FindAll(
                        x => x.equipe1.id == equipe1.id || x.equipe2.id == equipe1.id).FindAll(
                        y => y.equipe1.id == equipe.id || y.equipe2.id == equipe.id).Count == 0) {
                        return equipe;
                    }
                }
            }
            return null;
        }

        private List<EquipeCompeticao> reorganiza(List<EquipeCompeticao> timesRodada) {
            List<EquipeCompeticao> equipesReorganizadas = new List<EquipeCompeticao>();
            for (int iCount = 1; iCount < timesRodada.Count + 1; iCount++) {
                if (iCount >= timesRodada.Count)
                    equipesReorganizadas.Add(timesRodada[0]);
                else
                    equipesReorganizadas.Add(timesRodada[iCount]);
            }
            return equipesReorganizadas;
        }

        private bool partidaJaExiste(List<Competicao_Partida> partidas, Competicao_Partida partida) {

            if (partidas.FindAll(partida_ =>    (partida_.equipe1.id == partida.equipe1.id && partida_.equipe2.id == partida.equipe2.id) ||
                                                (partida_.equipe1.id == partida.equipe2.id && partida_.equipe2.id == partida.equipe1.id)).Count > 0)
                return true;
            else
                return false;
        }

        private void btnVisaoGeral_Click(object sender, EventArgs e) {
            new ViewCompeticao(competicao).ShowDialog();
        }
    }
}