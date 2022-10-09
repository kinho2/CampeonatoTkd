using System.Collections.Generic;

namespace CampeonatoTKD.Models.ViewModel
{
    public class AtletaFormViewModel
    {
        public Atleta Atleta { get; set; }
        public ICollection<Category> Category { get; set; }

    }
}
