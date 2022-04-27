using Microsoft.AspNetCore.Mvc;

namespace Module.Catalog.Controllers
{
    [ApiController]
    [Route("/api/catalog/[controller]")]
    internal class MoviesController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok();
        }
    }
}
