using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Addition_API.Data;
using Addition_API.Models;

namespace Addition_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Addition_APIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public Addition_APIController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("Add")]
        public IActionResult AddNumbers([FromBody] Addition model)
        {
            model.Total = model.First + model.Last;

            _context.Toplamalar.Add(model);
            _context.SaveChanges();

            return Ok(model);
        }

        [HttpGet("Totals")]
        public IActionResult GetTotals([FromQuery] int? minTotal)
        {
            var totalsQuery = _context.Toplamalar.AsQueryable();

            if (minTotal.HasValue)
            {
                totalsQuery = totalsQuery.Where(x => x.Total > minTotal.Value);
            }

            var totals = totalsQuery.Select(x => x.Total).ToList();

            return Ok(totals);
        }
    }
}
