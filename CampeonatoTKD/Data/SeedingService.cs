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
            if(_context.Category.Any() ||
               _context.Athletes.Any() ||
               _context.Fights.Any())
            {
                return; // DB has been seeded
            }

            Category C1 = new Category(1, "-74kg (68kg - 74kg)");
            Category C2 = new Category(2, "-80kg (74kg - 80kg)");
            Category C3 = new Category(3, "+80kg (80kg+)");


            Athlete A1 = new Athlete(1, "Marcos", "marcos@gmail.com", new DateTime(1998, 9, 14), 83.1, C3);
            Athlete A2 = new Athlete(2, "Kened", "kened@gmail.com", new DateTime(1996, 8, 9), 71.8, C1);
            Athlete A3 = new Athlete(3, "Camila", "camila@gmail.com", new DateTime(1994, 6, 20), 78.5, C2);
            Athlete A4 = new Athlete(4, "Nataly", "Nataly@gmail.com", new DateTime(1990, 11, 20), 79.0, C2);
            Athlete A5 = new Athlete(5, "Claudio", "claudio@gmail.com", new DateTime(1998, 3, 25), 82.0, C3);
            Athlete A6 = new Athlete(6, "Victor", "victor@gmail.com", new DateTime(2000, 2, 14), 68.5, C1);

            Fights L1 = new Fights(1, new DateTime (2022, 10, 07), 30, StatusLutas.Vitoria, A1);
            L1 = new Fights(1, new DateTime(2022, 10, 07), 5, StatusLutas.Derrota, A5);
            Fights L2 = new Fights(2, new DateTime(2022, 10, 07), 25, StatusLutas.Empate, A3);
            L2 = new Fights(2, new DateTime(2022, 10, 07), 25, StatusLutas.Empate, A4);
            Fights L3 = new Fights(3, new DateTime(2022, 10, 07), 45, StatusLutas.Vitoria, A2);
            L3 = new Fights(3, new DateTime(2022, 10, 07), 9, StatusLutas.Derrota, A6);


            _context.Category.AddRange(C1,C2,C3);
            _context.Athletes.AddRange(A1, A2 ,A3, A4, A5, A6);
            _context.Fights.AddRange(L1,L2,L3);
            _context.SaveChanges();

        }
    }
}
