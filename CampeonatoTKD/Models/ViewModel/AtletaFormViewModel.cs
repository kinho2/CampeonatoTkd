using System.Collections.Generic;

namespace CampeonatoTKD.Models.ViewModel
{
    public class AtletaFormViewModel
    {
        public Atleta Atleta { get; set; }
        public ICollection<Categoria>Categorias { get; set; }

    }
}
