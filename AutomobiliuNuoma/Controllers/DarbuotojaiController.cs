using AutomobiliuNuoma.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutomobiliuNuoma.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DarbuotojaiController : ControllerBase
    {
        private readonly IDarbuotojasService _darbuotojasService;

        public DarbuotojaiController(IDarbuotojasService darbuotojasService)
        {
            _darbuotojasService = darbuotojasService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Darbuotojas>>> GetAll()
        {
            var darbuotojai = await _darbuotojasService.GetAllDarbuotojai();
            return Ok(darbuotojai);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Darbuotojas>> GetById(int id)
        {
            var darbuotojas = await _darbuotojasService.GetDarbuotojasById(id);
            if (darbuotojas == null) return NotFound();
            return Ok(darbuotojas);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Darbuotojas darbuotojas)
        {
            if (darbuotojas == null) return BadRequest("Darbuotojas negali būti tuščias.");
            await _darbuotojasService.AddDarbuotojas(darbuotojas);
            return CreatedAtAction(nameof(GetById), new { id = darbuotojas.Id }, darbuotojas);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Darbuotojas darbuotojas)
        {
            if (id != darbuotojas.Id) return BadRequest();
            await _darbuotojasService.UpdateDarbuotojas(darbuotojas);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _darbuotojasService.DeleteDarbuotojas(id);
            return NoContent();
        }
    }
}