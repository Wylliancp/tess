using modelo.Tabelas;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace persistencia.Context
{
    public class EFContext : DbContext
    {

        public EFContext() : base("tess")
        {
           // Database.SetInitializer<EFContext>(new MigrateDatabaseToLatestVersion<EFContext, Configuration>());
            Database.SetInitializer<EFContext>(new DropCreateDatabaseIfModelChanges<EFContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Fabricante> Fabricantes { get; set; }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Compra> Compras { get; set; }
    }
}