﻿// <auto-generated />
using System;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("herois")
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.HeroisAggregated.Heroi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Altura")
                        .HasColumnType("float");

                    b.Property<DateTime?>("DataNascimento")
                        .HasColumnType("datetime2(7)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(120");

                    b.Property<string>("NomeHeroi")
                        .IsRequired()
                        .HasColumnType("nvarchar(120)");

                    b.Property<double>("Peso")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Herois", "herois");
                });

            modelBuilder.Entity("Domain.HeroisAggregated.Superpoder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Poder")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Superpoder");

                    b.HasKey("Id");

                    b.ToTable("Superpoderes", "herois");
                });

            modelBuilder.Entity("HeroiSuperpoder", b =>
                {
                    b.Property<int>("HeroisId")
                        .HasColumnType("int");

                    b.Property<int>("SuperpoderesId")
                        .HasColumnType("int");

                    b.HasKey("HeroisId", "SuperpoderesId");

                    b.HasIndex("SuperpoderesId");

                    b.ToTable("HeroisSuperpoderes", "herois");
                });

            modelBuilder.Entity("HeroiSuperpoder", b =>
                {
                    b.HasOne("Domain.HeroisAggregated.Heroi", null)
                        .WithMany()
                        .HasForeignKey("HeroisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.HeroisAggregated.Superpoder", null)
                        .WithMany()
                        .HasForeignKey("SuperpoderesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
