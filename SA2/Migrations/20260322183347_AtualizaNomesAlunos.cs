using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SA2.Migrations
{
    /// <inheritdoc />
    public partial class AtualizaNomesAlunos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Alunos",
                keyColumn: "Id",
                keyValue: 1,
                column: "Nome",
                value: "Clodoaldo Silva");

            migrationBuilder.UpdateData(
                table: "Alunos",
                keyColumn: "Id",
                keyValue: 2,
                column: "Nome",
                value: "César Brandão");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Alunos",
                keyColumn: "Id",
                keyValue: 1,
                column: "Nome",
                value: "Clodoaldo");

            migrationBuilder.UpdateData(
                table: "Alunos",
                keyColumn: "Id",
                keyValue: 2,
                column: "Nome",
                value: "César");
        }
    }
}
