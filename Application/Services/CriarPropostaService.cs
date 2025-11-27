using GestorProposta.Application.DTOs;
using GestorProposta.Domain.Entities;
using GestorProposta.Domain.Ports;

namespace GestorProposta.Application.Services
{
    public class CriarPropostaService
    {
        private readonly IPropostaRepository _repo;

        public CriarPropostaService(IPropostaRepository repo)
        {
            _repo = repo;
        }

        public async Task<Proposta> ExecutarAsync(PropostaCreateDto dto)
        {
            var proposta = new Proposta
            {
                ClienteNome = dto.ClienteNome,
                ClienteEmpresa = dto.ClienteEmpresa,
                ClienteEmail = dto.ClienteEmail,
                Valor = dto.Valor,
                Prazo = dto.Prazo,
                Descricao = dto.Descricao
            };

            return await _repo.CriarAsync(proposta);
        }
    }
}
