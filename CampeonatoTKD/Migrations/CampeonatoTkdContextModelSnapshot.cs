﻿// <auto-generated />
using System;
using CampeonatoTKD;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CampeonatoTKD.Migrations
{
    [DbContext(typeof(CampeonatoTkdContext))]
    partial class CampeonatoTkdContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CampeonatoTKD.Models.Atleta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BirthDate");

                    b.Property<int>("CategoriaId");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<double>("Peso");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Atletas");
                });

            modelBuilder.Entity("CampeonatoTKD.Models.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("CampeonatoTKD.Models.Lutas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AtletaId");

                    b.Property<DateTime>("Date");

                    b.Property<double>("Pontos");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("AtletaId");

                    b.ToTable("Lutas");
                });

            modelBuilder.Entity("CampeonatoTKD.Models.Atleta", b =>
                {
                    b.HasOne("CampeonatoTKD.Models.Categoria", "Categoria")
                        .WithMany("Atletas")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CampeonatoTKD.Models.Lutas", b =>
                {
                    b.HasOne("CampeonatoTKD.Models.Atleta", "Atleta")
                        .WithMany("Lutas")
                        .HasForeignKey("AtletaId");
                });
#pragma warning restore 612, 618
        }
    }
}
