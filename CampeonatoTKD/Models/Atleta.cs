using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;

namespace CampeonatoTKD.Models
{
    public class Atleta
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} required")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} size should be between {2} and {1}")]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Enter a valid email")]
        [Required(ErrorMessage = "{0} required")]
        public string Email { get; set; }

        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}")]
        [Required(ErrorMessage = "{0} required")]
        public DateTime BirthDate { get; set; }
        public double Peso { get; set; }
        public Categoria Categoria { get; set; }
        public int CategoriaId { get; set; }
        public ICollection<Lutas> Lutas { get; set; } = new List<Lutas>();


        public Atleta()
        {
        }

        public Atleta(int id, string name, string email, DateTime birthDate, double peso, Categoria categoria)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            Peso = peso;
            Categoria = categoria;
        }
        public void AddLutas(Lutas lutas)
        {
            Lutas.Add(lutas);
        }
        public void RemoveLutas(Lutas lutas)
        {
            Lutas.Remove(lutas);
        }
        public double TotalLutas(DateTime initial, DateTime final)
        {
            return Lutas.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Pontos);
        }
    }
}
