using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudDoYT.Migrations
{
    /// <inheritdoc />
    public partial class _6thadjustrelationsyntax : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livros_Bibliotecas_Id",
                table: "Livros");

            migrationBuilder.CreateIndex(
                name: "IX_Livros_BibliotecaId",
                table: "Livros",
                column: "BibliotecaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Livros_Bibliotecas_BibliotecaId",
                table: "Livros",
                column: "BibliotecaId",
                principalTable: "Bibliotecas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livros_Bibliotecas_BibliotecaId",
                table: "Livros");

            migrationBuilder.DropIndex(
                name: "IX_Livros_BibliotecaId",
                table: "Livros");

            migrationBuilder.AddForeignKey(
                name: "FK_Livros_Bibliotecas_Id",
                table: "Livros",
                column: "Id",
                principalTable: "Bibliotecas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
