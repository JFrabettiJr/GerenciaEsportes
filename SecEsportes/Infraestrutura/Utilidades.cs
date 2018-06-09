using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SecEsportes.Modelo;
using SecEsportes.Repositorio;

namespace SecEsportes.Infraestrutura
{
    public static class Utilidades{
        public enum WindowMode{
            ModoDeEdicao,
            ModoDeInsercao,
            ModoNormal,
            ModoCriacaoForm
        }

        public static List<List<EquipeCompeticao>> listaEquipesClassificadas(Competicao competicao, int numPartidasASeremGeradas, int numProximaFase) {
            int numTimesRestantes = 0, numTimesPorGrupo = 0;
            return listaEquipesClassificadas(competicao, numPartidasASeremGeradas, numProximaFase, ref numTimesRestantes, ref numTimesPorGrupo);
        }

        public static List<List<EquipeCompeticao>> listaEquipesClassificadas(Competicao competicao, int numPartidasASeremGeradas, int numProximaFase, ref int numTimesRestantes, ref int numTimesPorGrupo) {
            numTimesPorGrupo = (numPartidasASeremGeradas * 2) / competicao.numGrupos;
            numTimesRestantes = (numPartidasASeremGeradas * 2) % numTimesPorGrupo;

            // Define os times que vão para a próxima fase
            List<List<EquipeCompeticao>> timesProximaFase = new List<List<EquipeCompeticao>>();
            for (int numGrupo = 0; numGrupo < competicao.grupos.Count; numGrupo++) {
                timesProximaFase.Add(new List<EquipeCompeticao>());

                timesProximaFase[numGrupo] = new List<EquipeCompeticao>();
                timesProximaFase[numGrupo] = (from proximaFase in competicao.grupos[numGrupo]
                                              orderby proximaFase.pontos descending, proximaFase.vitorias descending, proximaFase.golsPro - proximaFase.golsContra descending
                                              select proximaFase).ToList<EquipeCompeticao>();

                timesProximaFase[numGrupo].RemoveRange(numTimesPorGrupo, timesProximaFase[numGrupo].Count - numTimesPorGrupo);

            }

            return timesProximaFase;
        }

        public static void criaPartidasProximaFase(ref Competicao competicao, List<List<EquipeCompeticao>> timesProximaFase, int numPartidasASeremGeradas, int numTimesRestantes, int numTimesPorGrupo, int numProximaFase) {
            // Faz a criação das partidas da fase final
            Competicao_Partida partida;
            EquipeCompeticao equipe1, equipe2;

            switch (numPartidasASeremGeradas) {
                case 2: // Semi final
                    if (numTimesRestantes == 0) {
                        if (numTimesPorGrupo == 1) {
                            equipe1 = timesProximaFase[0][0]; equipe2 = timesProximaFase[1][0]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 1);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                            equipe1 = timesProximaFase[2][0]; equipe2 = timesProximaFase[3][0]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 2);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);
                        }
                        if (numTimesPorGrupo == 2) {
                            equipe1 = timesProximaFase[0][0]; equipe2 = timesProximaFase[1][1]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 1);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                            equipe1 = timesProximaFase[0][1]; equipe2 = timesProximaFase[1][0]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 2);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);
                        }
                        if (numTimesPorGrupo == 4) {
                            equipe1 = timesProximaFase[0][0]; equipe2 = timesProximaFase[0][3]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 1);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                            equipe1 = timesProximaFase[0][1]; equipe2 = timesProximaFase[0][2]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 2);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);
                        }
                    }
                    break;
                case 4: // Quartas de final
                    if (numTimesRestantes == 0) {
                        if (numTimesPorGrupo == 1) {
                            equipe1 = timesProximaFase[0][0]; equipe2 = timesProximaFase[1][0]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 1);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                            equipe1 = timesProximaFase[2][0]; equipe2 = timesProximaFase[3][0]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 2);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                            equipe1 = timesProximaFase[4][0]; equipe2 = timesProximaFase[5][0]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 3);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                            equipe1 = timesProximaFase[6][0]; equipe2 = timesProximaFase[7][0]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 4);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);
                        }
                        if (numTimesPorGrupo == 2) {
                            equipe1 = timesProximaFase[0][0]; equipe2 = timesProximaFase[1][1]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 1);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                            equipe1 = timesProximaFase[0][1]; equipe2 = timesProximaFase[1][0]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 2);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                            equipe1 = timesProximaFase[2][0]; equipe2 = timesProximaFase[3][1]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 3);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                            equipe1 = timesProximaFase[2][1]; equipe2 = timesProximaFase[3][0]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 4);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);
                        }
                        if (numTimesPorGrupo == 4) {
                            equipe1 = timesProximaFase[0][0]; equipe2 = timesProximaFase[1][3]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 1);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                            equipe1 = timesProximaFase[1][0]; equipe2 = timesProximaFase[0][3]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 2);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                            equipe1 = timesProximaFase[0][1]; equipe2 = timesProximaFase[1][2]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 3);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                            equipe1 = timesProximaFase[0][2]; equipe2 = timesProximaFase[1][1]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 4);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);
                        }
                    }
                    break;
                case 8:
                    if (numTimesRestantes == 0) {
                        if (numTimesPorGrupo == 1) {
                            equipe1 = timesProximaFase[0][0]; equipe2 = timesProximaFase[1][0]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 1);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                            equipe1 = timesProximaFase[2][0]; equipe2 = timesProximaFase[3][0]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 2);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                            equipe1 = timesProximaFase[4][0]; equipe2 = timesProximaFase[5][0]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 3);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                            equipe1 = timesProximaFase[6][0]; equipe2 = timesProximaFase[7][0]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 4);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                            equipe1 = timesProximaFase[8][0]; equipe2 = timesProximaFase[9][0]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 5);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                            equipe1 = timesProximaFase[10][0]; equipe2 = timesProximaFase[11][0]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 6);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                            equipe1 = timesProximaFase[12][0]; equipe2 = timesProximaFase[13][0]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 7);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                            equipe1 = timesProximaFase[14][0]; equipe2 = timesProximaFase[15][0]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 8);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);
                        }
                        if (numTimesPorGrupo == 2) {
                            equipe1 = timesProximaFase[0][0]; equipe2 = timesProximaFase[1][1]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 1);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                            equipe1 = timesProximaFase[0][1]; equipe2 = timesProximaFase[1][0]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 2);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                            equipe1 = timesProximaFase[2][0]; equipe2 = timesProximaFase[3][1]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 3);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                            equipe1 = timesProximaFase[2][1]; equipe2 = timesProximaFase[3][0]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 4);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                            equipe1 = timesProximaFase[4][0]; equipe2 = timesProximaFase[5][1]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 5);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                            equipe1 = timesProximaFase[4][1]; equipe2 = timesProximaFase[5][0]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 6);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                            equipe1 = timesProximaFase[6][0]; equipe2 = timesProximaFase[7][1]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 7);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                            equipe1 = timesProximaFase[6][1]; equipe2 = timesProximaFase[7][0]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 8);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);
                        }
                        if (numTimesPorGrupo == 4) {
                            equipe1 = timesProximaFase[0][0]; equipe2 = timesProximaFase[1][3]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 1);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                            equipe1 = timesProximaFase[0][3]; equipe2 = timesProximaFase[1][0]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 2);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                            equipe1 = timesProximaFase[0][1]; equipe2 = timesProximaFase[1][2]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 3);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                            equipe1 = timesProximaFase[0][2]; equipe2 = timesProximaFase[1][1]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 4);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                            equipe1 = timesProximaFase[2][0]; equipe2 = timesProximaFase[3][3]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 5);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                            equipe1 = timesProximaFase[2][3]; equipe2 = timesProximaFase[3][0]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 6);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                            equipe1 = timesProximaFase[2][1]; equipe2 = timesProximaFase[3][2]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 7);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                            equipe1 = timesProximaFase[2][2]; equipe2 = timesProximaFase[3][1]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 8);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);
                        }
                        if (numTimesPorGrupo == 8) {
                            equipe1 = timesProximaFase[0][0]; equipe2 = timesProximaFase[1][7]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 1);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                            equipe1 = timesProximaFase[0][1]; equipe2 = timesProximaFase[1][6]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 2);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                            equipe1 = timesProximaFase[0][2]; equipe2 = timesProximaFase[1][5]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 3);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                            equipe1 = timesProximaFase[0][3]; equipe2 = timesProximaFase[1][4]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 4);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                            equipe1 = timesProximaFase[0][4]; equipe2 = timesProximaFase[1][3]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 5);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                            equipe1 = timesProximaFase[0][5]; equipe2 = timesProximaFase[1][2]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 6);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                            equipe1 = timesProximaFase[0][6]; equipe2 = timesProximaFase[1][1]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 7);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                            equipe1 = timesProximaFase[0][7]; equipe2 = timesProximaFase[1][0]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 8);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);
                        }
                        if (numTimesPorGrupo == 16) {
                            equipe1 = timesProximaFase[0][0]; equipe2 = timesProximaFase[0][15]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 1);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                            equipe1 = timesProximaFase[0][1]; equipe2 = timesProximaFase[0][14]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 2);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                            equipe1 = timesProximaFase[0][2]; equipe2 = timesProximaFase[0][13]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 3);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                            equipe1 = timesProximaFase[0][3]; equipe2 = timesProximaFase[0][12]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 4);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                            equipe1 = timesProximaFase[0][4]; equipe2 = timesProximaFase[0][11]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 5);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                            equipe1 = timesProximaFase[0][5]; equipe2 = timesProximaFase[0][10]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 6);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                            equipe1 = timesProximaFase[0][6]; equipe2 = timesProximaFase[0][9]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 7);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);

                            equipe1 = timesProximaFase[0][7]; equipe2 = timesProximaFase[0][8]; partida = new Competicao_Partida(equipe1, equipe2, numProximaFase, 8);
                            CompeticaoRepositorio.Instance.insertPartida(ref competicao, partida);
                        }
                    }
                    break;
            }
        }

        public static void enabled_Change(bool enabled, PictureBox pictureBox) {
            switch (pictureBox.Name) {
                case "btnAdicionar":
                    if (enabled)
                        pictureBox.Image = Properties.Resources.crud_adicionar;
                    else
                        pictureBox.Image = Properties.Resources.crud_adicionar_disabled;
                    break;
                case "btnSalvar":
                    if (enabled)
                        pictureBox.Image = Properties.Resources.crud_salvar;
                    else
                        pictureBox.Image = Properties.Resources.crud_salvar_disabled;
                    break;
                case "btnCancelar":
                    if (enabled)
                        pictureBox.Image = Properties.Resources.crud_cancelar;
                    else
                        pictureBox.Image = Properties.Resources.crud_cancelar_disabled;
                    break;
                case "btnExcluir":
                    if (enabled)
                        pictureBox.Image = Properties.Resources.crud_deletar;
                    else
                        pictureBox.Image = Properties.Resources.crud_deletar_disabled;
                    break;
                case "btnAtualizar":
                    if (enabled)
                        pictureBox.Image = Properties.Resources.crud_recarregar;
                    else
                        pictureBox.Image = Properties.Resources.crud_recarregar_disabled;
                    break;
                case "btnIncluirEquipes":
                    if (enabled)
                        pictureBox.Image = Properties.Resources.adicionar_equipe;
                    else
                        pictureBox.Image = Properties.Resources.adicionar_equipe_disabled;
                    break;
                case "btnExcluirEquipe":
                    if (enabled)
                        pictureBox.Image = Properties.Resources.excluir_equipe;
                    else
                        pictureBox.Image = Properties.Resources.excluir_equipe_disabled;
                    break;
                case "btnArbitros":
                    if (enabled)
                        pictureBox.Image = Properties.Resources.arbitro;
                    else
                        pictureBox.Image = Properties.Resources.arbitro_disabled;
                    break;
                case "btnVisaoGeral":
                    if (enabled)
                        pictureBox.Image = Properties.Resources.visao_geral;
                    else
                        pictureBox.Image = Properties.Resources.visao_geral_disabled;
                    break;
                case "btnGerarGrupos":
                    if (enabled)
                        pictureBox.Image = Properties.Resources.grupos;
                    else
                        pictureBox.Image = Properties.Resources.grupos_disabled;
                    break;
                case "btnGerarPartidas":
                    if (enabled)
                        pictureBox.Image = Properties.Resources.partida;
                    else
                        pictureBox.Image = Properties.Resources.partida_disabled;
                    break;
                case "btnAvancar":
                    if (enabled)
                        pictureBox.Image = Properties.Resources.avancar;
                    else
                        pictureBox.Image = Properties.Resources.avancar_disabled;
                    break;
                case "btnVoltar":
                    if (enabled)
                        pictureBox.Image = Properties.Resources.voltar;
                    else
                        pictureBox.Image = Properties.Resources.voltar_disabled;
                    break;
                case "btnIncluirArbitro":
                    if (enabled)
                        pictureBox.Image = Properties.Resources.adicionar_arbitro;
                    else
                        pictureBox.Image = Properties.Resources.adicionar_arbitro_disabled;
                    break;
                case "btnExcluirArbitro":
                    if (enabled)
                        pictureBox.Image = Properties.Resources.excluir_arbitro;
                    else
                        pictureBox.Image = Properties.Resources.excluir_arbitro_disabled;
                    break;
                case "btnIncluirAtleta":
                    if (enabled)
                        pictureBox.Image = Properties.Resources.adicionar_atleta;
                    else
                        pictureBox.Image = Properties.Resources.adicionar_atleta_disabled;
                    break;
                case "btnExcluirAtleta":
                    if (enabled)
                        pictureBox.Image = Properties.Resources.excluir_atleta;
                    else
                        pictureBox.Image = Properties.Resources.excluir_atleta_disabled;
                    break;
                case "btnDisputaPenaltis":
                    if (enabled)
                        pictureBox.Image = Properties.Resources.penaltis;
                    else
                        pictureBox.Image = Properties.Resources.penaltis_disabled;
                    break;
                case "btnIniciarPartida":
                    if (enabled)
                        pictureBox.Image = Properties.Resources.partida_iniciar;
                    else
                        pictureBox.Image = Properties.Resources.partida_iniciar_disabled;
                    break;
                case "btnEncerrarPartida":
                    if (enabled)
                        pictureBox.Image = Properties.Resources.partida_encerrar;
                    else
                        pictureBox.Image = Properties.Resources.partida_encerrar_disabled;
                    break;
            }
        }

    }

    public static class CompeticaoViewUtilidades {
        public static DataGridView criaAba(string tituloAba, int indice, TabControl tcTabs) {
            return criaAba(tituloAba, indice, tcTabs, null);
        }
        public static DataGridView criaAba(string tituloAba, int indice, TabControl tcTabs, DataGridViewCellMouseEventHandler dataGridViewCellMouseEventHandler) {
            // Cria o TabPage
            TabPage tabPage = new TabPage(tituloAba);
            tabPage.UseVisualStyleBackColor = true;
            tabPage.Padding = new Padding(3);

            // Cria o DataGridView
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;

            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 9.5F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;

            DataGridView dataGridView = new DataGridView();
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToOrderColumns = true;
            dataGridView.AutoGenerateColumns = false;
            dataGridView.BackgroundColor = Color.FromArgb(238, 238, 238);
            dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.ReadOnly = true;
            dataGridView.RowTemplate.Resizable = DataGridViewTriState.True;
            dataGridView.Tag = indice;

            if (!(dataGridViewCellMouseEventHandler is null)) {
                dataGridView.CellMouseClick -= dataGridViewCellMouseEventHandler;
                dataGridView.CellMouseClick += dataGridViewCellMouseEventHandler;
            }

            //Adiciona o DataGridView ao TabPage
            tabPage.Controls.Add(dataGridView);

            //Adiciona o TabPage às abas
            tcTabs.Controls.Add(tabPage);

            return dataGridView;
        }

        public static string getNomeGrupo(NomesGruposEnum nomesGrupos, int numeroGrupo) {
            string nomeGrupo = "Grupo ";

            if (nomesGrupos == NomesGruposEnum._0_PorNumeracao) {
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

        public static void refreshDataGridViewRodadas(DataGridView dgvRodada, List<Competicao_Partida> partidas, Competicao competicao, int numRodada) {
            dgvRodada.DataSource = null;
            dgvRodada.Refresh();

            dgvRodada.Columns.Clear();

            dgvRodada.DataSource = partidas;

            if (!(partidas is null)) {
                dgvRodada.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = "Nome_Grupo_Jogo" });
                dgvRodada.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = "Data_view" });
                dgvRodada.Columns.Add(new DataGridViewImageColumn(true) { DataPropertyName = "LogoEquipe1" });
                dgvRodada.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = "NomeEquipe1" });
                dgvRodada.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell() { Style = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleRight } }) { DataPropertyName = "PtsEquipe1" });
                dgvRodada.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell() { Style = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter } }) { DataPropertyName = "Vs" });
                dgvRodada.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell() { Style = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleLeft } }) { DataPropertyName = "PtsEquipe2" });
                dgvRodada.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = "NomeEquipe2" });
                dgvRodada.Columns.Add(new DataGridViewImageColumn(true) { DataPropertyName = "LogoEquipe2" });
                dgvRodada.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = "Arbitro_Partida" });

                dgvRodada.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = "Jogo" });
            }

            for (int iCount = 0; iCount < dgvRodada.Columns.Count; iCount++) {
                switch (dgvRodada.Columns[iCount].DataPropertyName) {
                    case "Nome_Grupo_Jogo":
                        if (numRodada < 0)
                            dgvRodada.Columns[iCount].HeaderText = "Jogo";
                        else
                            dgvRodada.Columns[iCount].HeaderText = "Grupo"; 
                        dgvRodada.Columns[iCount].Name = dgvRodada.Columns[iCount].DataPropertyName;
                        dgvRodada.Columns[iCount].ReadOnly = true;
                        dgvRodada.Columns[iCount].DisplayIndex = iCount;
                        break;
                    case "Data_view":
                        dgvRodada.Columns[iCount].HeaderText = "Data";
                        dgvRodada.Columns[iCount].Name = dgvRodada.Columns[iCount].DataPropertyName;
                        dgvRodada.Columns[iCount].DisplayIndex = iCount;
                        dgvRodada.Columns[iCount].ValueType = Type.GetType("System.String");
                        break;
                    case "LogoEquipe1":
                        dgvRodada.Columns[iCount].HeaderText = "";
                        dgvRodada.Columns[iCount].Name = dgvRodada.Columns[iCount].DataPropertyName;
                        dgvRodada.Columns[iCount].DisplayIndex = iCount;
                        dgvRodada.Columns[iCount].ReadOnly = true;
                        dgvRodada.Columns[iCount].Width = 30;
                        ((DataGridViewImageColumn)dgvRodada.Columns[iCount]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                        break;
                    case "NomeEquipe1":
                        dgvRodada.Columns[iCount].HeaderText = "Casa";
                        dgvRodada.Columns[iCount].Name = dgvRodada.Columns[iCount].DataPropertyName;
                        dgvRodada.Columns[iCount].DisplayIndex = iCount;
                        dgvRodada.Columns[iCount].ReadOnly = true;
                        break;
                    case "PtsEquipe1":
                        dgvRodada.Columns[iCount].HeaderText = " ";
                        dgvRodada.Columns[iCount].Name = dgvRodada.Columns[iCount].DataPropertyName;
                        dgvRodada.Columns[iCount].Width = 30;
                        dgvRodada.Columns[iCount].DisplayIndex = iCount;
                        dgvRodada.Columns[iCount].ReadOnly = true;
                        break;
                    case "Vs":
                        dgvRodada.Columns[iCount].HeaderText = "X";
                        dgvRodada.Columns[iCount].Name = dgvRodada.Columns[iCount].DataPropertyName;
                        dgvRodada.Columns[iCount].Width = 20;
                        dgvRodada.Columns[iCount].DisplayIndex = iCount;
                        dgvRodada.Columns[iCount].ReadOnly = true;
                        break;
                    case "PtsEquipe2":
                        dgvRodada.Columns[iCount].HeaderText = " ";
                        dgvRodada.Columns[iCount].Name = dgvRodada.Columns[iCount].DataPropertyName;
                        dgvRodada.Columns[iCount].Width = 30;
                        dgvRodada.Columns[iCount].DisplayIndex = iCount;
                        dgvRodada.Columns[iCount].ReadOnly = true;
                        break;
                    case "NomeEquipe2":
                        dgvRodada.Columns[iCount].HeaderText = "Visitante";
                        dgvRodada.Columns[iCount].Name = dgvRodada.Columns[iCount].DataPropertyName;
                        dgvRodada.Columns[iCount].DisplayIndex = iCount;
                        dgvRodada.Columns[iCount].ReadOnly = true;
                        break;
                    case "LogoEquipe2":
                        dgvRodada.Columns[iCount].HeaderText = "";
                        dgvRodada.Columns[iCount].Name = dgvRodada.Columns[iCount].DataPropertyName;
                        dgvRodada.Columns[iCount].DisplayIndex = iCount;
                        dgvRodada.Columns[iCount].Width = 30;
                        dgvRodada.Columns[iCount].ReadOnly = true;
                        ((DataGridViewImageColumn)dgvRodada.Columns[iCount]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                        break;
                    case "Arbitro_Partida":
                        dgvRodada.Columns[iCount].HeaderText = "Árbitro";
                        dgvRodada.Columns[iCount].Name = dgvRodada.Columns[iCount].DataPropertyName;
                        dgvRodada.Columns[iCount].DisplayIndex = iCount;
                        dgvRodada.Columns[iCount].ReadOnly = true;
                        break;
                    default:
                        dgvRodada.Columns[iCount].Visible = false;
                        dgvRodada.Columns[iCount].ReadOnly = true;
                        break;
                }
            }

            //Preenche os campos que vieram sem preenchimento do data set
            for (int iCount = 0; iCount < dgvRodada.Rows.Count; iCount++) {
                Competicao_Partida partida = partidas[iCount];

                if (numRodada < 0)
                    dgvRodada.Rows[iCount].Cells["Nome_Grupo_Jogo"].Value = "Jogo " + partida.numGrupo.ToString();
                else
                    dgvRodada.Rows[iCount].Cells["Nome_Grupo_Jogo"].Value = getNomeGrupo(competicao.nomesGrupos, partida.numGrupo + 1); 

                dgvRodada.Rows[iCount].Cells["PtsEquipe1"].Value = (partida.encerrada == false ? "" : partida.eventos.Count(eventos => eventos.equipe.id.Equals(partida.equipe1.id) && eventos.tpEvento.Equals(tpEventoEnum.Gol)).ToString());
                dgvRodada.Rows[iCount].Cells["PtsEquipe2"].Value = (partida.encerrada == false ? "" : partida.eventos.Count(eventos => eventos.equipe.id.Equals(partida.equipe2.id) && eventos.tpEvento.Equals(tpEventoEnum.Gol)).ToString());
                dgvRodada.Rows[iCount].Cells["Vs"].Value = "X";
                dgvRodada.Rows[iCount].Cells["NomeEquipe1"].Value = partida.equipe1.nome;
                dgvRodada.Rows[iCount].Cells["NomeEquipe2"].Value = partida.equipe2.nome;
                if (partida.data is null)
                    dgvRodada.Rows[iCount].Cells["Data_view"].Value = ""; 
                else
                    dgvRodada.Rows[iCount].Cells["Data_view"].Value = ((DateTime)partida.data).ToString("dd/MM/yyyy");

                // Pinta de negrito a equipe vencedora
                DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle(dgvRodada.Rows[iCount].DefaultCellStyle);
                dataGridViewCellStyle.Font = new Font(dgvRodada.Font, FontStyle.Bold);

                dgvRodada.Rows[iCount].Cells["PtsEquipe1"].Style = dataGridViewCellStyle;
                dgvRodada.Rows[iCount].Cells["Vs"].Style = dataGridViewCellStyle;
                dgvRodada.Rows[iCount].Cells["PtsEquipe2"].Style = dataGridViewCellStyle;

                int golsEquipe1, golsEquipe2;
                golsEquipe1 = partida.eventos.FindAll(eventosAEncontrar => eventosAEncontrar.tpEvento.Equals(tpEventoEnum.Gol) && eventosAEncontrar.equipe.id == partida.equipe1.id).Count;
                golsEquipe2 = partida.eventos.FindAll(eventosAEncontrar => eventosAEncontrar.tpEvento.Equals(tpEventoEnum.Gol) && eventosAEncontrar.equipe.id == partida.equipe2.id).Count;

                if (partida.rodada < 0) {
                    // Jogo de fase final
                    int golsPenaltiEquipe1, golsPenaltiEquipe2;
                    golsPenaltiEquipe1 = partida.eventos.FindAll(eventosAEncontrar => eventosAEncontrar.tpEvento.Equals(tpEventoEnum.Gol_Penalti) && eventosAEncontrar.equipe.id == partida.equipe1.id).Count;
                    golsPenaltiEquipe2 = partida.eventos.FindAll(eventosAEncontrar => eventosAEncontrar.tpEvento.Equals(tpEventoEnum.Gol_Penalti) && eventosAEncontrar.equipe.id == partida.equipe2.id).Count;

                    // Verifica se o jogo foi para os pênaltis
                    if (golsPenaltiEquipe1 > 0 || golsPenaltiEquipe2 > 0) {

                        dgvRodada.Rows[iCount].Cells["NomeEquipe1"].Value = dgvRodada.Rows[iCount].Cells["NomeEquipe1"].Value + " (" + golsPenaltiEquipe1 + ")";
                        dgvRodada.Rows[iCount].Cells["NomeEquipe2"].Value = dgvRodada.Rows[iCount].Cells["NomeEquipe2"].Value + " (" + golsPenaltiEquipe2 + ")";

                        if (golsPenaltiEquipe1 > golsPenaltiEquipe2) {
                            dgvRodada.Rows[iCount].Cells["NomeEquipe1"].Style = dataGridViewCellStyle;
                        } else {
                            if (golsPenaltiEquipe2 > golsPenaltiEquipe1) {
                                dgvRodada.Rows[iCount].Cells["NomeEquipe2"].Style = dataGridViewCellStyle;
                            }
                        }
                    } else {
                        if (golsEquipe1 > golsEquipe2) {
                            dgvRodada.Rows[iCount].Cells["NomeEquipe1"].Style = dataGridViewCellStyle;
                        } else {
                            if (golsEquipe2 > golsEquipe1) {
                                dgvRodada.Rows[iCount].Cells["NomeEquipe2"].Style = dataGridViewCellStyle;
                            }
                        }
                    }
                } else {
                    // Jogo de fase classificatória
                    if (golsEquipe1 > golsEquipe2) {
                        dgvRodada.Rows[iCount].Cells["NomeEquipe1"].Style = dataGridViewCellStyle;
                    } else {
                        if (golsEquipe2 > golsEquipe1) {
                            dgvRodada.Rows[iCount].Cells["NomeEquipe2"].Style = dataGridViewCellStyle;
                        }
                    }
                }

                // Árbitro
                if (partida.arbitro is null)
                    dgvRodada.Rows[iCount].Cells["Arbitro_Partida"].Value = "";
                else
                    dgvRodada.Rows[iCount].Cells["Arbitro_Partida"].Value = partida.arbitro.pessoa.nome;

                // Logo das equipes
                if (!(partida.equipe1.urlLogo is null) && partida.equipe1.urlLogo.Length > 0 && File.Exists(partida.equipe1.urlLogo))
                    dgvRodada.Rows[iCount].Cells["LogoEquipe1"].Value = Icon.FromHandle(new Bitmap(Image.FromFile(partida.equipe1.urlLogo), new Size(20, 20)).GetHicon());
                else
                    dgvRodada.Rows[iCount].Cells["LogoEquipe1"].Value = Properties.Resources.nothing_ico;

                if (!(partida.equipe2.urlLogo is null) && partida.equipe2.urlLogo.Length > 0 && File.Exists(partida.equipe2.urlLogo))
                    dgvRodada.Rows[iCount].Cells["LogoEquipe2"].Value = Icon.FromHandle(new Bitmap(Image.FromFile(partida.equipe2.urlLogo), new Size(20, 20)).GetHicon());
                else
                    dgvRodada.Rows[iCount].Cells["LogoEquipe2"].Value = Properties.Resources.nothing_ico;
            }

            dgvRodada.Refresh();
        }

        public static void refreshDataGridViewGrupos(Competicao competicao, DataGridView dgvGrupo, List<EquipeCompeticao> equipes, List<EquipeCompeticao> timesProximaFase) {
            dgvGrupo.DataSource = null;
            dgvGrupo.Refresh();

            dgvGrupo.Columns.Clear();

            if (!(equipes is null)) {
                equipes = (from customDS in equipes
                              orderby customDS.pontos descending, customDS.vitorias descending, customDS.golsPro - customDS.golsContra descending
                              select customDS).ToList<EquipeCompeticao>();
            }

            dgvGrupo.DataSource = equipes;

            if (!(equipes is null)) {
                dgvGrupo.Columns.Add(new DataGridViewImageColumn(true) { DataPropertyName = "LogoEquipe" });
                dgvGrupo.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = nameof(EquipeCompeticao.codigo) });
                dgvGrupo.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = nameof(EquipeCompeticao.nome) });
                dgvGrupo.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = nameof(EquipeCompeticao.pontos) });
                dgvGrupo.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = "NumJogos" });
                dgvGrupo.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = nameof(EquipeCompeticao.vitorias) });
                dgvGrupo.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = nameof(EquipeCompeticao.empates) });
                dgvGrupo.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = nameof(EquipeCompeticao.derrotas) });
                dgvGrupo.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = nameof(EquipeCompeticao.golsPro) });
                dgvGrupo.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = nameof(EquipeCompeticao.golsContra) });
                dgvGrupo.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = "SaldoGols" });
                dgvGrupo.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = "Aproveitamento" });
            }

            for (int iCount = 0; iCount < dgvGrupo.Columns.Count; iCount++) {
                switch (dgvGrupo.Columns[iCount].DataPropertyName) {
                    case "LogoEquipe":
                        dgvGrupo.Columns[iCount].HeaderText = "";
                        dgvGrupo.Columns[iCount].Name = dgvGrupo.Columns[iCount].DataPropertyName;
                        dgvGrupo.Columns[iCount].DisplayIndex = iCount;
                        dgvGrupo.Columns[iCount].ReadOnly = true;
                        dgvGrupo.Columns[iCount].Width = 30;
                        ((DataGridViewImageColumn)dgvGrupo.Columns[iCount]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                        break;
                    case nameof(EquipeCompeticao.codigo):
                        dgvGrupo.Columns[iCount].HeaderText = "Código";
                        dgvGrupo.Columns[iCount].Name = dgvGrupo.Columns[iCount].DataPropertyName;
                        dgvGrupo.Columns[iCount].Width = 50;
                        dgvGrupo.Columns[iCount].DisplayIndex = iCount;
                        break;
                    case nameof(EquipeCompeticao.nome):
                        dgvGrupo.Columns[iCount].HeaderText = "Nome da equipe";
                        dgvGrupo.Columns[iCount].Name = dgvGrupo.Columns[iCount].DataPropertyName;
                        dgvGrupo.Columns[iCount].Width = 150;
                        dgvGrupo.Columns[iCount].DisplayIndex = iCount;
                        break;
                    case nameof(EquipeCompeticao.pontos):
                        dgvGrupo.Columns[iCount].HeaderText = "Pts.";
                        dgvGrupo.Columns[iCount].Name = dgvGrupo.Columns[iCount].DataPropertyName;
                        dgvGrupo.Columns[iCount].Width = 50;
                        dgvGrupo.Columns[iCount].DisplayIndex = iCount;
                        break;
                    case "NumJogos":
                        dgvGrupo.Columns[iCount].HeaderText = "J";
                        dgvGrupo.Columns[iCount].Name = dgvGrupo.Columns[iCount].DataPropertyName;
                        dgvGrupo.Columns[iCount].Width = 40;
                        dgvGrupo.Columns[iCount].DisplayIndex = iCount;
                        break;
                    case nameof(EquipeCompeticao.vitorias):
                        dgvGrupo.Columns[iCount].HeaderText = "V";
                        dgvGrupo.Columns[iCount].Name = dgvGrupo.Columns[iCount].DataPropertyName;
                        dgvGrupo.Columns[iCount].Width = 40;
                        dgvGrupo.Columns[iCount].DisplayIndex = iCount;
                        break;
                    case nameof(EquipeCompeticao.empates):
                        dgvGrupo.Columns[iCount].HeaderText = "E";
                        dgvGrupo.Columns[iCount].Name = dgvGrupo.Columns[iCount].DataPropertyName;
                        dgvGrupo.Columns[iCount].Width = 40;
                        dgvGrupo.Columns[iCount].DisplayIndex = iCount;
                        break;
                    case nameof(EquipeCompeticao.derrotas):
                        dgvGrupo.Columns[iCount].HeaderText = "D";
                        dgvGrupo.Columns[iCount].Name = dgvGrupo.Columns[iCount].DataPropertyName;
                        dgvGrupo.Columns[iCount].Width = 40;
                        dgvGrupo.Columns[iCount].DisplayIndex = iCount;
                        break;
                    case nameof(EquipeCompeticao.golsPro):
                        dgvGrupo.Columns[iCount].HeaderText = "GP";
                        dgvGrupo.Columns[iCount].Name = dgvGrupo.Columns[iCount].DataPropertyName;
                        dgvGrupo.Columns[iCount].Width = 40;
                        dgvGrupo.Columns[iCount].DisplayIndex = iCount;
                        break;
                    case nameof(EquipeCompeticao.golsContra):
                        dgvGrupo.Columns[iCount].HeaderText = "GC";
                        dgvGrupo.Columns[iCount].Name = dgvGrupo.Columns[iCount].DataPropertyName;
                        dgvGrupo.Columns[iCount].Width = 40;
                        dgvGrupo.Columns[iCount].DisplayIndex = iCount;
                        break;
                    case "SaldoGols":
                        dgvGrupo.Columns[iCount].HeaderText = "SG";
                        dgvGrupo.Columns[iCount].Name = dgvGrupo.Columns[iCount].DataPropertyName;
                        dgvGrupo.Columns[iCount].Width = 40;
                        dgvGrupo.Columns[iCount].DisplayIndex = iCount;
                        break;
                    case "Aproveitamento":
                        dgvGrupo.Columns[iCount].HeaderText = " %";
                        dgvGrupo.Columns[iCount].Name = dgvGrupo.Columns[iCount].DataPropertyName;
                        dgvGrupo.Columns[iCount].Width = 50;
                        dgvGrupo.Columns[iCount].DisplayIndex = iCount;
                        break;
                    default:
                        dgvGrupo.Columns[iCount].Visible = false;
                        break;
                }
            }

            // Pinta de negrito as equipes classificadas
            DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle(dgvGrupo.DefaultCellStyle);
            dataGridViewCellStyle.Font = new Font(dgvGrupo.Font, FontStyle.Bold);

            //Preenche os campos que vieram sem preenchimento do data set
            for (int iCount = 0; iCount < dgvGrupo.Rows.Count; iCount++) {
                EquipeCompeticao equipe = equipes[iCount];

                dgvGrupo.Rows[iCount].Cells["NumJogos"].Value = equipe.vitorias + equipe.derrotas + equipe.empates;

                dgvGrupo.Rows[iCount].Cells["SaldoGols"].Value = equipe.golsPro - equipe.golsContra;

                if (equipe.vitorias + equipe.derrotas + equipe.empates > 0)
                    dgvGrupo.Rows[iCount].Cells["Aproveitamento"].Value = equipe.pontos * 100 / ((equipe.vitorias + equipe.derrotas + equipe.empates) * 3);
                else
                    dgvGrupo.Rows[iCount].Cells["Aproveitamento"].Value = 0;

                // Pinta as equipes que irão se classificar
                if (!(timesProximaFase is null)) {
                    if (timesProximaFase.Contains(equipe)) {
                        dgvGrupo.Rows[iCount].DefaultCellStyle = dataGridViewCellStyle;
                    }
                }

                // Logo da equipe
                if (!(equipe.urlLogo is null) && equipe.urlLogo.Length > 0 && File.Exists(equipe.urlLogo))
                    dgvGrupo.Rows[iCount].Cells["LogoEquipe"].Value = Icon.FromHandle(new Bitmap(Image.FromFile(equipe.urlLogo), new Size(20, 20)).GetHicon());
                else
                    dgvGrupo.Rows[iCount].Cells["LogoEquipe"].Value = Properties.Resources.nothing_ico;

            }

            dgvGrupo.Refresh();
        }

        public static void dgvEquipesGrupo_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e) {
            DataGridView dataGridView = (DataGridView)sender;
            int numGrupo = Convert.ToInt32(((List<Object>)dataGridView.Tag)[0]);
            Competicao competicao = (Competicao)((List<Object>)dataGridView.Tag)[1];
            Usuario usuarioLogado = (Usuario)((List<Object>)dataGridView.Tag)[2];

            List<EquipeCompeticao> equipesNogrupo = (from equipes in competicao.grupos[numGrupo]
                                                     orderby equipes.pontos descending, equipes.vitorias descending, equipes.golsPro - equipes.golsContra descending
                                                     select equipes).ToList<EquipeCompeticao>();

            if ((e.RowIndex > -1) && (!(competicao.grupos is null)))
                new Views.EditEquipe(usuarioLogado, equipesNogrupo[e.RowIndex], competicao).ShowDialog();
        }

    }

}
