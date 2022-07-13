using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace notaria.Migrations
{
    public partial class TableToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArchivoTramiteEntity_Tramite_tramiteId",
                table: "ArchivoTramiteEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_ArchivoTramiteEntity_Users_usuarioCreoId",
                table: "ArchivoTramiteEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArchivoTramiteEntity",
                table: "ArchivoTramiteEntity");

            migrationBuilder.RenameTable(
                name: "ArchivoTramiteEntity",
                newName: "ArchivoTramite");

            migrationBuilder.RenameIndex(
                name: "IX_ArchivoTramiteEntity_usuarioCreoId",
                table: "ArchivoTramite",
                newName: "IX_ArchivoTramite_usuarioCreoId");

            migrationBuilder.RenameIndex(
                name: "IX_ArchivoTramiteEntity_tramiteId",
                table: "ArchivoTramite",
                newName: "IX_ArchivoTramite_tramiteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArchivoTramite",
                table: "ArchivoTramite",
                column: "id");

            migrationBuilder.CreateTable(
                name: "Tokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Correo = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Confirmado = table.Column<bool>(type: "bit", nullable: true),
                    FechaCreado = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tokens", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ArchivoTramite_Tramite_tramiteId",
                table: "ArchivoTramite",
                column: "tramiteId",
                principalTable: "Tramite",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_ArchivoTramite_Users_usuarioCreoId",
                table: "ArchivoTramite",
                column: "usuarioCreoId",
                principalTable: "Users",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArchivoTramite_Tramite_tramiteId",
                table: "ArchivoTramite");

            migrationBuilder.DropForeignKey(
                name: "FK_ArchivoTramite_Users_usuarioCreoId",
                table: "ArchivoTramite");

            migrationBuilder.DropTable(
                name: "Tokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArchivoTramite",
                table: "ArchivoTramite");

            migrationBuilder.RenameTable(
                name: "ArchivoTramite",
                newName: "ArchivoTramiteEntity");

            migrationBuilder.RenameIndex(
                name: "IX_ArchivoTramite_usuarioCreoId",
                table: "ArchivoTramiteEntity",
                newName: "IX_ArchivoTramiteEntity_usuarioCreoId");

            migrationBuilder.RenameIndex(
                name: "IX_ArchivoTramite_tramiteId",
                table: "ArchivoTramiteEntity",
                newName: "IX_ArchivoTramiteEntity_tramiteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArchivoTramiteEntity",
                table: "ArchivoTramiteEntity",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_ArchivoTramiteEntity_Tramite_tramiteId",
                table: "ArchivoTramiteEntity",
                column: "tramiteId",
                principalTable: "Tramite",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_ArchivoTramiteEntity_Users_usuarioCreoId",
                table: "ArchivoTramiteEntity",
                column: "usuarioCreoId",
                principalTable: "Users",
                principalColumn: "id");
        }
    }
}
