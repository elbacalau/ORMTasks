using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ORMTasks.Server.Migrations
{
    /// <inheritdoc />
    public partial class AgregarSegundoApellido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumeroTelefono",
                table: "Usuarios",
                newName: "numero_telefono");

            migrationBuilder.AddColumn<string>(
                name: "SegundoApelldo",
                table: "Usuarios",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SegundoApelldo",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "numero_telefono",
                table: "Usuarios",
                newName: "NumeroTelefono");
        }
    }
}
