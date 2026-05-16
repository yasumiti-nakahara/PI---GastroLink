using GastroLink.Api.Data;
using GastroLink.Api.DTOs.Restaurante;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace GastroLink.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Restaurante", "Influencer")]
    public class RestaurantesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RestaurantesController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var restaurantes = await _context.Restaurantes
                .Select(r => new RestauranteReadDto
                {
                    Id = r.Id,
                    NomeRestaurante = r.NomeRestaurante,
                    Endereco = r.Endereco,
                    Categoria = r.Categoria,
                    FotoUrl = r.FotoUrl
                })
                .ToListAsync();

            return Ok(restaurantes);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var restaurante = await _context.Restaurantes
                .Where(r => r.Id == id)
                .Select(r => new RestauranteReadDto
                {
                    Id = r.Id,
                    NomeRestaurante = r.NomeRestaurante,
                    Endereco = r.Endereco,
                    Categoria = r.Categoria,
                    FotoUrl = r.FotoUrl,
                })
                .FirstOrDefaultAsync();

            if (restaurante == null)
                return NotFound();

            return Ok(restaurante);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RestauranteCreateDto dto)
        {
            var usuarioId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var restaurante = new Entities.Restaurante
            {
                NomeRestaurante = dto.NomeRestaurante,
                Endereco = dto.Endereco,
                Categoria = dto.Categoria,
                FotoUrl = dto.FotoUrl,
                UsuarioId= usuarioId
            };
            _context.Restaurantes.Add(restaurante);
            await _context.SaveChangesAsync();
            var readDto = new RestauranteReadDto
            {
                Id = restaurante.Id,
                NomeRestaurante = restaurante.NomeRestaurante,
                Endereco = restaurante.Endereco,
                Categoria = restaurante.Categoria,
                FotoUrl = restaurante.FotoUrl
            };
            return CreatedAtAction(nameof(GetById), new { id = readDto.Id }, readDto);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, RestauranteUpdateDto dto)
        {
            var restaurante = await _context.Restaurantes.FindAsync(id);
            if (restaurante == null)
                return NotFound();
            restaurante.NomeRestaurante = dto.NomeRestaurante ?? restaurante.NomeRestaurante;
            restaurante.Endereco = dto.Endereco ?? restaurante.Endereco;
            restaurante.Categoria = dto.Categoria ?? restaurante.Categoria;
            restaurante.FotoUrl = dto.FotoUrl ?? restaurante.FotoUrl;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var restaurante = await _context.Restaurantes.FindAsync(id);
            if (restaurante == null)
                return NotFound();
            _context.Restaurantes.Remove(restaurante);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}