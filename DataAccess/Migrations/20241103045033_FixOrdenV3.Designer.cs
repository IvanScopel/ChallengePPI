﻿// <auto-generated />
using DataAccess.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(ChallengePPIContext))]
    [Migration("20241103045033_FixOrdenV3")]
    partial class FixOrdenV3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("Modern_Spanish_CI_AS")
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entities.Activo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PrecioUnitario")
                        .HasColumnType("float");

                    b.Property<string>("Ticker")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<int>("TipoActivoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TipoActivoId");

                    b.ToTable("Activos");

                    b.HasDiscriminator<string>("Tipo").HasValue("Activo");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Entities.Orden", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ActivoId")
                        .HasColumnType("int");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("CuentaId")
                        .HasColumnType("int");

                    b.Property<double>("MontoTotal")
                        .HasColumnType("float");

                    b.Property<string>("Operacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<double>("Precio")
                        .HasColumnType("float");

                    b.Property<int>("TipoEstadoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ActivoId");

                    b.HasIndex("TipoEstadoId");

                    b.ToTable("Ordenes");
                });

            modelBuilder.Entity("Entities.TipoActivo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TipoActivos");
                });

            modelBuilder.Entity("Entities.TipoEstado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TipoEstados");
                });

            modelBuilder.Entity("Entities.Activos.Accion", b =>
                {
                    b.HasBaseType("Entities.Activo");

                    b.HasDiscriminator().HasValue("Accion");
                });

            modelBuilder.Entity("Entities.Activos.Bono", b =>
                {
                    b.HasBaseType("Entities.Activo");

                    b.HasDiscriminator().HasValue("Bono");
                });

            modelBuilder.Entity("Entities.Activos.FCI", b =>
                {
                    b.HasBaseType("Entities.Activo");

                    b.HasDiscriminator().HasValue("FCI");
                });

            modelBuilder.Entity("Entities.Activo", b =>
                {
                    b.HasOne("Entities.TipoActivo", "TipoActivo")
                        .WithMany("Activos")
                        .HasForeignKey("TipoActivoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoActivo");
                });

            modelBuilder.Entity("Entities.Orden", b =>
                {
                    b.HasOne("Entities.Activo", "Activo")
                        .WithMany()
                        .HasForeignKey("ActivoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.TipoEstado", "Estado")
                        .WithMany()
                        .HasForeignKey("TipoEstadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Activo");

                    b.Navigation("Estado");
                });

            modelBuilder.Entity("Entities.TipoActivo", b =>
                {
                    b.Navigation("Activos");
                });
#pragma warning restore 612, 618
        }
    }
}
