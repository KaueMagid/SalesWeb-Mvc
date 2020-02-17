using Microsoft.EntityFrameworkCore.Migrations;

namespace SalesWebMVC.Migrations
{
    public partial class DepartamentForeigKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Saller_Departament_DepartamentId",
                table: "Saller");

            migrationBuilder.AlterColumn<int>(
                name: "DepartamentId",
                table: "Saller",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Saller_Departament_DepartamentId",
                table: "Saller",
                column: "DepartamentId",
                principalTable: "Departament",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Saller_Departament_DepartamentId",
                table: "Saller");

            migrationBuilder.AlterColumn<int>(
                name: "DepartamentId",
                table: "Saller",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Saller_Departament_DepartamentId",
                table: "Saller",
                column: "DepartamentId",
                principalTable: "Departament",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
