using CineAPI.Contexts;
using CineAPI.Model;
using CineAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CineAPI.Repository
{
    public class PeliculaSalaCineRepository : IPeliculaSalaCineRepository
    {
        private readonly AppDbContext _context;

        public PeliculaSalaCineRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AsignarPelicula(PeliculaSalaCine asignacion)
        {
            var existe = await _context.PeliculaSalaCine.AnyAsync(ps =>
                ps.Id_Pelicula == asignacion.Id_Pelicula &&
                ps.Id_Sala_Cine == asignacion.Id_Sala_Cine);

            if (!existe)
            {
                _context.PeliculaSalaCine.Add(asignacion);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<PeliculaSalaCine>> ObtenerTodas()
        {
            return await _context.PeliculaSalaCine
                .Include(p => p.Pelicula)
                .Include(s => s.SalaCine)
                .ToListAsync();
        }

        public async Task<IEnumerable<PeliculaSalaCine>> ObtenerPorSala(int idSala)
        {
            return await _context.PeliculaSalaCine
                .Where(ps => ps.Id_Sala_Cine == idSala)
                .Include(p => p.Pelicula)
                .Include(s => s.SalaCine)
                .ToListAsync();
        }
    }
}
