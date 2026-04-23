using APIOSProduto.DTOs;
using APIOSProduto.Entities;
using APIOSProduto.Models;
using APIOSProduto.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIOSProduto.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {

        private readonly IProdutoService _service;
        
        public ProdutoController(IProdutoService service)
        {
            _service = service;
        }

        // GET: api/produtos
        [HttpGet]

        public async Task<IActionResult> Get()
        {
            var produto = await _service.GetAll();
            return Ok(new ApiResponse<List<Produto>>
            {
                Sucesso = true,
                Mensagem = "Lista de produtos",
                Dados = produto

            });
        }

        // GET: api/produtos/1
        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var produto = await _service.GetById(id);

            if (produto == null)
                return NotFound(new ApiResponse<string>
                {
                    Sucesso = false,
                    Mensagem = "Produto não encontrado",
                    Dados = null
                });

            return Ok(new ApiResponse<Produto>
            {
                Sucesso = true,
                Mensagem = "Produto listado",
                Dados = produto

            });
        }

        // Post: api/produtos
        [HttpPost]

        public async Task<IActionResult> Post([FromBody] ProdutoDTO dto)
        {
            var produto = await _service.Create(dto);
            return Ok(new ApiResponse<Produto>
            {
                Sucesso = true,
                Mensagem = "Produto criado com sucesso!",
                Dados = produto

            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProdutoDTO dto)
        {
            var produto = await _service.Update(id, dto);

            if (produto == null)
                return NotFound(new ApiResponse<string>
                {
                    Sucesso = false,
                    Mensagem = "Produto não encontrado",
                    Dados = null
                });

            return Ok(new ApiResponse<Produto>
            {
                Sucesso = true,
                Mensagem = "Produto editado com sucesso",
                Dados = produto

            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var removido = await _service.Delete(id);

            if(!removido)
                return NotFound(new ApiResponse<string>
                {
                    Sucesso = false,
                    Mensagem = "Produto não encontrado",
                    Dados = null
                });

            return NoContent();
        } 
    }
}
