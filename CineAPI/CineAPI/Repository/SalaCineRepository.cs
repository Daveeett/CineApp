using CineAPI.Contexts;
using CineAPI.Model;
using CineAPI.Model.DTOs;
using CineAPI.Repository.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;

namespace CineAPI.Repository
{
    public class SalaCineRepository : ISalaCineRepository
    {
        private readonly AppDbContext _context;

        public SalaCineRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SalaCine>> ObtenerTodas()
        {
            return await _context.SalaCine.ToListAsync();
        }

        public async Task<SalaCine> ObtenerPorId(int id)
        {
            return await _context.SalaCine.FirstOrDefaultAsync(s => s.Id_Sala == id);
        }

        public async Task Crear(SalaCine sala)
        {
            _context.SalaCine.Add(sala);
            await _context.SaveChangesAsync();
        }

        public async Task Actualizar(SalaCine sala)
        {
            _context.SalaCine.Update(sala);
            await _context.SaveChangesAsync();
        }

        public async Task Eliminar(int id)
        {
            var sala = await ObtenerPorId(id);
            if (sala != null)
            {
                _context.SalaCine.Remove(sala);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<string> ObtenerEstadoPorNombre(string nombre)
        {
            var estado = await _context.SalaCine
                .Where(s => s.Nombre == nombre)
                .Select(s => s.Estado)
                .FirstOrDefaultAsync();

            return estado;
        }
    }
}
