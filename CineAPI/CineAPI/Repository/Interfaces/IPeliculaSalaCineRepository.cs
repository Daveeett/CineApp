using CineAPI.Model;

namespace CineAPI.Repository.Interfaces
{
    public interface IPeliculaSalaCineRepository
    {
        Task AsignarPelicula(PeliculaSalaCine asignacion);
        Task<IEnumerable<PeliculaSalaCine>> ObtenerTodas();
        Task<IEnumerable<PeliculaSalaCine>> ObtenerPorSala(int idSala);
    }
}
