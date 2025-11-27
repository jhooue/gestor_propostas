namespace GestorProposta.Application.DTOs
{
    public class PropostaCreateDto
    {
        public string ClienteNome { get; set; }
        public string ClienteEmpresa { get; set; }
        public string ClienteEmail { get; set; }
        public decimal Valor { get; set; }
        public DateTime Prazo { get; set; }
        public string Descricao { get; set; }
    }
}
