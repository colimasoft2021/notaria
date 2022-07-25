using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace notaria.Migrations
{
    public partial class ActualizarPasoTramite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "campoRegistroPublicoPropiedad",
                table: "TramitePaso",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "campoTrasladoDominio",
                table: "TramitePaso",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "esParalelo",
                table: "TramitePaso",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "permitirArchivo",
                table: "TramitePaso",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "campoRegistroPublicoPropiedad",
                table: "TramitePaso");

            migrationBuilder.DropColumn(
                name: "campoTrasladoDominio",
                table: "TramitePaso");

            migrationBuilder.DropColumn(
                name: "esParalelo",
                table: "TramitePaso");

            migrationBuilder.DropColumn(
                name: "permitirArchivo",
                table: "TramitePaso");
        }
    }
}
