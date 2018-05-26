using SecEsportes.Modelo;
using SecEsportes.Repositorio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecEsportes.Infraestrutura {
    public static class GerenciadorCSV {

        public static void exportarPlanilha(Competicao competicao, Competicao_Partida partida) {
            StringBuilder conteudoCSV = new StringBuilder();

            // Cabeçalho
            conteudoCSV.AppendLine("idCompeticao;Competicao"); // Linha 1
            conteudoCSV.AppendFormat("{0};{1}", competicao.id, competicao.nome).AppendLine().AppendLine(); // Linha 2
            /*  idCompeticao = A2 - [1, 0]   */

            // Partida
            conteudoCSV.AppendLine("idPartida"); // Linha 4
            conteudoCSV.AppendFormat("{0}", partida.id).AppendLine().AppendLine(); // Linha 5
            /*  idPartida = A5 - [4, 0]  */

            // Data da partida
            conteudoCSV.AppendLine("dataPartida"); // Linha 7
            if (partida.data is null)
                conteudoCSV.AppendFormat("{0}", "").AppendLine().AppendLine(); // Linha 8
            else
                conteudoCSV.AppendFormat("{0}", ((DateTime)partida.data).ToString("dd/MM/yyyy")).AppendLine().AppendLine(); // Linha 8
            /*  dataPartida = A8 - [7, 0]   */

            // Árbitro
            conteudoCSV.AppendLine("idArbito;Arbitro"); // Linha 10
            conteudoCSV.AppendFormat("{0};{1}", (partida.arbitro is null ? 0 : partida.arbitro.pessoa.id), (partida.arbitro is null ? "" : partida.arbitro.pessoa.nome)).AppendLine().AppendLine();  // Linha 11
            /*  idCompeticao = A11 - [10, 0]   */

            // Equipes
            conteudoCSV.AppendLine("idEquipe1;Equipe 1; ;idEquipe2;Equipe 2"); // Linha 13
            conteudoCSV.AppendFormat("{0};{1};;{2};{3}", partida.equipe1.id, partida.equipe1.nome, partida.equipe2.id, partida.equipe2.nome).AppendLine().AppendLine(); // Linha 14
            /*  idEquipe1 = A14 - [13, 0]
             *  idEquipe2 = D14 - [13, 3] */

            // Atletas
            conteudoCSV.AppendLine("idAtleta;numAtleta;Atleta;Gol;Gol Penalti;Cartao Amarelo;Cartao Vermelho;;idAtleta;numAtleta;Atleta;Gol;Gol Penalti;Cartao Amarelo;Cartao Vermelho"); // Linha 16

            int numLinhas = (partida.equipe1.atletas.Count > partida.equipe2.atletas.Count ? partida.equipe1.atletas.Count : partida.equipe2.atletas.Count);
            for (int iCount = 0; iCount < numLinhas; iCount++) {
                Atleta atletaEquipe1, atletaEquipe2;
                if (iCount < partida.equipe1.atletas.Count) {
                    atletaEquipe1 = partida.equipe1.atletas[iCount];
                    conteudoCSV.AppendFormat("{0};{1};{2};0;0;0;0;", atletaEquipe1.pessoa.id, atletaEquipe1.numero, atletaEquipe1.pessoa.nome);
                } else {
                    conteudoCSV.Append(";;;;;;;");
                }
                /*  idAtleta = A? - [?, 0]
                 *  numeroAtleta = B? - [?, 1]
                 *  Gol = D? - [?, 3]
                 *  Gol Penalti = E? - [?, 4]
                 *  CA = F? - [?, 5]
                 *  CV = G? - [?, 6]
                 */

                conteudoCSV.Append(";");

                if (iCount < partida.equipe2.atletas.Count) {
                    atletaEquipe2 = partida.equipe2.atletas[iCount];
                    conteudoCSV.AppendFormat("{0};{1};{2};0;0;0;0;", atletaEquipe2.pessoa.id, atletaEquipe2.numero, atletaEquipe2.pessoa.nome);
                } else {
                    conteudoCSV.Append(";;;;;;;");
                }
                /*  idAtleta = I? - [?, 8]
                 *  numeroAtleta = J? - [?, 9]
                 *  Gol = L? - [?, 11]
                 *  Gol Penalti = M? - [?, 12]
                 *  CA = N? - [?, 13]
                 *  CV = O? - [?, 14]
                 */

                conteudoCSV.AppendLine();
            }

            // Escolhe onde vai salvar o arquivo
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV|*.csv";
            saveFileDialog.FileName = String.Format("{0} - {1} x {2}", competicao.nome, partida.equipe1.nome, partida.equipe2.nome);
            saveFileDialog.Title = String.Format("Escolha um diretório para salvar templade da partida entre {0} e {1}", partida.equipe1.nome, partida.equipe2.nome);

            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                // Salva o arquivo
                StreamWriter salvar = new StreamWriter(saveFileDialog.FileName);
                salvar.WriteLine(conteudoCSV.ToString());
                salvar.Close();

                if (MessageBox.Show(String.Format("Gostaria de abrir a planilha {0} ?", saveFileDialog.FileName),
                    String.Format("{0} x {1}", partida.equipe1.nome, partida.equipe2.nome),
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                    System.Diagnostics.Process.Start(saveFileDialog.FileName);
            } 
        }

        public static Competicao_Partida importarPlanilha(Competicao competicao, Competicao_Partida partida) {
            string stringLine;
            StreamReader file = null;

            try {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "CSV|*.csv";
                openFileDialog.Title = String.Format("{0} - {1} x {2} - Importe a planilha para a partida", competicao.nome, partida.equipe1.nome, partida.equipe2.nome);
                openFileDialog.FileName = String.Format("{0} - {1} x {2}", competicao.nome, partida.equipe1.nome, partida.equipe2.nome);
                if (openFileDialog.ShowDialog() == DialogResult.OK) {

                    // Lê o arquivo
                    file = new StreamReader(openFileDialog.FileName);

                    int numLinha = 0;
                
                    // Lê linha por linha
                    while ((stringLine = file.ReadLine()) != null) {
                        // Separa a linha toda num array
                        List<string> line = stringLine.Split(';').ToList();

                        switch (numLinha) {
                            case 1: // Linha do id da competição
                                if (Convert.ToInt32(line[0]) != competicao.id) {
                                    throw new Exception(String.Format("{0} x {1} - Não foi possível importar a planilha da partida" +
                                        Environment.NewLine + Environment.NewLine + "O id da Competição na planilha ({2}) está diferente do id da competição({3}).",
                                        partida.equipe1.nome, partida.equipe2.nome, line[0], competicao.id));
                                }
                                break;

                            case 4: // Linha do id da partida
                                if (Convert.ToInt32(line[0]) != partida.id) {
                                    throw new Exception(String.Format("{0} x {1} - Não foi possível importar a planilha da partida" +
                                        Environment.NewLine + Environment.NewLine + "O id da partida na planilha ({2}) está diferente do id da partida ({3}).",
                                        partida.equipe1.nome, partida.equipe2.nome, line[0], partida.id));
                                }
                                break;

                            case 13: // Linha do id das equipes
                                if (Convert.ToInt32(line[0]) != partida.equipe1.id) {
                                    throw new Exception(String.Format("{0} x {1} - Não foi possível importar a planilha da partida" +
                                        Environment.NewLine + Environment.NewLine + "O id da equipe 1 na planilha ({2}) está diferente do id da equipe 1 ({3}).",
                                        partida.equipe1.nome, partida.equipe2.nome, line[0], partida.equipe1.id));
                                }

                                if (Convert.ToInt32(line[3]) != partida.equipe2.id) {
                                    throw new Exception(String.Format("{0} x {1} - Não foi possível importar a planilha da partida" +
                                        Environment.NewLine + Environment.NewLine + "O id da equipe 2 na planilha ({2}) está diferente do id da equipe 2 ({3}).",
                                        partida.equipe1.nome, partida.equipe2.nome, line[3], partida.equipe2.id));
                                }
                                break;

                            default:
                                if (numLinha >= 16 && line.Count == 15) {
                                    List<string> infoEquipe1 = line.GetRange(0, 7);
                                    List<string> infoEquipe2 = line.GetRange(8, 7);

                                    Atleta atletaEquipe1, atletaEquipe2;

                                    if (infoEquipe1[0].Length == 0 && infoEquipe2[0].Length == 0) {
                                        throw new Exception(String.Format("Não foi identificado o id dos jogadores na linha {0} da planilha.", numLinha + 1));
                                    }

                                    if (infoEquipe1[0].Length > 0) {
                                        atletaEquipe1 = PessoaRepositorio.Instance.getAtletaByCompeticao(Convert.ToInt32(infoEquipe1[0]), competicao.id);

                                        if (partida.equipe1.atletas.Find(find => find.pessoa.id == atletaEquipe1.pessoa.id) is null) {
                                            // Inconsistencia
                                            throw new Exception();
                                        }

                                        // Cria os eventos da Equipe 1
                                        int numGols1, numGolsPenalti1, numCA1, numCV1;
                                        numGols1 = Convert.ToInt32(infoEquipe1[3]);
                                        numGolsPenalti1 = Convert.ToInt32(infoEquipe1[4]);
                                        numCA1 = Convert.ToInt32(infoEquipe1[5]);
                                        numCV1 = Convert.ToInt32(infoEquipe1[6]);
                                        for (int iCount = 0; iCount < numGols1; iCount++)
                                            partida.eventos.Add(new Competicao_Partida_Evento(partida.equipe1, atletaEquipe1, tpEventoEnum.Gol));

                                        for (int iCount = 0; iCount < numGolsPenalti1; iCount++)
                                            partida.eventos.Add(new Competicao_Partida_Evento(partida.equipe1, atletaEquipe1, tpEventoEnum.Gol_Penalti));

                                        for (int iCount = 0; iCount < numCA1; iCount++)
                                            partida.eventos.Add(new Competicao_Partida_Evento(partida.equipe1, atletaEquipe1, tpEventoEnum.CartaoAmarelo));

                                        for (int iCount = 0; iCount < numCV1; iCount++)
                                            partida.eventos.Add(new Competicao_Partida_Evento(partida.equipe1, atletaEquipe1, tpEventoEnum.CartaoVermelho));

                                    }

                                    if (infoEquipe2[0].Length > 0) {
                                        atletaEquipe2 = PessoaRepositorio.Instance.getAtletaByCompeticao(Convert.ToInt32(infoEquipe2[0]), competicao.id);

                                        if (partida.equipe2.atletas.Find(find => find.pessoa.id == atletaEquipe2.pessoa.id) is null) {
                                            // Inconsitencia
                                            throw new Exception();
                                        }

                                        // Cria os eventos da Equipe 2
                                        int numGols2, numGolsPenalti2, numCA2, numCV2;
                                        numGols2 = Convert.ToInt32(infoEquipe2[3]);
                                        numGolsPenalti2 = Convert.ToInt32(infoEquipe2[4]);
                                        numCA2 = Convert.ToInt32(infoEquipe2[5]);
                                        numCV2 = Convert.ToInt32(infoEquipe2[6]);
                                        for (int iCount = 0; iCount < numGols2; iCount++)
                                            partida.eventos.Add(new Competicao_Partida_Evento(partida.equipe2, atletaEquipe2, tpEventoEnum.Gol));

                                        for (int iCount = 0; iCount < numGolsPenalti2; iCount++)
                                            partida.eventos.Add(new Competicao_Partida_Evento(partida.equipe2, atletaEquipe2, tpEventoEnum.Gol_Penalti));

                                        for (int iCount = 0; iCount < numCA2; iCount++)
                                            partida.eventos.Add(new Competicao_Partida_Evento(partida.equipe2, atletaEquipe2, tpEventoEnum.CartaoAmarelo));

                                        for (int iCount = 0; iCount < numCV2; iCount++)
                                            partida.eventos.Add(new Competicao_Partida_Evento(partida.equipe2, atletaEquipe2, tpEventoEnum.CartaoVermelho));

                                    }

                                }
                                break;
                        }

                        numLinha++;
                    }

                    file.Close();

                }

                // Insere efetivamente os eventos no banco de dados
                for (int iCount = 0; iCount < partida.eventos.Count; iCount++) {
                    CompeticaoRepositorio.Instance.insertEvento(partida, partida.eventos[iCount]);
                }

                return partida;

            } catch (Exception ex) {
                partida.eventos = new List<Competicao_Partida_Evento>();

                if (!(file is null))
                    file.Close();

                MessageBox.Show(ex.Message, 
                    String.Format("Não foi possível importar a planilha da partida entre {0} e {1}", partida.equipe1.nome, partida.equipe2.nome), 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning);

                return null;
            }
        }
    }
}