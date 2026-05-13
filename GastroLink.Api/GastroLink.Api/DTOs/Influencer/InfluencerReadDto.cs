namespace GastroLink.Api.DTOs.Influencer
{
    public class InfluencerReadDto
    {
        public int Id { get; set; }
        public string Instagram { get; set; } = string.Empty;
        public string TipoConteudo { get; set; } = string.Empty;
        public string? FotoUrl { get; set; } 
        public string Contato { get; set; } = string.Empty;
    }
}
