namespace GastroLink.Api.DTOs.Parceria
{
    public class ParceriaReadDto
    {
        public int Id { get; set; }
        public DateTime DataParceria { get; set; } 
        public string NomeInfluencer { get; set; }
        public string NomeRestaurante { get; set; }
    }
}
