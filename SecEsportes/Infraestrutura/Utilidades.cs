using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SecEsportes.Modelo;

namespace SecEsportes.Infraestrutura
{
    public static class Utilidades{
        public enum WindowMode{
            ModoDeEdicao,
            ModoDeInsercao,
            ModoNormal,
            ModoCriacaoForm
        }
    }

    public static class CompeticaoViewUtilidades {
        public static DataGridView criaAba(string tituloAba, int indice, TabControl tcTabs, DataGridViewCellMouseEventHandler dataGridViewCellMouseEventHandler = null) {
            // Cria o TabPage
            TabPage tabPage = new TabPage(tituloAba);
            tabPage.UseVisualStyleBackColor = true;
            tabPage.Padding = new Padding(3);

            // Cria o DataGridView
            DataGridView dataGridView = new DataGridView();
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToOrderColumns = true;
            dataGridView.AutoGenerateColumns = false;
            dataGridView.BackgroundColor = Color.FromArgb(238, 238, 238);
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
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

        public static void refreshDataGridViewRodadas(DataGridView dgvRodada, List<Competicao_Partida> dataSource, Competicao competicao, int numRodada) {
            dgvRodada.DataSource = null;
            dgvRodada.Refresh();

            dgvRodada.Columns.Clear();

            dgvRodada.DataSource = dataSource;

            if (!(dataSource is null)) {
                dgvRodada.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = nameof(Competicao_Partida.data) });

                dgvRodada.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = "Nome_Grupo_Jogo" });
                dgvRodada.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = "Jogo" });
                dgvRodada.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = "NomeEquipe1" });
                dgvRodada.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = "NomeEquipe2" });
                dgvRodada.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()  { Style = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleRight } }) { DataPropertyName = "PtsEquipe1" });
                dgvRodada.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()  { Style = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleLeft } }) { DataPropertyName = "PtsEquipe2" });
                dgvRodada.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()  { Style = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter } }) { DataPropertyName = "Vs" });
            }

            for (var iCount = 0; iCount < dgvRodada.Columns.Count; iCount++) {
                switch (dgvRodada.Columns[iCount].DataPropertyName) {
                    case "Nome_Grupo_Jogo":
                        if (numRodada < 0)
                            dgvRodada.Columns[iCount].HeaderText = "Jogo";
                        else
                            dgvRodada.Columns[iCount].HeaderText = "Grupo"; 
                        dgvRodada.Columns[iCount].Name = dgvRodada.Columns[iCount].DataPropertyName;
                        dgvRodada.Columns[iCount].DisplayIndex = 0;
                        break;
                    case nameof(Competicao_Partida.data):
                        dgvRodada.Columns[iCount].HeaderText = "Data";
                        dgvRodada.Columns[iCount].Name = dgvRodada.Columns[iCount].DataPropertyName;
                        dgvRodada.Columns[iCount].DisplayIndex = 1;
                        break;
                    case "NomeEquipe1":
                        dgvRodada.Columns[iCount].HeaderText = "Casa";
                        dgvRodada.Columns[iCount].Name = dgvRodada.Columns[iCount].DataPropertyName;
                        dgvRodada.Columns[iCount].DisplayIndex = 2;
                        break;
                    case "PtsEquipe1":
                        dgvRodada.Columns[iCount].HeaderText = " ";
                        dgvRodada.Columns[iCount].Name = dgvRodada.Columns[iCount].DataPropertyName;
                        dgvRodada.Columns[iCount].Width = 30;
                        dgvRodada.Columns[iCount].DisplayIndex = 3;
                        break;
                    case "Vs":
                        dgvRodada.Columns[iCount].HeaderText = "X";
                        dgvRodada.Columns[iCount].Name = dgvRodada.Columns[iCount].DataPropertyName;
                        dgvRodada.Columns[iCount].Width = 20;
                        dgvRodada.Columns[iCount].DisplayIndex = 4;
                        break;
                    case "PtsEquipe2":
                        dgvRodada.Columns[iCount].HeaderText = " ";
                        dgvRodada.Columns[iCount].Name = dgvRodada.Columns[iCount].DataPropertyName;
                        dgvRodada.Columns[iCount].Width = 30;
                        dgvRodada.Columns[iCount].DisplayIndex = 5;
                        break;
                    case "NomeEquipe2":
                        dgvRodada.Columns[iCount].HeaderText = "Visitante";
                        dgvRodada.Columns[iCount].Name = dgvRodada.Columns[iCount].DataPropertyName;
                        dgvRodada.Columns[iCount].DisplayIndex = 6;
                        break;
                    default:
                        dgvRodada.Columns[iCount].Visible = false;
                        break;
                }
            }

            //Preenche os campos que vieram sem preenchimento do data set
            for (var iCount = 0; iCount < dgvRodada.Rows.Count; iCount++) {
                if (numRodada < 0) {
                    //int numJogo = iCount + 1;
                    //switch (numRodada) {
                    //    case -1: // Final
                    //        switch (competicao.mataMata) {
                    //            case MataMataEnum._2_Final: numJogo += 0; break;
                    //            case MataMataEnum._3_SemiFinal: numJogo += 2 + (competicao.jogosIdaEVolta_MataMata ? 2 : 0); break;
                    //            case MataMataEnum._4_QuartasFinal: numJogo += 4 + (competicao.jogosIdaEVolta_MataMata ? 4 : 0); break;
                    //            case MataMataEnum._5_OitavasFinal: numJogo += 8 + (competicao.jogosIdaEVolta_MataMata ? 8 : 0); break;
                    //        }
                    //        break;
                    //    case -2: // Semi-final
                    //        switch (competicao.mataMata) {
                    //            case MataMataEnum._3_SemiFinal: numJogo += 0; break;
                    //            case MataMataEnum._4_QuartasFinal: numJogo += 4 + (competicao.jogosIdaEVolta_MataMata ? 4 : 0); break;
                    //            case MataMataEnum._5_OitavasFinal: numJogo += 8 + (competicao.jogosIdaEVolta_MataMata ? 8 : 0); break;
                    //        }
                    //        break;
                    //    case -3: //Quartas de final
                    //        switch (competicao.mataMata) {
                    //            case MataMataEnum._4_QuartasFinal: numJogo += 0; break;
                    //            case MataMataEnum._5_OitavasFinal: numJogo += 8 + (competicao.jogosIdaEVolta_MataMata ? 8 : 0); break;
                    //        }
                    //        break;
                    //    case -4: // Oitavas de final
                    //        switch (competicao.mataMata) {
                    //            case MataMataEnum._5_OitavasFinal: numJogo += 0; break;
                    //        }
                    //        break;
                    //}

                    //dgvRodada.Rows[iCount].Cells["Nome_Grupo_Jogo"].Value = "Jogo " + numJogo.ToString();
                    dgvRodada.Rows[iCount].Cells["Nome_Grupo_Jogo"].Value = "Jogo " + dataSource[iCount].numGrupo.ToString();
                } else
                    dgvRodada.Rows[iCount].Cells["Nome_Grupo_Jogo"].Value = getNomeGrupo(competicao.nomesGrupos, dataSource[iCount].numGrupo + 1); 

                dgvRodada.Rows[iCount].Cells["PtsEquipe1"].Value = (dataSource[iCount].encerrada == false ? "" : dataSource[iCount].eventos.Count(eventos => eventos.equipe.id.Equals(dataSource[iCount].equipe1.id) && eventos.tpEvento.Equals(tpEventoEnum.Gol)).ToString());
                dgvRodada.Rows[iCount].Cells["PtsEquipe2"].Value = (dataSource[iCount].encerrada == false ? "" : dataSource[iCount].eventos.Count(eventos => eventos.equipe.id.Equals(dataSource[iCount].equipe2.id) && eventos.tpEvento.Equals(tpEventoEnum.Gol)).ToString());
                dgvRodada.Rows[iCount].Cells["Vs"].Value = "X";
                dgvRodada.Rows[iCount].Cells["NomeEquipe1"].Value = dataSource[iCount].equipe1.nome;
                dgvRodada.Rows[iCount].Cells["NomeEquipe2"].Value = dataSource[iCount].equipe2.nome;
                dgvRodada.Rows[iCount].Cells[nameof(Competicao_Partida.data)].Value = dataSource[iCount].data.ToString("dd/MM/yyyy");

                // Pinta de negrito a equipe vencedora
                DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle(dgvRodada.Rows[iCount].DefaultCellStyle);
                dataGridViewCellStyle.Font = new Font(dgvRodada.Font, FontStyle.Bold);

                int golsEquipe1, golsEquipe2;
                golsEquipe1 = dataSource[iCount].eventos.FindAll(eventosAEncontrar => eventosAEncontrar.tpEvento.Equals(tpEventoEnum.Gol) && eventosAEncontrar.equipe.id == dataSource[iCount].equipe1.id).Count;
                golsEquipe2 = dataSource[iCount].eventos.FindAll(eventosAEncontrar => eventosAEncontrar.tpEvento.Equals(tpEventoEnum.Gol) && eventosAEncontrar.equipe.id == dataSource[iCount].equipe2.id).Count;

                dgvRodada.Rows[iCount].Cells["PtsEquipe1"].Style = dataGridViewCellStyle;
                dgvRodada.Rows[iCount].Cells["Vs"].Style = dataGridViewCellStyle;
                dgvRodada.Rows[iCount].Cells["PtsEquipe2"].Style = dataGridViewCellStyle;

                if (golsEquipe1 > golsEquipe2) {
                    dgvRodada.Rows[iCount].Cells["NomeEquipe1"].Style = dataGridViewCellStyle;
                } else {
                    if (golsEquipe2 > golsEquipe1) {
                        dgvRodada.Rows[iCount].Cells["NomeEquipe2"].Style = dataGridViewCellStyle;
                    }
                }
            }

            dgvRodada.Refresh();
        }

        public static void refreshDataGridViewGrupos(DataGridView dgvGrupo, List<EquipeCompeticao> dataSource) {
            dgvGrupo.DataSource = null;
            dgvGrupo.Refresh();

            dgvGrupo.Columns.Clear();

            if (!(dataSource is null)) {
                dataSource = (from customDS in dataSource
                              orderby customDS.pontos descending, customDS.vitorias descending, customDS.golsPro - customDS.golsContra descending
                              select customDS).ToList<EquipeCompeticao>();
            }

            dgvGrupo.DataSource = dataSource;

            if (!(dataSource is null)) {
                dgvGrupo.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = nameof(EquipeCompeticao.codigo) });
                dgvGrupo.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = nameof(EquipeCompeticao.nome) });
                dgvGrupo.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = nameof(EquipeCompeticao.pontos) });
                dgvGrupo.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = nameof(EquipeCompeticao.vitorias) });
                dgvGrupo.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = nameof(EquipeCompeticao.empates) });
                dgvGrupo.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = nameof(EquipeCompeticao.derrotas) });
                dgvGrupo.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = nameof(EquipeCompeticao.golsPro) });
                dgvGrupo.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = nameof(EquipeCompeticao.golsContra) });

                dgvGrupo.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = "SaldoGols" });
                dgvGrupo.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = "NumJogos" });
                dgvGrupo.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { DataPropertyName = "Aproveitamento" });
            }

            for (int iCount = 0; iCount < dgvGrupo.Columns.Count; iCount++) {
                switch (dgvGrupo.Columns[iCount].DataPropertyName) {
                    case nameof(EquipeCompeticao.codigo):
                        dgvGrupo.Columns[iCount].HeaderText = "Código";
                        dgvGrupo.Columns[iCount].Name = dgvGrupo.Columns[iCount].DataPropertyName;
                        dgvGrupo.Columns[iCount].DisplayIndex = 0;
                        break;
                    case nameof(EquipeCompeticao.nome):
                        dgvGrupo.Columns[iCount].HeaderText = "Nome da equipe";
                        dgvGrupo.Columns[iCount].Name = dgvGrupo.Columns[iCount].DataPropertyName;
                        dgvGrupo.Columns[iCount].DisplayIndex = 1;
                        break;
                    case nameof(EquipeCompeticao.pontos):
                        dgvGrupo.Columns[iCount].HeaderText = "Pts.";
                        dgvGrupo.Columns[iCount].Name = dgvGrupo.Columns[iCount].DataPropertyName;
                        dgvGrupo.Columns[iCount].Width = 50;
                        dgvGrupo.Columns[iCount].DisplayIndex = 2;
                        break;
                    case "NumJogos":
                        dgvGrupo.Columns[iCount].HeaderText = "J";
                        dgvGrupo.Columns[iCount].Name = dgvGrupo.Columns[iCount].DataPropertyName;
                        dgvGrupo.Columns[iCount].Width = 40;
                        dgvGrupo.Columns[iCount].DisplayIndex = 3;
                        break;
                    case nameof(EquipeCompeticao.vitorias):
                        dgvGrupo.Columns[iCount].HeaderText = "V";
                        dgvGrupo.Columns[iCount].Name = dgvGrupo.Columns[iCount].DataPropertyName;
                        dgvGrupo.Columns[iCount].Width = 40;
                        dgvGrupo.Columns[iCount].DisplayIndex = 4;
                        break;
                    case nameof(EquipeCompeticao.empates):
                        dgvGrupo.Columns[iCount].HeaderText = "E";
                        dgvGrupo.Columns[iCount].Name = dgvGrupo.Columns[iCount].DataPropertyName;
                        dgvGrupo.Columns[iCount].Width = 40;
                        dgvGrupo.Columns[iCount].DisplayIndex = 5;
                        break;
                    case nameof(EquipeCompeticao.derrotas):
                        dgvGrupo.Columns[iCount].HeaderText = "D";
                        dgvGrupo.Columns[iCount].Name = dgvGrupo.Columns[iCount].DataPropertyName;
                        dgvGrupo.Columns[iCount].Width = 40;
                        dgvGrupo.Columns[iCount].DisplayIndex = 6;
                        break;
                    case nameof(EquipeCompeticao.golsPro):
                        dgvGrupo.Columns[iCount].HeaderText = "GP";
                        dgvGrupo.Columns[iCount].Name = dgvGrupo.Columns[iCount].DataPropertyName;
                        dgvGrupo.Columns[iCount].Width = 40;
                        dgvGrupo.Columns[iCount].DisplayIndex = 7;
                        break;
                    case nameof(EquipeCompeticao.golsContra):
                        dgvGrupo.Columns[iCount].HeaderText = "GC";
                        dgvGrupo.Columns[iCount].Name = dgvGrupo.Columns[iCount].DataPropertyName;
                        dgvGrupo.Columns[iCount].Width = 40;
                        dgvGrupo.Columns[iCount].DisplayIndex = 8;
                        break;
                    case "SaldoGols":
                        dgvGrupo.Columns[iCount].HeaderText = "SG";
                        dgvGrupo.Columns[iCount].Name = dgvGrupo.Columns[iCount].DataPropertyName;
                        dgvGrupo.Columns[iCount].Width = 40;
                        dgvGrupo.Columns[iCount].DisplayIndex = 9;
                        break;
                    case "Aproveitamento":
                        dgvGrupo.Columns[iCount].HeaderText = " %";
                        dgvGrupo.Columns[iCount].Name = dgvGrupo.Columns[iCount].DataPropertyName;
                        dgvGrupo.Columns[iCount].Width = 50;
                        dgvGrupo.Columns[iCount].DisplayIndex = 10;
                        break;
                    default:
                        dgvGrupo.Columns[iCount].Visible = false;
                        break;
                }
            }

            //Preenche os campos que vieram sem preenchimento do data set
            for (int iCount = 0; iCount < dgvGrupo.Rows.Count; iCount++) {
                dgvGrupo.Rows[iCount].Cells["NumJogos"].Value = dataSource[iCount].vitorias + dataSource[iCount].derrotas + dataSource[iCount].empates;

                dgvGrupo.Rows[iCount].Cells["SaldoGols"].Value = dataSource[iCount].golsPro - dataSource[iCount].golsContra;

                if (dataSource[iCount].vitorias + dataSource[iCount].derrotas + dataSource[iCount].empates > 0)
                    dgvGrupo.Rows[iCount].Cells["Aproveitamento"].Value = dataSource[iCount].pontos * 100 / ((dataSource[iCount].vitorias + dataSource[iCount].derrotas + dataSource[iCount].empates) * 3);
                else
                    dgvGrupo.Rows[iCount].Cells["Aproveitamento"].Value = 0;
            }

            dgvGrupo.Refresh();
        }


    }

}
