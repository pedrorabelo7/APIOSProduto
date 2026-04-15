using APIOSProduto.Data;
using APIOSProduto.Entities;
using APIOSProduto.Repositories.Interfaces;

namespace APIOSProduto.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _context;
        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Produto> GetById(int id)
        {
            return await _context.Produtos.FindAsync(id);
        }

        public async Task Update(Produto produto)
        {
            _context.Produtos.Update(produto);
            await _context.SaveChangesAsync();
        }
    }
}
