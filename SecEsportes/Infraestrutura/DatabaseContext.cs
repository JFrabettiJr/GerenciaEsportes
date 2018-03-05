using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SQLite;

namespace SecEsportes.Infraestrutura
{
    class DatabaseContext : DbContext
    {

        public DatabaseContext() :
            base(new SQLiteConnection()
            {
                ConnectionString = new SQLiteConnectionStringBuilder()
                {
                    DataSource = SQLiteDatabase.Instance.createSQLiteDatabase(),
                    ForeignKeys = true
                }.ConnectionString
            }, true){

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder){
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Modelo.Atleta> Atleta { get; set; }
    }
}