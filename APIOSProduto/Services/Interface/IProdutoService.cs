using APIOSProduto.DTOs;
using APIOSProduto.Entities;

namespace APIOSProduto.Services.Interface
{
    public interface IProdutoService
    {
        Task<List<Produto>> GetAll();
        Task<Produto> GetById(int id);
        Task<Produto> Create(ProdutoDTO dto);    
    }
}
