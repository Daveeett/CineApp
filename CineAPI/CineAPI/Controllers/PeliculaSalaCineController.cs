using CineAPI.Model;
using CineAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CineAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeliculaSalaCineController : ControllerBase
    {
        private readonly IPeliculaSalaCineService _service;

        public PeliculaSalaCineController(IPeliculaSalaCineService service)
        {
            _service = service;
        }

        [HttpPost("asignar")]
        public async Task<IActionResult> Asignar([FromBody] PeliculaSalaCine asignacion)
        {
            await _service.AsignarPelicula(asignacion);
            return Ok(new { status = "success", data = "Película asignada a sala correctamente" });
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodas()
        {
            var lista = await _service.ObtenerTodas();
            return Ok(new { status = "success", data = lista });
        }

        [HttpGet("sala/{idSala}")]
        public async Task<IActionResult> ObtenerPorSala(int idSala)
        {
            var lista = await _service.ObtenerPorSala(idSala);
            return Ok(new { status = "success", data = lista });
        }
    }

}
