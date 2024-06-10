using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fagner_Projeto___MVC.Migrations
{
    /// <inheritdoc />
    public partial class M03addTableFichas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GrupoMuscular",
                table: "Exercicios");

            migrationBuilder.AddColumn<int>(
                name: "Tipo",
                table: "Exercicios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Fichas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExercicioId = table.Column<int>(type: "int", nullable: false),
                    Repetiçoes = table.Column<int>(type: "int", nullable: false),
                    NumeroSerie = table.Column<int>(type: "int", nullable: false),
                    TempoDescanso = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fichas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fichas_Exercicios_ExercicioId",
                        column: x => x.ExercicioId,
                        principalTable: "Exercicios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fichas_ExercicioId",
                table: "Fichas",
                column: "ExercicioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fichas");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Exercicios");

            migrationBuilder.AddColumn<string>(
                name: "GrupoMuscular",
                table: "Exercicios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
