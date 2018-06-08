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

        private Usuario usuarioLogado;

        #region Inicialização da classe
        public EditCompeticao(Usuario usuarioLogado, Competicao competicao) {   
            windowMode = Utilidades.WindowMode.ModoCriacaoForm;
            InitializeComponent();

            // Centraliza a tela
            CenterToScreen();

            this.usuarioLogado = usuarioLogado;

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
                    default:
                        dgvEquipes.Columns[iCount].Visible = false;
                        dgvEquipes.Columns[iCount].DisplayIndex = 5;
                        break;
                }
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

            switch (cboFaseFinal.SelectedIndex) {
                case 0:
                    newCompeticao.faseFinal = FaseFinalEnum._1_Nao;
                    break;
                case 1:
                    newCompeticao.faseFinal = FaseFinalEnum._2_Final;
                    break;
                case 2:
                    newCompeticao.faseFinal = FaseFinalEnum._3_SemiFinal;
                    break;
                case 3:
                    newCompeticao.faseFinal = FaseFinalEnum._4_QuartasFinal;
                    break;
                case 4:
                    newCompeticao.faseFinal = FaseFinalEnum._5_OitavasFinal;
                    break;
            }

            switch (cboNomeacaoGrupos.SelectedIndex) {
                case 0: newCompeticao.nomesGrupos = NomesGruposEnum._0_PorNumeracao;    break;
                case 1: newCompeticao.nomesGrupos = NomesGruposEnum._1_PorLetras;   break;
            }

            switch (cboSuspensao.SelectedIndex) {
                case 0: newCompeticao.tpSuspensao = SuspensaoEnum._1_2CA_1Jogo_2CAe1CV_2Jogos; break;
                case 1: newCompeticao.tpSuspensao = SuspensaoEnum._2_3CA_1Jogo_3CAe1CV_2Jogos; break;
                case 2: newCompeticao.tpSuspensao = SuspensaoEnum._3_2CA_1Jogo; break;
                case 3: newCompeticao.tpSuspensao = SuspensaoEnum._4_3CA_1Jogo; break;
            }

            newCompeticao.jogosIdaEVolta = chkIdaEVolta.Checked;
            newCompeticao.jogosIdaEVolta_FaseFinal = chkIdaEVoltaFaseFinal.Checked;
            newCompeticao.zerarCartoesFaseFinal = chkZerarCartoesFaseFinal.Checked;

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

            competicao.arbitros = CompeticaoRepositorio.Instance.getArbitroPorCompeticao(competicao.id);

            // Verifica qual o modo que a competição está para avaliar qual será a visualizaçao
            int posicaoInicial, tamanhoTotal = 0;
            posicaoInicial = dgvEquipes.Location.Y;
            if (dgvEquipes.Visible)
                tamanhoTotal += dgvEquipes.Size.Height;
            if (tcGrupos.Visible)
                tamanhoTotal += tcGrupos.Size.Height;

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
                tcGrupos.Visible = false;
                btnGerarGrupos.Enabled = false;
            } else {
                // Competição em preparação, encerrada ou iniciada

                // Deixa visível os botões/informações
                tcGrupos.Visible = true;

                // Deixa invisível os botões/informações
                btnIncluirEquipes.Enabled = false;
                btnExcluirEquipe.Enabled = false;

                // Cria a abas e os grupos
                tcGrupos.Controls.Clear();

                // Seleciona os times até então classificados para a próxima fase
                int numProximaFase = 0;
                int numPartidasASeremGeradas = 0;

                switch (competicao.faseFinal) {
                    case FaseFinalEnum._5_OitavasFinal: numProximaFase = -4; numPartidasASeremGeradas = 8; break;
                    case FaseFinalEnum._4_QuartasFinal: numProximaFase = -3; numPartidasASeremGeradas = 4; break;
                    case FaseFinalEnum._3_SemiFinal: numProximaFase = -2; numPartidasASeremGeradas = 2; break;
                    case FaseFinalEnum._2_Final: numProximaFase = -1; numPartidasASeremGeradas = 1; break;
                }
                List<List<EquipeCompeticao>> timesProximaFase = Utilidades.listaEquipesClassificadas(competicao, numPartidasASeremGeradas, numProximaFase);

                for (int numGrupo = 0; numGrupo < competicao.numGrupos; numGrupo++) {
                    DataGridView dataGridView = CompeticaoViewUtilidades.criaAba(CompeticaoViewUtilidades.getNomeGrupo(competicao.nomesGrupos, numGrupo + 1), numGrupo, tcGrupos, dgvGrupoEquipes_CellMouseClick);
                    dataGridView.Tag = new List<Object> { numGrupo, competicao, usuarioLogado };
                    dataGridView.CellMouseDoubleClick += CompeticaoViewUtilidades.dgvEquipesGrupo_CellMouseDoubleClick;

                    if (numGrupo < competicao.grupos.Count)
                        CompeticaoViewUtilidades.refreshDataGridViewGrupos(competicao, dataGridView, competicao.grupos[numGrupo], timesProximaFase[numGrupo]);
                    else
                        CompeticaoViewUtilidades.refreshDataGridViewGrupos(competicao, dataGridView, null, null);
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
                    tcGrupos.Location = new System.Drawing.Point(tcGrupos.Location.X, posicaoInicial + dgvEquipes.Size.Height + 5);
                    tcGrupos.Size = new System.Drawing.Size(tcGrupos.Size.Width, tamanhoTotal / 2);

                    dgvEquipes.CellMouseClick -= dgvEquipes_CellMouseClick;
                    dgvEquipes.CellMouseClick += dgvEquipes_CellMouseClick;

                } else {
                    // Competição encerrada ou iniciada

                    // Bloqueia os campos para edição
                    bloqueiaCampos(true);

                    // Deleta o evento que seria acionado no clique do DataGridView dos grupos
                    for (int iCount = 0; iCount < tcGrupos.Controls.Count; iCount++) {
                        TabPage tabPage = (TabPage)tcGrupos.Controls[iCount];
                        ((DataGridView)tabPage.Controls[0]).CellMouseClick -= dgvGrupoEquipes_CellMouseClick;
                    }
                    
                    // Reajusta as abas com os grupos
                    tcGrupos.Location = new System.Drawing.Point(tcGrupos.Location.X, posicaoInicial);
                    tcGrupos.Size = new System.Drawing.Size(tcGrupos.Size.Width, tamanhoTotal);

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
            tlp3.Enabled = !bloqueia;
        }

        private void dgvEquipes_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
            if (e.RowIndex > -1 && e.ColumnIndex > -1) {
                if (e.Button == MouseButtons.Right) {

                    // Cria o menu de contexto e suas respectivas configurações
                    ContextMenu contextMenu = new ContextMenu();
                    for (var iCount = 0; iCount < tcGrupos.Controls.Count; iCount++) {
                        MenuItem menuItem = new MenuItem("Enviar " + equipes[e.RowIndex].codigo + " - " + equipes[e.RowIndex].nome + " para o " + tcGrupos.Controls[iCount].Text);
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
            if ((numTimesRestantes == 0 && competicao.grupos[idGrupo].Count >= numTimesPorGrupo) ||
                (competicao.grupos[idGrupo].Count >= (numTimesRestantes / competicao.numGrupos) + numTimesPorGrupo)) {
                insereEmGrupo = false;
            }

            if (insereEmGrupo) {
                // Verifica se o clube já está em algum grupo
                for (int numGrupo = 0; numGrupo < tcGrupos.Controls.Count; numGrupo++) {
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

            tcGrupos.SelectedIndex = (idGrupoInserido == null ? idGrupo : idGrupoInserido.Value);

        }

        private void enviarParaGrupo(int idGrupo, EquipeCompeticao equipe) {
            competicao.grupos[idGrupo].Add(equipe);

            // Atualiza o DataSource dos grupos
            DataGridView dgvGrupo = (DataGridView)tcGrupos.Controls[idGrupo].Controls[0];

            CompeticaoViewUtilidades.refreshDataGridViewGrupos(competicao, dgvGrupo, competicao.grupos[idGrupo], null);

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
                        if (EquipeRepositorio.Instance.getNumAtletasPorEquipe(competicao.id, equipe.id) < competicao.numMinimoJogadores) {
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
                    numPartidasRestantes = CompeticaoRepositorio.Instance.getNumPartidasRestantes(competicao);

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
                        if (!(EquipeRepositorio.Instance.todosAtletasTemNumero(competicao.id, equipe.id))) {
                            MessageBox.Show("Por favor verifique" + Environment.NewLine + Environment.NewLine +
                            "Existem equipes que têm atletas sem a numeração definida",
                            "Não foi possível avançar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                    }

                    // Verifica se todas as equipes têm grupo
                    int numTotalEquipes = dgvEquipes.Rows.Count, numTotalEquipesEmGrupo = 0;
                    for (int iCount = 0; iCount < tcGrupos.Controls.Count; iCount++) {
                        TabPage tabPage = ((TabPage)tcGrupos.Controls[0]);
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

                    //if (numCorretoPartidas != CompeticaoRepositorio.Instance.getnumPartidas(competicao)) {
                    if (CompeticaoRepositorio.Instance.getnumPartidas(competicao) == 0) {
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

            insertEquipeForm = new InsertEquipe(usuarioLogado, competicao.id);
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
            cboFaseFinal.SelectedIndex = -1;
            cboSuspensao.SelectedIndex = -1;
            chkIdaEVolta.Checked = false;
            chkZerarCartoesFaseFinal.Checked = false;
            chkIdaEVoltaFaseFinal.Checked = false;
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
            competicao.equipes = EquipeRepositorio.Instance.getEquipesByCompeticao(competicao.id);
            competicao.grupos = CompeticaoRepositorio.Instance.getGruposPorCompeticao(competicao.id, competicao.equipes);

            // Carrega o combobox das opções de fase final (conferir o FaseFinalEnum da classe Competicao)
            cboFaseFinal.Items.Clear();
            cboFaseFinal.Items.Add("Não");               //_1_Nao,
            cboFaseFinal.Items.Add("Final");             //_2_Final,
            cboFaseFinal.Items.Add("Semi-Final");        //_3_SemiFinal,
            cboFaseFinal.Items.Add("Quartas de Final");  //_4_QuartasFinal,
            cboFaseFinal.Items.Add("Oitavas de Final");  //_5_OitavasFinal,

            // Carrega o combobox das opções de nomeação dos grupos
            cboNomeacaoGrupos.Items.Clear();
            cboNomeacaoGrupos.Items.Add("Por numeração");
            cboNomeacaoGrupos.Items.Add("Por letras");

            // Carrega o combobox das opções de suspensão (conferir o SuspensaoEnum da classe Competicao)
            cboSuspensao.Items.Clear();
            cboSuspensao.Items.Add("2 CAs = 1 Jogo | 2 CAs + 1 CV = 2 Jogos");
            cboSuspensao.Items.Add("3 CAs = 1 Jogo | 3 CAs + 1 CV = 2 Jogos");
            cboSuspensao.Items.Add("2 CAs = 1 Jogo");
            cboSuspensao.Items.Add("3 CAs = 1 Jogo");

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

            switch (competicao.faseFinal) {
                case FaseFinalEnum._1_Nao:
                    cboFaseFinal.SelectedIndex = 0;
                    break;
                case FaseFinalEnum._2_Final:
                    cboFaseFinal.SelectedIndex = 1;
                    break;
                case FaseFinalEnum._3_SemiFinal:
                    cboFaseFinal.SelectedIndex = 2;
                    break;
                case FaseFinalEnum._4_QuartasFinal:
                    cboFaseFinal.SelectedIndex = 3;
                    break;
                case FaseFinalEnum._5_OitavasFinal:
                    cboFaseFinal.SelectedIndex = 4;
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
                case NomesGruposEnum._0_PorNumeracao:   cboNomeacaoGrupos.SelectedIndex = 0;    break;
                case NomesGruposEnum._1_PorLetras:  cboNomeacaoGrupos.SelectedIndex = 1;    break;
            }

            switch (competicao.tpSuspensao) {
                case SuspensaoEnum._1_2CA_1Jogo_2CAe1CV_2Jogos: cboSuspensao.SelectedIndex = 0; break;
                case SuspensaoEnum._2_3CA_1Jogo_3CAe1CV_2Jogos: cboSuspensao.SelectedIndex = 1; break;
                case SuspensaoEnum._3_2CA_1Jogo: cboSuspensao.SelectedIndex = 2; break;
                case SuspensaoEnum._4_3CA_1Jogo: cboSuspensao.SelectedIndex = 3; break;
            }
            
            chkIdaEVolta.Checked = competicao.jogosIdaEVolta;
            chkIdaEVoltaFaseFinal.Checked = competicao.jogosIdaEVolta_FaseFinal;
            chkZerarCartoesFaseFinal.Checked = competicao.zerarCartoesFaseFinal;

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
                new EditEquipe(usuarioLogado, equipe, competicao).ShowDialog();
            }
        }

        private void load(object sender, EventArgs e) {
            btnAtualizar_Click(null, null);

            toolTip1.SetToolTip(btnAtualizar, btnAtualizar.Tag.ToString());
            toolTip1.SetToolTip(btnCancelar, btnCancelar.Tag.ToString());
            toolTip1.SetToolTip(btnSalvar, btnSalvar.Tag.ToString());
            toolTip1.SetToolTip(btnIncluirEquipes, btnIncluirEquipes.Tag.ToString());
            toolTip1.SetToolTip(btnExcluirEquipe, btnExcluirEquipe.Tag.ToString());
            toolTip1.SetToolTip(btnArbitros, btnArbitros.Tag.ToString());
            toolTip1.SetToolTip(btnVisaoGeral, btnVisaoGeral.Tag.ToString());
            toolTip1.SetToolTip(btnGerarGrupos, btnGerarGrupos.Tag.ToString());
            toolTip1.SetToolTip(btnGerarPartidas, btnGerarPartidas.Tag.ToString());
            toolTip1.SetToolTip(btnAvancar, btnAvancar.Tag.ToString());
            toolTip1.SetToolTip(btnVoltar, btnVoltar.Tag.ToString());
        }

        private void btnGerarGrupos_Click(object sender, EventArgs e) {
            // O número de grupos precisa ser maior que 0
            // O número de times definidos precisa ser maior que 0
            // O número de times inseridos precisa ser igual o número de times definidos

            if (competicao.numGrupos > 0 && competicao.numTimes > 0 && competicao.numTimes == equipes.Count) {

                competicao.grupos = new List<List<EquipeCompeticao>>();
                CompeticaoRepositorio.Instance.deleteGrupos(ref competicao);

                List<EquipeCompeticao> equipes_Sorteio = new List<EquipeCompeticao>(equipes);
                int numTimesPorGrupo = competicao.numTimes / competicao.numGrupos;
                int numTimesRestantes = competicao.numTimes % competicao.numGrupos;

                tcGrupos.Controls.Clear();

                for (int numGrupo = 0; numGrupo < competicao.numGrupos; numGrupo++) {
                    DataGridView dataGridView = CompeticaoViewUtilidades.criaAba(CompeticaoViewUtilidades.getNomeGrupo(competicao.nomesGrupos, numGrupo + 1), numGrupo, tcGrupos, dgvGrupoEquipes_CellMouseClick);
                    dataGridView.Tag = new List<Object> { numGrupo, competicao, usuarioLogado };
                    dataGridView.CellMouseDoubleClick += CompeticaoViewUtilidades.dgvEquipesGrupo_CellMouseDoubleClick;

                    competicao.grupos.Add(new List<EquipeCompeticao>());

                    // Faz o sorteio das equipes
                    for (int iCount = 0; iCount < numTimesPorGrupo; iCount++) {
                        int numSorteado = new Random().Next(equipes_Sorteio.Count - 1);
                        enviarParaGrupo(numGrupo, equipes_Sorteio[numSorteado]);
                        equipes_Sorteio.RemoveAt(numSorteado);
                    }

                    // Insere as equipes restantes
                    if (numTimesRestantes > 0) {
                        int numSorteado = new Random().Next(equipes_Sorteio.Count - 1);
                        enviarParaGrupo(numGrupo, equipes_Sorteio[numSorteado]);
                        equipes_Sorteio.RemoveAt(numSorteado);
                        numTimesRestantes--;
                    }

                    //Atualiza o DataGridView com as equipes daquele grupo
                    // Seleciona os times até então classificados para a próxima fase
                    int numProximaFase = 0;
                    int numPartidasASeremGeradas = 0;

                    switch (competicao.faseFinal) {
                        case FaseFinalEnum._5_OitavasFinal: numProximaFase = -4; numPartidasASeremGeradas = 8; break;
                        case FaseFinalEnum._4_QuartasFinal: numProximaFase = -3; numPartidasASeremGeradas = 4; break;
                        case FaseFinalEnum._3_SemiFinal: numProximaFase = -2; numPartidasASeremGeradas = 2; break;
                        case FaseFinalEnum._2_Final: numProximaFase = -1; numPartidasASeremGeradas = 1; break;
                    }
                    List<List<EquipeCompeticao>> timesProximaFase = Utilidades.listaEquipesClassificadas(competicao, numPartidasASeremGeradas, numProximaFase);

                    CompeticaoViewUtilidades.refreshDataGridViewGrupos(competicao, dataGridView, competicao.grupos[numGrupo], timesProximaFase[numGrupo]);
                }

                MessageBox.Show(
                    "Grupos gerados.",
                    competicao.nome, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void dgvGrupoEquipes_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
            if (e.RowIndex > -1 && e.ColumnIndex > -1) {
                if (e.Button == MouseButtons.Right) {

                    DataGridView dataGridView = (DataGridView)sender;
                    int indiceGrupo = Convert.ToInt32(dataGridView.Tag);

                    // Cria o menu de contexto e suas respectivas configurações para cada equipe do grupo
                    ContextMenu contextMenu = new ContextMenu();
                    MenuItem menuItem = new MenuItem("Excluir " + competicao.grupos[indiceGrupo][e.RowIndex].codigo + " - " + competicao.grupos[indiceGrupo][e.RowIndex].nome + " do " + tcGrupos.Controls[indiceGrupo].Text);
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
            DataGridView dgvGrupo = (DataGridView)tcGrupos.Controls[idGrupo].Controls[0];

            CompeticaoViewUtilidades.refreshDataGridViewGrupos(competicao, dgvGrupo, competicao.grupos[idGrupo], null);

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

                    if (CompeticaoRepositorio.Instance.getNumPartidasEncerradas(competicao) > 0) {
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

                            // Deleta os grupos até então criados
                            CompeticaoRepositorio.Instance.deleteGrupos(ref competicao);
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

                        // Deleta as partidas até então criadas
                        CompeticaoRepositorio.Instance.deletaPartidas(ref competicao);

                        // Deleta os grupos até então criados
                        CompeticaoRepositorio.Instance.deleteGrupos(ref competicao);

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
            for (int iCount = 0; iCount < tcGrupos.Controls.Count; iCount++) {
                TabPage tabPage = ((TabPage)tcGrupos.Controls[iCount]);
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
                List<EquipeCompeticao> equipesNoGrupo = competicao.grupos[numGrupo];
                int timesNoGrupo = equipesNoGrupo.Count;

                // Define o número de equipes que ficarão para o chapéu
                int timesASobrarPorRodada = timesNoGrupo % 2;

                // Define o número de rodas únicas
                int numRodadasUnicas = timesNoGrupo - (timesASobrarPorRodada == 1 ? 0 : 1);

                // Lista com as equipes que ficaram para o chapéu por rodada
                List<EquipeCompeticao> equipeQueSobra = new List<EquipeCompeticao>();

                // Partidas
                List<Competicao_Partida> partidas = new List<Competicao_Partida>();
                for (int numRodada = 0; numRodada < numRodadasUnicas; numRodada++) {

                    List<EquipeCompeticao> timesRodada = reorganiza(new List<EquipeCompeticao>(equipesNoGrupo));

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
                                timesRodada = new List<EquipeCompeticao>(equipesNoGrupo);
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
                                    
                                    // Quando tiver um número ímpar no grupo verifica se a equipe que está ficando para o chapéu já havia ficado numa rodada anterior
                                    if (timesRodada.Count == 1 && timesASobrarPorRodada == 1) {
                                        // Se uma equipe que já havia ficado para o chapéu ficar novamente, refaz a rodada
                                        if (equipeJaSobrouNoutraRodada(timesRodada[0], equipeQueSobra)){
                                            partidas.RemoveAll(x => x.rodada == numRodada + 1);
                                            timesRodada = new List<EquipeCompeticao>(equipesNoGrupo);
                                            repeat = true;
                                        } else {
                                            equipeQueSobra.Add(timesRodada[0]);
                                        }
                                    }
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

            MessageBox.Show(
                "Partidas geradas.",
                competicao.nome, MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private bool equipeJaSobrouNoutraRodada(EquipeCompeticao equipeASobrar, List<EquipeCompeticao> equipeQueSobra) {
            foreach(EquipeCompeticao equipeJaSobrou in equipeQueSobra) {
                if (equipeJaSobrou.id == equipeASobrar.id) {
                    return true;
                }
            }
            return false;
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
            new ViewCompeticao(usuarioLogado, competicao).ShowDialog();
        }

        private void btnArbitros_Click(object sender, EventArgs e) {
            new EditArbitros(usuarioLogado, competicao).ShowDialog();
        }

        private void btn_EnableChanged(object sender, EventArgs e) {
            PictureBox pictureBox = (PictureBox)sender;
            Utilidades.enabled_Change(pictureBox.Enabled, pictureBox);
        }

    }
}