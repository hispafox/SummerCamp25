﻿// <auto-generated />
using System;
using ApiPaisesProyecto.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiPaises8.Migrations
{
    [DbContext(typeof(ContextoApi))]
    [Migration("20250723120721_inicial")]
    partial class inicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.18");

            modelBuilder.Entity("ConversorAcme.Api.Entidades.Pais", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Capital")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaFinTemporadaAlta")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaInicioTemporadaAlta")
                        .HasColumnType("TEXT");

                    b.Property<string>("Idioma")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Paises");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Capital = "Madrid",
                            FechaFinTemporadaAlta = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FechaInicioTemporadaAlta = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Idioma = "Español",
                            Nombre = "España"
                        },
                        new
                        {
                            Id = 2,
                            Capital = "París",
                            FechaFinTemporadaAlta = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FechaInicioTemporadaAlta = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Idioma = "Francés",
                            Nombre = "Francia"
                        },
                        new
                        {
                            Id = 3,
                            Capital = "Roma",
                            FechaFinTemporadaAlta = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FechaInicioTemporadaAlta = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Idioma = "Italiano",
                            Nombre = "Italia"
                        });
                });

            modelBuilder.Entity("ConversorAcme.Api.Entidades.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Apellidos")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Apellidos = "García",
                            Email = "",
                            Nombre = "Juan"
                        },
                        new
                        {
                            Id = 2,
                            Apellidos = "Lopez",
                            Email = "",
                            Nombre = "Maria"
                        },
                        new
                        {
                            Id = 3,
                            Apellidos = "Gomez",
                            Email = "",
                            Nombre = "Pedro"
                        },
                        new
                        {
                            Id = 4,
                            Apellidos = "Rodriguez",
                            Email = "",
                            Nombre = "Laura"
                        },
                        new
                        {
                            Id = 5,
                            Apellidos = "Perez",
                            Email = "",
                            Nombre = "Carlos"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
