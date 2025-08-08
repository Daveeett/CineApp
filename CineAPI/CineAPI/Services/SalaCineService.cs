using CineAPI.Model;
using CineAPI.Repository.Interfaces;
using CineAPI.Services.Interfaces;

namespace CineAPI.Services
{
    public class SalaCineService : ISalaCineService
    {
        private readonly ISalaCineRepository _repository;

        public SalaCineService(ISalaCineRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<SalaCine>> ObtenerTodas() => await _repository.ObtenerTodas();
        public async Task<SalaCine> ObtenerPorId(int id) => await _repository.ObtenerPorId(id);
        public async Task Crear(SalaCine sala) => await _repository.Crear(sala);
        public async Task Actualizar(SalaCine sala) => await _repository.Actualizar(sala);
        public async Task Eliminar(int id) => await _repository.Eliminar(id);
        public async Task<string> ObtenerEstadoPorNombre(string nombre) => await _repository.ObtenerEstadoPorNombre(nombre);
    }
}
