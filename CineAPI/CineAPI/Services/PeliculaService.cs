using CineAPI.Model;
using CineAPI.Repository.Interfaces;
using CineAPI.Services.Interfaces;

namespace CineAPI.Services
{
    public class PeliculaService : IPeliculaService
    {
        private readonly IPeliculaRepository _repo;

        public PeliculaService(IPeliculaRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<Pelicula>> ObtenerTodas()
        {
            return await _repo.ObtenerTodas();
        }

        public async Task<Pelicula?> ObtenerPorId(int id)
        {
            return await _repo.ObtenerPorId(id);
        }

        public async Task Crear(Pelicula pelicula)
        {
            await _repo.Crear(pelicula);
        }

        public async Task Actualizar(Pelicula pelicula)
        {
            await _repo.Actualizar(pelicula);
        }

        public async Task Eliminar(int id)
        {
            await _repo.Eliminar(id);
        }
    }
}