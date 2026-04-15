using APIOSProduto.DTOs;
using APIOSProduto.Entities;
using APIOSProduto.Repositories.Interfaces;
using APIOSProduto.Services.Interface;

namespace APIOSProduto.Services
{
    public class EstoqueService : IEstoqueService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMovimentacaoRepository _movimentacaoRepository;


        public EstoqueService (IProdutoRepository produtoRepository, IMovimentacaoRepository movimentacaoRepository)
        {
            _produtoRepository = produtoRepository;
            _movimentacaoRepository = movimentacaoRepository;
        }

        public async Task<string> Movimentar(MovimentacaoDTO dto)
        {
            var produto = await _produtoRepository.GetById(dto.ProdutoId);

            if (produto == null)
                return "Produto não encontrado";

            if ((dto.Tipo == "Saída" || dto.Tipo == "saída" && produto.QuantidadeEstoque < dto.Quantidade))
                return "Estoque insuficiente";

            if (dto.Tipo == "Entrada" || dto.Tipo == "entrada")
                produto.QuantidadeEstoque += dto.Quantidade;
            else
                produto.QuantidadeEstoque -= dto.Quantidade;

            await _produtoRepository.Update(produto);

            var mov = new Movimentacao
            {
                ProdutoId = dto.ProdutoId,
                Tipo = dto.Tipo,
                Quantidade = dto.Quantidade,
            };

            await _movimentacaoRepository.Add(mov);

            return "Movimentação realizada com sucesso!";
        }
       
    }
}
