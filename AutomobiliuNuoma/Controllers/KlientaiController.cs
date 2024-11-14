using AutomobiliuNuoma.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutomobiliuNuoma.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KlientaiController : ControllerBase
    {
        private readonly IKlientasService _klientasService;

        public KlientaiController(IKlientasService klientasService)
        {
            _klientasService = klientasService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Klientas>>> GetAll()
        {
            var klientai = await _klientasService.GetAllKlientai();
            return Ok(klientai);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Klientas>> GetById(int id)
        {
            var klientas = await _klientasService.GetKlientasById(id);
            if (klientas == null) return NotFound();
            return Ok(klientas);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Klientas klientas)
        {
            if (klientas == null) return BadRequest("Klientas negali būti tuščias.");
            await _klientasService.AddKlientas(klientas);
            return CreatedAtAction(nameof(GetById), new { id = klientas.Id }, klientas);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Klientas klientas)
        {
            if (id != klientas.Id) return BadRequest();
            await _klientasService.UpdateKlientas(klientas);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _klientasService.DeleteKlientas(id);
            return NoContent();
        }
    }
}