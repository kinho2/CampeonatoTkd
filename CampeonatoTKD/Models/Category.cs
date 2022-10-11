using System;
using System.Collections.Generic;
using System.Linq;
namespace CampeonatoTKD.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Athlete> athlete { get; set; } = new List<Athlete>();

        public Category()
        {
        }

        public Category(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public void AddAtleta(Athlete atleta)
        {
            athlete.Add(atleta);
        }
        public double TotalAtletas(DateTime initial, DateTime final)
        {
            return athlete.Sum(atletas => atletas.TotalFights(initial, final));
        }
    }
}