﻿// <auto-generated />
using System;
using App.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace App.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210911181931_Update5")]
    partial class Update5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("App.Domain.Entities.Cidade", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CEP")
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.Property<string>("UF")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("cidade");
                });

            modelBuilder.Entity("App.Domain.Entities.Pessoa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("CidadeId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.Property<int>("Peso")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CidadeId");

                    b.ToTable("pessoa");
                });

            modelBuilder.Entity("App.Domain.Entities.Pessoa", b =>
                {
                    b.HasOne("App.Domain.Entities.Cidade", "Cidade")
                        .WithMany()
                        .HasForeignKey("CidadeId");

                    b.Navigation("Cidade");
                });
#pragma warning restore 612, 618
        }
    }
}
