using CampeonatoTKD.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampeonatoTKD.Services
{
    public class CategoryService
    {
        private readonly CampeonatoTkdContext _context;

        public CategoryService(CampeonatoTkdContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> FindAllAsync()
        {
            return await _context.Category.OrderBy(x => x.Name).ToListAsync();
        }
    }
}