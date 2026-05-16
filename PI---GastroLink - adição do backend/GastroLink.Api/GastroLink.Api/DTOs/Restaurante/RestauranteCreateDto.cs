using System.ComponentModel.DataAnnotations;

namespace GastroLink.Api.DTOs.Restaurante
{
    public class RestauranteCreateDto
    {
        [Required]
        [StringLength(100)] 
        public string NomeRestaurante { get; set; } = string.Empty;
        [Required]
        [StringLength(200)]
        public string Endereco { get; set; } = string.Empty;
        [Required]
        [StringLength(50)]
        public string Categoria { get; set; } = string.Empty;
        [Required]
        [StringLength(500)]
        public string FotoUrl { get; set; } = string.Empty;
    }
}
