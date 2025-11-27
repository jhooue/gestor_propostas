using GestorProposta.Domain.Ports;

namespace GestorProposta.Application.Services
{
    public class DeletarPropostaService
    {
        private readonly IPropostaRepository _repo;

        public DeletarPropostaService(IPropostaRepository repo)
        {
            _repo = repo;
        }

        public async Task ExecutarAsync(int id)
        {
            await _repo.DeletarAsync(id);
        }
    }
}
