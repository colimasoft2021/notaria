using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace notaria.Migrations
{
    public partial class SeedersInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Rol",
                columns: new[] { "rolName" },
                values: new object[,]
                {
                    { "Administrador" },
                    { "Usuario" }
                }
            );

            migrationBuilder.InsertData(
                table: "Estatus",
                columns: new[] { "estatus" },
                values: new object[,]
                {
                    { "Completado" },
                    { "En Proceso" },
                    { "Vencido" }
                }
            );

            migrationBuilder.InsertData(
                table: "TipoActo",
                columns: new[] { "tipoActo", "numeroDePasos" },
                values: new object[,]
                {
                    { "Certificación de copias de documentos", 5  },
                    { "Testamentos", 7 },
                    { "Titulo de Compraventa", 8 },
                    { "Créditos Hipotecarios", 6 },
                    { "Escritura de propiedades", 5 },
                    { "Actas constitutivas", 9 },
                    { "Cartas poder", 4 },
                    { "Constitución de fideicomisos y sociedades", 5 },
                    { "Poderes notariales", 6 },
                    { "Adjudicaciones", 6 },
                    { "Certificaciones", 6 },

                    { "Contratos de arrendamiento", 6 },
                    { "Sociedades", 6 },
                    { "Sucesiones", 6 },
                    { "Donaciones", 6 },
                    { "Alianzas", 6 },
                    { "Escisiones", 6 },
                    { "Predio", 6 },
                    { "Cotejos", 6 },
                    { "Fideicomisos", 6 },
                    { "Ratificaciones", 6 },
                    { "Créditos", 6 }
                }
            );

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "nombre", "apellido", "correo", "clave", "Activo", "modificar", "rolId" },
                values: new object[,] {//Clave 1234567890
                    { "DEV", "ColimaSoft", "colimasoft@colimasoft.com", "x3Xnt1ft5jDNCqERO9ECZhqziCnKUqZCKreChi8mhkY=", true, true, 1 }
                }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
