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
    }
}
