using CampeonatoTKD.Models;
using Microsoft.EntityFrameworkCore;
using CampeonatoTKD.Services.Exceptions;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CampeonatoTKD.Services
{
    public class AthleteService
    {
        private readonly CampeonatoTkdContext _context;

        public AthleteService(CampeonatoTkdContext context)
        {
            _context = context;
        }
        public async Task<List<Athlete>> FindAllAsync()
        {
            return await _context.Atletas.ToListAsync();
        }
        public async Task InsertAsync(Athlete obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }
        public async Task<Athlete> FindByIdAsync(int id)
        {
            return await _context.Atletas.Include(obj => obj.Category).FirstOrDefaultAsync(obj => obj.Id == id);
        }
        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Atletas.FindAsync(id);
                _context.Atletas.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException("Can't Delete seller because he/she has sales.");
            }
        }
        public async Task UpdateAsync(Athlete obj)
        {
            bool hasAny = await _context.Atletas.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new ApplicationExeption("Id not found");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

    }
}
