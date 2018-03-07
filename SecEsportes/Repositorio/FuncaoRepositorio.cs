using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecEsportes.Modelo;

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

        public Funcao getFuncao(int id)
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

        public List<Funcao> getFuncoes()
        {
            using (var connection = Infraestrutura.SQLiteDatabase.Instance.SQLiteDatabaseConnection())
            {
                connection.Open();

                List<Funcao> funcoes = connection.Query<Funcao>("SELECT * FROM Funcao").ToList();

                return funcoes;
            }
        }

    }
}