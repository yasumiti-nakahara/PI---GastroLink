using System.ComponentModel.DataAnnotations;

namespace GastroLink.Api.DTOs.Auth
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(50, ErrorMessage = "O campo Nome deve ter no máximo 50 caracteres.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O campo Email deve ser um endereço de email válido.")]
        [StringLength(100, ErrorMessage = "O campo Email deve ter no máximo 100 caracteres.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        [StringLength(100, MinimumLength = 6,
        ErrorMessage = "A senha deve ter entre 6 e 100 caracteres.")]
        public string Senha { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
