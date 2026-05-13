using GastroLink.Api.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GastroLink.Api.DTOs.Proposta;
using System.Security.Claims;
using GastroLink.Api.Entities;

namespace GastroLink.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Influencer")]
     public class PropostasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PropostasController(AppDbContext context) => _context = context;

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var proposta = await _context.Propostas.FindAsync(id);
            if (proposta == null)
            {
                return NotFound();
            }
            return Ok(proposta);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PropostaCreateDto dto)
        {
            var usuarioId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var influencer = await _context.Influencers.FirstOrDefaultAsync(i => i.UsuarioId == usuarioId);

            if(influencer == null)
            {
                return BadRequest("Influencer não encontrado para o usuário autenticado.");
            }

            var proposta = new Proposta
            {
                Seguidores = dto.Seguidores,
                Contato = dto.Contato,
                Descricao = dto.Descricao,
                InfluencerId = influencer.Id,
                RestauranteId = dto.RestauranteId// ELE N ESTA ENCONTRA RSRS

            };
            _context.Propostas.Add(proposta);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = proposta.Id }, proposta);
        }

    }
}
