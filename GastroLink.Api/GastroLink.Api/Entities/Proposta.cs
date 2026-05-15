using System.ComponentModel.DataAnnotations;

namespace GastroLink.Api.Entities
{
    public class Proposta
    {
        public int Id { get; set; }
        [Required]
        public string Seguidores { get; set; }
        [Required]
        [StringLength(20)]
        public string Contato { get; set; }
        [Required]
        [StringLength(1000)]
        public string Descricao { get; set; }
        [Required]
        public string Status { get; set; } = "Pendente";
        public int InfluencerId { get; set; }
        public Influencer Influencer { get; set; }
        public int RestauranteId { get; set; }
        public Restaurante Restaurante { get; set; }

    }
}
