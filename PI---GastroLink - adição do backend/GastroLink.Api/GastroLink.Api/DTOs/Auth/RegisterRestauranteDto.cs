namespace GastroLink.Api.DTOs.Auth
{
    public class RegisterRestauranteDto
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public string NomeRestaurante { get; set; }
        public string Endereco { get; set; }
        public string Categoria { get; set; }
        public string FotoUrl { get; set; }
    }
}