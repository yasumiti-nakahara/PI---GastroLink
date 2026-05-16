using GastroLink.Api.Data;
using GastroLink.Api.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GastroLink.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Restaurante")]
    public class ParceriasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ParceriasController(AppDbContext context)
        {
            _context = context;
        }

        // ACEITAR PROPOSTA
        [HttpPost("{propostaId:int}")]
        public async Task<IActionResult> AceitarProposta(int propostaId)
        {
            var proposta = await _context.Propostas
                .FirstOrDefaultAsync(p => p.Id == propostaId);

            if (proposta == null)
                return NotFound("Proposta não encontrada.");

            if (proposta.Status == "Aceita")
                return BadRequest("Essa proposta já foi aceita.");

            if (proposta.Status == "Recusada")
                return BadRequest("Essa proposta já foi recusada.");

            proposta.Status = "Aceita";

            var parceria = new Parceria
            {
                InfluencerId = proposta.InfluencerId,
                RestauranteId = proposta.RestauranteId
            };

            _context.Parcerias.Add(parceria);

            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Parceria criada com sucesso."
            });
        }

        // RECUSAR PROPOSTA
        [HttpPut("recusar/{propostaId:int}")]
        public async Task<IActionResult> RecusarProposta(int propostaId)
        {
            var proposta = await _context.Propostas
                .FirstOrDefaultAsync(p => p.Id == propostaId);

            if (proposta == null)
                return NotFound("Proposta não encontrada.");

            if (proposta.Status == "Recusada")
                return BadRequest("Essa proposta já foi recusada.");

            if (proposta.Status == "Aceita")
                return BadRequest("Essa proposta já foi aceita.");

            proposta.Status = "Recusada";

            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Proposta recusada."
            });
        }
    }
}