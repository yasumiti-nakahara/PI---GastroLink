using GastroLink.Api.Data;
using GastroLink.Api.DTOs.Auth;
using GastroLink.Api.Entities;
using GastroLink.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace GastroLink.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly TokenService TokenService;

        public AuthController(AppDbContext Context, TokenService tokenService)
        {
            _context = Context;
            TokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var usuarioExiste = await _context.Usuarios.AnyAsync(u => u.Email == registerDto.Email);

            if (usuarioExiste)
            {
                return BadRequest("Email já registrado.");
            }
            var usuario = new Usuario
            {
                Nome = registerDto.Nome,
                Email = registerDto.Email,
                Senha = registerDto.Senha,
                Role = registerDto.Role
            };
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                Message = "Usuário registrado com sucesso."
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == loginDto.Email && u.Senha == loginDto.Senha);
           
            if (usuario == null)
            {
                return Unauthorized("Credenciais inválidas.");
            }
            var token = TokenService.GerarToken(usuario);
            return Ok(new
            {
                Token = token,
                Message = "Login bem-sucedido."
            });
        }
    }        
}
