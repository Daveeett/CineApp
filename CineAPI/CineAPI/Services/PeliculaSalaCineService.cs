using CineAPI.Model;
using CineAPI.Repository.Interfaces;
using CineAPI.Services.Interfaces;

namespace CineAPI.Services
{
    public class PeliculaSalaCineService : IPeliculaSalaCineService
    {
        private readonly IPeliculaSalaCineRepository _repository;

        public PeliculaSalaCineService(IPeliculaSalaCineRepository repository)
        {
            _repository = repository;
        }

        public async Task AsignarPelicula(PeliculaSalaCine asignacion) =>
            await _repository.AsignarPelicula(asignacion);

        public async Task<IEnumerable<PeliculaSalaCine>> ObtenerTodas() =>
            await _repository.ObtenerTodas();

        public async Task<IEnumerable<PeliculaSalaCine>> ObtenerPorSala(int idSala) =>
            await _repository.ObtenerPorSala(idSala);
    }
}
