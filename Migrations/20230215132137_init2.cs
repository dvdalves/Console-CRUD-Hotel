using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Teste.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_hospedes_reservas_Reservaid",
                table: "hospedes");

            migrationBuilder.DropIndex(
                name: "IX_hospedes_Reservaid",
                table: "hospedes");

            migrationBuilder.DropColumn(
                name: "Reservaid",
                table: "hospedes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Reservaid",
                table: "hospedes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_hospedes_Reservaid",
                table: "hospedes",
                column: "Reservaid");

            migrationBuilder.AddForeignKey(
                name: "FK_hospedes_reservas_Reservaid",
                table: "hospedes",
                column: "Reservaid",
                principalTable: "reservas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
