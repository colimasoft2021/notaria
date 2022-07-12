﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using notaria.DataContext;

#nullable disable

namespace notaria.Migrations
{
    [DbContext(typeof(NotariaContext))]
    [Migration("20220627145450_TableToken")]
    partial class TableToken
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("notaria.DataEntities.ActoEntity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int?>("diasHabiles")
                        .HasColumnType("int");

                    b.Property<int?>("numeroDePasos")
                        .HasColumnType("int");

                    b.Property<int?>("tipoActoId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("tipoActoId");

                    b.ToTable("Acto");
                });

            modelBuilder.Entity("notaria.DataEntities.ArchivoPasoTramiteEntity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<DateTime?>("fechaActualizacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("fechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<int?>("pasoTramiteId")
                        .HasColumnType("int");

                    b.Property<string>("urlArchivo")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int?>("usuarioCreoId")
                        .HasColumnType("int");

                    b.Property<int?>("usuarioModificoId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("pasoTramiteId");

                    b.HasIndex("usuarioCreoId");

                    b.ToTable("ArchivoPasoTramite");
                });

            modelBuilder.Entity("notaria.DataEntities.ArchivoTramiteEntity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<DateTime?>("fechaActualizacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("fechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<int?>("tramiteId")
                        .HasColumnType("int");

                    b.Property<string>("urlArchivo")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int?>("usuarioCreoId")
                        .HasColumnType("int");

                    b.Property<int?>("usuarioModificoId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("tramiteId");

                    b.HasIndex("usuarioCreoId");

                    b.ToTable("ArchivoTramite");
                });

            modelBuilder.Entity("notaria.DataEntities.EstatusEntity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("estatus")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.ToTable("Estatus");
                });

            modelBuilder.Entity("notaria.DataEntities.PasoActoEntity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int?>("actoId")
                        .HasColumnType("int");

                    b.Property<bool?>("calificacionPositivoRPP")
                        .HasColumnType("bit");

                    b.Property<bool?>("campoRegistroPublicoPropiedad")
                        .HasColumnType("bit");

                    b.Property<bool?>("campoTrasladoDominio")
                        .HasColumnType("bit");

                    b.Property<bool?>("deRechazoTD")
                        .HasColumnType("bit");

                    b.Property<bool?>("deSalidaTD")
                        .HasColumnType("bit");

                    b.Property<int?>("diasHabiles")
                        .HasColumnType("int");

                    b.Property<bool?>("esIndependiente")
                        .HasColumnType("bit");

                    b.Property<bool?>("esParalelo")
                        .HasColumnType("bit");

                    b.Property<bool?>("fechaEnviadoActivoTD")
                        .HasColumnType("bit");

                    b.Property<bool?>("fechaPositivoFirmaRPP")
                        .HasColumnType("bit");

                    b.Property<bool?>("fechaPositivoPagoRPP")
                        .HasColumnType("bit");

                    b.Property<bool?>("fechaPositivoSelloRPP")
                        .HasColumnType("bit");

                    b.Property<bool?>("fechaRechazoEnviadoTD")
                        .HasColumnType("bit");

                    b.Property<bool?>("fechaRechazoRevisionTD")
                        .HasColumnType("bit");

                    b.Property<bool?>("fechaRechazoTD")
                        .HasColumnType("bit");

                    b.Property<bool?>("fechaReingresoRechazoRPP")
                        .HasColumnType("bit");

                    b.Property<bool?>("fechaRevisionTD")
                        .HasColumnType("bit");

                    b.Property<bool?>("motivoRechazoRPP")
                        .HasColumnType("bit");

                    b.Property<bool?>("motivoRechazoTD")
                        .HasColumnType("bit");

                    b.Property<bool?>("permitirArchivo")
                        .HasColumnType("bit");

                    b.Property<bool?>("positivoRPP")
                        .HasColumnType("bit");

                    b.Property<bool?>("rechazoRPP")
                        .HasColumnType("bit");

                    b.Property<string>("titulo")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("id");

                    b.HasIndex("actoId");

                    b.ToTable("PasoActo");
                });

            modelBuilder.Entity("notaria.DataEntities.RolEntity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("rolName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("id");

                    b.ToTable("Rol");
                });

            modelBuilder.Entity("notaria.DataEntities.TipoActoEntity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int?>("numeroDePasos")
                        .HasColumnType("int");

                    b.Property<string>("tipoActo")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.ToTable("TipoActo");
                });

            modelBuilder.Entity("notaria.DataEntities.TokenEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool?>("Confirmado")
                        .HasColumnType("bit");

                    b.Property<string>("Correo")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("FechaCreado")
                        .HasColumnType("datetime2");

                    b.Property<string>("Token")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Tokens");
                });

            modelBuilder.Entity("notaria.DataEntities.TramiteEntity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int?>("actoId")
                        .HasColumnType("int");

                    b.Property<int?>("diasHabiles")
                        .HasColumnType("int");

                    b.Property<int?>("estatusId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("fechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("fechaEscritura")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("fechaFirma")
                        .HasColumnType("datetime2");

                    b.Property<string>("numeroDeEscritura")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("parteA")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("parteB")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("usuarioId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("actoId");

                    b.HasIndex("estatusId");

                    b.HasIndex("usuarioId");

                    b.ToTable("Tramite");
                });

            modelBuilder.Entity("notaria.DataEntities.TramitePasoEntity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("calificacionPositivoRPP")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int?>("diasHabiles")
                        .HasColumnType("int");

                    b.Property<int?>("diasRetraso")
                        .HasColumnType("int");

                    b.Property<int?>("estatusId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("fechaDeSalidaTD")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("fechaEnviadoActivoTD")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("fechaPositivoFirmaRPP")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("fechaPositivoPagoRPP")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("fechaPositivoSelloRPP")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("fechaRealizado")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("fechaRechazoEnviadoTD")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("fechaRechazoRevisionTD")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("fechaRechazoTD")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("fechaReingresoRechazoRPP")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("fechaRevisionTD")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("fechaVencimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("motivoRechazoRPP")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("motivoRechazoTD")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int?>("pasoActoId")
                        .HasColumnType("int");

                    b.Property<bool?>("positivoRPP")
                        .HasColumnType("bit");

                    b.Property<bool?>("rechazoRPP")
                        .HasColumnType("bit");

                    b.Property<bool?>("rechazoTD")
                        .HasColumnType("bit");

                    b.Property<string>("titulo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("tramiteId")
                        .HasColumnType("int");

                    b.Property<int?>("usuarioId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("estatusId");

                    b.HasIndex("pasoActoId");

                    b.HasIndex("tramiteId");

                    b.HasIndex("usuarioId");

                    b.ToTable("TramitePaso");
                });

            modelBuilder.Entity("notaria.DataEntities.UserEntity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("apellido")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("clave")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("correo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool?>("modificar")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("rolId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("rolId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("notaria.DataEntities.ActoEntity", b =>
                {
                    b.HasOne("notaria.DataEntities.TipoActoEntity", "TipoActoEntity")
                        .WithMany()
                        .HasForeignKey("tipoActoId");

                    b.Navigation("TipoActoEntity");
                });

            modelBuilder.Entity("notaria.DataEntities.ArchivoPasoTramiteEntity", b =>
                {
                    b.HasOne("notaria.DataEntities.TramitePasoEntity", "TramitePasoEntity")
                        .WithMany()
                        .HasForeignKey("pasoTramiteId");

                    b.HasOne("notaria.DataEntities.UserEntity", "UserEntity")
                        .WithMany()
                        .HasForeignKey("usuarioCreoId");

                    b.Navigation("TramitePasoEntity");

                    b.Navigation("UserEntity");
                });

            modelBuilder.Entity("notaria.DataEntities.ArchivoTramiteEntity", b =>
                {
                    b.HasOne("notaria.DataEntities.TramiteEntity", "TramiteEntity")
                        .WithMany()
                        .HasForeignKey("tramiteId");

                    b.HasOne("notaria.DataEntities.UserEntity", "UserEntity")
                        .WithMany()
                        .HasForeignKey("usuarioCreoId");

                    b.Navigation("TramiteEntity");

                    b.Navigation("UserEntity");
                });

            modelBuilder.Entity("notaria.DataEntities.PasoActoEntity", b =>
                {
                    b.HasOne("notaria.DataEntities.ActoEntity", "ActoEntity")
                        .WithMany()
                        .HasForeignKey("actoId");

                    b.Navigation("ActoEntity");
                });

            modelBuilder.Entity("notaria.DataEntities.TramiteEntity", b =>
                {
                    b.HasOne("notaria.DataEntities.ActoEntity", "ActoEntity")
                        .WithMany()
                        .HasForeignKey("actoId");

                    b.HasOne("notaria.DataEntities.EstatusEntity", "EstatusEntity")
                        .WithMany()
                        .HasForeignKey("estatusId");

                    b.HasOne("notaria.DataEntities.UserEntity", "UserEntity")
                        .WithMany()
                        .HasForeignKey("usuarioId");

                    b.Navigation("ActoEntity");

                    b.Navigation("EstatusEntity");

                    b.Navigation("UserEntity");
                });

            modelBuilder.Entity("notaria.DataEntities.TramitePasoEntity", b =>
                {
                    b.HasOne("notaria.DataEntities.EstatusEntity", "EstatusEntity")
                        .WithMany()
                        .HasForeignKey("estatusId");

                    b.HasOne("notaria.DataEntities.PasoActoEntity", "PasoActoEntity")
                        .WithMany()
                        .HasForeignKey("pasoActoId");

                    b.HasOne("notaria.DataEntities.TramiteEntity", "TramiteEntity")
                        .WithMany()
                        .HasForeignKey("tramiteId");

                    b.HasOne("notaria.DataEntities.UserEntity", "UserEntity")
                        .WithMany()
                        .HasForeignKey("usuarioId");

                    b.Navigation("EstatusEntity");

                    b.Navigation("PasoActoEntity");

                    b.Navigation("TramiteEntity");

                    b.Navigation("UserEntity");
                });

            modelBuilder.Entity("notaria.DataEntities.UserEntity", b =>
                {
                    b.HasOne("notaria.DataEntities.RolEntity", "RolEntity")
                        .WithMany()
                        .HasForeignKey("rolId");

                    b.Navigation("RolEntity");
                });
#pragma warning restore 612, 618
        }
    }
}
