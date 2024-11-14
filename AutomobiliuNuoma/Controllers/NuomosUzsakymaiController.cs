using AutomobiliuNuoma.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutomobiliuNuoma.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NuomosUzsakymaiController : ControllerBase
    {
        private readonly INuomosUzsakymasService _nuomosUzsakymasService;

        public NuomosUzsakymaiController(INuomosUzsakymasService nuomosUzsakymasService)
        {
            _nuomosUzsakymasService = nuomosUzsakymasService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NuomosUzsakymas>>> GetAll()
        {
            var nuomosUzsakymai = await _nuomosUzsakymasService.GetAllNuomosUzsakymai();
            return Ok(nuomosUzsakymai);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NuomosUzsakymas>> GetById(int id)
        {
            var nuomosUzsakymas = await _nuomosUzsakymasService.GetNuomosUzsakymasById(id);
            if (nuomosUzsakymas == null) return NotFound();
            return Ok(nuomosUzsakymas);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] NuomosUzsakymas nuomosUzsakymas)
        {
            if (nuomosUzsakymas == null) return BadRequest("Nuomos užsakymas negali būti tuščias.");
            await _nuomosUzsakymasService.AddNuomosUzsakymas(nuomosUzsakymas);
            return CreatedAtAction(nameof(GetById), new { id = nuomosUzsakymas.Id }, nuomosUzsakymas);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] NuomosUzsakymas nuomosUzsakymas)
        {
            if (id != nuomosUzsakymas.Id) return BadRequest();
            await _nuomosUzsakymasService.UpdateNuomosUzsakymas(nuomosUzsakymas);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _nuomosUzsakymasService.DeleteNuomosUzsakymas(id);
            return NoContent();
        }
    }
}