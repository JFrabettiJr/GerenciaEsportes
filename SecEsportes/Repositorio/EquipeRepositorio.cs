using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using SecEsportes.Modelo;
using SecEsportes.Infraestrutura;

namespace SecEsportes.Repositorio
{
    public class EquipeRepositorio {
        #region Implementação Singleton
        private static EquipeRepositorio instance = null;
        public static EquipeRepositorio Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EquipeRepositorio();
                }
                return instance;
            }
        }
        #endregion

        private EquipeRepositorio(){

        }

        public Equipe get(int id, ref string messageError)
        {
            try {
                using (var connection = SQLiteDatabase.Instance.SQLiteDatabaseConnection()) {
                    connection.Open();

                    Equipe equipe = connection.Query<Equipe>(
                        "SELECT * FROM Equipe WHERE id = @id", new { id })
                        .FirstOrDefault();

                    return equipe;
                }
            }
            catch(Exception ex) {
                messageError = ex.Message;
                return null;
            }
        }
        public List<Equipe> get(ref string messageError)
        {
            try {
                using (var connection = SQLiteDatabase.Instance.SQLiteDatabaseConnection()) {
                    connection.Open();

                    List<Equipe> equipes = connection.Query<Equipe>("SELECT * FROM Equipe").ToList();

                    return equipes;
                }
            }catch (Exception ex) {
                messageError = ex.Message;
                return null;
            }
        }
        public bool insert(ref Equipe equipe, ref string messageError) {
            try{
                equipe.id = SQLiteDatabase.Instance.SQLiteDatabaseConnection().Query<int>("" +
                    "INSERT INTO Equipe (Codigo, Nome) VALUES (@Codigo, @Nome); select last_insert_rowid()",
                    equipe).First();
                return true;
            }catch (Exception ex){
                messageError = ex.Message;
                return false;
            }
        }
        public bool update(Equipe equipe, ref string messageError) {
            try{
                SQLiteDatabase.Instance.SQLiteDatabaseConnection().Query(
                    "UPDATE Equipe SET Codigo = @Codigo, Nome = @Nome WHERE id = @id", equipe);
                return true;
            }catch (Exception ex){
                messageError = ex.Message;
                return false;
            }
        }
        public bool delete(Equipe equipe, ref string messageError) {
            try{
                SQLiteDatabase.Instance.SQLiteDatabaseConnection().Query(
                    "DELETE FROM Equipe WHERE id = @id", equipe);
                return true;
            }catch (Exception ex){
                messageError = ex.Message;
                return false;
            }
        }
    }
}