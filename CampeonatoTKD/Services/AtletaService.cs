using System;
using CampeonatoTKD.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data;


namespace CampeonatoTKD.Services
{
    public class AtletaService
    {
        private readonly CampeonatoTkdContext _context;

        public AtletaService(CampeonatoTkdContext context)
        {
            _context = context;
        }
        public async Task<List<Atleta>> FindAllAsync()
        {
            return await _context.Atletas.ToListAsync();
        }
        public async Task InsertAsync(Atleta obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }
        public async Task<Atleta> FindByIdAsync(int id)
        {
            return await _context.Atletas.Include(obj => obj.Categoria).FirstOrDefaultAsync(obj => obj.Id == id);
        }
        
    }
}
