using Equipamentos.Models;
using System.Data.Entity;

namespace Equipamentos.Contexts
{
    public class EFContext : DbContext
    {
        public EFContext() : base("Projeto") {
            Database.SetInitializer<EFContext>
                (new DropCreateDatabaseIfModelChanges<EFContext>());
        }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Fabricante> Fabricantes { get; set; }

        public DbSet<Produto> Produtos { get; set; }

    }
}