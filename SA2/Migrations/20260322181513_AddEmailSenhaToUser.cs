using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SA2.Migrations
{
    /// <inheritdoc />
    public partial class AddEmailSenhaToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Alunos",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "Alunos",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Alunos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Senha" },
                values: new object[] { "clodoaldo@exemplo.com", "senha123" });

            migrationBuilder.UpdateData(
                table: "Alunos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "Senha" },
                values: new object[] { "cesar@exemplo.com", "senha123" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "Senha",
                table: "Alunos");
        }
    }
}
