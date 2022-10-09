using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CampeonatoTKD.Migrations
{
    public partial class atualizandoCategoriaToCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atletas_Categoria_CategoriaId",
                table: "Atletas");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.RenameColumn(
                name: "Peso",
                table: "Atletas",
                newName: "Weight");

            migrationBuilder.RenameColumn(
                name: "CategoriaId",
                table: "Atletas",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Atletas_CategoriaId",
                table: "Atletas",
                newName: "IX_Atletas_CategoryId");

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Atletas_Category_CategoryId",
                table: "Atletas",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atletas_Category_CategoryId",
                table: "Atletas");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.RenameColumn(
                name: "Weight",
                table: "Atletas",
                newName: "Peso");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Atletas",
                newName: "CategoriaId");

            migrationBuilder.RenameIndex(
                name: "IX_Atletas_CategoryId",
                table: "Atletas",
                newName: "IX_Atletas_CategoriaId");

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Atletas_Categoria_CategoriaId",
                table: "Atletas",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
