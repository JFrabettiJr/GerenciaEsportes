using SecEsportes.Modelo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecEsportes.Infraestrutura {
    public static class RelatorioHTML {

        public static void relatorioArtilheiros(Competicao competicao, List<Atleta_List_Artilheiro> artilheiros, bool fotoAtleta) {
            //Cabeçalho HTML
            StringBuilder cabecalhoHTML = new StringBuilder();
            cabecalhoHTML.AppendLine("<html>");
            cabecalhoHTML.AppendLine("    <head>");
            cabecalhoHTML.AppendLine("            <link rel=\"stylesheet\" href=\"https://stackpath.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css\" integrity=\"sha384-WskhaSGFgHYWDcbwN70/dfYBj47jz9qbsMId/iRN3ewGhXQFZCSftd1LZCfmhktB\" crossorigin=\"anonymous\">");
            cabecalhoHTML.AppendLine("            <script src=\"https://stackpath.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js\" integrity=\"sha384-smHYKdLADwkXOn1EmN1qk/HfnUcbVRZyYmZ4qpPea6sjB/pTJ0euyQp0Mk8ck+5T\" crossorigin=\"anonymous\"></script>");
            cabecalhoHTML.AppendLine("        <meta charset=\"UTF-8\">");
            cabecalhoHTML.AppendFormat("        <title>{0} - Artilheiros</title>", competicao.nome).AppendLine();
            cabecalhoHTML.AppendLine("    </head>");
            cabecalhoHTML.AppendLine("    <body>");

            //Cabeçalho Relatório
            StringBuilder cabecalhoRelatorio = new StringBuilder();
            cabecalhoRelatorio.AppendLine("        <div class=\"card\">");
            cabecalhoRelatorio.AppendFormat("            <div class=\"card-header bg-primary mb-3\"><strong>{0} - Artilheiros</strong></div>", competicao.nome).AppendLine();
            cabecalhoRelatorio.AppendLine("            <div class=\"card-body\">");
            cabecalhoRelatorio.AppendLine("                <table class=\"table table-striped\">");
            cabecalhoRelatorio.AppendLine("                    <thead>");
            cabecalhoRelatorio.AppendLine("                        <tr>");
            cabecalhoRelatorio.AppendLine("                            <th style=\"width: 6%\">P.</th>");

            if (fotoAtleta)
                cabecalhoRelatorio.AppendLine("                            <th style=\"width: 10%\"> </th>");

            cabecalhoRelatorio.AppendLine("                            <th style=\"width: 30%\">Atleta</th>");
            cabecalhoRelatorio.AppendLine("                            <th style=\"width: 19%\">Equipe</th>");
            cabecalhoRelatorio.AppendLine("                            <th style=\"width: 15%\">Gols</th>");
            cabecalhoRelatorio.AppendLine("                            <th style=\"width: 10%\">Média</th>");
            cabecalhoRelatorio.AppendLine("                            <th style=\"width: 10%\">Partidas</th>");
            cabecalhoRelatorio.AppendLine("                        </tr>");
            cabecalhoRelatorio.AppendLine("                    </thead>");
            cabecalhoRelatorio.AppendLine("                    <tbody>");

            //Artilheiros
            StringBuilder artilheirosRelatorio = new StringBuilder();
            for (int iCount = 0; iCount < artilheiros.Count; iCount++) {
                Atleta_List_Artilheiro artilheiro = artilheiros[iCount];

                artilheirosRelatorio.AppendLine("                        <tr> ");
                artilheirosRelatorio.AppendFormat("							<td>{0}º</td> ", iCount + 1).AppendLine();

                if (fotoAtleta)
                    artilheirosRelatorio.AppendFormat("							<td><div class=\"text-center\">	<img height=\"75\" src=\"file:///{0}\" class=\"rounded\"></div></td>  ", (artilheiro.atleta.pessoa.urlFoto is null ? "" : artilheiro.atleta.pessoa.urlFoto)).AppendLine();

                artilheirosRelatorio.AppendFormat("							<td>{0}</td> ", artilheiro.nome_Atleta).AppendLine();
                artilheirosRelatorio.AppendFormat("							<td>{0}</td> ", artilheiro.nome_Equipe).AppendLine();
                artilheirosRelatorio.AppendFormat("							<td>{0}</td> ", artilheiro.num_Gols).AppendLine();
                artilheirosRelatorio.AppendFormat("							<td>{0}</td>  ", Convert.ToDouble(artilheiro.num_Gols) / Convert.ToDouble(artilheiro.num_Partidas)).AppendLine();
                artilheirosRelatorio.AppendFormat("							<td>{0}</td> ", artilheiro.num_Partidas).AppendLine();
                artilheirosRelatorio.AppendLine("						</tr> ");
            }

            //Parte final relatório
            StringBuilder finalRelatorio = new StringBuilder();
            finalRelatorio.AppendLine("                    </tbody>");
            finalRelatorio.AppendLine("                </table>");
            finalRelatorio.AppendLine("            </div>");
            finalRelatorio.AppendLine("        </div>");

            //Final HTML
            StringBuilder finalHTML = new StringBuilder();
            finalHTML.AppendLine("    </body>");
            finalHTML.AppendLine("</html>");

            //HTML Inteiro
            StringBuilder fullHTML = new StringBuilder();
            fullHTML.Append(cabecalhoHTML.ToString());
            fullHTML.Append(cabecalhoRelatorio.ToString());
            fullHTML.Append(artilheirosRelatorio.ToString());
            fullHTML.Append(finalRelatorio.ToString());
            fullHTML.Append(finalHTML.ToString());

            // Escolhe onde vai salvar o arquivo
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "HTML Files|*.html";
            saveFileDialog.Title = "Escolha um diretório para salvar o relatório de artilheiros";
            saveFileDialog.FileName = String.Format("{0} - Relatório de artilharia", competicao.nome);

            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                // Salva o arquivo
                StreamWriter salvar = new StreamWriter(saveFileDialog.FileName);
                salvar.WriteLine(fullHTML.ToString());
                salvar.Close();

                if (MessageBox.Show("Gostaria de abrir o relatório?",
                    "Relatório de artilharia",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                    System.Diagnostics.Process.Start(saveFileDialog.FileName);
            }
        }
        public static void relatorioGrupos(Competicao competicao, bool fotoEquipe, List<List<EquipeCompeticao>> timesProximaFase) {
            StringBuilder cabecalhoHTML = new StringBuilder();
            StringBuilder cabecalhoRelatorio = new StringBuilder();
            StringBuilder equipesRelatorio = new StringBuilder();
            StringBuilder finalRelatorio = new StringBuilder();
            StringBuilder finalHTML = new StringBuilder();
            StringBuilder fullHTML = new StringBuilder();

            //Cabeçalho HTML
            cabecalhoHTML = new StringBuilder();
            cabecalhoHTML.AppendLine("<html>");
            cabecalhoHTML.AppendLine("    <head>");
            cabecalhoHTML.AppendLine("        <link rel=\"stylesheet\" href=\"https://stackpath.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css\" integrity=\"sha384-WskhaSGFgHYWDcbwN70/dfYBj47jz9qbsMId/iRN3ewGhXQFZCSftd1LZCfmhktB\" crossorigin=\"anonymous\">");
            cabecalhoHTML.AppendLine("        <script src=\"https://stackpath.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js\" integrity=\"sha384-smHYKdLADwkXOn1EmN1qk/HfnUcbVRZyYmZ4qpPea6sjB/pTJ0euyQp0Mk8ck+5T\" crossorigin=\"anonymous\"></script>");
            cabecalhoHTML.AppendLine("        <meta charset=\"UTF-8\">");
            cabecalhoHTML.AppendFormat("        <title>{0} - Classificação</title>", competicao.nome).AppendLine();
            cabecalhoHTML.AppendLine("    </head>");
            cabecalhoHTML.AppendLine("    <body>");

            fullHTML.Append(cabecalhoHTML.ToString());


            //Cabeçalho Relatório - Por Grupo
            for (int iGrupo = 0; iGrupo < competicao.grupos.Count; iGrupo++) {

                // Ordena as equipes
                competicao.grupos[iGrupo] = (from customDS in competicao.grupos[iGrupo]
                                             orderby customDS.pontos descending, customDS.vitorias descending, customDS.golsPro - customDS.golsContra descending
                                             select customDS).ToList<EquipeCompeticao>();

                cabecalhoRelatorio = new StringBuilder();
                cabecalhoRelatorio.AppendLine("		<div class=\"card\">");
                cabecalhoRelatorio.AppendFormat("            <div class=\"card-header bg-primary mb-3\"><strong>{0}</strong></div>", CompeticaoViewUtilidades.getNomeGrupo(competicao.nomesGrupos, iGrupo+1)).AppendLine();
                cabecalhoRelatorio.AppendLine("            <div class=\"card-body\">");
                cabecalhoRelatorio.AppendLine("                <table class=\"table table-striped\">");
                cabecalhoRelatorio.AppendLine("                    <thead>");
                cabecalhoRelatorio.AppendLine("                        <tr>");
                cabecalhoRelatorio.AppendLine("                            <th style=\"width: 6%\">P.</th>");

                if (fotoEquipe)
                    cabecalhoRelatorio.AppendLine("                            <th style=\"width: 10%\"> </th>");

                cabecalhoRelatorio.AppendLine("                            <th style=\"width: 20%\">Equipe</th>");
                cabecalhoRelatorio.AppendLine("                            <th style=\"width: 9%\">Pts</th>");
                cabecalhoRelatorio.AppendLine("                            <th style=\"width: 6%\">J</th>");
                cabecalhoRelatorio.AppendLine("                            <th style=\"width: 6%\">V</th>");
                cabecalhoRelatorio.AppendLine("                            <th style=\"width: 6%\">E</th>");
                cabecalhoRelatorio.AppendLine("                            <th style=\"width: 6%\">D</th>");
                cabecalhoRelatorio.AppendLine("                            <th style=\"width: 6%\">GP</th>");
                cabecalhoRelatorio.AppendLine("                            <th style=\"width: 6%\">GC</th>");
                cabecalhoRelatorio.AppendLine("                            <th style=\"width: 6%\">SG</th>");
                cabecalhoRelatorio.AppendLine("                            <th style=\"width: 6%\">%</th>");
                cabecalhoRelatorio.AppendLine("                        </tr>");
                cabecalhoRelatorio.AppendLine("                    </thead>");
                cabecalhoRelatorio.AppendLine("                    <tbody>");

                fullHTML.Append(cabecalhoRelatorio.ToString());

                //Equipes
                for (int iEquipe = 0; iEquipe < competicao.grupos[iGrupo].Count; iEquipe++) {
                    EquipeCompeticao equipe = competicao.grupos[iGrupo][iEquipe];

                    //Verifica se a equipe até então está se classificando
                    bool classificada = false;
                    if (timesProximaFase[iGrupo].Contains(equipe)){
                        classificada = true;
                    }

                    equipesRelatorio = new StringBuilder();
                    equipesRelatorio.AppendFormat("                        <tr {0}>", (classificada ? "style=\"font-weight:bold\"" : "")).AppendLine();
                    equipesRelatorio.AppendFormat("							<td>{0}º</td>", iEquipe+1).AppendLine();

                    if (fotoEquipe)
                        equipesRelatorio.AppendFormat("							<td><div class=\"text-center\">	<img height=\"75\" src=\"file:///{0}\" class=\"rounded\"></div></td>  ", (equipe.urlLogo is null ? "" : equipe.urlLogo)).AppendLine();

                    equipesRelatorio.AppendFormat("							<td>{0}</td>", equipe.nome).AppendLine();
                    equipesRelatorio.AppendFormat("							<td>{0}</td>", equipe.pontos).AppendLine();
                    equipesRelatorio.AppendFormat("							<td>{0}</td>", equipe.vitorias + equipe.derrotas + equipe.empates).AppendLine();
                    equipesRelatorio.AppendFormat("							<td>{0}</td>", equipe.vitorias).AppendLine();
                    equipesRelatorio.AppendFormat("							<td>{0}</td>", equipe.empates).AppendLine();
                    equipesRelatorio.AppendFormat("							<td>{0}</td>", equipe.derrotas).AppendLine();
                    equipesRelatorio.AppendFormat("							<td>{0}</td>", equipe.golsPro).AppendLine();
                    equipesRelatorio.AppendFormat("							<td>{0}</td>", equipe.golsContra).AppendLine();
                    equipesRelatorio.AppendFormat("							<td>{0}</td>", equipe.golsPro - equipe.golsContra).AppendLine();
                    if (equipe.vitorias + equipe.derrotas + equipe.empates > 0)
                        equipesRelatorio.AppendFormat("							<td>{0}</td>", equipe.pontos * 100 / ((equipe.vitorias + equipe.derrotas + equipe.empates) * 3)).AppendLine();
                    else
                        equipesRelatorio.AppendFormat("							<td>{0}</td>", 0).AppendLine();
                    equipesRelatorio.AppendLine("						</tr> ");

                    fullHTML.Append(equipesRelatorio.ToString());
                }

                //Parte final relatório
                finalRelatorio = new StringBuilder();
                finalRelatorio.AppendLine("                    </tbody>");
                finalRelatorio.AppendLine("                </table>");
                finalRelatorio.AppendLine("            </div>");
                finalRelatorio.AppendLine("        </div>");

                fullHTML.Append(finalRelatorio.ToString());
            }

            //Final HTML
            finalHTML = new StringBuilder();
            finalHTML.AppendLine("    </body>");
            finalHTML.AppendLine("</html>");

            fullHTML.Append(finalHTML.ToString());

            // Escolhe onde vai salvar o arquivo
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "HTML Files|*.html";
            saveFileDialog.Title = "Escolha um diretório para salvar o relatório de classificação";
            saveFileDialog.FileName = String.Format("{0} - Relatório de classificação", competicao.nome);

            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                // Salva o arquivo
                StreamWriter salvar = new StreamWriter(saveFileDialog.FileName);
                salvar.WriteLine(fullHTML.ToString());
                salvar.Close();

                if (MessageBox.Show("Gostaria de abrir o relatório?",
                    "Relatório de classificação",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                    System.Diagnostics.Process.Start(saveFileDialog.FileName);

            }
        }

        public static void relatorioPartidas(Competicao competicao, List<Competicao_Partida> partidas, int rodada, string nomeRodada, bool fotoAtleta) {
            //Cabeçalho HTML
            StringBuilder cabecalhoHTML = new StringBuilder();
            cabecalhoHTML.AppendLine("<html>");
            cabecalhoHTML.AppendLine("    <head>");
            cabecalhoHTML.AppendLine("            <link rel=\"stylesheet\" href=\"https://stackpath.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css\" integrity=\"sha384-WskhaSGFgHYWDcbwN70/dfYBj47jz9qbsMId/iRN3ewGhXQFZCSftd1LZCfmhktB\" crossorigin=\"anonymous\">");
            cabecalhoHTML.AppendLine("            <script src=\"https://stackpath.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js\" integrity=\"sha384-smHYKdLADwkXOn1EmN1qk/HfnUcbVRZyYmZ4qpPea6sjB/pTJ0euyQp0Mk8ck+5T\" crossorigin=\"anonymous\"></script>");
            cabecalhoHTML.AppendLine("        <meta charset=\"UTF-8\">");
            cabecalhoHTML.AppendFormat("        <title>{0} - Artilheiros</title>", competicao.nome).AppendLine();
            cabecalhoHTML.AppendLine("    </head>");
            cabecalhoHTML.AppendLine("    <style>");
            cabecalhoHTML.AppendLine("        th {	font-size: 18px;	}");
            cabecalhoHTML.AppendLine("        td {	font-size: 16px;	}");
            cabecalhoHTML.AppendLine("        div {	font-size: 18px;	}");
            cabecalhoHTML.AppendLine("    </style>");
            cabecalhoHTML.AppendLine("    <body>");

            //Cabeçalho Relatório
            StringBuilder cabecalhoRelatorio = new StringBuilder();
            cabecalhoRelatorio.AppendLine("		<div class=\"card\">");
            cabecalhoRelatorio.AppendFormat("            <div class=\"card-header bg-primary mb-3\"><strong>{0}</strong></div>", nomeRodada).AppendLine();
            cabecalhoRelatorio.AppendLine("            <div class=\"card-body\">");
            cabecalhoRelatorio.AppendLine("                <table class=\"table table-striped\">");
            cabecalhoRelatorio.AppendLine("                    <thead>");
            cabecalhoRelatorio.AppendLine("                        <tr>");

            string nomeGrupoJogo;
            if (rodada < 0)
                nomeGrupoJogo = "Jogo";
            else
                nomeGrupoJogo = "Grupo";
            cabecalhoRelatorio.AppendFormat("                            <th style=\"width: 10%\">{0}</th>", nomeGrupoJogo).AppendLine();

            cabecalhoRelatorio.AppendLine("                            <th style=\"width: 10%\">Data</th>");

            if (fotoAtleta)
                cabecalhoRelatorio.AppendLine("                            <th style=\"width: 4.41%\"> </th>");

            cabecalhoRelatorio.AppendLine("                            <th style=\"width: 17.85%\">Casa</th>");
            cabecalhoRelatorio.AppendLine("                            <th style=\"width: 6%\"> </th>");
            cabecalhoRelatorio.AppendLine("                            <th style=\"width: 2%\">X</th>");
            cabecalhoRelatorio.AppendLine("                            <th style=\"width: 6%\"> </th>");
            cabecalhoRelatorio.AppendLine("                            <th style=\"width: 17.85%\">Visitante</th>");

            if (fotoAtleta)
                cabecalhoRelatorio.AppendLine("                            <th style=\"width: 4.41%\"> </th>");

            cabecalhoRelatorio.AppendLine("                            <th style=\"width: 15.66%\">Árbitro</th>");
            cabecalhoRelatorio.AppendLine("                        </tr>");
            cabecalhoRelatorio.AppendLine("                    </thead>");
            cabecalhoRelatorio.AppendLine("                    <tbody>");

            //Partidas
            StringBuilder partidasRelatorio = new StringBuilder();
            for (int numPartida = 0; numPartida < partidas.Count; numPartida++){
                Competicao_Partida partida = partidas[numPartida];

                int numGolsEquipe1, numGolsEquipe2;
                numGolsEquipe1 = partida.eventos.FindAll(find => find.tpEvento == tpEventoEnum.Gol && find.id_Equipe == partida.equipe1.id).Count;
                numGolsEquipe2 = partida.eventos.FindAll(find => find.tpEvento == tpEventoEnum.Gol && find.id_Equipe == partida.equipe2.id).Count;

                int numGolsPenaltiEquipe1, numGolsPenaltiEquipe2;
                numGolsPenaltiEquipe1 = partida.eventos.FindAll(find => find.tpEvento == tpEventoEnum.Gol_Penalti && find.id_Equipe == partida.equipe1.id).Count;
                numGolsPenaltiEquipe2 = partida.eventos.FindAll(find => find.tpEvento == tpEventoEnum.Gol_Penalti && find.id_Equipe == partida.equipe2.id).Count;

                bool vitoriaEquipe1, vitoriaEquipe2;
                if (numGolsPenaltiEquipe1 > 0 || numGolsPenaltiEquipe2 > 0) {
                    vitoriaEquipe1 = numGolsPenaltiEquipe1 > numGolsPenaltiEquipe2;
                    vitoriaEquipe2 = numGolsPenaltiEquipe2 > numGolsPenaltiEquipe1;
                } else {
                    vitoriaEquipe1 = numGolsEquipe1 > numGolsEquipe2;
                    vitoriaEquipe2 = numGolsEquipe2 > numGolsEquipe1;
                }

                partidasRelatorio.AppendLine("                        <tr>");

                if (rodada < 0)
                    nomeGrupoJogo = "Jogo " + partida.numGrupo.ToString();
                else
                    nomeGrupoJogo = CompeticaoViewUtilidades.getNomeGrupo(competicao.nomesGrupos, partida.numGrupo + 1);
                partidasRelatorio.AppendFormat("							<td>{0}</td>", nomeGrupoJogo).AppendLine();

                string dataJogo;
                if (partida.data is null)
                    dataJogo = "";
                else
                    dataJogo = ((DateTime)partida.data).ToString("dd/MM/yyyy");
                partidasRelatorio.AppendFormat("							<td>{0}</td>", dataJogo).AppendLine();

                if (fotoAtleta)
                    partidasRelatorio.AppendFormat("							<td><div class=\"text-center\">	<img height=\"25\" src=\"file:///{0}\" class=\"rounded\"></div></td>  ", (partida.equipe1.urlLogo is null ? "" : partida.equipe1.urlLogo)).AppendLine();

                string golsEquipe1 = numGolsEquipe1.ToString();
                if (numGolsPenaltiEquipe1 > 0 || numGolsPenaltiEquipe2 > 0)
                    golsEquipe1 += " (" + numGolsPenaltiEquipe1.ToString() + ")";
                partidasRelatorio.AppendFormat("							<td {0}>{1}</td>", (vitoriaEquipe1 ? "style=\"font-weight:bold\"" : ""), partida.equipe1.nome).AppendLine();
                partidasRelatorio.AppendFormat("							<td align=\"right\" {0}>{1}</td>", (vitoriaEquipe1 ? "style=\"font-weight:bold\"" : ""), (partida.encerrada ? golsEquipe1 : "")).AppendLine();
                partidasRelatorio.AppendLine("							<td style=\"font-weight:bold\">X</td>");

                string golsEquipe2 = "";
                if (numGolsPenaltiEquipe1 > 0 || numGolsPenaltiEquipe2 > 0)
                    golsEquipe2 = "(" + numGolsPenaltiEquipe2.ToString() + ") ";
                golsEquipe2 += numGolsEquipe2.ToString();
                partidasRelatorio.AppendFormat("							<td align=\"left\" {0}>{1}</td>", (vitoriaEquipe2 ? "style=\"font-weight:bold\"" : ""), (partida.encerrada ? golsEquipe2 : "")).AppendLine();

                partidasRelatorio.AppendFormat("							<td {0}>{1}</td>", (vitoriaEquipe2 ? "style=\"font-weight:bold\"" : ""), partida.equipe2.nome).AppendLine();

                if (fotoAtleta)
                    partidasRelatorio.AppendFormat("							<td><div class=\"text-center\">	<img height=\"25\" src=\"file:///{0}\" class=\"rounded\"></div></td>  ", (partida.equipe2.urlLogo is null ? "" : partida.equipe2.urlLogo)).AppendLine();

                partidasRelatorio.AppendFormat("							<td>{0}</td>", (partida.arbitro is null? "" : partida.arbitro.pessoa.nome)).AppendLine();
                partidasRelatorio.AppendLine("						</tr> ");
            }

            //Parte final relatório
            StringBuilder finalRelatorio = new StringBuilder();
            finalRelatorio.AppendLine("                    </tbody>");
            finalRelatorio.AppendLine("                </table>");
            finalRelatorio.AppendLine("            </div>");
            finalRelatorio.AppendLine("        </div>");

            //Final HTML
            StringBuilder finalHTML = new StringBuilder();
            finalHTML.AppendLine("    </body>");
            finalHTML.AppendLine("</html>");

            //HTML Inteiro
            StringBuilder fullHTML = new StringBuilder();
            fullHTML.Append(cabecalhoHTML.ToString());
            fullHTML.Append(cabecalhoRelatorio.ToString());
            fullHTML.Append(partidasRelatorio.ToString());
            fullHTML.Append(finalRelatorio.ToString());
            fullHTML.Append(finalHTML.ToString());

            // Escolhe onde vai salvar o arquivo
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "HTML Files|*.html";
            saveFileDialog.Title = "Escolha um diretório para salvar o relatório de partidas";
            saveFileDialog.FileName = String.Format("{0} - {1} - Relatório de partidas", competicao.nome, nomeRodada);

            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                // Salva o arquivo
                StreamWriter salvar = new StreamWriter(saveFileDialog.FileName);
                salvar.WriteLine(fullHTML.ToString());
                salvar.Close();

                if (MessageBox.Show("Gostaria de abrir o relatório?",
                    "Relatório de partidas",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                    System.Diagnostics.Process.Start(saveFileDialog.FileName);
            }
        }
    }
}