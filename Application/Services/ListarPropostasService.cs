using GestorProposta.Domain.Entities;
using GestorProposta.Domain.Ports;

namespace GestorProposta.Application.Services
{
    public class ListarPropostasService
    {
        private readonly IPropostaRepository _repo;

        public ListarPropostasService(IPropostaRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<Proposta>> ExecutarAsync()
        {
            return await _repo.ListarTodasAsync();
        }
    }
}
