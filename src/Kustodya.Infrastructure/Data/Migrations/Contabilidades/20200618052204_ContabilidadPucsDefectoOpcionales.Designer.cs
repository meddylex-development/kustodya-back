﻿// <auto-generated />
using System;
using Kustodya.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Kustodya.Infrastructure.Data.Contabilidades;

namespace Kustodya.Infrastructure.Data.Migrations.Contabilidades
{
    [DbContext(typeof(ContabilidadContext))]
    [Migration("20200618052204_ContabilidadPucsDefectoOpcionales")]
    partial class ContabilidadPucsDefectoOpcionales
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Contabilidad")
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Kustodya.ApplicationCore.Entities.Contabilidad.CentroCosto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RegionalId")
                        .HasColumnType("int");

                    b.Property<int?>("SegmentoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RegionalId");

                    b.HasIndex("SegmentoId");

                    b.ToTable("CentroCosto");
                });

            modelBuilder.Entity("Kustodya.Contabilidad", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid?>("CodigoPucCreditoMovimientoPorDefecto")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CodigoPucDebitoMovimientoPorDefecto")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescripcionMovimientoPorDefecto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EntidadId")
                        .HasColumnType("int");

                    b.Property<string>("ReferenciaMovimientoPorDefecto")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CodigoPucCreditoMovimientoPorDefecto")
                        .IsUnique()
                        .HasFilter("[CodigoPucCreditoMovimientoPorDefecto] IS NOT NULL");

                    b.HasIndex("CodigoPucDebitoMovimientoPorDefecto")
                        .IsUnique()
                        .HasFilter("[CodigoPucDebitoMovimientoPorDefecto] IS NOT NULL");

                    b.HasIndex("EntidadId", "Codigo")
                        .IsUnique()
                        .HasFilter("[Codigo] IS NOT NULL");

                    b.ToTable("Contabilidades");
                });

            modelBuilder.Entity("Kustodya.ApplicationCore.Entities.Contabilidad.DepuracionContable", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccionesRealizadas")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Anexos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ClaseDocumento")
                        .HasColumnType("int");

                    b.Property<Guid>("ContabilidadId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("CoordinadorId")
                        .HasColumnType("int");

                    b.Property<string>("DescripcionFicha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DisposicionesLegales")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ElaboradoporId")
                        .HasColumnType("int");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaElaboracion")
                        .HasColumnType("datetime2");

                    b.Property<string>("FichaTecnica")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FichaTecnicaAprobada")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Folios")
                        .HasColumnType("int");

                    b.Property<int?>("GerenteId")
                        .HasColumnType("int");

                    b.Property<int?>("InterventorId")
                        .HasColumnType("int");

                    b.Property<string>("Recomendaciones")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SegmentoId")
                        .HasColumnType("int");

                    b.Property<string>("SituacionEncontrada")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Subcuenta")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioCreacion")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ContabilidadId");

                    b.HasIndex("SegmentoId");

                    b.ToTable("DepuracionesContables");
                });

            modelBuilder.Entity("Kustodya.ApplicationCore.Movimiento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CentroBeneficioId")
                        .HasColumnType("int");

                    b.Property<long>("CodigoContable")
                        .HasColumnType("bigint");

                    b.Property<int?>("Credito")
                        .HasColumnType("int");

                    b.Property<int?>("Debito")
                        .HasColumnType("int");

                    b.Property<Guid>("DepuracionContableId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DescripcionMovimiento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EntidadId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("NitTercero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("NumComprobanteCierre")
                        .HasColumnType("bigint");

                    b.Property<string>("Referencia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReferenciacionSoportes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoAjuste")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsuarioCreacion")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CentroBeneficioId");

                    b.HasIndex("DepuracionContableId");

                    b.ToTable("Movimientos");
                });

            modelBuilder.Entity("Kustodya.ApplicationCore.Entities.Contabilidad.Puc", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ContabilidadId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoContabilidad")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ContabilidadId");

                    b.ToTable("Pucs");
                });

            modelBuilder.Entity("Kustodya.ApplicationCore.Entities.Contabilidad.Regional", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Codigo")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Regional");
                });

            modelBuilder.Entity("Kustodya.ApplicationCore.Entities.Contabilidad.Segmento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Codigo")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Segmento");
                });

            modelBuilder.Entity("Kustodya.ApplicationCore.Entities.Contabilidad.CentroCosto", b =>
                {
                    b.HasOne("Kustodya.ApplicationCore.Entities.Contabilidad.Regional", "Regional")
                        .WithMany()
                        .HasForeignKey("RegionalId");

                    b.HasOne("Kustodya.ApplicationCore.Entities.Contabilidad.Segmento", "Segmento")
                        .WithMany()
                        .HasForeignKey("SegmentoId");
                });

            modelBuilder.Entity("Kustodya.Contabilidad", b =>
                {
                    b.HasOne("Kustodya.ApplicationCore.Entities.Contabilidad.Puc", "PucCreditoPorDefecto")
                        .WithOne()
                        .HasForeignKey("Kustodya.Contabilidad", "CodigoPucCreditoMovimientoPorDefecto")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Kustodya.ApplicationCore.Entities.Contabilidad.Puc", "PucDebitoPorDefecto")
                        .WithOne()
                        .HasForeignKey("Kustodya.Contabilidad", "CodigoPucDebitoMovimientoPorDefecto")
                        .OnDelete(DeleteBehavior.NoAction);
                });

            modelBuilder.Entity("Kustodya.ApplicationCore.Entities.Contabilidad.DepuracionContable", b =>
                {
                    b.HasOne("Kustodya.Contabilidad", "Contabilidad")
                        .WithMany("DepuracionesContables")
                        .HasForeignKey("ContabilidadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kustodya.ApplicationCore.Entities.Contabilidad.Segmento", "Segmento")
                        .WithMany()
                        .HasForeignKey("SegmentoId");
                });

            modelBuilder.Entity("Kustodya.ApplicationCore.Movimiento", b =>
                {
                    b.HasOne("Kustodya.ApplicationCore.Entities.Contabilidad.CentroCosto", "CentroBeneficio")
                        .WithMany()
                        .HasForeignKey("CentroBeneficioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kustodya.ApplicationCore.Entities.Contabilidad.DepuracionContable", "DepuracionContable")
                        .WithMany("Movimientos")
                        .HasForeignKey("DepuracionContableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Kustodya.ApplicationCore.Entities.Contabilidad.Puc", b =>
                {
                    b.HasOne("Kustodya.Contabilidad", "Contabilidad")
                        .WithMany("Pucs")
                        .HasForeignKey("ContabilidadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}