using CineAPI.Model;

namespace CineAPI.Repository.Interfaces
{
    public interface IPeliculaRepository
    {
        Task<List<Pelicula>> ObtenerTodas();
        Task<Pelicula?> ObtenerPorId(int id);
        Task Crear(Pelicula pelicula);
        Task Actualizar(Pelicula pelicula);
        Task Eliminar(int id);
    }
}