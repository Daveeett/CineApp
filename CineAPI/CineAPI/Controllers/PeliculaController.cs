using Microsoft.AspNetCore.Mvc;
using CineAPI.Model;
using CineAPI.Services.Interfaces;

namespace CineAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeliculaController : ControllerBase
    {
        private readonly IPeliculaService _service;

        public PeliculaController(IPeliculaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var peliculas = await _service.ObtenerTodas();
            return Ok(new { status = "success", data = peliculas });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pelicula = await _service.ObtenerPorId(id);
            if (pelicula == null)
                return NotFound(new { status = "error", data = "Película no encontrada" });

            return Ok(new { status = "success", data = pelicula });
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] Pelicula pelicula)
        {
            await _service.Crear(pelicula);
            return Ok(new { status = "success", data = "Película creada correctamente" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] Pelicula pelicula)
        {
            pelicula.Id_Pelicula = id;
            await _service.Actualizar(pelicula);
            return Ok(new { status = "success", data = "Película actualizada" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            await _service.Eliminar(id);
            return Ok(new { status = "success", data = "Película eliminada" });
        }
    }
}