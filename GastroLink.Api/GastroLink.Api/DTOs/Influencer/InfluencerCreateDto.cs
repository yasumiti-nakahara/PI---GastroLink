using System.ComponentModel.DataAnnotations;

namespace GastroLink.Api.DTOs.Influencer
{
    public class InfluencerCreateDto
    {
        [Required]
        [StringLength(100)]
        public string Instagram { get; set; }
        [Required]
        [StringLength(100)]
        public string TipoConteudo { get; set; }
        [StringLength(500)]
        public string? FotoUrl { get; set; }
        [Required]
        [StringLength(20)]
        public string Contato { get; set; }

    }
}
