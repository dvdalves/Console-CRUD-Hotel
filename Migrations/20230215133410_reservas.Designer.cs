﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using CrudHotel;

#nullable disable

namespace Teste.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20230215133410_reservas")]
    partial class reservas
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GerenciadorDeHospedes.GerenciadorDeHospedes+Reserva", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("DiasReservados")
                        .HasColumnType("int");

                    b.Property<string>("NomeHotel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PrecoPorDia")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("reservas");
                });

            modelBuilder.Entity("GerenciadorDeHospedes.Hospede", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Reservaid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Reservaid")
                        .IsUnique()
                        .HasFilter("[Reservaid] IS NOT NULL");

                    b.ToTable("hospedes");
                });

            modelBuilder.Entity("GerenciadorDeHospedes.Hospede", b =>
                {
                    b.HasOne("GerenciadorDeHospedes.GerenciadorDeHospedes+Reserva", null)
                        .WithOne("Hospede")
                        .HasForeignKey("GerenciadorDeHospedes.Hospede", "Reservaid");
                });

            modelBuilder.Entity("GerenciadorDeHospedes.GerenciadorDeHospedes+Reserva", b =>
                {
                    b.Navigation("Hospede");
                });
#pragma warning restore 612, 618
        }
    }
}