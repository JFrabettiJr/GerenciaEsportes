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

        public Funcao get(int id)
        {
            using (var connection = Infraestrutura.SQLiteDatabase.Instance.SQLiteDatabaseConnection())
            {
                connection.Open();

                Funcao funcao = connection.Query<Funcao>(
                    "SELECT * FROM Funcao WHERE id = @id", new { id })
                    .FirstOrDefault();

                return funcao;
            }
        }
        public List<Funcao> get()
        {
            using (var connection = SQLiteDatabase.Instance.SQLiteDatabaseConnection())
            {
                connection.Open();

                List<Funcao> funcoes = connection.Query<Funcao>("SELECT * FROM Funcao").ToList();

                return funcoes;
            }
        }
        public bool insert(ref Funcao funcao){
            try{
                funcao.id = SQLiteDatabase.Instance.SQLiteDatabaseConnection().Query<int>("" +
                    "INSERT INTO Funcao (Codigo, Descricao) VALUES (@Codigo, @Descricao); select last_insert_rowid()",
                    funcao).First();
                return true;
            }catch (Exception ex){
                return false;
            }
        }
        public bool update(Funcao funcao){
            try{
                SQLiteDatabase.Instance.SQLiteDatabaseConnection().Query(
                    "UPDATE Funcao SET Codigo = @Codigo, Descricao = @Descricao WHERE id = @id", funcao);
                return true;
            }catch (Exception ex){
                return false;
            }
        }
        public bool delete(Funcao funcao){
            try{
                SQLiteDatabase.Instance.SQLiteDatabaseConnection().Query(
                    "DELETE FROM Funcao WHERE id = @id", funcao);
                return true;
            }catch (Exception ex){
                return false;
            }
        }
    }
}