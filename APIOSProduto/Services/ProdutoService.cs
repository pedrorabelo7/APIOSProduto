using APIOSProduto.Data;
using APIOSProduto.DTOs;
using APIOSProduto.Entities;
using APIOSProduto.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace APIOSProduto.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly AppDbContext _context;

        public ProdutoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Produto> Create(ProdutoDTO dto)
        {
            var produto = new Produto
            {
                Nome = dto.Nome,
                Preco = dto.Preco,
                QuantidadeEstoque = 0
            };

            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();

            return produto;
        }

        public async Task<bool> Delete(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);

            if (produto == null)
                return false;

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<Produto>> GetAll()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task<Produto> GetById(int id)
        {
            return await _context.Produtos.FindAsync(id);
        }

        public async Task<Produto> Update(int id, ProdutoDTO dto)
        {
            var produto = await _context.Produtos.FindAsync(id);

            if (produto == null)
                return null;

            produto.Nome = dto.Nome;
            produto.Preco = dto.Preco;

            await _context.SaveChangesAsync();

            return produto;
        }
    }
}
