using System;

namespace GestorProposta.Domain.Entities
{
    public class Proposta
    {
        public int Id { get; set; }
        public string ClienteNome { get; set; }
        public string ClienteEmpresa { get; set; }
        public string ClienteEmail { get; set; }
        public decimal Valor { get; set; }
        public DateTime Prazo { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; } // Aberta, Enviada, Aceita, Recusada
        public DateTime DataCriacao { get; set; }
    }
}