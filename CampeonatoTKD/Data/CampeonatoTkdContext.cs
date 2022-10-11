using CampeonatoTKD.Models;
using Microsoft.EntityFrameworkCore;

namespace CampeonatoTKD
{
    public class CampeonatoTkdContext : DbContext
    {
        public CampeonatoTkdContext(DbContextOptions<CampeonatoTkdContext> options)
            : base(options)
        {
        }
        public DbSet<Category> Category { get; set; }
        public DbSet<Athlete> Atletas { get; set; }
        public DbSet<Fights> Lutas { get; set; }


    }
}