using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SC.ProyectoAPIV3Core2.DrivenAdapters.Sql.Migrations.SqlServerMigrations
{
    public partial class AddCredito : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Creditos",
                columns: table => new
                {
                    CreditoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Frecuencia = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Plazo = table.Column<int>(type: "int", nullable: false),
                    Valor_capital = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Creditos", x => x.CreditoId);
                    table.ForeignKey(
                        name: "FK_Creditos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Creditos_ClienteId",
                table: "Creditos",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Creditos");
        }
    }
}
