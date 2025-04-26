using Microsoft.EntityFrameworkCore;
using Parcial_Delgado.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Jugador> Jugadores => Set<Jugador>();
    public DbSet<Equipo> Equipos => Set<Equipo>();
}
