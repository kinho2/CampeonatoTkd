using CampeonatoTKD.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampeonatoTKD.Services
{
    public class LutasService
    {
        private readonly CampeonatoTkdContext _context;

        public LutasService(CampeonatoTkdContext context)
        {
            _context = context;
        }

        public async Task<List<Lutas>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.Lutas select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }
            return await result
                .Include(x => x.Atleta)
                .Include(x => x.Atleta.Categoria)
                .OrderByDescending(x => x.Date)
                .ToListAsync();
        }
        public async Task<List<IGrouping<Categoria,Lutas>>>FindByDateGroupingAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.Lutas select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }
            return await result
                .Include(x => x.Atleta)
                .Include(x => x.Atleta.Categoria)
                .OrderByDescending(x => x.Date)
                .GroupBy(x => x.Atleta.Categoria)
                .ToListAsync();

        }
    }
}
