using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FixOrdenV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "precioUnitario",
                table: "Activos",
                newName: "PrecioUnitario");

            migrationBuilder.RenameColumn(
                name: "nombre",
                table: "Activos",
                newName: "Nombre");

            migrationBuilder.AddColumn<string>(
                name: "NombreActivo",
                table: "Ordenes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NombreActivo",
                table: "Ordenes");

            migrationBuilder.RenameColumn(
                name: "PrecioUnitario",
                table: "Activos",
                newName: "precioUnitario");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Activos",
                newName: "nombre");

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
    }
}
