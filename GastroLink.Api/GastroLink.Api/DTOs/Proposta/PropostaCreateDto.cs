using System.ComponentModel.DataAnnotations;

namespace GastroLink.Api.DTOs.Proposta
{
    public class PropostaCreateDto
    {
        [Required]
        [StringLength(100)]
        public string Seguidores { get; set; }
        [Required]
        [StringLength(20)]
        public string Contato { get; set; }
        [Required]
        [StringLength(1000)]
        public string Descricao { get; set; }
        [Required]
        public int RestauranteId { get; set; }
    }
}
