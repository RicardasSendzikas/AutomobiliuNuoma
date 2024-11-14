using AutomobiliuNuoma.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutomobiliuNuoma.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutomobiliaiController : ControllerBase
    {
        private readonly IAutomobilisService _automobilisService;

        public AutomobiliaiController(IAutomobilisService automobilisService)
        {
            _automobilisService = automobilisService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Automobilis>>> GetAll()
        {
            var automobiliai = await _automobilisService.GetAllAutomobiliai();
            return Ok(automobiliai);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Automobilis>> GetById(int id)
        {
            var automobilis = await _automobilisService.GetAutomobilisById(id);
            if (automobilis == null) return NotFound();
            return Ok(automobilis);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Automobilis automobilis)
        {
            if (automobilis == null) return BadRequest("Automobilis negali būti tuščias.");
            await _automobilisService.AddAutomobilis(automobilis);
            return CreatedAtAction(nameof(GetById), new { id = automobilis.Id }, automobilis);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Automobilis automobilis)
        {
            if (id != automobilis.Id) return BadRequest();
            await _automobilisService.UpdateAutomobilis(automobilis);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _automobilisService.DeleteAutomobilis(id);
            return NoContent();
        }
    }
}