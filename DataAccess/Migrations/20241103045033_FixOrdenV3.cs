using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FixOrdenV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NombreActivo",
                table: "Ordenes");

            migrationBuilder.AddColumn<int>(
                name: "ActivoId",
                table: "Ordenes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_ActivoId",
                table: "Ordenes",
                column: "ActivoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ordenes_Activos_ActivoId",
                table: "Ordenes",
                column: "ActivoId",
                principalTable: "Activos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ordenes_Activos_ActivoId",
                table: "Ordenes");

            migrationBuilder.DropIndex(
                name: "IX_Ordenes_ActivoId",
                table: "Ordenes");

            migrationBuilder.DropColumn(
                name: "ActivoId",
                table: "Ordenes");

            migrationBuilder.AddColumn<string>(
                name: "NombreActivo",
                table: "Ordenes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
