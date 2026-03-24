using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SA2.Migrations
{
    /// <inheritdoc />
    public partial class MoverIdENomeParaUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NomeDoAluno",
                table: "Alunos",
                newName: "Nome");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Alunos",
                newName: "NomeDoAluno");
        }
    }
}
