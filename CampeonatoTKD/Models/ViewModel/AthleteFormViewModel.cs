using System.Collections.Generic;

namespace CampeonatoTKD.Models.ViewModel
{
    public class AthleteFormViewModel
    {
        public Athlete Athlete { get; set; }
        public ICollection<Category> Category { get; set; }

    }
}
