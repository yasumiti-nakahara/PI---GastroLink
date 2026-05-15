using System.ComponentModel.DataAnnotations;

namespace GastroLink.Api.DTOs.Auth
{
    public class LoginDto
    {
        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [StringLength(100)]
        [EmailAddress(ErrorMessage = "O campo Email deve ser um endereço de email válido.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        public string Senha { get; set; }
    }
}
