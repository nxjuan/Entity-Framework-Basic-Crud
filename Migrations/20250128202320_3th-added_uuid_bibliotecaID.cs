using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudDoYT.Migrations
{
    /// <inheritdoc />
    public partial class _3thadded_uuid_bibliotecaID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BibliotecaId",
                table: "Livros",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BibliotecaId",
                table: "Livros");
        }
    }
}
