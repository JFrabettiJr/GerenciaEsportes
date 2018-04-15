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

            Competicao newCompeticao = new Competicao(txtNome.Text, dataInicio, modalidade);
            newCompeticao.id = competicao.id;
            newCompeticao.dataInicial = dataInicio;

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
                case 5:
                    newCompeticao.mataMata = MataMataEnum._6_16AvosFinal;
                    break;
                case 6:
                    newCompeticao.mataMata = MataMataEnum._7_32AvosFinal;
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

            if (competicao.status == StatusEnum._1_Aberta) {
                // Competição aberta

                // Reajusta o DataGridView com as equipes
                dgvEquipes.Location = new System.Drawing.Point(dgvEquipes.Location.X, posicaoInicial);
                dgvEquipes.Size = new System.Drawing.Size(dgvEquipes.Size.Width, tamanhoTotal);

                // Deixa visível os botões/informações
                dgvEquipes.Visible = true;
                btnIncluirEquipes.Visible = true;
                btnExcluirEquipe.Visible = true;

                // Deixa invisível os botões/informações
                tabs.Visible = false;
                btnGerarGrupos.Visible = false;
            } else {
                // Competição em preparação, encerrada ou iniciada

                // Deixa visível os botões/informações
                tabs.Visible = true;

                // Deixa invisível os botões/informações
                btnIncluirEquipes.Visible = false;
                btnExcluirEquipe.Visible = false;

                // Cria a abas e os grupos
                tabs.Controls.Clear();
                for (int numGrupo = 0; numGrupo < competicao.numGrupos; numGrupo++) {
                    DataGridView dataGridView = criaAbaDeGrupo(getNomeGrupo(numGrupo + 1), numGrupo);

                    if (numGrupo < competicao.grupos.Count)
                        refreshDataGridViewGrupos(dataGridView, competicao.grupos[numGrupo]);
                    else
                        refreshDataGridViewGrupos(dataGridView, null);
                }

                if (competicao.status == StatusEnum._3_EmPreparacao) {
                    // Competição em preparação

                    // Deixa visível os botões/informações
                    dgvEquipes.Visible = true;
                    btnGerarGrupos.Visible = true;

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
                    btnGerarGrupos.Visible = false;
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

            refreshDataGridViewGrupos(dgvGrupo, competicao.grupos[idGrupo]);

            CompeticaoRepositorio.Instance.updateGrupos(competicao.id, idGrupo, equipe.id);
        }

        private void refreshDataGridViewGrupos(DataGridView dgvGrupo, List<EquipeCompeticao> dataSource) {
            dgvGrupo.DataSource = null;
            dgvGrupo.Refresh();

            dgvGrupo.Columns.Clear();

            dgvGrupo.DataSource = dataSource;

            if (!(dataSource is null)) {
                dgvGrupo.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = "SaldoGols" });
                dgvGrupo.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = "NumJogos" });
                dgvGrupo.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = "Aproveitamento" });
            }

            for (var iCount = 0; iCount < dgvGrupo.Columns.Count; iCount++) {
                switch (dgvGrupo.Columns[iCount].DataPropertyName) {
                    case nameof(EquipeCompeticao.nome):
                        dgvGrupo.Columns[iCount].HeaderText = "Nome da equipe";
                        dgvGrupo.Columns[iCount].Name = dgvGrupo.Columns[iCount].DataPropertyName;
                        break;
                    case nameof(EquipeCompeticao.codigo):
                        dgvGrupo.Columns[iCount].HeaderText = "Código";
                        dgvGrupo.Columns[iCount].Name = dgvGrupo.Columns[iCount].DataPropertyName;
                        break;
                    case "NumJogos":
                        dgvGrupo.Columns[iCount].HeaderText = "J";
                        dgvGrupo.Columns[iCount].Name = dgvGrupo.Columns[iCount].DataPropertyName;
                        dgvGrupo.Columns[iCount].Width = 40;
                        break;
                    case nameof(EquipeCompeticao.vitorias):
                        dgvGrupo.Columns[iCount].HeaderText = "V";
                        dgvGrupo.Columns[iCount].Name = dgvGrupo.Columns[iCount].DataPropertyName;
                        dgvGrupo.Columns[iCount].Width = 40;
                        break;
                    case nameof(EquipeCompeticao.empates):
                        dgvGrupo.Columns[iCount].HeaderText = "E";
                        dgvGrupo.Columns[iCount].Name = dgvGrupo.Columns[iCount].DataPropertyName;
                        dgvGrupo.Columns[iCount].Width = 40;
                        break;
                    case nameof(EquipeCompeticao.pontos):
                        dgvGrupo.Columns[iCount].HeaderText = "Pts.";
                        dgvGrupo.Columns[iCount].Name = dgvGrupo.Columns[iCount].DataPropertyName;
                        dgvGrupo.Columns[iCount].Width = 50;
                        break;
                    case nameof(EquipeCompeticao.derrotas):
                        dgvGrupo.Columns[iCount].HeaderText = "D";
                        dgvGrupo.Columns[iCount].Name = dgvGrupo.Columns[iCount].DataPropertyName;
                        dgvGrupo.Columns[iCount].Width = 40;
                        break;
                    case nameof(EquipeCompeticao.golsPro):
                        dgvGrupo.Columns[iCount].HeaderText = "GP";
                        dgvGrupo.Columns[iCount].Name = dgvGrupo.Columns[iCount].DataPropertyName;
                        dgvGrupo.Columns[iCount].Width = 40;
                        break;
                    case nameof(EquipeCompeticao.golsContra):
                        dgvGrupo.Columns[iCount].HeaderText = "GC";
                        dgvGrupo.Columns[iCount].Name = dgvGrupo.Columns[iCount].DataPropertyName;
                        dgvGrupo.Columns[iCount].Width = 40;
                        break;
                    case "SaldoGols":
                        dgvGrupo.Columns[iCount].HeaderText = "SG";
                        dgvGrupo.Columns[iCount].Name = dgvGrupo.Columns[iCount].DataPropertyName;
                        dgvGrupo.Columns[iCount].Width = 40;
                        break;
                    case "Aproveitamento":
                        dgvGrupo.Columns[iCount].HeaderText = " %";
                        dgvGrupo.Columns[iCount].Name = dgvGrupo.Columns[iCount].DataPropertyName;
                        dgvGrupo.Columns[iCount].Width = 50;
                        break;
                    default:
                        dgvGrupo.Columns[iCount].Visible = false;
                        break;
                }
            }

            //Preenche os campos que vieram sem preenchimento do data set
            for (var iCount = 0; iCount < dgvGrupo.Rows.Count; iCount++) {
                dgvGrupo.Rows[iCount].Cells["NumJogos"].Value = dataSource[iCount].vitorias + dataSource[iCount].derrotas + dataSource[iCount].empates;

                dgvGrupo.Rows[iCount].Cells["SaldoGols"].Value = dataSource[iCount].golsPro - dataSource[iCount].golsContra;

                if (dataSource[iCount].vitorias + dataSource[iCount].derrotas + dataSource[iCount].empates > 0)
                    dgvGrupo.Rows[iCount].Cells["Aproveitamento"].Value = dataSource[iCount].pontos * 100 / ((dataSource[iCount].vitorias + dataSource[iCount].derrotas + dataSource[iCount].empates) * 3);
                else
                    dgvGrupo.Rows[iCount].Cells["Aproveitamento"].Value = 0;
            }

            dgvGrupo.Refresh();
        }
        private string getNomeGrupo(int numeroGrupo) {
            string nomeGrupo = "Grupo ";

            if (competicao.nomesGrupos == NomesGruposEnum._0_PorNumeracao) {
                nomeGrupo += numeroGrupo.ToString();
            } else {
                switch (numeroGrupo) {
                    case 1: nomeGrupo += "A"; break;
                    case 2: nomeGrupo += "B"; break;
                    case 3: nomeGrupo += "C"; break;
                    case 4: nomeGrupo += "D"; break;
                    case 5: nomeGrupo += "E"; break;
                    case 6: nomeGrupo += "F"; break;
                    case 7: nomeGrupo += "G"; break;
                    case 8: nomeGrupo += "H"; break;
                    case 9: nomeGrupo += "I"; break;
                    case 10: nomeGrupo += "J"; break;
                    case 11: nomeGrupo += "K"; break;
                    case 12: nomeGrupo += "L"; break;
                    case 13: nomeGrupo += "M"; break;
                    case 14: nomeGrupo += "N"; break;
                    case 15: nomeGrupo += "O"; break;
                    case 16: nomeGrupo += "P"; break;
                }
            }

            return nomeGrupo;

        }
        private void btnAvancar_Click(object sender, EventArgs e) {
            Competicao newCompeticao;

            switch (competicao.status) {
                case StatusEnum._0_Encerrada:
                    break;
                case StatusEnum._1_Aberta:

                    // Mais de 1 equipe
                    if (dgvEquipes.Rows.Count == 1) {
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
                case StatusEnum._2_Iniciada:
                    newCompeticao = competicao;
                    newCompeticao.status = StatusEnum._0_Encerrada;

                    if (CompeticaoRepositorio.Instance.update(newCompeticao, ref errorMessage)) {
                        competicao = newCompeticao;
                    } else {
                        MessageBox.Show("Houve um erro ao tentar salvar o registro." + Environment.NewLine + Environment.NewLine + errorMessage, "Contate o Suporte técnico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    load(null, null);
                    break;

                case StatusEnum._3_EmPreparacao:
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
                            if (atleta.Numero is null || atleta.Numero < 1) {
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

            // Carrega o combobox das opções de mata-mata (conferir o MataMataEnum da classe Competicao)
            cboMataMata.Items.Clear();
            cboMataMata.Items.Add("Não");               //_1_Nao,
            cboMataMata.Items.Add("Final");             //_2_Final,
            cboMataMata.Items.Add("Semi-Final");        //_3_SemiFinal,
            cboMataMata.Items.Add("Quartas de Final");  //_4_QuartasFinal,
            cboMataMata.Items.Add("Oitavas de Final");  //_5_OitavasFinal,
            cboMataMata.Items.Add("16 avos de Final");  //_6_16AvosFinal,
            cboMataMata.Items.Add("32 avos de Final");  //_7_32AvosFinal

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
                case MataMataEnum._6_16AvosFinal:
                    cboMataMata.SelectedIndex = 5;
                    break;
                case MataMataEnum._7_32AvosFinal:
                    cboMataMata.SelectedIndex = 6;
                    break;
            }

            switch (competicao.status) {
                case StatusEnum._0_Encerrada:
                    txtStatus.Text = "Competição encerrada";

                    btnAvancar.Text = "";
                    btnAvancar.Visible = false;
                    btnVoltar.Text = "Reabrir";
                    btnVoltar.Visible = true;
                    break;
                case StatusEnum._1_Aberta:
                    txtStatus.Text = "Competição aberta";

                    btnAvancar.Text = "Preparar";
                    btnAvancar.Visible = true;
                    btnVoltar.Text = "";
                    btnVoltar.Visible = false;
                    break;
                case StatusEnum._2_Iniciada:
                    txtStatus.Text = "Competição iniciada";

                    btnAvancar.Text = "Encerrar";
                    btnAvancar.Visible = true;
                    btnVoltar.Text = "Voltar";
                    btnVoltar.Visible = true;
                    break;
                case StatusEnum._3_EmPreparacao:
                    txtStatus.Text = "Competição em preparação";

                    btnAvancar.Text = "Iniciar";
                    btnAvancar.Visible = true;
                    btnVoltar.Text = "Voltar";
                    btnVoltar.Visible = true;
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
                    break;
                case Utilidades.WindowMode.ModoDeEdicao:
                    btnCancelar.Enabled = true;
                    btnSalvar.Enabled = true;
                    dgvEquipes.Enabled = false;
                    btnAtualizar.Enabled = false;
                    btnAvancar.Enabled = false;
                    break;
                case Utilidades.WindowMode.ModoDeInsercao:
                    btnCancelar.Enabled = true;
                    btnSalvar.Enabled = true;
                    dgvEquipes.Enabled = false;
                    btnAtualizar.Enabled = false;
                    btnAvancar.Enabled = false;
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
                    DataGridView dataGridView = criaAbaDeGrupo(getNomeGrupo(numGrupo + 1), numGrupo);

                    competicao.grupos.Add(new List<EquipeCompeticao>());

                    // Faz o sorteio das equipes
                    for (int jCount = 0; jCount < numTimesPorGrupo; jCount++) {
                        int numSorteado = new Random().Next(equipes_Sorteio.Count - 1);
                        enviarParaGrupo(numGrupo, equipes_Sorteio[numSorteado]);
                        equipes_Sorteio.RemoveAt(numSorteado);
                    }

                    //Atualiza o DataGridView com as equipes daquele grupo
                    refreshDataGridViewGrupos(dataGridView, competicao.grupos[numGrupo]);
                }
            }
        }

        private DataGridView criaAbaDeGrupo(string nomeGrupo, int indiceGrupo) {
            // Cria o TabPage
            TabPage tabPage = new TabPage(nomeGrupo);
            tabPage.UseVisualStyleBackColor = true;
            tabPage.Padding = new Padding(3);

            // Cria o DataGridView
            DataGridView dataGridView = new DataGridView();
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToOrderColumns = true;
            dataGridView.BackgroundColor = System.Drawing.Color.Gainsboro;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.ReadOnly = true;
            dataGridView.RowTemplate.Resizable = DataGridViewTriState.True;
            dataGridView.Tag = indiceGrupo;

            dataGridView.CellMouseClick -= dgvGrupoEquipes_CellMouseClick;
            dataGridView.CellMouseClick += dgvGrupoEquipes_CellMouseClick;

            //Adiciona o DataGridView ao TabPage
            tabPage.Controls.Add(dataGridView);

            //Adiciona o TabPage às abas
            tabs.Controls.Add(tabPage);

            return dataGridView;
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
                    int x, y;
                    x = dataGridView.RowHeadersWidth;
                    y = (dataGridView[e.ColumnIndex, e.RowIndex].Size.Height * e.RowIndex) + dataGridView.ColumnHeadersHeight;
                    contextMenu.Show(dataGridView, new System.Drawing.Point(x, y));

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
            refreshDataGridViewGrupos(dgvGrupo, competicao.grupos[idGrupo]);

        }

        private void btnVoltar_Click(object sender, EventArgs e) {
            Competicao newCompeticao;

            switch (competicao.status) {
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
                case StatusEnum._2_Iniciada:
                    newCompeticao = competicao;
                    newCompeticao.status = StatusEnum._3_EmPreparacao;

                    if (CompeticaoRepositorio.Instance.update(newCompeticao, ref errorMessage)) {
                        competicao = newCompeticao;
                    } else {
                        MessageBox.Show("Houve um erro ao tentar salvar o registro." + Environment.NewLine + Environment.NewLine + errorMessage, "Contate o Suporte técnico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    load(null, null);
                    break;

                case StatusEnum._3_EmPreparacao:
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
    }
}