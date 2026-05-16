using GastroLink.Api.Data;
using GastroLink.Api.DTOs.Auth;
using GastroLink.Api.Entities;
using GastroLink.Api.Services;
using GastroLink.Api.DTOs.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GastroLink.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly TokenService _tokenService;

        public AuthController(AppDbContext context, TokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            
        }

        [HttpPost("register-restaurante")]
        public async Task<IActionResult> RegisterRestaurante(RegisterRestauranteDto dto)
        {
            var usuarioExiste = await _context.Usuarios.AnyAsync(u => u.Email == dto.Email);
            if (usuarioExiste)
            {
                return BadRequest("Email já registrado.");
            }

            var usuario = new Usuario
            {
                Nome = dto.Nome,
                Email = dto.Email,
                Senha = dto.Senha,
                Role = "Restaurante"
            };
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            var restaurante = new Restaurante
            {
                NomeRestaurante = dto.NomeRestaurante,
                Endereco = dto.Endereco,
                Categoria = dto.Categoria,
                FotoUrl = dto.FotoUrl,
                UsuarioId = usuario.Id
            };
            _context.Restaurantes.Add(restaurante);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Restaurante e Usuário cadastrados com sucesso!" });
        }

    }
}