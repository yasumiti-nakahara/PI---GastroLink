using System.ComponentModel.DataAnnotations;

namespace GastroLink.Api.Entities
{
    public class Parceria
    {
        public int Id { get; set; }
        public DateTime DataParceria { get; set; } = DateTime.Now;
        public int InfluencerId { get; set; }
        public Influencer Influencer { get; set; }
        public int RestauranteId { get; set; } 
        public Restaurante Restaurante { get; set; }

    }
}
