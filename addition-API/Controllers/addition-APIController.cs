using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace addition_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class addition_APIController : ControllerBase
    {
        [HttpGet]
        public IActionResult Add(double sayi1, double sayi2)
        {
            double sonuc = sayi1 + sayi2;
            return Ok(new { Toplam = sonuc });
        }
    }
}
