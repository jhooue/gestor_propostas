using GestorProposta.Domain.Entities;
using GestorProposta.Domain.Ports;

namespace GestorProposta.Application.Services
{
    public class ObterPropostaService
    {
        private readonly IPropostaRepository _repo;

        public ObterPropostaService(IPropostaRepository repo)
        {
            _repo = repo;
        }

        public async Task<Proposta> ExecutarAsync(int id)
        {
            return await _repo.ObterPorIdAsync(id);
        }
    }
}
