using APIOSProduto.DTOs;
using APIOSProduto.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIOSProduto.Controllers
{
    [Authorize]
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
