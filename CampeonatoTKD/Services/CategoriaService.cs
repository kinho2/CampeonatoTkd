using CampeonatoTKD.Models;
using Microsoft.EntityFrameworkCore;

namespace CampeonatoTKD.Services
{
    public class CategoriaService
    {
        private readonly CampeonatoTkdContext _context;

        public  CategoriaService(CampeonatoTkdContext context)
        {
            _context = context;
        }

        public async Task<List<Categoria>> FindAllAsync()
        {
            return await _context.Categoria.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
