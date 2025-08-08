using CineAPI.Model;

namespace CineAPI.Services.Interfaces
{
    public interface IPeliculaService
    {
        Task<List<Pelicula>> ObtenerTodas();
        Task<Pelicula?> ObtenerPorId(int id);
        Task Crear(Pelicula pelicula);
        Task Actualizar(Pelicula pelicula);
        Task Eliminar(int id);
    }
}
