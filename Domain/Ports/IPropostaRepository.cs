using System.Collections.Generic;
using System.Threading.Tasks;
using GestorProposta.Domain.Entities;

namespace GestorProposta.Domain.Ports
{
    public interface IPropostaRepository
    {
        Task<Proposta> CriarAsync(Proposta proposta);
        Task<Proposta> ObterPorIdAsync(int id);
        Task<List<Proposta>> ListarTodasAsync();
        Task AtualizarAsync(Proposta proposta);
        Task DeletarAsync(int id);
    }
}
