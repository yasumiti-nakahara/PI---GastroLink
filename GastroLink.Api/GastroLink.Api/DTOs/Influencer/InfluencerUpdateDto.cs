using System.ComponentModel.DataAnnotations;

namespace GastroLink.Api.DTOs.Influencer
{
    public class InfluencerUpdateDto
    {
        [StringLength(100)]
        public string? Instagram { get; set; }
        [StringLength(100)]
        public string? TipoConteudo { get; set; }
        [StringLength(500)]
        public string? FotoUrl { get; set; }
        [StringLength(20)]
        public string? Contato { get; set; }

    }
}
