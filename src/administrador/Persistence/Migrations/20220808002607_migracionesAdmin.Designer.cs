﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using administrador.Persistence.Database;

#nullable disable

namespace administrador.Persistence.Migrations
{
    [DbContext(typeof(RCVDbContext))]
    [Migration("20220808002607_migracionesAdmin")]
    partial class migracionesAdmin
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "uuid-ossp");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("administrador.Persistence.Entities.AseguradoEntity", b =>
                {
                    b.Property<int>("ci")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ci"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("primer_a")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("primer_n")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("segundo_a")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("segundo_n")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<char>("sexo")
                        .HasColumnType("character(1)");

                    b.HasKey("ci");

                    b.ToTable("asegurado");
                });

            modelBuilder.Entity("administrador.Persistence.Entities.CarrosEntity", b =>
                {
                    b.Property<string>("placa")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("MarcaEntityId")
                        .HasColumnType("uuid")
                        .HasColumnName("marca");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("color")
                        .HasColumnType("text");

                    b.Property<DateTime?>("fabricacion")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("segmento")
                        .HasColumnType("text");

                    b.Property<Guid>("serial")
                        .HasColumnType("uuid");

                    b.HasKey("placa");

                    b.HasIndex("MarcaEntityId");

                    b.ToTable("cars");
                });

            modelBuilder.Entity("administrador.Persistence.Entities.IncidentesEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<Guid>("PolizaEntityId")
                        .HasColumnType("uuid")
                        .HasColumnName("poliza");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.Property<Guid?>("UsuariosEntityId")
                        .HasColumnType("uuid");

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("fecha")
                        .HasColumnType("DATE");

                    b.Property<string>("ubicacion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UsuariosEntityId");

                    b.ToTable("incident");
                });

            modelBuilder.Entity("administrador.Persistence.Entities.MarcaEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.Property<string>("categoria")
                        .HasColumnType("text");

                    b.Property<string>("marca")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("marca");
                });

            modelBuilder.Entity("administrador.Persistence.Entities.PagosEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<Guid>("AnalisisEntityId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.Property<Guid>("UserEntityId")
                        .HasColumnType("uuid");

                    b.Property<int>("costo")
                        .HasColumnType("integer");

                    b.Property<string>("estatus")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("fechaFin")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("fechaInicio")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("pagos");
                });

            modelBuilder.Entity("administrador.Persistence.Entities.PolizaEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<int>("AseguradoEntityId")
                        .HasColumnType("integer")
                        .HasColumnName("dni");

                    b.Property<string>("CarrosEntityId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("placa");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.Property<int>("cobertura")
                        .HasColumnType("integer");

                    b.Property<DateTime>("compra")
                        .HasColumnType("DATE");

                    b.Property<bool>("desactivada")
                        .HasColumnType("boolean");

                    b.Property<int>("precio")
                        .HasColumnType("integer");

                    b.Property<string>("tipo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("vencimiento")
                        .HasColumnType("DATE");

                    b.HasKey("Id");

                    b.HasIndex("AseguradoEntityId");

                    b.HasIndex("CarrosEntityId");

                    b.ToTable("poliza");
                });

            modelBuilder.Entity("administrador.Persistence.Entities.UsuariosEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.Property<string>("mail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("tipo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("user");
                });

            modelBuilder.Entity("administrador.Persistence.Entities.CarrosEntity", b =>
                {
                    b.HasOne("administrador.Persistence.Entities.MarcaEntity", "MarcaEntity")
                        .WithMany()
                        .HasForeignKey("MarcaEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MarcaEntity");
                });

            modelBuilder.Entity("administrador.Persistence.Entities.IncidentesEntity", b =>
                {
                    b.HasOne("administrador.Persistence.Entities.UsuariosEntity", null)
                        .WithMany("admin")
                        .HasForeignKey("UsuariosEntityId");
                });

            modelBuilder.Entity("administrador.Persistence.Entities.PolizaEntity", b =>
                {
                    b.HasOne("administrador.Persistence.Entities.AseguradoEntity", "AseguradoEntity")
                        .WithMany("polizas")
                        .HasForeignKey("AseguradoEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("administrador.Persistence.Entities.CarrosEntity", "CarrosEntity")
                        .WithMany()
                        .HasForeignKey("CarrosEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AseguradoEntity");

                    b.Navigation("CarrosEntity");
                });

            modelBuilder.Entity("administrador.Persistence.Entities.AseguradoEntity", b =>
                {
                    b.Navigation("polizas");
                });

            modelBuilder.Entity("administrador.Persistence.Entities.UsuariosEntity", b =>
                {
                    b.Navigation("admin");
                });
#pragma warning restore 612, 618
        }
    }
}
