using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceDT.Server.Data;
using ServiceDT.Shared.Models;

namespace ServiceDT.Server.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EtudeController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
        public EtudeController(ApplicationDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var devs = await _context.SuiviBEs.ToListAsync();
            return Ok(devs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var dev = await _context.SuiviBEs.FirstOrDefaultAsync(a => a.SuiviBEId == id);
            return Ok(dev);
        }

        [HttpPost]
        public async Task<IActionResult> Post(SuiviBE developer)
        {
            _context.Add(developer);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(SuiviBE developer)
        {
            _context.Entry(developer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var dev = new SuiviBE { SuiviBEId = id };
            _context.Remove(dev);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
