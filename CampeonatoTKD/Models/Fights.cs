using CampeonatoTKD.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace CampeonatoTKD.Models
{
    public class Fights
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }
        public double Pontos { get; set; }
        public StatusLutas Status { get; set; }
        public Atleta Atleta { get; set; }

        public Fights()
        {
        }

        public Fights(int id, DateTime date, double pontos, StatusLutas status, Atleta atleta)
        {
            Id = id;
            Date = date;
            Pontos = pontos;
            Status = status;
            Atleta = atleta;
        }
    }
}