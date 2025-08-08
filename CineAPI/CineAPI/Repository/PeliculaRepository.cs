using CineAPI.Contexts;
using CineAPI.Model;
using CineAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CineAPI.Repository
{
    public class PeliculaRepository : IPeliculaRepository
    {
        private readonly AppDbContext _context;

        public PeliculaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Pelicula>> ObtenerTodas()
        {
            return await _context.Pelicula.ToListAsync();
        }

        public async Task<Pelicula?> ObtenerPorId(int id)
        {
            return await _context.Pelicula.FindAsync(id);
        }

        public async Task Crear(Pelicula pelicula)
        {
            _context.Pelicula.Add(pelicula);
            await _context.SaveChangesAsync();
        }

        public async Task Actualizar(Pelicula pelicula)
        {
            _context.Pelicula.Update(pelicula);
            await _context.SaveChangesAsync();
        }

        public async Task Eliminar(int id)
        {
            var pelicula = await _context.Pelicula.FindAsync(id);
            if (pelicula != null)
            {
                _context.Pelicula.Remove(pelicula);
                await _context.SaveChangesAsync();
            }
        }
    }
}