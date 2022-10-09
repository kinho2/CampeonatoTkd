using System;
using System.Collections.Generic;
using System.Linq;
namespace CampeonatoTKD.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Atleta> Atletas { get; set; } = new List<Atleta>();

        public Category()
        {
        }

        public Category(int id, string name)
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
            return Atletas.Sum(atletas => atletas.TotalFights(initial, final));
        }
    }
}