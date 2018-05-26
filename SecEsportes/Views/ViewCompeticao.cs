using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SecEsportes.Infraestrutura;
using SecEsportes.Modelo;
using System.Linq;
using SecEsportes.Repositorio;
using System.Drawing;
using System.Text;

namespace SecEsportes.Views
{
    public partial class ViewCompeticao : Form
    {
        private Utilidades.WindowMode windowMode;
        private Competicao competicao;
        private List<Atleta_List_Artilheiro> artilheiros;
        private string errorMessage = "";
        private List<List<Competicao_Partida>> partidasPorRodada;
        private List<List<Competicao_Partida>> partidasPorRodada_view;
        private List<DataGridView> dgvRodadas;
        private SetArbitro setArbitroForm;

        private Usuario usuarioLogado;

        #region Inicialização da classe
        public ViewCompeticao(Usuario usuarioLogado, Competicao competicao)
        {
            InitializeComponent();

            // Centraliza o form na tela
            CenterToScreen();

            this.usuarioLogado = usuarioLogado;

            this.competicao = competicao;
            this.Text += " - " + competicao.nome;

        }
        #endregion
        private void load(object sender, EventArgs e) {
            lblCompeticao.Text = competicao.nome;

            competicao.partidas = CompeticaoRepositorio.Instance.getPartidasPorCompeticao(competicao.id);

            // Cria as abas das partidas
            tcPartidas.Controls.Clear();
            tcAbas.SelectedTab = tpPartidas;

            dgvRodadas = new List<DataGridView>();
            partidasPorRodada = new List<List<Competicao_Partida>>();
            int numRodadas = CompeticaoRepositorio.Instance.getNumRodadas(competicao);
            for (int numRodada = 0; numRodada < numRodadas; numRodada++) {
                DataGridView dgvRodada = CompeticaoViewUtilidades.criaAba("Rodada " + (numRodada + 1).ToString(), numRodada, tcPartidas, dgvPartidas_CellMouseClick);
                dgvRodada.Tag = numRodada + 1;
                dgvRodada.ReadOnly = false;
                dgvRodada.CellEndEdit += dgvRodada_CellEndEdit;
                dgvRodada.CellMouseDoubleClick += dgvRodadas_CellMouseDoubleClick;

                dgvRodadas.Add(dgvRodada);

                List<Competicao_Partida> partidas = competicao.partidas.FindAll(partidasAEncontrar => partidasAEncontrar.rodada == numRodada + 1);
                CompeticaoViewUtilidades.refreshDataGridViewRodadas(dgvRodada, partidas, competicao, numRodada);

                partidasPorRodada.Add(partidas);
            }

            // Cria as abas das partidas da fase final
            int numAbasAdicionais = 0;
            switch (competicao.mataMata) {
                case MataMataEnum._1_Nao:   numAbasAdicionais = 0;  break;
                case MataMataEnum._2_Final: numAbasAdicionais = 1; break;
                case MataMataEnum._3_SemiFinal: numAbasAdicionais = 2; break;
                case MataMataEnum._4_QuartasFinal: numAbasAdicionais = 3; break;
                case MataMataEnum._5_OitavasFinal: numAbasAdicionais = 4; break;
            }

            // Define o nome da aba e o número da rodada (fase final)
            for (int numAbaAdicional = 0; numAbaAdicional < numAbasAdicionais; numAbaAdicional++) {
                string nomeAba = "";
                int numRodada = 0;
                switch (numAbasAdicionais) {
                    case 1:
                        nomeAba = "Final";
                        numRodada = -1;
                        break;
                    case 2:
                        switch (numAbaAdicional) {
                            case 0:
                                nomeAba = "Semi-Final";
                                numRodada = -2;
                                break;
                            case 1:
                                nomeAba = "Final";
                                numRodada = -1;
                                break;
                        }
                        break;
                    case 3:
                        switch (numAbaAdicional) {
                            case 0:
                                nomeAba = "Quartas de Final";
                                numRodada = -3;
                                break;
                            case 1:
                                nomeAba = "Semi-Final";
                                numRodada = -2;
                                break;
                            case 2:
                                nomeAba = "Final";
                                numRodada = -1;
                                break;
                        }
                        break;
                    case 4:
                        switch (numAbaAdicional) {
                            case 0:
                                nomeAba = "Oitavas de Final";
                                numRodada = -4;
                                break;
                            case 1:
                                nomeAba = "Quartas de Final";
                                numRodada = -3;
                                break;
                            case 2:
                                nomeAba = "Semi-Final";
                                numRodada = -2;
                                break;
                            case 3:
                                nomeAba = "Final";
                                numRodada = -1;
                                break;
                        }
                        break;
                }
                DataGridView dgvRodada = CompeticaoViewUtilidades.criaAba(nomeAba, numRodada, tcPartidas);
                dgvRodada.Tag = numRodada;
                dgvRodada.CellMouseDoubleClick += dgvRodadas_CellMouseDoubleClick;
                dgvRodada.ReadOnly = false;
                dgvRodada.CellEndEdit += dgvRodada_CellEndEdit;
                dgvRodadas.Add(dgvRodada);

                List<Competicao_Partida> partidas = competicao.partidas.FindAll(partidasAEncontrar => partidasAEncontrar.rodada == numRodada);
                partidasPorRodada.Add(partidas);

                CompeticaoViewUtilidades.refreshDataGridViewRodadas(dgvRodada, partidas, competicao, numRodada);
            }

            partidasPorRodada_view = new List<List<Competicao_Partida>>(partidasPorRodada);

            if (competicao.status == StatusEnum._0_Encerrada)
                btnProximaFase.Enabled = false;
            else
                btnProximaFase.Enabled = true;

            // Cria a abas dos grupos e a classificação
            tcClassificacao.Controls.Clear();
            tcAbas.SelectedTab = tpClassificacao;

            // Seleciona os times até então classificados para a próxima fase
            int numProximaFase = 0;
            int numPartidasASeremGeradas = 0;

            switch (competicao.mataMata) {
                case MataMataEnum._5_OitavasFinal: numProximaFase = -4; numPartidasASeremGeradas = 8; break;
                case MataMataEnum._4_QuartasFinal: numProximaFase = -3; numPartidasASeremGeradas = 4; break;
                case MataMataEnum._3_SemiFinal: numProximaFase = -2; numPartidasASeremGeradas = 2; break;
                case MataMataEnum._2_Final: numProximaFase = -1; numPartidasASeremGeradas = 1; break;
            }

            competicao.equipes = EquipeRepositorio.Instance.getEquipesByCompeticao(competicao.id);
            competicao.grupos = CompeticaoRepositorio.Instance.getGruposPorCompeticao(competicao.id, competicao.equipes);

            List<List<EquipeCompeticao>> timesProximaFase = Utilidades.listaEquipesClassificadas(competicao, numPartidasASeremGeradas, numProximaFase);

            for (int numGrupo = 0; numGrupo < competicao.numGrupos; numGrupo++) {
                DataGridView dgvGrupos = CompeticaoViewUtilidades.criaAba(CompeticaoViewUtilidades.getNomeGrupo(competicao.nomesGrupos, numGrupo + 1), numGrupo, tcClassificacao);

                if (numGrupo < competicao.grupos.Count)
                    CompeticaoViewUtilidades.refreshDataGridViewGrupos(competicao, dgvGrupos, competicao.grupos[numGrupo], timesProximaFase[numGrupo]);
                else
                    CompeticaoViewUtilidades.refreshDataGridViewGrupos(competicao, dgvGrupos, null, null);
            }

            // Cria a aba de artilheiros
            tcAbas.SelectedTab = tpArtilheiros;
            artilheiros = CompeticaoRepositorio.Instance.getArtilheiros(competicao.id);
            refreshDataGridViewArtilheiros(dgvArtilheiros, artilheiros);
            
            // Verifica qual a atual fase da competicao
            if (competicao.status == StatusEnum._0_Encerrada) {
                lblFase.Text = "Campeão: " + competicao.campeao.nome;
            } else {
                string nomeFaseAtual = "";
                switch (competicao.fase_Atual) {
                    case 0: nomeFaseAtual = "Classificatória"; break;
                    case -1: nomeFaseAtual = "Final"; break;
                    case -2: nomeFaseAtual = "Semi-Final"; break;
                    case -3: nomeFaseAtual = "Quartas de Final"; break;
                    case -4: nomeFaseAtual = "Oitava de Final"; break;
                    case -5: nomeFaseAtual = "16 avos de Final"; break;
                    case -6: nomeFaseAtual = "32 avos de Final"; break;
                }
                lblFase.Text = "Fase atual: " + nomeFaseAtual;
            }

            tcAbas.SelectedIndex = 0;

            //Preenche o ComboBox da busca
            cboCamposBusca.Items.Clear();
            cboCamposBusca.Items.Add("Equipe");

            cboCamposBusca.SelectedIndex = 0;

        }

        private void dgvRodada_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex > -1) {
                DataGridView dataGridView = (DataGridView)sender;
                Competicao_Partida partida = partidasPorRodada_view[tcPartidas.SelectedIndex][e.RowIndex];

                string strData = dataGridView.Rows[e.RowIndex].Cells["Data_view"].Value.ToString();
                DateTime dataPartida = new DateTime();
                if (DateTime.TryParseExact(strData, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.NoCurrentDateDefault, out dataPartida)) {
                    if (dataPartida.Date >= DateTime.Now.Date) {
                        partida.data = dataPartida;
                        partidasPorRodada_view[tcPartidas.SelectedIndex][e.RowIndex].data = dataPartida;
                        partidasPorRodada[tcPartidas.SelectedIndex].Find(find => find.id == partida.id).data = dataPartida;

                        CompeticaoRepositorio.Instance.updatePartida(ref competicao, partida);

                        return;
                    }
                }

                dataGridView.Rows[e.RowIndex].Cells["Data_view"].Value = "";

            }
        }

        private void dgvPartidas_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
            if (e.RowIndex > -1 && e.ColumnIndex > -1) {
                if (e.Button == MouseButtons.Right) {

                    DataGridView dataGridView = (DataGridView)sender;

                    // Recupera a partida que foi selecionada
                    List<Competicao_Partida> partidas = competicao.partidas.FindAll(find => find.rodada == Convert.ToInt32(dataGridView.Tag));
                    Competicao_Partida partida = partidas[e.RowIndex];

                    // Cria o menu de contexto e suas respectivas configurações para cada equipe do grupo
                    ContextMenu contextMenu = new ContextMenu(); ;
                    MenuItem menuItem;

                    menuItem = new MenuItem("Importar planilha da partida");
                    menuItem.Click += importarPlanilha;
                    menuItem.Tag = new List<Object>() { competicao, partida, dataGridView, partidas};
                    menuItem.Enabled = !partida.encerrada;
                    contextMenu.MenuItems.Add(menuItem);

                    menuItem = new MenuItem("Exportar layout da planilha para a partida");
                    menuItem.Click += exportarPlanilha;
                    menuItem.Tag = new List<Object>() { competicao, partida, dataGridView, partidas};
                    menuItem.Enabled = !partida.encerrada;
                    contextMenu.MenuItems.Add(menuItem);

                    menuItem = new MenuItem("Definir árbitro da partida");
                    menuItem.Click += (_sender, _e) => {
                        setArbitroForm = new SetArbitro(usuarioLogado, competicao, partida);

                        setArbitroForm.FormClosing += (__sender, __e) => {
                            if (!(setArbitroForm.arbitroSelecionado is null)) {
                                partida.arbitro = setArbitroForm.arbitroSelecionado;
                                partida.id_Arbitro = setArbitroForm.arbitroSelecionado.pessoa.id;

                                CompeticaoRepositorio.Instance.updatePartida(ref competicao, partida);

                                int numRodada = Convert.ToInt32(Convert.ToInt32(dataGridView.Tag));
                                if (numRodada >= 0)
                                    numRodada--;
                                CompeticaoViewUtilidades.refreshDataGridViewRodadas(dataGridView, partidas, competicao, numRodada);
                            }
                        };

                        setArbitroForm.ShowDialog();
                    };
                    menuItem.Tag = new List<Object>() { competicao, partida, dataGridView, partidas };
                    menuItem.Enabled = !partida.encerrada;
                    contextMenu.MenuItems.Add(menuItem);

                    // Define onde será aberto o menu de contexto
                    contextMenu.Show(dataGridView, new Point(dataGridView.RowHeadersWidth, dataGridView.ColumnHeadersHeight));
                }
            }
        }

        private void importarPlanilha(object sender, EventArgs e) {
            Competicao competicao = (Competicao)(((List<Object>)((MenuItem)sender).Tag)[0]);
            Competicao_Partida partida = (Competicao_Partida)(((List<Object>)((MenuItem)sender).Tag)[1]);
            DataGridView dataGridView = (DataGridView)(((List<Object>)((MenuItem)sender).Tag)[2]);
            List<Competicao_Partida> partidas = (List<Competicao_Partida>)(((List<Object>)((MenuItem)sender).Tag)[3]);

            if (partida.data is null)
                MessageBox.Show("Por favor verifique" + Environment.NewLine + Environment.NewLine +
                String.Format("Não foi possível importar a planilhada da partida entre {0} e {1} pois não foi definida uma data para a realização da partida", partida.equipe1.nome, partida.equipe2.nome),
                String.Format("{0} - {1} x {2}", competicao.nome, partida.equipe1.nome, partida.equipe2.nome), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (partida.arbitro is null)
                MessageBox.Show("Por favor verifique" + Environment.NewLine + Environment.NewLine +
                String.Format("Não foi possível realizar a partida entre {0} e {1} pois não foi definido o árbitro da partida", partida.equipe1.nome, partida.equipe2.nome),
                String.Format("{0} - {1} x {2}", competicao.nome, partida.equipe1.nome, partida.equipe2.nome), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else {
                if (partida.equipe1.atletas is null)
                    partida.equipe1.atletas = PessoaRepositorio.Instance.getAtletasByEquipeCompeticao(competicao.id, partida.equipe1.id);

                if (partida.equipe2.atletas is null)
                    partida.equipe2.atletas = PessoaRepositorio.Instance.getAtletasByEquipeCompeticao(competicao.id, partida.equipe2.id);

                partida = GerenciadorCSV.importarPlanilha(competicao, partida);

                if (!(partida is null)) {
                    abrePartida(partida, dataGridView, partidas, true);
                }
            }

        }

        private void exportarPlanilha(object sender, EventArgs e) {
            Competicao competicao = (Competicao)(((List<Object>)((MenuItem)sender).Tag)[0]);
            Competicao_Partida partida = (Competicao_Partida)(((List<Object>)((MenuItem)sender).Tag)[1]);

            if (partida.data is null)
                MessageBox.Show("Por favor verifique" + Environment.NewLine + Environment.NewLine +
                String.Format("Não foi possível exportar a planilha da partida entre {0} e {1} pois não foi definida uma data para a realização da partida", partida.equipe1.nome, partida.equipe2.nome),
                String.Format("{0} - {1} x {2}", competicao.nome, partida.equipe1.nome, partida.equipe2.nome), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (partida.arbitro is null)
                MessageBox.Show("Por favor verifique" + Environment.NewLine + Environment.NewLine +
                String.Format("Não foi possível realizar a partida entre {0} e {1} pois não foi definido o árbitro da partida", partida.equipe1.nome, partida.equipe2.nome),
                String.Format("{0} - {1} x {2}", competicao.nome, partida.equipe1.nome, partida.equipe2.nome), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else {

                if (partida.equipe1.atletas is null)
                    partida.equipe1.atletas = PessoaRepositorio.Instance.getAtletasByEquipeCompeticao(competicao.id, partida.equipe1.id);

                if (partida.equipe2.atletas is null)
                    partida.equipe2.atletas = PessoaRepositorio.Instance.getAtletasByEquipeCompeticao(competicao.id, partida.equipe2.id);

                GerenciadorCSV.exportarPlanilha(competicao, partida);
            }
        }

        private void dgvRodadas_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e) {
            if (e.RowIndex > -1) {
                int numRodada;
                numRodada = Convert.ToInt32(((DataGridView)sender).Tag);
                List<Competicao_Partida> partidas = competicao.partidas.FindAll(partidasAEncontrar => partidasAEncontrar.rodada == numRodada);
                Competicao_Partida partida = partidas[e.RowIndex];

                if (partida.data is null)
                    MessageBox.Show("Por favor verifique" + Environment.NewLine + Environment.NewLine +
                    String.Format("Não foi possível realizar a partida entre {0} e {1} pois não foi definida uma data para a realização da partida", partida.equipe1.nome, partida.equipe2.nome),
                    String.Format("{0} - {1} x {2}", competicao.nome, partida.equipe1.nome, partida.equipe2.nome), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (partida.arbitro is null)
                    MessageBox.Show("Por favor verifique" + Environment.NewLine + Environment.NewLine +
                    String.Format("Não foi possível realizar a partida entre {0} e {1} pois não foi definido o árbitro da partida", partida.equipe1.nome, partida.equipe2.nome),
                    String.Format("{0} - {1} x {2}", competicao.nome, partida.equipe1.nome, partida.equipe2.nome), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    abrePartida(partida, (DataGridView)sender, partidas, false);

            }
        }

        private void abrePartida(Competicao_Partida partida, DataGridView sender, List<Competicao_Partida> partidas, bool partidaIniciada) {
            ViewPartida viewPartida = new ViewPartida(usuarioLogado, competicao, partida, partidaIniciada);
            viewPartida.Tag = new List<Object>() {sender, partidas};
            viewPartida.FormClosing += viewPartida_FormClosing;
            viewPartida.ShowDialog();
        }

        private void viewPartida_FormClosing(object sender, FormClosingEventArgs e) {
            DataGridView dgvRodadas = (DataGridView)((List<Object>)((ViewPartida)sender).Tag)[0];
            List<Competicao_Partida> partidas = (List<Competicao_Partida>)((List<Object>)((ViewPartida)sender).Tag)[1];

            load(null, null);
        }

        private static void refreshDataGridViewArtilheiros(DataGridView dgvArtilheiros, List<Atleta_List_Artilheiro> artilheiros) {
            dgvArtilheiros.DataSource = null;
            dgvArtilheiros.Refresh();

            dgvArtilheiros.Columns.Clear();

            dgvArtilheiros.DataSource = artilheiros;

            if (!(artilheiros is null)) {
                dgvArtilheiros.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = nameof(Atleta_List_Artilheiro.nome_Atleta) });
                dgvArtilheiros.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = nameof(Atleta_List_Artilheiro.nome_Equipe) });
                dgvArtilheiros.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = nameof(Atleta_List_Artilheiro.num_Gols) });
                dgvArtilheiros.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = nameof(Atleta_List_Artilheiro.num_Partidas) });
                dgvArtilheiros.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = nameof(Atleta_List_Artilheiro.media) });
            }

            for (int iCount = 0; iCount < dgvArtilheiros.Columns.Count; iCount++) {
                switch (dgvArtilheiros.Columns[iCount].DataPropertyName) {
                    case nameof(Atleta_List_Artilheiro.nome_Atleta):
                        dgvArtilheiros.Columns[iCount].HeaderText = "Atleta";
                        dgvArtilheiros.Columns[iCount].Name = dgvArtilheiros.Columns[iCount].DataPropertyName;
                        dgvArtilheiros.Columns[iCount].DisplayIndex = 0;
                        dgvArtilheiros.Columns[iCount].Width = 150;
                        break;
                    case nameof(Atleta_List_Artilheiro.nome_Equipe):
                        dgvArtilheiros.Columns[iCount].HeaderText = "Equipe";
                        dgvArtilheiros.Columns[iCount].Name = dgvArtilheiros.Columns[iCount].DataPropertyName;
                        dgvArtilheiros.Columns[iCount].DisplayIndex = 1;
                        dgvArtilheiros.Columns[iCount].Width = 100;
                        break;
                    case nameof(Atleta_List_Artilheiro.num_Gols):
                        dgvArtilheiros.Columns[iCount].HeaderText = "Gols";
                        dgvArtilheiros.Columns[iCount].Name = dgvArtilheiros.Columns[iCount].DataPropertyName;
                        dgvArtilheiros.Columns[iCount].DisplayIndex = 2;
                        dgvArtilheiros.Columns[iCount].Width = 50;
                        break;
                    case nameof(Atleta_List_Artilheiro.num_Partidas):
                        dgvArtilheiros.Columns[iCount].HeaderText = "Jogos";
                        dgvArtilheiros.Columns[iCount].Name = dgvArtilheiros.Columns[iCount].DataPropertyName;
                        dgvArtilheiros.Columns[iCount].DisplayIndex = 3;
                        dgvArtilheiros.Columns[iCount].Width = 40;
                        break;
                    case nameof(Atleta_List_Artilheiro.media):
                        dgvArtilheiros.Columns[iCount].HeaderText = "Média";
                        dgvArtilheiros.Columns[iCount].Name = dgvArtilheiros.Columns[iCount].DataPropertyName;
                        dgvArtilheiros.Columns[iCount].DisplayIndex = 4;
                        dgvArtilheiros.Columns[iCount].Width = 50;
                        break;
                    default:
                        dgvArtilheiros.Columns[iCount].Visible = false;
                        break;
                }
            }

            dgvArtilheiros.Refresh();
        }

        private void btnProximaFase_Click(object sender, EventArgs e) {
            int numPartidasRestantes;
            if (competicao.fase_Atual == 0) {
                numPartidasRestantes = competicao.partidas.FindAll(partidas => partidas.encerrada == false && partidas.rodada > competicao.fase_Atual).Count;
            } else {
                numPartidasRestantes = competicao.partidas.FindAll(partidas => partidas.encerrada == false && partidas.rodada == competicao.fase_Atual).Count;
            }

            if (numPartidasRestantes > 0) {
                MessageBox.Show("Por favor verifique" + Environment.NewLine + Environment.NewLine +
                    "Existem ainda " + numPartidasRestantes + " partidas que não foram encerradas nesta fase.",
                    "Não foi possível avançar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else {
                int numProximaFase = 0;
                int numPartidasASeremGeradas = 0;

                // Caso a fase atual seja a fase classificatória
                if (competicao.fase_Atual >= 0) {
                    switch (competicao.mataMata) {
                        case MataMataEnum._5_OitavasFinal: numProximaFase = -4; numPartidasASeremGeradas = 8; break;
                        case MataMataEnum._4_QuartasFinal: numProximaFase = -3; numPartidasASeremGeradas = 4; break;
                        case MataMataEnum._3_SemiFinal: numProximaFase = -2; numPartidasASeremGeradas = 2; break;
                        case MataMataEnum._2_Final: numProximaFase = -1; numPartidasASeremGeradas = 1; break;
                    }

                    // O campeonato é só por pontos corridos
                    if ( (competicao.mataMata == MataMataEnum._1_Nao) && (competicao.grupos.Count == 1) ) {
                        competicao.status = StatusEnum._0_Encerrada;

                        EquipeCompeticao campeao = (from proximaFase in competicao.grupos[0]
                                                    orderby proximaFase.pontos descending, proximaFase.vitorias descending, proximaFase.golsPro - proximaFase.golsContra descending
                                                    select proximaFase).ToList<EquipeCompeticao>().First();

                        competicao.campeao = campeao;
                        competicao.id_Campeao = campeao.id;
                        CompeticaoRepositorio.Instance.update(competicao);
                    } else {
                        int numTimesPorGrupo = 0, numTimesRestantes = 0;
                        List<List<EquipeCompeticao>> timesProximaFase = Utilidades.listaEquipesClassificadas(competicao, numPartidasASeremGeradas, numProximaFase, ref numTimesRestantes, ref numTimesPorGrupo);
                        Utilidades.criaPartidasProximaFase(ref competicao, timesProximaFase, numPartidasASeremGeradas, numTimesRestantes, numTimesPorGrupo , numProximaFase);

                        // Cria as partidas de volta da fase final
                        if (competicao.jogosIdaEVolta_MataMata) {
                            List<Competicao_Partida> partidasIda = competicao.partidas.FindAll(partidasIdaAEncontrar => partidasIdaAEncontrar.rodada == numProximaFase);
                            for (int numPartidaVolta = 0; numPartidaVolta < partidasIda.Count; numPartidaVolta++) {
                                Competicao_Partida partidaDeVolta = new Competicao_Partida(partidasIda[numPartidaVolta].equipe2, partidasIda[numPartidaVolta].equipe1, numProximaFase, partidasIda[numPartidaVolta].numGrupo);
                                CompeticaoRepositorio.Instance.insertPartida(ref competicao, partidaDeVolta);
                            }
                        }
                    }
                } else {
                    // Neste caso, a fase atual já é uma das fases finais

                    numProximaFase = competicao.fase_Atual + 1;

                    // Define os times que vão para a próxima fase
                    List<List<EquipeCompeticao>> timesProximaFase = new List<List<EquipeCompeticao>>();
                    List<EquipeCompeticao> timesClassificadosFaseAnterior = new List<EquipeCompeticao>();

                    List<Competicao_Partida> partidasFaseAnterior = new List<Competicao_Partida>();
                    partidasFaseAnterior = competicao.partidas.FindAll(partidasFinalizadas => partidasFinalizadas.encerrada == true && partidasFinalizadas.rodada == competicao.fase_Atual);

                    // Define os classificados
                    for (int iCount = 0; iCount < partidasFaseAnterior.Count; iCount++) {
                        Competicao_Partida partidaFaseAnterior = partidasFaseAnterior[iCount];
                        EquipeCompeticao equipeVencedora = null;

                        int golsEquipe1, golsEquipe2;
                        if (competicao.jogosIdaEVolta_MataMata) {
                            if (iCount < partidasFaseAnterior.Count / 2) {
                                Competicao_Partida partidaDeVoltaFaseAnterior = partidasFaseAnterior.FindAll(x => x.numGrupo == partidaFaseAnterior.numGrupo && x.rodada == partidaFaseAnterior.rodada).Last();

                                golsEquipe1 = partidaFaseAnterior.eventos.FindAll(eventosAEncontrar => eventosAEncontrar.tpEvento.Equals(tpEventoEnum.Gol) && eventosAEncontrar.equipe.id == partidaFaseAnterior.equipe1.id).Count;
                                golsEquipe2 = partidaFaseAnterior.eventos.FindAll(eventosAEncontrar => eventosAEncontrar.tpEvento.Equals(tpEventoEnum.Gol) && eventosAEncontrar.equipe.id == partidaFaseAnterior.equipe2.id).Count;

                                golsEquipe1 += partidaDeVoltaFaseAnterior.eventos.FindAll(eventosAEncontrar => eventosAEncontrar.tpEvento.Equals(tpEventoEnum.Gol) && eventosAEncontrar.equipe.id == partidaFaseAnterior.equipe1.id).Count;
                                golsEquipe2 += partidaDeVoltaFaseAnterior.eventos.FindAll(eventosAEncontrar => eventosAEncontrar.tpEvento.Equals(tpEventoEnum.Gol) && eventosAEncontrar.equipe.id == partidaFaseAnterior.equipe2.id).Count;

                                // Verifica se a partida empatou e foi para os penaltis
                                if (golsEquipe1 == golsEquipe2) {
                                    int golsPenaltiEquipe1, golsPenaltiEquipe2;
                                    golsPenaltiEquipe1 = partidaDeVoltaFaseAnterior.eventos.FindAll(eventosAEncontrar => eventosAEncontrar.tpEvento.Equals(tpEventoEnum.Gol_Penalti) && eventosAEncontrar.equipe.id == partidasFaseAnterior[iCount].equipe1.id).Count;
                                    golsPenaltiEquipe2 = partidaDeVoltaFaseAnterior.eventos.FindAll(eventosAEncontrar => eventosAEncontrar.tpEvento.Equals(tpEventoEnum.Gol_Penalti) && eventosAEncontrar.equipe.id == partidasFaseAnterior[iCount].equipe2.id).Count;

                                    if (golsPenaltiEquipe1 > golsPenaltiEquipe2) {
                                        equipeVencedora = partidaFaseAnterior.equipe1;
                                    } else {if (golsPenaltiEquipe2 > golsPenaltiEquipe1) {
                                            equipeVencedora = partidaFaseAnterior.equipe2;
                                        }
                                    }
                                } else {
                                    // Não empatou
                                    if (golsEquipe1 > golsEquipe2) {
                                        equipeVencedora = partidaFaseAnterior.equipe1;
                                    } else {if (golsEquipe2 > golsEquipe1) {
                                            equipeVencedora = partidaFaseAnterior.equipe2;
                                        }
                                    }
                                }

                                timesClassificadosFaseAnterior.Add(equipeVencedora);

                            }
                        } else {
                            // Verifica o vencedor
                            golsEquipe1 = partidaFaseAnterior.eventos.FindAll(eventosAEncontrar => eventosAEncontrar.tpEvento.Equals(tpEventoEnum.Gol) && eventosAEncontrar.equipe.id == partidasFaseAnterior[iCount].equipe1.id).Count;
                            golsEquipe2 = partidaFaseAnterior.eventos.FindAll(eventosAEncontrar => eventosAEncontrar.tpEvento.Equals(tpEventoEnum.Gol) && eventosAEncontrar.equipe.id == partidasFaseAnterior[iCount].equipe2.id).Count;

                            // Verifica se a partida empatou e foi para os penaltis
                            if (golsEquipe1 == golsEquipe2) {
                                int golsPenaltiEquipe1, golsPenaltiEquipe2;
                                golsPenaltiEquipe1 = partidaFaseAnterior.eventos.FindAll(eventosAEncontrar => eventosAEncontrar.tpEvento.Equals(tpEventoEnum.Gol_Penalti) && eventosAEncontrar.equipe.id == partidasFaseAnterior[iCount].equipe1.id).Count;
                                golsPenaltiEquipe2 = partidaFaseAnterior.eventos.FindAll(eventosAEncontrar => eventosAEncontrar.tpEvento.Equals(tpEventoEnum.Gol_Penalti) && eventosAEncontrar.equipe.id == partidasFaseAnterior[iCount].equipe2.id).Count;

                                if (golsPenaltiEquipe1 > golsPenaltiEquipe2) {
                                    equipeVencedora = partidaFaseAnterior.equipe1;
                                } else {if (golsPenaltiEquipe2 > golsPenaltiEquipe1) {
                                        equipeVencedora = partidaFaseAnterior.equipe2;
                                    }
                                }
                            } else {
                                // Não empatou
                                if (golsEquipe1 > golsEquipe2) {
                                    equipeVencedora = partidaFaseAnterior.equipe1;
                                } else {if (golsEquipe2 > golsEquipe1) {
                                        equipeVencedora = partidaFaseAnterior.equipe2;
                                    }
                                }
                            }

                            timesClassificadosFaseAnterior.Add(equipeVencedora);
                        }
                    }

                    int numPartidasASeremGeradasProximaFase = 0;

                    // Faz a criação das partidas
                    Competicao_Partida partida;
                    EquipeCompeticao equipe1, equipe2;
                    switch (numProximaFase) {
                        case -1: // Final
                            numPartidasASeremGeradasProximaFase = 1;

                            equipe1 = timesClassificadosFaseAnterior[0];    equipe2 = timesClassificadosFaseAnterior[1];
                            partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 1);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                            break;
                        case -2: // Semi-Final
                            equipe1 = timesClassificadosFaseAnterior[0]; equipe2 = timesClassificadosFaseAnterior[1];
                            partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 1);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                            equipe1 = timesClassificadosFaseAnterior[2]; equipe2 = timesClassificadosFaseAnterior[3];
                            partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 2);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                            numPartidasASeremGeradasProximaFase = 2;
                            break;
                        case -3: // Quartas de Final
                            equipe1 = timesClassificadosFaseAnterior[0]; equipe2 = timesClassificadosFaseAnterior[1];
                            partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 1);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                            equipe1 = timesClassificadosFaseAnterior[2]; equipe2 = timesClassificadosFaseAnterior[3];
                            partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 2);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                            equipe1 = timesClassificadosFaseAnterior[4]; equipe2 = timesClassificadosFaseAnterior[5];
                            partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 3);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                            equipe1 = timesClassificadosFaseAnterior[6]; equipe2 = timesClassificadosFaseAnterior[7];
                            partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 4);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                            numPartidasASeremGeradasProximaFase = 4;
                            break;
                    }

                    // Cria as partidas de volta da fase final
                    if (competicao.jogosIdaEVolta_MataMata) {
                        List<Competicao_Partida> partidasIda = competicao.partidas.FindAll(partidasIdaAEncontrar => partidasIdaAEncontrar.rodada == numProximaFase);
                        for (int numPartidaVolta = 0; numPartidaVolta < partidasIda.Count; numPartidaVolta++) {
                            Competicao_Partida partidaDeVolta = new Competicao_Partida(partidasIda[numPartidaVolta].equipe2, partidasIda[numPartidaVolta].equipe1, numProximaFase, partidasIda[numPartidaVolta].numGrupo);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partidaDeVolta);
                        }
                    }
                }

                competicao.fase_Atual = numProximaFase;
                CompeticaoRepositorio.Instance.update(competicao);

                load(null, null);
            }
        }

        private void btnGerarHTML_Classificacao_Click(object sender, EventArgs e) {
            // Seleciona os times até então classificados para a próxima fase
            int numProximaFase = 0;
            int numPartidasASeremGeradas = 0;

            switch (competicao.mataMata) {
                case MataMataEnum._5_OitavasFinal: numProximaFase = -4; numPartidasASeremGeradas = 8; break;
                case MataMataEnum._4_QuartasFinal: numProximaFase = -3; numPartidasASeremGeradas = 4; break;
                case MataMataEnum._3_SemiFinal: numProximaFase = -2; numPartidasASeremGeradas = 2; break;
                case MataMataEnum._2_Final: numProximaFase = -1; numPartidasASeremGeradas = 1; break;
            }

            competicao.equipes = EquipeRepositorio.Instance.getEquipesByCompeticao(competicao.id);
            competicao.grupos = CompeticaoRepositorio.Instance.getGruposPorCompeticao(competicao.id, competicao.equipes);

            List<List<EquipeCompeticao>> timesProximaFase = Utilidades.listaEquipesClassificadas(competicao, numPartidasASeremGeradas, numProximaFase);

            RelatorioHTML.relatorioGrupos(competicao, 
                MessageBox.Show("Gostaria de exibir o logo das equipes no relatório de classificação?", String.Format("{0} - Relatório de classificação", competicao.nome), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes, 
                timesProximaFase);

        }

        private void btnGerarHTML_Artilheiros_Click(object sender, EventArgs e) {
            RelatorioHTML.relatorioArtilheiros(competicao, artilheiros,
                MessageBox.Show("Gostaria de exibir a foto dos artilheiros no relatório de artilharia?", String.Format("{0} - Relatório de artilharia", competicao.nome), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);
        }

        private void busca() {
            string textoBusca = txtBusca.Text.ToUpper();

            if (textoBusca.Length == 0) {
                partidasPorRodada_view = new List<List<Competicao_Partida>>(partidasPorRodada);
            } else {
                switch (cboCamposBusca.SelectedIndex) {
                    case 0: // Equipe
                        // Percorre todas as rodadas
                        for (int iCount = 0; iCount < partidasPorRodada.Count; iCount++) {
                            partidasPorRodada_view[iCount] = partidasPorRodada[iCount].FindAll(find => find.equipe1.nome.ToUpper().Contains(textoBusca) || find.equipe2.nome.ToUpper().Contains(textoBusca));
                        }
                        break;
                }
            }

            for (int iCount = 0; iCount < partidasPorRodada.Count; iCount++) {
                int numRodada = Convert.ToInt32(dgvRodadas[iCount].Tag);
                if (numRodada >= 0)
                    numRodada--;

                CompeticaoViewUtilidades.refreshDataGridViewRodadas(dgvRodadas[iCount], partidasPorRodada_view[iCount], competicao, numRodada);
            }
        }

        private void txtBusca_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                busca();
            }
        }
    }
}