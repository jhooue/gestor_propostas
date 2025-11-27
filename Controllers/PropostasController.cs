using GestorProposta.Application.DTOs;
using GestorProposta.Application.Services;
using GestorProposta.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GestorProposta.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropostasController : ControllerBase
    {
        private readonly CriarPropostaService _criarService;
        private readonly ListarPropostasService _listarService;
        private readonly ObterPropostaService _obterService;
        private readonly AtualizarStatusPropostaService _atualizarService;
        private readonly DeletarPropostaService _deletarService;

        public PropostasController(
            CriarPropostaService criarService,
            ListarPropostasService listarService,
            ObterPropostaService obterService,
            AtualizarStatusPropostaService atualizarService,
            DeletarPropostaService deletarService)
        {
            _criarService = criarService;
            _listarService = listarService;
            _obterService = obterService;
            _atualizarService = atualizarService;
            _deletarService = deletarService;
        }

        [HttpPost]
        public async Task<ActionResult<Proposta>> Criar([FromBody] PropostaCreateDto dto)
        {
            var proposta = await _criarService.ExecutarAsync(dto);
            return CreatedAtAction(nameof(Obter), new { id = proposta.Id }, proposta);
        }

        [HttpGet]
        public async Task<ActionResult<List<Proposta>>> Listar()
        {
            var propostas = await _listarService.ExecutarAsync();
            return Ok(propostas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Proposta>> Obter(int id)
        {
            var proposta = await _obterService.ExecutarAsync(id);
            if (proposta == null) return NotFound();
            return Ok(proposta);
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> AtualizarStatus(int id, [FromBody] PropostaUpdateStatusDto dto)
        {
            await _atualizarService.ExecutarAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            await _deletarService.ExecutarAsync(id);
            return NoContent();
        }
    }
}
