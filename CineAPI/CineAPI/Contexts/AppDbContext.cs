using Microsoft.EntityFrameworkCore;
using CineAPI.Model;

namespace CineAPI.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Pelicula> Pelicula { get; set; }
        public DbSet<SalaCine> SalaCine { get; set; }
        public DbSet<PeliculaSalaCine> PeliculaSalaCine { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Tablas
            modelBuilder.Entity<Pelicula>().ToTable("pelicula");
            modelBuilder.Entity<SalaCine>().ToTable("sala_cine");
            modelBuilder.Entity<PeliculaSalaCine>().ToTable("pelicula_salacine");

            // Claves primarias
            modelBuilder.Entity<Pelicula>().HasKey(p => p.Id_Pelicula);
            modelBuilder.Entity<SalaCine>().HasKey(s => s.Id_Sala);
            modelBuilder.Entity<PeliculaSalaCine>().HasKey(ps => ps.Id_Pelicula_Sala);

            // Relaciones
            modelBuilder.Entity<PeliculaSalaCine>()
                .HasOne(ps => ps.Pelicula)
                .WithMany(p => p.PeliculasSalas)
                .HasForeignKey(ps => ps.Id_Pelicula);

            modelBuilder.Entity<PeliculaSalaCine>()
                .HasOne(ps => ps.SalaCine)
                .WithMany(s => s.PeliculasSalas)
                .HasForeignKey(ps => ps.Id_Sala_Cine);
        }
    }
}
