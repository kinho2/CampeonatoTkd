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
        public DbSet<Athlete> Athletes { get; set; }
        public DbSet<Fights> Fights { get; set; }


    }
}