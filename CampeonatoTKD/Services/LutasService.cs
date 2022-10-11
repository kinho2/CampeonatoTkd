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

        public async Task<List<Fights>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
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
                .Include(x => x.Athlete)
                .Include(x => x.Athlete.Category)
                .OrderByDescending(x => x.Date)
                .ToListAsync();
        }
        public async Task<List<IGrouping<Category, Fights>>>FindByDateGroupingAsync(DateTime? minDate, DateTime? maxDate)
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
                .Include(x => x.Athlete)
                .Include(x => x.Athlete.Category)
                .OrderByDescending(x => x.Date)
                .GroupBy(x => x.Athlete.Category)
                .ToListAsync();

        }
    }
}
