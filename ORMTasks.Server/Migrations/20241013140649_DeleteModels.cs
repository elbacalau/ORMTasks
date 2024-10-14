using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ORMTasks.Server.Migrations
{
    /// <inheritdoc />
    public partial class DeleteModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adjuntos_Tarjetas_TarjetaId",
                table: "Adjuntos");

            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Tarjetas_TarjetaId",
                table: "Comentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Usuarios_UsuarioId",
                table: "Comentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Listas_Tableros_TableroId",
                table: "Listas");

            migrationBuilder.DropForeignKey(
                name: "FK_Tableros_Usuarios_PropietarioId",
                table: "Tableros");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarjetas_Listas_ListaId",
                table: "Tarjetas");

            migrationBuilder.DropTable(
                name: "Etiquetas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tarjetas",
                table: "Tarjetas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tableros",
                table: "Tableros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Listas",
                table: "Listas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comentarios",
                table: "Comentarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Adjuntos",
                table: "Adjuntos");

            migrationBuilder.RenameTable(
                name: "Tarjetas",
                newName: "Tarjeta");

            migrationBuilder.RenameTable(
                name: "Tableros",
                newName: "Tablero");

            migrationBuilder.RenameTable(
                name: "Listas",
                newName: "Lista");

            migrationBuilder.RenameTable(
                name: "Comentarios",
                newName: "Comentario");

            migrationBuilder.RenameTable(
                name: "Adjuntos",
                newName: "Adjunto");

            migrationBuilder.RenameIndex(
                name: "IX_Tarjetas_ListaId",
                table: "Tarjeta",
                newName: "IX_Tarjeta_ListaId");

            migrationBuilder.RenameIndex(
                name: "IX_Tableros_PropietarioId",
                table: "Tablero",
                newName: "IX_Tablero_PropietarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Listas_TableroId",
                table: "Lista",
                newName: "IX_Lista_TableroId");

            migrationBuilder.RenameIndex(
                name: "IX_Comentarios_UsuarioId",
                table: "Comentario",
                newName: "IX_Comentario_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Comentarios_TarjetaId",
                table: "Comentario",
                newName: "IX_Comentario_TarjetaId");

            migrationBuilder.RenameIndex(
                name: "IX_Adjuntos_TarjetaId",
                table: "Adjunto",
                newName: "IX_Adjunto_TarjetaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tarjeta",
                table: "Tarjeta",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tablero",
                table: "Tablero",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lista",
                table: "Lista",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comentario",
                table: "Comentario",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Adjunto",
                table: "Adjunto",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Adjunto_Tarjeta_TarjetaId",
                table: "Adjunto",
                column: "TarjetaId",
                principalTable: "Tarjeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comentario_Tarjeta_TarjetaId",
                table: "Comentario",
                column: "TarjetaId",
                principalTable: "Tarjeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comentario_Usuarios_UsuarioId",
                table: "Comentario",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lista_Tablero_TableroId",
                table: "Lista",
                column: "TableroId",
                principalTable: "Tablero",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tablero_Usuarios_PropietarioId",
                table: "Tablero",
                column: "PropietarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarjeta_Lista_ListaId",
                table: "Tarjeta",
                column: "ListaId",
                principalTable: "Lista",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adjunto_Tarjeta_TarjetaId",
                table: "Adjunto");

            migrationBuilder.DropForeignKey(
                name: "FK_Comentario_Tarjeta_TarjetaId",
                table: "Comentario");

            migrationBuilder.DropForeignKey(
                name: "FK_Comentario_Usuarios_UsuarioId",
                table: "Comentario");

            migrationBuilder.DropForeignKey(
                name: "FK_Lista_Tablero_TableroId",
                table: "Lista");

            migrationBuilder.DropForeignKey(
                name: "FK_Tablero_Usuarios_PropietarioId",
                table: "Tablero");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarjeta_Lista_ListaId",
                table: "Tarjeta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tarjeta",
                table: "Tarjeta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tablero",
                table: "Tablero");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lista",
                table: "Lista");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comentario",
                table: "Comentario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Adjunto",
                table: "Adjunto");

            migrationBuilder.RenameTable(
                name: "Tarjeta",
                newName: "Tarjetas");

            migrationBuilder.RenameTable(
                name: "Tablero",
                newName: "Tableros");

            migrationBuilder.RenameTable(
                name: "Lista",
                newName: "Listas");

            migrationBuilder.RenameTable(
                name: "Comentario",
                newName: "Comentarios");

            migrationBuilder.RenameTable(
                name: "Adjunto",
                newName: "Adjuntos");

            migrationBuilder.RenameIndex(
                name: "IX_Tarjeta_ListaId",
                table: "Tarjetas",
                newName: "IX_Tarjetas_ListaId");

            migrationBuilder.RenameIndex(
                name: "IX_Tablero_PropietarioId",
                table: "Tableros",
                newName: "IX_Tableros_PropietarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Lista_TableroId",
                table: "Listas",
                newName: "IX_Listas_TableroId");

            migrationBuilder.RenameIndex(
                name: "IX_Comentario_UsuarioId",
                table: "Comentarios",
                newName: "IX_Comentarios_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Comentario_TarjetaId",
                table: "Comentarios",
                newName: "IX_Comentarios_TarjetaId");

            migrationBuilder.RenameIndex(
                name: "IX_Adjunto_TarjetaId",
                table: "Adjuntos",
                newName: "IX_Adjuntos_TarjetaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tarjetas",
                table: "Tarjetas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tableros",
                table: "Tableros",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Listas",
                table: "Listas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comentarios",
                table: "Comentarios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Adjuntos",
                table: "Adjuntos",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Etiquetas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Color = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etiquetas", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Adjuntos_Tarjetas_TarjetaId",
                table: "Adjuntos",
                column: "TarjetaId",
                principalTable: "Tarjetas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Tarjetas_TarjetaId",
                table: "Comentarios",
                column: "TarjetaId",
                principalTable: "Tarjetas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Usuarios_UsuarioId",
                table: "Comentarios",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Listas_Tableros_TableroId",
                table: "Listas",
                column: "TableroId",
                principalTable: "Tableros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tableros_Usuarios_PropietarioId",
                table: "Tableros",
                column: "PropietarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarjetas_Listas_ListaId",
                table: "Tarjetas",
                column: "ListaId",
                principalTable: "Listas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
