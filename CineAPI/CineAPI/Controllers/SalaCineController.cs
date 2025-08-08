using CineAPI.Model;
using CineAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CineAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalaCineController : ControllerBase
    {
        private readonly ISalaCineService _service;

        public SalaCineController(ISalaCineService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var salas = await _service.ObtenerTodas();
            return Ok(new { status = "success", data = salas });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var sala = await _service.ObtenerPorId(id);
            if (sala == null) return NotFound(new { status = "error", data = "Sala no encontrada" });
            return Ok(new { status = "success", data = sala });
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] SalaCine sala)
        {
            await _service.Crear(sala);
            return Ok(new { status = "success", data = "Sala creada exitosamente" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] SalaCine sala)
        {
            sala.Id_Sala = id;
            await _service.Actualizar(sala);
            return Ok(new { status = "success", data = "Sala actualizada" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            await _service.Eliminar(id);
            return Ok(new { status = "success", data = "Sala eliminada" });
        }

        [HttpGet("estado")]
        public async Task<IActionResult> Estado([FromQuery] string nombre)
        {
            var estado = await _service.ObtenerEstadoPorNombre(nombre);
            return Ok(new { status = "success", data = new { estado } });
        }

    }
}
