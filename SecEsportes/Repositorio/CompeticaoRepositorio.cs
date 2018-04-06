﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using SecEsportes.Modelo;
using SecEsportes.Infraestrutura;
using System.Data.SQLite;

namespace SecEsportes.Repositorio
{
    public class CompeticaoRepositorio {
        #region Implementação Singleton
        private static CompeticaoRepositorio instance = null;
        public static CompeticaoRepositorio Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CompeticaoRepositorio();
                }
                return instance;
            }
        }
        #endregion

        private CompeticaoRepositorio(){

        }

        public void CreateTable(SQLiteConnection connection) {
            //Criação da tabela Competicoes
            if (connection.GetSchema("Tables", new[] { null, null, "Competicao", null }).Rows.Count == 0) {
                SQLiteCommand command = connection.CreateCommand();

                command.CommandText = "CREATE Table Competicao (" +
                    "id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "nome NVARCHAR(100) NOT NULL, " +
                    "dataInicial DATETIME NOT NULL, " +
                    "dataFinal DATETIME NULL, " +
                    "id_Modalidade INTEGER, " +
                    "numTimes INTEGER, " +
                    "numGrupos INTEGER, " +
                    "mataMata INTEGER, " +
                    "jogosIdaEVolta INTEGER, " +
                    "jogosIdaEVolta_MataMata INTEGER, " +
                    "status INTEGER, " +
                    "nomesGrupos INTEGER, " +
                    "FOREIGN KEY(id_Modalidade) REFERENCES modalidade(id) " +
                    ") ";
                command.ExecuteNonQuery();
            }
        }
        public Competicao get(int id) {
            string myString = String.Empty;
            return get(id, ref myString);
        }
        public Competicao get(int id, ref string messageError)
        {
            try {
                using (var connection = SQLiteDatabase.Instance.SQLiteDatabaseConnection()) {
                    connection.Open();

                    Competicao competicao = connection.Query<Competicao>(
                        "SELECT * FROM Competicao WHERE id = @id", new { id })
                        .FirstOrDefault();

                    competicao.equipes = EquipeRepositorio.Instance.getEquipesByCompeticao(competicao.id);

                    return competicao;
                }
            }
            catch(Exception ex) {
                messageError = ex.Message;
                return null;
            }
        }
        public List<Competicao> get() {
            string myString = String.Empty;
            return get(ref myString);
        }
        public List<Competicao> get(ref string messageError)
        {
            try {
                using (var connection = SQLiteDatabase.Instance.SQLiteDatabaseConnection()) {
                    connection.Open();
                    
                    List<Competicao> competicoes = connection.Query<Competicao>("SELECT * FROM Competicao").ToList();
                    for(int iCount = 0; iCount < competicoes.Count; iCount++) {
                        competicoes[iCount].equipes = EquipeRepositorio.Instance.getEquipesByCompeticao(competicoes[iCount].id);
                        competicoes[iCount].modalidade = ModalidadeRepositorio.Instance.get(competicoes[iCount].id_Modalidade);
                    }

                    return competicoes;
                }
            }catch (Exception ex) {
                messageError = ex.Message;
                return null;
            }
        }
        public bool insert(ref Competicao competicao, ref string messageError) {
            try{
                competicao.id = SQLiteDatabase.Instance.SQLiteDatabaseConnection().Query<int>("" +
                    "INSERT INTO Competicao " +
                    "(Nome, dataInicial, dataFinal, id_Modalidade, numTimes, numGrupos, mataMata, jogosIdaEVolta, jogosIdaEvolta_MataMata, status, nomesGrupos) " +
                    "VALUES " +
                    "(@Nome, @dataInicial, @dataFinal, @id_Modalidade, @numTimes, @numGrupos, @mataMata, @jogosIdaEVolta, @jogosIdaEVolta_MataMata, @status, @nomesGrupos); " +
                    "select last_insert_rowid()",
                    new {   competicao.nome,
                            competicao.dataInicial,
                            competicao.dataFinal,
                            id_Modalidade = competicao.modalidade.id,
                            competicao.numTimes,
                            competicao.numGrupos,
                            competicao.mataMata,
                            jogosIdaEVolta = (competicao.jogosIdaEVolta == true ? 1 : 0),
                            jogosIdaEVolta_MataMata = (competicao.jogosIdaEVolta_MataMata == true ? 1 : 0),
                            competicao.status,
                            competicao.nomesGrupos
                    }).First();
                return true;
            }catch (Exception ex){
                messageError = ex.Message;
                return false;
            }
        }
        public bool insertEquipeEmCompeticao(int idCompeticao, Equipe_Insert equipe) {
            try {
                SQLiteDatabase.Instance.SQLiteDatabaseConnection().Query("" +
                    "INSERT INTO Equipe_Competicao " +
                    "(id_Equipe, id_Competicao, id_Treinador, id_Representante, jogos, golsPro, golsContra, vitorias, empates, derrotas, nome) " +
                    "VALUES " +
                    "(@idEquipe, @idCompeticao, @idTreinador, @idRepresentante, @jogos, @golsPro, @golsContra, @vitorias, @empates, @derrotas, @nome); ",
                    new {   idEquipe = equipe.id,
                            idCompeticao,
                            idTreinador = -1,
                            idRepresentante = -1,
                            jogos = 0,
                            golsPro = 0,
                            golsContra = 0,
                            vitorias = 0,
                            empates = 0,
                            derrotas = 0,
                            nome = ""
                        });
                return true;
            }catch (Exception ex) {
                return false;
            }
        }
        public bool update(Competicao competicao, ref string messageError) {
            try{
                SQLiteDatabase.Instance.SQLiteDatabaseConnection().Query(
                    "UPDATE Competicao " +
                    "SET    Nome = @Nome, " +
                    "       dataInicial = @dataInicial, " +
                    "       dataFinal = @dataFinal, " +
                    "       id_Modalidade = @id_Modalidade, " +
                    "       numTimes = @numTimes," +
                    "       numGrupos = @numGrupos, " +
                    "       mataMata = @mataMata, " +
                    "       jogosIdaEVolta = @jogosIdaEVolta, " +
                    "       jogosIdaEVolta_MataMata = @jogosIdaEVolta_MataMata, " +
                    "       status = @status, " +
                    "       nomesGrupos = @nomesGrupos " +
                    "WHERE id = @id",
                    new {   competicao.nome,
                            competicao.dataInicial,
                            competicao.dataFinal,
                            id_Modalidade = competicao.modalidade.id,
                            competicao.numTimes,
                            competicao.numGrupos,
                            competicao.mataMata,
                            jogosIdaEVolta = (competicao.jogosIdaEVolta == true ? 1 : 0),
                            jogosIdaEVolta_MataMata = (competicao.jogosIdaEVolta_MataMata == true ? 1 : 0),
                            competicao.status,
                            competicao.id,
                            competicao.nomesGrupos
                    });
                return true;
            }catch (Exception ex){
                messageError = ex.Message;
                return false;
            }
        }
        public bool delete(Competicao competicao, ref string messageError) {
            try{
                SQLiteDatabase.Instance.SQLiteDatabaseConnection().Query(
                    "DELETE FROM Competicao WHERE id = @id", competicao);
                return true;
            }catch (Exception ex){
                messageError = ex.Message;
                return false;
            }
        }
        public bool deleteEquipe(EquipeCompeticao equipe, ref string messageError) {
            try {
                SQLiteDatabase.Instance.SQLiteDatabaseConnection().Query(
                    "DELETE FROM Equipe_Competicao WHERE id = @id", equipe);
                return true;
            }catch (Exception ex) {
                messageError = ex.Message;
                return false;
            }
        }
    }
}