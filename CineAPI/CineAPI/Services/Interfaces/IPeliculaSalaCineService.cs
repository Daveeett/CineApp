using CineAPI.Model;

namespace CineAPI.Services.Interfaces
{
    public interface IPeliculaSalaCineService
    {
        Task AsignarPelicula(PeliculaSalaCine asignacion);
        Task<IEnumerable<PeliculaSalaCine>> ObtenerTodas();
        Task<IEnumerable<PeliculaSalaCine>> ObtenerPorSala(int idSala);
    }
}
