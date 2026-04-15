using APIOSProduto.Data;
using APIOSProduto.Entities;
using APIOSProduto.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APIOSProduto.Repositories
{
    public class MovimentacaoRepository : IMovimentacaoRepository
    {
        private readonly AppDbContext _context;


        public MovimentacaoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(Movimentacao mov)
        {
            await _context.Movimentacoes.AddAsync(mov);
            await _context.SaveChangesAsync();
        }


        public async Task<List<Movimentacao>> GetByProduto(int produtoId)
        {
            return await _context.Movimentacoes.Where(m => m.ProdutoId == produtoId).ToListAsync();
        }

    }
}
