using Microsoft.EntityFrameworkCore;
using PRODUTOSTORE.Models;

namespace PRODUTOSTORE.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Produto> tblProduto { get; set; }
        public DbSet<CategoriaProduto> tblCategoriaProduto { get; set; }
    }
}
