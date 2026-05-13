using System.ComponentModel.DataAnnotations;

namespace GastroLink.Api.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Nome { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 6,
        ErrorMessage = "A senha deve ter entre 6 e 100 caracteres.")]
        public string Senha { get; set; }
        [Required]
        public string Role { get; set; }

    }
}
