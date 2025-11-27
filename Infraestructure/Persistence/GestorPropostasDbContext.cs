using GestorProposta.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace GestorProposta.Infrastructure.Persistence
{
    public class GestorPropostasDbContext : DbContext
    {
        public GestorPropostasDbContext(DbContextOptions<GestorPropostasDbContext> options)
            : base(options)
        {
        }
        public DbSet<Proposta> Propostas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Proposta>(entity =>
            {
                entity.ToTable("Propostas");

                entity.HasKey(p => p.Id);

                entity.Property(p => p.ClienteNome)
                      .HasMaxLength(150)
                      .IsRequired();

                entity.Property(p => p.ClienteEmpresa)
                      .HasMaxLength(150);

                entity.Property(p => p.ClienteEmail)
                      .HasMaxLength(200);

                entity.Property(p => p.Valor)
                      .HasColumnType("numeric(18,2)");

                entity.Property(p => p.Prazo)
                      .IsRequired();

                entity.Property(p => p.Descricao)
                      .HasMaxLength(2000);

                entity.Property(p => p.Status)
                      .HasMaxLength(50);

                entity.Property(p => p.DataCriacao)
                      .IsRequired();
            });
        }
    }
}
