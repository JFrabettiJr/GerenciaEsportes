using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecEsportes.Modelo;
using SecEsportes.Infraestrutura;
using System.Data.SQLite;

namespace SecEsportes.Repositorio {
    public class UsuarioRepositorio {

        public Usuario usuarioMaster;

        #region Implementação Singleton
        private static UsuarioRepositorio instance = null;
        public static UsuarioRepositorio Instance {
            get {
                if (instance == null) {
                    instance = new UsuarioRepositorio();
                }
                return instance;
            }
        }
        #endregion

        private UsuarioRepositorio() {
            usuarioMaster = new Usuario("master", "", "Usuário master");
            usuarioMaster.senha = "master";
        }

        public void CreateTable(SQLiteConnection connection) {
            //Criação da tabela Usuario

            
            if (connection.GetSchema("Tables", new[] { null, null, "Usuario", null }).Rows.Count == 0) {
                SQLiteCommand command = connection.CreateCommand();

                command.CommandText = "CREATE Table Usuario (" +
                    "id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "username NVARCHAR(30) NOT NULL UNIQUE, " +
                    "nome NVARCHAR(100) NOT NULL, " +
                    "email VARCHAR(100), " +
                    "senha NVARCHAR(20) NOT NULL, " +
                    "ultimoLogin DATETIME NULL " +
                    ") ";
                command.ExecuteNonQuery();

                insert(ref usuarioMaster);

            }
        }
        public Usuario get(int id) {
            string auxString = "";
            return get(id, ref auxString);
        }
        public Usuario get(int id, ref string messageError) {
            try {
                using (var connection = SQLiteDatabase.Instance.SQLiteDatabaseConnection()) {
                    connection.Open();

                    Usuario usuario = connection.Query<Usuario>(
                        "SELECT * FROM Usuario WHERE id = @id", new { id })
                        .FirstOrDefault();

                    return usuario;
                }
            } catch (Exception ex) {
                messageError = ex.Message;
                return null;
            }
        }
        public List<Usuario> get() {
            string myString = "";
            return get(ref myString);
        }
        public List<Usuario> get(ref string messageError) {
            try {
                using (var connection = SQLiteDatabase.Instance.SQLiteDatabaseConnection()) {
                    connection.Open();

                    List<Usuario> usuario = connection.Query<Usuario>("SELECT * FROM Usuario").ToList();

                    return usuario;
                }
            } catch (Exception ex) {
                messageError = ex.Message;
                return null;
            }
        }
        public bool insert(ref Usuario usuario) {
            string myString = "";
            return insert(ref usuario, ref myString);
        }
        public bool insert(ref Usuario usuario, ref string messageError) {
            try {
                SQLiteConnection connection = SQLiteDatabase.Instance.SQLiteDatabaseConnection();
                usuario.id = connection.Query<int>("" +
                    "INSERT INTO Usuario (username, nome, email, senha) " +
                    "VALUES (@username, @nome, @email, @senha); " +
                    "select last_insert_rowid()",
                    usuario).First();

                return true;
            } catch (Exception ex) {
                messageError = ex.Message;
                return false;
            }
        }
        public bool update(Usuario usuario) {
            string myString = "";
            return update(usuario, ref myString);
        }
        public bool update(Usuario usuario, ref string messageError) {
            try {
                SQLiteConnection connection = SQLiteDatabase.Instance.SQLiteDatabaseConnection();
                connection.Query(
                    "UPDATE usuario SET username = @username, nome = @nome, email = @email, senha = @senha, ultimoLogin = @ultimoLogin WHERE id = @id", usuario);

                return true;
            } catch (Exception ex) {
                messageError = ex.Message;
                return false;
            }
        }
        public bool delete(Usuario usuario, ref string messageError) {
            try {
                SQLiteConnection connection = SQLiteDatabase.Instance.SQLiteDatabaseConnection();
                connection.Query(
                    "DELETE FROM Usuario WHERE id = @id", usuario);

                return true;
            } catch (Exception ex) {
                messageError = ex.Message;
                return false;
            }
        }

        public Usuario login(string username, string senha) {
            Usuario usuario;

            try {
                using (var connection = SQLiteDatabase.Instance.SQLiteDatabaseConnection()) {
                    connection.Open();

                    usuario = connection.Query<Usuario>("SELECT * " +
                                                        "FROM Usuario " +
                                                        "WHERE  username = @username ", 
                                                        new {username}).First();

                    if (usuario.senha.Equals(senha)) {
                        usuario.ultimoLogin = DateTime.Now;
                        update(usuario);
                        return usuario;
                    } else {
                        return null;
                    }
                }
            } catch (Exception ex) {
                return null;
            }

        }

    }
}