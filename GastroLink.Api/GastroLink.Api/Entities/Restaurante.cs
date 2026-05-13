using System.ComponentModel.DataAnnotations;

namespace GastroLink.Api.Entities
{
    public class Restaurante
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string NomeRestaurante { get; set; }
        [Required]
        [StringLength(200)]
        public string Endereco { get; set; }
        [Required]
        public string Categoria { get; set; }
        [StringLength(500)]
        public string FotoUrl { get; set; }

        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }
    }
}
