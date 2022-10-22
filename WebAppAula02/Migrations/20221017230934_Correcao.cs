using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppAula02.Migrations
{
    public partial class Correcao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstudanteId = table.Column<int>(type: "int", nullable: false),
                    LivroId = table.Column<int>(type: "int", nullable: false),
                    DiaReserva = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiaDevolucao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LivrosId = table.Column<int>(type: "int", nullable: false),
                    UsuariosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservas_Usuarios_UsuariosId",
                        column: x => x.UsuariosId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservas_Livros_LivrosId",
                        column: x => x.LivrosId,
                        principalTable: "Livros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_UsuariosId",
                table: "Reservas",
                column: "UsuariosId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_LivrosId",
                table: "Reservas",
                column: "LivrosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservas");
        }
    }
}
