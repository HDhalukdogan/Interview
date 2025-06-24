using Microsoft.AspNetCore.Mvc;
using PocAPI.DTOs;
using PocAPI.Services;

namespace PocAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoEntitiesController(IDemoEntityService demoEntityService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await demoEntityService.GetDemoEntitiesAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await demoEntityService.GetDemoEntityByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateDemoDto createDemoDto)
        {
            var entity = await demoEntityService.CrateDemoEntityAsync(createDemoDto);
            return CreatedAtAction(nameof(GetById), new { id = entity.Id }, entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateDemoDto updateDemoDto)
        {
            if (id != updateDemoDto.Id)
                return BadRequest();

            var entity = await demoEntityService.UpdateEntityAsync(updateDemoDto);
            return CreatedAtAction(nameof(GetById), new { id = entity.Id }, entity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await demoEntityService.DeleteEntityAsync(id);
            return result ? Ok("Deleted") : BadRequest("Not deleted");
        }
    }
}
