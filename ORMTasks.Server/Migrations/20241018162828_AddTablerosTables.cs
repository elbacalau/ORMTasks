using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ORMTasks.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddTablerosTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tableros_Usuarios_UserId",
                table: "tableros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tableros",
                table: "tableros");

            migrationBuilder.RenameTable(
                name: "tableros",
                newName: "Tableros");

            migrationBuilder.RenameIndex(
                name: "IX_tableros_UserId",
                table: "Tableros",
                newName: "IX_Tableros_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tableros",
                table: "Tableros",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tableros_Usuarios_UserId",
                table: "Tableros",
                column: "UserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tableros_Usuarios_UserId",
                table: "Tableros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tableros",
                table: "Tableros");

            migrationBuilder.RenameTable(
                name: "Tableros",
                newName: "tableros");

            migrationBuilder.RenameIndex(
                name: "IX_Tableros_UserId",
                table: "tableros",
                newName: "IX_tableros_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tableros",
                table: "tableros",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tableros_Usuarios_UserId",
                table: "tableros",
                column: "UserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
