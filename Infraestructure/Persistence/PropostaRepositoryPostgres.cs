using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestorProposta.Domain.Entities;
using GestorProposta.Domain.Ports;
using Microsoft.EntityFrameworkCore;

namespace GestorProposta.Infrastructure.Persistence
{
    public class PropostaRepositoryPostgres : IPropostaRepository
    {
        private readonly GestorPropostasDbContext _context;

        public PropostaRepositoryPostgres(GestorPropostasDbContext context)
        {
            _context = context;
        }

        public async Task<Proposta> CriarAsync(Proposta proposta)
        {
            if (string.IsNullOrEmpty(proposta.Status))
                proposta.Status = "Aberta";
            if (proposta.DataCriacao == default)
                proposta.DataCriacao = System.DateTime.UtcNow;

            _context.Propostas.Add(proposta);
            await _context.SaveChangesAsync();
            return proposta;
        }

        public async Task<Proposta> ObterPorIdAsync(int id)
        {
            return await _context.Propostas.FindAsync(id);
        }

        public async Task<List<Proposta>> ListarTodasAsync()
        {
            return await _context.Propostas
                .OrderByDescending(p => p.DataCriacao)
                .ToListAsync();
        }

        public async Task AtualizarAsync(Proposta proposta)
        {
            _context.Propostas.Update(proposta);
            await _context.SaveChangesAsync();
        }

        public async Task DeletarAsync(int id)
        {
            var proposta = await _context.Propostas.FindAsync(id);
            if (proposta != null)
            {
                _context.Propostas.Remove(proposta);
                await _context.SaveChangesAsync();
            }
        }
    }
}
