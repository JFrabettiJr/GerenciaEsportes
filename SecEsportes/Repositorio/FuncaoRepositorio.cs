using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecEsportes.Modelo;
using SecEsportes.Infraestrutura;
using System.Data.SQLite;

namespace SecEsportes.Repositorio
{
    public class FuncaoRepositorio{
        #region Implementação Singleton
        private static FuncaoRepositorio instance = null;
        public static FuncaoRepositorio Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FuncaoRepositorio();
                }
                return instance;
            }
        }
        #endregion

        public string codigoAtleta {
            get {
                return "ATL";
            }
        }

        private FuncaoRepositorio(){

        }

        public void CreateTable(SQLiteConnection connection) {
            //Criação da tabela função
            if (connection.GetSchema("Tables", new[] { null, null, "Funcao", null }).Rows.Count == 0) {
                SQLiteCommand command = connection.CreateCommand();

                command.CommandText = "CREATE Table Funcao (" +
                    "id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "codigo NVARCHAR(10) NOT NULL UNIQUE, " +
                    "descricao NVARCHAR(100) NOT NULL) ";
                command.ExecuteNonQuery();
            }

            //Inserção do registro de atleta
            if (connection.Query("SELECT 1 FROM Funcao WHERE codigo = '" + codigoAtleta + "' LIMIT 1; ").Count() < 1){
                SQLiteCommand command = connection.CreateCommand();

                command.CommandText = "INSERT INTO Funcao (codigo, descricao) VALUES ('" + codigoAtleta + "', 'Atleta') ";
                command.ExecuteNonQuery();
            }

        }
        public Funcao get(int id) {
            string auxString = "";
            return get(id, ref auxString);
        }
        public Funcao get(int id, ref string messageError) {
            try {
                using (var connection = SQLiteDatabase.Instance.SQLiteDatabaseConnection()) {
                    connection.Open();

                    Funcao funcao = connection.Query<Funcao>(
                        "SELECT * FROM Funcao WHERE id = @id", new { id })
                        .FirstOrDefault();

                    return funcao;
                }
            }
            catch(Exception ex) {
                messageError = ex.Message;
                return null;
            }
        }
        public List<Funcao> get(ref string messageError)
        {
            try {
                using (var connection = SQLiteDatabase.Instance.SQLiteDatabaseConnection()) {
                    connection.Open();

                    List<Funcao> funcoes = connection.Query<Funcao>("SELECT * FROM Funcao").ToList();

                    return funcoes;
                }
            }
            catch(Exception ex) {
                messageError = ex.Message;
                return null;
            }
        }
        public List<Funcao> getFuncaoByPessoa(int idPessoa) {
            try {
                using (var connection = SQLiteDatabase.Instance.SQLiteDatabaseConnection()) {
                    connection.Open();

                    List<Funcao> funcoes = connection.Query<Funcao>("" +
                        "SELECT * " +
                        "FROM Funcao " +
                        "WHERE Funcao.ID IN (" +
                        "   SELECT ID_Funcao FROM Pessoa_Funcoes WHERE ID_Pessoa = " + idPessoa + " " +
                        ") ").ToList();

                    return funcoes;
                }
            }
            catch (Exception ex) {
                return null;
            }
        }
        public List<Atleta_Insert> getAtletasForaCompeticao(ref string errorMessage, int idCompeticao) {
            try {
                using (var connection = SQLiteDatabase.Instance.SQLiteDatabaseConnection()) {
                    connection.Open();

                    string strSQL;
                    strSQL = "SELECT 0 As Selected, pessoa.id as id_pessoa, Pessoa_Funcoes.id_funcao " +
                                "FROM   Pessoa " +
                                "       INNER JOIN Pessoa_Funcoes ON Pessoa.id = Pessoa_Funcoes.id_Pessoa " +
                                "WHERE   1 = 1 " +
                                "        AND Pessoa_Funcoes.id_Funcao IN(SELECT  id " +
                                "                                        FROM    Funcao WHERE codigo = @codigoAtleta) " +
                                "        AND Pessoa.id NOT IN(  SELECT  id_Atleta " +
                                "                               FROM    Equipe_Atletas " +
                                "                               WHERE   Equipe_Atletas.id_Competicao = @idCompeticao) " +
                                "ORDER BY  Pessoa.Nome";

                    List<Atleta_Insert> atletas = connection.Query<Atleta_Insert>(strSQL,
                        new {   codigoAtleta,
                                idCompeticao
                    }).ToList();

                    foreach (Atleta atleta in atletas) {
                        atleta.funcao = FuncaoRepositorio.Instance.get(atleta.id_funcao);
                        atleta.pessoa = PessoaRepositorio.Instance.get(atleta.id_pessoa);
                    }

                    return atletas;
                }
            }
            catch (Exception ex) {
                errorMessage = ex.Message;
                return null;
            }
        }
        public bool insert(ref Funcao funcao, ref string messageError) {
            try{
                funcao.id = SQLiteDatabase.Instance.SQLiteDatabaseConnection().Query<int>("" +
                    "INSERT INTO Funcao (Codigo, Descricao) VALUES (@Codigo, @Descricao); select last_insert_rowid()",
                    funcao).First();
                return true;
            }catch (Exception ex){
                messageError = ex.Message;
                return false;
            }
        }
        public bool update(Funcao funcao, ref string messageError) {
            try{
                SQLiteDatabase.Instance.SQLiteDatabaseConnection().Query(
                    "UPDATE Funcao SET Codigo = @Codigo, Descricao = @Descricao WHERE id = @id WHERE Codigo <> @codigoAtleta", 
                        new {   funcao.codigo,
                                funcao.descricao,
                                funcao.id,
                                codigoAtleta
                        });
                return true;
            }catch (Exception ex){
                messageError = ex.Message;
                return false;
            }
        }
        public bool delete(Funcao funcao, ref string messageError) {
            try{
                SQLiteDatabase.Instance.SQLiteDatabaseConnection().Query(
                    "DELETE FROM Funcao WHERE id = @id AND Codigo <> @codigoAtleta", 
                    new {   funcao.id,
                            codigoAtleta
                    });
                return true;
            }catch (Exception ex){
                messageError = ex.Message;
                return false;
            }
        }
    }
}