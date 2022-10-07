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
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Atleta> Atletas { get; set; }
        public DbSet<Lutas> Lutas { get; set; }


    }
}
