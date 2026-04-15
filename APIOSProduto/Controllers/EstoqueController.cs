using APIOSProduto.DTOs;
using APIOSProduto.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APIOSProduto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstoqueController : ControllerBase
    {
        private readonly IEstoqueService _service;

        public EstoqueController(IEstoqueService service)
        {
            _service = service;
        }

        [HttpPost("movimentar")]
        public async Task<IActionResult> Movimentar([FromBody] MovimentacaoDTO dto)
        {
            var result = await _service.Movimentar(dto);

            if(result.Contains("não") || result.Contains("insuficiente"))
                    return BadRequest(result);

            return Ok(result);
        
        }
    }
}
