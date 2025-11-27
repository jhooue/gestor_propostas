using GestorProposta.Application.DTOs;
using GestorProposta.Domain.Ports;

namespace GestorProposta.Application.Services
{
    public class AtualizarStatusPropostaService
    {
        private readonly IPropostaRepository _repo;

        public AtualizarStatusPropostaService(IPropostaRepository repo)
        {
            _repo = repo;
        }

        public async Task ExecutarAsync(int id, PropostaUpdateStatusDto dto)
        {
            var proposta = await _repo.ObterPorIdAsync(id);
            if (proposta != null)
            {
                proposta.Status = dto.Status;
                await _repo.AtualizarAsync(proposta);
            }
        }
    }
}
