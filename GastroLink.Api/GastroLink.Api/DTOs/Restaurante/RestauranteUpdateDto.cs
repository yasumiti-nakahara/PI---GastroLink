using System.ComponentModel.DataAnnotations;

namespace GastroLink.Api.DTOs.Restaurante
{
    public class RestauranteUpdateDto
    {
        [StringLength(100)]
        public string? NomeRestaurante { get; set; } 
        [StringLength(200)]
        public string? Endereco { get; set; } 
        [StringLength(50)]
        public string? Categoria { get; set; } 
        [StringLength(500)]
        public string? FotoUrl { get; set; } 
    }
}
