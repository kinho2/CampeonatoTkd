using System;
using CampeonatoTKD.Models;
using CampeonatoTKD.Models.Enums;
using System.Linq;
using CampeonatoTKD.Models.Enums;

namespace CampeonatoTKD.Data
{
    public class SeedingService
    {
        private CampeonatoTkdContext _context;
        public SeedingService(CampeonatoTkdContext context)
        {
            _context = context;
        }
        public void Seed()
        {
            if(_context.Categoria.Any() ||
               _context.Atletas.Any() ||
               _context.Lutas.Any())
            {
                return; // DB has been seeded
            }

            Categoria C1 = new Categoria(1, "-74kg (68kg - 74kg)");
            Categoria C2 = new Categoria(2, "-80kg (74kg - 80kg)");
            Categoria C3 = new Categoria(3, "+80kg (80kg+)");


            Atleta A1 = new Atleta(1, "Marcos", "marcos@gmail.com", new DateTime(1998, 9, 14), 83.1, C3);
            Atleta A2 = new Atleta(2, "Kened", "kened@gmail.com", new DateTime(1996, 8, 9), 71.8, C1);
            Atleta A3 = new Atleta(3, "Camila", "camila@gmail.com", new DateTime(1994, 6, 20), 78.5, C2);
            Atleta A4 = new Atleta(4, "Nataly", "Nataly@gmail.com", new DateTime(1990, 11, 20), 79.0, C2);
            Atleta A5 = new Atleta(5, "Claudio", "claudio@gmail.com", new DateTime(1998, 3, 25), 82.0, C3);
            Atleta A6 = new Atleta(6, "Victor", "victor@gmail.com", new DateTime(2000, 2, 14), 68.5, C1);

            Lutas L1 = new Lutas(1, new DateTime (2022, 10, 07), 30, StatusLutas.Vitoria, A1);
            L1 = new Lutas(1, new DateTime(2022, 10, 07), 5, StatusLutas.Derrota, A5);
            Lutas L2 = new Lutas(2, new DateTime(2022, 10, 07), 25, StatusLutas.Empate, A3);
            L2 = new Lutas(2, new DateTime(2022, 10, 07), 25, StatusLutas.Empate, A4);
            Lutas L3 = new Lutas(3, new DateTime(2022, 10, 07), 45, StatusLutas.Vitoria, A2);
            L3 = new Lutas(3, new DateTime(2022, 10, 07), 9, StatusLutas.Derrota, A6);


            _context.Categoria.AddRange(C1,C2,C3);
            _context.Atletas.AddRange(A1, A2 ,A3, A4, A5, A6);
            _context.Lutas.AddRange(L1,L2,L3);
            _context.SaveChanges();

        }
    }
}
