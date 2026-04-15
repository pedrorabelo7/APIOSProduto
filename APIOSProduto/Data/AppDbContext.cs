using APIOSProduto.Entities;
using Microsoft.EntityFrameworkCore;

namespace APIOSProduto.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet <Produto> Produtos { get; set; }
        public  DbSet <Movimentacao> Movimentacoes { get; set; }
        public  AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }
    }
}
