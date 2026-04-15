using APIOSProduto.DTOs;

namespace APIOSProduto.Services.Interface
{
    public interface IEstoqueService
    {
        Task<string> Movimentar(MovimentacaoDTO dto);
    }
}
