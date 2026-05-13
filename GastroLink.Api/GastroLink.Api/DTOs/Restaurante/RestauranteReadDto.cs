using System.ComponentModel.DataAnnotations;

namespace GastroLink.Api.DTOs.Restaurante
{
    public class RestauranteReadDto
    {
        public int Id { get; set; }
        public string NomeRestaurante { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public string FotoUrl { get; set; } = string.Empty;
    }
}
