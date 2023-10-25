﻿// <auto-generated />
using System;
using FerrocarrilNCA;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FerrocarrilNCA.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231024032632_Inicial")]
    partial class Inicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FerrocarrilNCA.Entidades.BaseOperativa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Ubicacion")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("BaseOperativas");
                });

            modelBuilder.Entity("FerrocarrilNCA.Entidades.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Art2000")
                        .HasColumnType("bit");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("EmpleadoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmpleadoId")
                        .IsUnique();

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("FerrocarrilNCA.Entidades.Empleado", b =>
                {
                    b.Property<int>("Legajo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Legajo"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("BaseOperativaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaIngreso")
                        .HasColumnType("date");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("ServicioId")
                        .HasColumnType("int");

                    b.HasKey("Legajo");

                    b.HasIndex("BaseOperativaId");

                    b.HasIndex("ServicioId");

                    b.ToTable("Empleados");
                });

            modelBuilder.Entity("FerrocarrilNCA.Entidades.Servicio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<decimal>("Item")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Servicios");
                });

            modelBuilder.Entity("FerrocarrilNCA.Entidades.Sueldo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("CantServicios")
                        .HasColumnType("int");

                    b.Property<int>("EmpleadoId")
                        .HasColumnType("int");

                    b.Property<int>("Total")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("EmpleadoId")
                        .IsUnique();

                    b.ToTable("Sueldos");
                });

            modelBuilder.Entity("FerrocarrilNCA.Entidades.Categoria", b =>
                {
                    b.HasOne("FerrocarrilNCA.Entidades.Empleado", "EmpleadoNavegation")
                        .WithOne("CategoriaNavegation")
                        .HasForeignKey("FerrocarrilNCA.Entidades.Categoria", "EmpleadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EmpleadoNavegation");
                });

            modelBuilder.Entity("FerrocarrilNCA.Entidades.Empleado", b =>
                {
                    b.HasOne("FerrocarrilNCA.Entidades.BaseOperativa", "BaseOperativaNavegation")
                        .WithMany("EmpleadoNavegation")
                        .HasForeignKey("BaseOperativaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FerrocarrilNCA.Entidades.Servicio", "ServicioNavegation")
                        .WithMany("EmpleadoNavegation")
                        .HasForeignKey("ServicioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BaseOperativaNavegation");

                    b.Navigation("ServicioNavegation");
                });

            modelBuilder.Entity("FerrocarrilNCA.Entidades.Sueldo", b =>
                {
                    b.HasOne("FerrocarrilNCA.Entidades.Empleado", "EmpleadoNavegation")
                        .WithOne("SueldoNavegation")
                        .HasForeignKey("FerrocarrilNCA.Entidades.Sueldo", "EmpleadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EmpleadoNavegation");
                });

            modelBuilder.Entity("FerrocarrilNCA.Entidades.BaseOperativa", b =>
                {
                    b.Navigation("EmpleadoNavegation");
                });

            modelBuilder.Entity("FerrocarrilNCA.Entidades.Empleado", b =>
                {
                    b.Navigation("CategoriaNavegation")
                        .IsRequired();

                    b.Navigation("SueldoNavegation")
                        .IsRequired();
                });

            modelBuilder.Entity("FerrocarrilNCA.Entidades.Servicio", b =>
                {
                    b.Navigation("EmpleadoNavegation");
                });
#pragma warning restore 612, 618
        }
    }
}