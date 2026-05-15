using GastroLink.Api.Data;
using GastroLink.Api.DTOs.Influencer;
using GastroLink.Api.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace GastroLink.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Influencer")]
    public class InfluencersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public InfluencersController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var influencers = await _context.Influencers
                .Select(i => new InfluencerReadDto
                {
                    Id = i.Id,
                    Instagram = i.Instagram,
                    TipoConteudo = i.TipoConteudo,
                    FotoUrl = i.FotoUrl,
                    Contato = i.Contato
                })
                .ToListAsync();
            return Ok(influencers);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var influencer = await _context.Influencers.Where(i => i.Id == id)
                .Select(i => new InfluencerReadDto
                {
                    Id = i.Id,
                    Instagram = i.Instagram,
                    TipoConteudo = i.TipoConteudo,
                    FotoUrl = i.FotoUrl,
                    Contato = i.Contato
                })
                .FirstOrDefaultAsync();
            if (influencer == null) return NotFound();

            return Ok(influencer);
        }

        [HttpPost]
        public async Task<IActionResult> Create(InfluencerCreateDto dto)
        {
            var usuarioId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value );
            
            var influencer = new Influencer
            {
                Instagram = dto.Instagram,
                TipoConteudo = dto.TipoConteudo,
                FotoUrl = dto.FotoUrl,
                Contato = dto.Contato,
                UsuarioId = usuarioId
            };
        
             _context.Influencers.Add(influencer);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = influencer.Id }, influencer);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, InfluencerUpdateDto dto)
        {
            var influencer = await _context.Influencers.FindAsync(id);
            if (influencer == null) return NotFound();

            influencer.Instagram = dto.Instagram ?? influencer.Instagram;
            influencer.TipoConteudo = dto.TipoConteudo ?? influencer.TipoConteudo;
            influencer.FotoUrl = dto.FotoUrl ?? influencer.FotoUrl;
            influencer.Contato = dto.Contato ?? influencer.Contato;

            await _context.SaveChangesAsync();

            return Ok(influencer);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var influencer = await _context.Influencers.FindAsync(id);
            if (influencer == null) return NotFound();

            _context.Influencers.Remove(influencer);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
