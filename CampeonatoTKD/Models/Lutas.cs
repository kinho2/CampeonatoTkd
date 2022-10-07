﻿using CampeonatoTKD.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace CampeonatoTKD.Models
{
    public class Lutas
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }
        public double Pontos { get; set; }
        public LutasStatus Status { get; set; }
        public Atleta Atleta { get; set; }

        public Lutas()
        {
        }

        public Lutas(int id, DateTime date, double pontos, LutasStatus status, Atleta atleta)
        {
            Id = id;
            Date = date;
            Pontos = pontos;
            Status = status;
            Atleta = atleta;
        }
    }
}