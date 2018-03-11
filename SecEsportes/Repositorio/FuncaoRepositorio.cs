using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecEsportes.Modelo;
using SecEsportes.Infraestrutura;

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

        private FuncaoRepositorio(){

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
                        "   SELECT IDFuncao FROM PessoaFuncoes WHERE IDPessoa = " + idPessoa + " " +
                        ") ").ToList();

                    return funcoes;
                }
            }
            catch (Exception ex) {
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
                    "UPDATE Funcao SET Codigo = @Codigo, Descricao = @Descricao WHERE id = @id", funcao);
                return true;
            }catch (Exception ex){
                messageError = ex.Message;
                return false;
            }
        }
        public bool delete(Funcao funcao, ref string messageError) {
            try{
                SQLiteDatabase.Instance.SQLiteDatabaseConnection().Query(
                    "DELETE FROM Funcao WHERE id = @id", funcao);
                return true;
            }catch (Exception ex){
                messageError = ex.Message;
                return false;
            }
        }
    }
}