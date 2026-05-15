using System.ComponentModel.DataAnnotations;

namespace GastroLink.Api.Entities
{
    public class Influencer
    {
        public int Id { get; set; }
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
        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }
    }
}
