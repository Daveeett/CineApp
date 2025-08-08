using CineAPI.Model;

namespace CineAPI.Repository.Interfaces
{
    public interface ISalaCineRepository
    {
        Task<IEnumerable<SalaCine>> ObtenerTodas();
        Task<SalaCine> ObtenerPorId(int id);
        Task Crear(SalaCine sala);
        Task Actualizar(SalaCine sala);
        Task Eliminar(int id);
        Task<string> ObtenerEstadoPorNombre(string nombre);
    }
}
