using APIOSProduto.Entities;

namespace APIOSProduto.Repositories.Interfaces
{
    public interface IProdutoRepository
    {
        Task<Produto> GetById(int id);
        Task Update(Produto produto);

    }
}
