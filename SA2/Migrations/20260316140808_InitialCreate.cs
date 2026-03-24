using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SA2.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeDoAluno = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    RegistroAluno = table.Column<int>(type: "int", nullable: false),
                    CursoId = table.Column<int>(type: "int", nullable: false),
                    StatusWifi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StatusAction = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "CursoId", "NomeDoAluno", "RegistroAluno", "StatusAction", "StatusWifi" },
                values: new object[,]
                {
                    { 1, 1, "Clodoaldo", 1001, "Aprovado", "Ativo" },
                    { 2, 2, "César", 1002, "Aguardando aprovação", "Inativo" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alunos");
        }
    }
}
