﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

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
        public double Weight { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public ICollection<Fights> Fights { get; set; } = new List<Fights>();


        public Atleta()
        {
        }

        public Atleta(int id, string name, string email, DateTime birthDate, double weight, Category category)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            Weight = weight;
            Category = category;
        }
        public void AddLutas(Fights fights)
        {
            Fights.Add(fights);
        }
        public void RemoveLutas(Fights fights)
        {
            Fights.Remove(fights);
        }
        public double TotalFights(DateTime initial, DateTime final)
        {
            return Fights.Where(fi => fi.Date >= initial && fi.Date <= final).Sum(fi => fi.Pontos);
        }
    }
}