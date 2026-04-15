using APIOSProduto.Entities;

namespace APIOSProduto.Repositories.Interfaces
{
    public interface IMovimentacaoRepository
    {
        Task Add(Movimentacao mov);
        Task<List<Movimentacao>> GetByProduto(int produtoId);
    }
}
