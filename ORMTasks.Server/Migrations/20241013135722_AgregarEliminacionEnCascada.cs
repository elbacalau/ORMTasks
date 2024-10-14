using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ORMTasks.Server.Migrations
{
    /// <inheritdoc />
    public partial class AgregarEliminacionEnCascada : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Orden",
                table: "Tarjetas");

            migrationBuilder.RenameColumn(
                name: "SegundoApelldo",
                table: "Usuarios",
                newName: "segundo_apellido");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaVencimiento",
                table: "Tarjetas",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "segundo_apellido",
                table: "Usuarios",
                newName: "SegundoApelldo");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaVencimiento",
                table: "Tarjetas",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AddColumn<int>(
                name: "Orden",
                table: "Tarjetas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
