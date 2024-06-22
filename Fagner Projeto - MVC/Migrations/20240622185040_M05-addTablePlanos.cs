using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fagner_Projeto___MVC.Migrations
{
    /// <inheritdoc />
    public partial class M05addTablePlanos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Carboidratos",
                table: "alimentos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Gorduras",
                table: "alimentos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Proteinas",
                table: "alimentos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Planos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlimentoId = table.Column<int>(type: "int", nullable: false),
                    Refeição = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hora = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Porção = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Planos_alimentos_AlimentoId",
                        column: x => x.AlimentoId,
                        principalTable: "alimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Planos_AlimentoId",
                table: "Planos",
                column: "AlimentoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Planos");

            migrationBuilder.DropColumn(
                name: "Carboidratos",
                table: "alimentos");

            migrationBuilder.DropColumn(
                name: "Gorduras",
                table: "alimentos");

            migrationBuilder.DropColumn(
                name: "Proteinas",
                table: "alimentos");
        }
    }
}
