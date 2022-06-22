﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace notaria.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estatus",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    estatus = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estatus", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rolName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TipoActo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipoActo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    numeroDePasos = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoActo", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    apellido = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    correo = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    clave = table.Column<string>(type: "varchar(max)", maxLength: 2147483647, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    modificar = table.Column<bool>(type: "bit", nullable: false),
                    rolId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                    table.ForeignKey(
                        name: "FK_Users_Rol_rolId",
                        column: x => x.rolId,
                        principalTable: "Rol",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Acto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    diasHabiles = table.Column<int>(type: "int", nullable: true),
                    numeroDePasos = table.Column<int>(type: "int", nullable: true),
                    tipoActoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acto", x => x.id);
                    table.ForeignKey(
                        name: "FK_Acto_TipoActo_tipoActoId",
                        column: x => x.tipoActoId,
                        principalTable: "TipoActo",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "PasoActo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    diasHabiles = table.Column<int>(type: "int", nullable: true),
                    titulo = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    permitirArchivo = table.Column<bool>(type: "bit", nullable: true),
                    esParalelo = table.Column<bool>(type: "bit", nullable: true),
                    esIndependiente = table.Column<bool>(type: "bit", nullable: true),
                    campoTrasladoDominio = table.Column<bool>(type: "bit", nullable: true),
                    campoRegistroPublicoPropiedad = table.Column<bool>(type: "bit", nullable: true),
                    fechaEnviadoActivoTD = table.Column<bool>(type: "bit", nullable: true),
                    deSalidaTD = table.Column<bool>(type: "bit", nullable: true),
                    fechaRevisionTD = table.Column<bool>(type: "bit", nullable: true),
                    deRechazoTD = table.Column<bool>(type: "bit", nullable: true),
                    fechaRechazoTD = table.Column<bool>(type: "bit", nullable: true),
                    motivoRechazoTD = table.Column<bool>(type: "bit", nullable: true),
                    fechaRechazoEnviadoTD = table.Column<bool>(type: "bit", nullable: true),
                    fechaRechazoRevisionTD = table.Column<bool>(type: "bit", nullable: true),
                    positivoRPP = table.Column<bool>(type: "bit", nullable: true),
                    fechaPositivoFirmaRPP = table.Column<bool>(type: "bit", nullable: true),
                    fechaPositivoPagoRPP = table.Column<bool>(type: "bit", nullable: true),
                    fechaPositivoSelloRPP = table.Column<bool>(type: "bit", nullable: true),
                    calificacionPositivoRPP = table.Column<bool>(type: "bit", nullable: true),
                    rechazoRPP = table.Column<bool>(type: "bit", nullable: true),
                    fechaReingresoRechazoRPP = table.Column<bool>(type: "bit", nullable: true),
                    motivoRechazoRPP = table.Column<bool>(type: "bit", nullable: true),
                    actoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasoActo", x => x.id);
                    table.ForeignKey(
                        name: "FK_PasoActo_Acto_actoId",
                        column: x => x.actoId,
                        principalTable: "Acto",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Tramite",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numeroDeEscritura = table.Column<string>(type: "varchar(max)", nullable: true),
                    fechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    fechaEscritura = table.Column<DateTime>(type: "datetime2", nullable: true),
                    fechaFirma = table.Column<DateTime>(type: "datetime2", nullable: true),
                    parteA = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    parteB = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    diasHabiles = table.Column<int>(type: "int", nullable: true),
                    usuarioId = table.Column<int>(type: "int", nullable: true),
                    estatusId = table.Column<int>(type: "int", nullable: true),
                    actoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tramite", x => x.id);
                    table.ForeignKey(
                        name: "FK_Tramite_Acto_actoId",
                        column: x => x.actoId,
                        principalTable: "Acto",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Tramite_Estatus_estatusId",
                        column: x => x.estatusId,
                        principalTable: "Estatus",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Tramite_Users_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ArchivoTramite",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    urlArchivo = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    fechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    fechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    tramiteId = table.Column<int>(type: "int", nullable: true),
                    usuarioCreoId = table.Column<int>(type: "int", nullable: true),
                    usuarioModificoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchivoTramite", x => x.id);
                    table.ForeignKey(
                        name: "FK_ArchivoTramite_Tramite_tramiteId",
                        column: x => x.tramiteId,
                        principalTable: "Tramite",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_ArchivoTramite_Users_usuarioCreoId",
                        column: x => x.usuarioCreoId,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "TramitePaso",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    diasHabiles = table.Column<int>(type: "int", nullable: true),
                    titulo = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    fechaRealizado = table.Column<DateTime>(type: "datetime2", nullable: true),
                    fechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    diasRetraso = table.Column<int>(type: "int", nullable: true),
                    fechaEnviadoActivoTD = table.Column<DateTime>(type: "datetime2", nullable: true),
                    fechaDeSalidaTD = table.Column<DateTime>(type: "datetime2", nullable: true),
                    fechaRevisionTD = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rechazoTD = table.Column<bool>(type: "bit", nullable: true),
                    fechaRechazoTD = table.Column<DateTime>(type: "datetime2", nullable: true),
                    motivoRechazoTD = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    fechaRechazoEnviadoTD = table.Column<DateTime>(type: "datetime2", nullable: true),
                    fechaRechazoRevisionTD = table.Column<DateTime>(type: "datetime2", nullable: true),
                    positivoRPP = table.Column<bool>(type: "bit", nullable: true),
                    fechaPositivoFirmaRPP = table.Column<DateTime>(type: "datetime2", nullable: true),
                    fechaPositivoPagoRPP = table.Column<DateTime>(type: "datetime2", nullable: true),
                    fechaPositivoSelloRPP = table.Column<DateTime>(type: "datetime2", nullable: true),
                    calificacionPositivoRPP = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    rechazoRPP = table.Column<bool>(type: "bit", nullable: true),
                    fechaReingresoRechazoRPP = table.Column<DateTime>(type: "datetime2", nullable: true),
                    motivoRechazoRPP = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    pasoActoId = table.Column<int>(type: "int", nullable: true),
                    estatusId = table.Column<int>(type: "int", nullable: true),
                    usuarioId = table.Column<int>(type: "int", nullable: true),
                    tramiteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TramitePaso", x => x.id);
                    table.ForeignKey(
                        name: "FK_TramitePaso_Estatus_estatusId",
                        column: x => x.estatusId,
                        principalTable: "Estatus",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_TramitePaso_PasoActo_pasoActoId",
                        column: x => x.pasoActoId,
                        principalTable: "PasoActo",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_TramitePaso_Tramite_tramiteId",
                        column: x => x.tramiteId,
                        principalTable: "Tramite",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_TramitePaso_Users_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ArchivoPasoTramite",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    urlArchivo = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    fechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    fechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    pasoTramiteId = table.Column<int>(type: "int", nullable: true),
                    usuarioCreoId = table.Column<int>(type: "int", nullable: true),
                    usuarioModificoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchivoPasoTramite", x => x.id);
                    table.ForeignKey(
                        name: "FK_ArchivoPasoTramite_TramitePaso_pasoTramiteId",
                        column: x => x.pasoTramiteId,
                        principalTable: "TramitePaso",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_ArchivoPasoTramite_Users_usuarioCreoId",
                        column: x => x.usuarioCreoId,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acto_tipoActoId",
                table: "Acto",
                column: "tipoActoId");

            migrationBuilder.CreateIndex(
                name: "IX_ArchivoPasoTramite_pasoTramiteId",
                table: "ArchivoPasoTramite",
                column: "pasoTramiteId");

            migrationBuilder.CreateIndex(
                name: "IX_ArchivoPasoTramite_usuarioCreoId",
                table: "ArchivoPasoTramite",
                column: "usuarioCreoId");

            migrationBuilder.CreateIndex(
                name: "IX_ArchivoTramite_tramiteId",
                table: "ArchivoTramite",
                column: "tramiteId");

            migrationBuilder.CreateIndex(
                name: "IX_ArchivoTramite_usuarioCreoId",
                table: "ArchivoTramite",
                column: "usuarioCreoId");

            migrationBuilder.CreateIndex(
                name: "IX_PasoActo_actoId",
                table: "PasoActo",
                column: "actoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tramite_actoId",
                table: "Tramite",
                column: "actoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tramite_estatusId",
                table: "Tramite",
                column: "estatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Tramite_usuarioId",
                table: "Tramite",
                column: "usuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_TramitePaso_estatusId",
                table: "TramitePaso",
                column: "estatusId");

            migrationBuilder.CreateIndex(
                name: "IX_TramitePaso_pasoActoId",
                table: "TramitePaso",
                column: "pasoActoId");

            migrationBuilder.CreateIndex(
                name: "IX_TramitePaso_tramiteId",
                table: "TramitePaso",
                column: "tramiteId");

            migrationBuilder.CreateIndex(
                name: "IX_TramitePaso_usuarioId",
                table: "TramitePaso",
                column: "usuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_rolId",
                table: "Users",
                column: "rolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArchivoPasoTramite");

            migrationBuilder.DropTable(
                name: "ArchivoTramite");

            migrationBuilder.DropTable(
                name: "TramitePaso");

            migrationBuilder.DropTable(
                name: "PasoActo");

            migrationBuilder.DropTable(
                name: "Tramite");

            migrationBuilder.DropTable(
                name: "Acto");

            migrationBuilder.DropTable(
                name: "Estatus");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "TipoActo");

            migrationBuilder.DropTable(
                name: "Rol");
        }
    }
}
