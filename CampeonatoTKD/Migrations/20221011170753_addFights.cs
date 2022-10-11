using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CampeonatoTKD.Migrations
{
    public partial class addFights : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lutas_Atletas_AtletaId",
                table: "Lutas");

            migrationBuilder.DropTable(
                name: "Atletas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lutas",
                table: "Lutas");

            migrationBuilder.RenameTable(
                name: "Lutas",
                newName: "Fights");

            migrationBuilder.RenameColumn(
                name: "AtletaId",
                table: "Fights",
                newName: "AthleteId");

            migrationBuilder.RenameIndex(
                name: "IX_Lutas_AtletaId",
                table: "Fights",
                newName: "IX_Fights_AthleteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fights",
                table: "Fights",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Athletes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Weight = table.Column<double>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Athletes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Athletes_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Athletes_CategoryId",
                table: "Athletes",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fights_Athletes_AthleteId",
                table: "Fights",
                column: "AthleteId",
                principalTable: "Athletes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fights_Athletes_AthleteId",
                table: "Fights");

            migrationBuilder.DropTable(
                name: "Athletes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fights",
                table: "Fights");

            migrationBuilder.RenameTable(
                name: "Fights",
                newName: "Lutas");

            migrationBuilder.RenameColumn(
                name: "AthleteId",
                table: "Lutas",
                newName: "AtletaId");

            migrationBuilder.RenameIndex(
                name: "IX_Fights_AthleteId",
                table: "Lutas",
                newName: "IX_Lutas_AtletaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lutas",
                table: "Lutas",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Atletas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    Weight = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atletas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Atletas_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atletas_CategoryId",
                table: "Atletas",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lutas_Atletas_AtletaId",
                table: "Lutas",
                column: "AtletaId",
                principalTable: "Atletas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
