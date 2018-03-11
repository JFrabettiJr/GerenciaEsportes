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
    public class PessoaRepositorio{
        #region Implementação Singleton
        private static PessoaRepositorio instance = null;
        public static PessoaRepositorio Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PessoaRepositorio();
                }
                return instance;
            }
        }
        #endregion

        private PessoaRepositorio(){

        }

        public Pessoa get(int id, ref string messageError) {
            try {
                using (var connection = SQLiteDatabase.Instance.SQLiteDatabaseConnection()) {
                    connection.Open();

                    Pessoa pessoa = connection.Query<Pessoa>(
                        "SELECT * FROM pessoa WHERE id = @id", new { id })
                        .FirstOrDefault();

                    pessoa.funcoes = FuncaoRepositorio.Instance.getFuncaoByPessoa(pessoa.id);

                    return pessoa;
                }
            }
            catch(Exception ex) {
                messageError = ex.Message;
                return null;
            }
        }
        public List<Pessoa> get(ref string messageError)
        {
            try {
                using (var connection = SQLiteDatabase.Instance.SQLiteDatabaseConnection()) {
                    connection.Open();

                    List<Pessoa> pessoas = connection.Query<Pessoa>("SELECT * FROM pessoa").ToList();
                    foreach (Pessoa pessoa in pessoas) {
                        pessoa.funcoes = FuncaoRepositorio.Instance.getFuncaoByPessoa(pessoa.id);
                    }

                    return pessoas;
                }
            }
            catch(Exception ex) {
                messageError = ex.Message;
                return null;
            }
        }
        public bool insert(ref Pessoa pessoa, ref string messageError) {
            try{
                SQLiteConnection connection = SQLiteDatabase.Instance.SQLiteDatabaseConnection();
                pessoa.id = connection.Query<int>("" +
                    "INSERT INTO pessoa (CPF, Nome, DataNascimento) VALUES (@CPF, @Nome, @DataNascimento); select last_insert_rowid()",
                    pessoa).First();

                // Insere as funções
                for (int iCount = 0; iCount < pessoa.funcoes.Count; iCount++) {
                    pessoa.funcoes[iCount].id = connection.Query<int>("SELECT id FROM Funcao WHERE codigo = '" + pessoa.funcoes[iCount].codigo + "'").First();
                    connection.Query("INSERT INTO PessoaFuncoes (idPessoa, idFuncao) VALUES (" + pessoa.id + ", " + pessoa.funcoes[iCount].id + ") ");
                }

                return true;
            }catch (Exception ex){
                messageError = ex.Message;
                return false;
            }
        }
        public bool update(Pessoa pessoa, ref string messageError) {
            try{
                SQLiteConnection connection = SQLiteDatabase.Instance.SQLiteDatabaseConnection();
                connection.Query(
                    "UPDATE pessoa SET CPF = @CPF, Nome = @Nome, DataNascimento = @DataNascimento WHERE id = @id", pessoa);

                // Atualiza as funções
                string funcoesStr = "";
                for (int iCount = 0; iCount < pessoa.funcoes.Count; iCount++) {
                    pessoa.funcoes[iCount].id = connection.Query<int>("SELECT id FROM Funcao WHERE codigo = '" + pessoa.funcoes[iCount].codigo + "'").First();
                    funcoesStr += pessoa.funcoes[iCount].id.ToString() + ", ";
                    if (connection.Query("SELECT 1 FROM PessoaFuncoes WHERE idPessoa = " + pessoa.id + " AND idFuncao = " + pessoa.funcoes[iCount].id + " ").Count() == 0) {
                        connection.Query("INSERT INTO PessoaFuncoes (idPessoa, idFuncao) VALUES (" + pessoa.id + ", " + pessoa.funcoes[iCount].id + ") ");
                    }
                }

                // Deleta as funções que não são mais utilizadas
                if (funcoesStr.Length > 0) {
                    funcoesStr = funcoesStr.Substring(0, funcoesStr.Length - 2);
                    connection.Query("DELETE FROM PessoaFuncoes WHERE idPessoa = " + pessoa.id + " AND idFuncao NOT IN (" + funcoesStr + ") ");
                }

                return true;
            }catch (Exception ex){
                messageError = ex.Message;
                return false;
            }
        }
        public bool delete(Pessoa pessoa, ref string messageError) {
            try{
                SQLiteConnection connection = SQLiteDatabase.Instance.SQLiteDatabaseConnection();
                connection.Query(
                    "DELETE FROM pessoa WHERE id = @id", pessoa);

                connection.Query(
                    "DELETE FROM PessoaFuncoes WHERE idPessoa = @id", pessoa);

                return true;
            }catch (Exception ex){
                messageError = ex.Message;
                return false;
            }
        }
    }
}