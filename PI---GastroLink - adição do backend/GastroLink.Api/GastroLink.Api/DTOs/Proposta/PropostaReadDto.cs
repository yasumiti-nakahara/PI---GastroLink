using System.ComponentModel.DataAnnotations;

namespace GastroLink.Api.DTOs.Proposta
{
    public class PropostaReadDto
    {
        public int Id { get; set; }
        public string Seguidores { get; set; } = string.Empty;
        public string Contato { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}
