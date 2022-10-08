using System;
using System.Collections.Generic;
using System.Linq;
namespace CampeonatoTKD.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Atleta> Atletas { get; set; } = new List<Atleta>();

        public Categoria()
        {
        }

        public Categoria(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public void AddAtleta(Atleta atleta)
        {
            Atletas.Add(atleta);
        }
        public double TotalAtletas(DateTime initial, DateTime final)
        {
            return Atletas.Sum(atletas => atletas.TotalLutas(initial, final));
        }
    }
}