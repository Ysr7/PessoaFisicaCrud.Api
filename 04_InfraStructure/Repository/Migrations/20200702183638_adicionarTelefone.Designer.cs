﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository;

namespace Repository.Migrations
{
    [DbContext(typeof(WG2RContext))]
    [Migration("20200702183638_adicionarTelefone")]
    partial class adicionarTelefone
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Core.Entities.PessoaFisica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(155) CHARACTER SET utf8mb4")
                        .HasMaxLength(155);

                    b.Property<int>("Idade")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(155) CHARACTER SET utf8mb4")
                        .HasMaxLength(155);

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("PessoasFisicas");
                });

            modelBuilder.Entity("Core.Entities.Telefone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("DDD")
                        .IsRequired()
                        .HasColumnType("varchar(2) CHARACTER SET utf8mb4")
                        .HasMaxLength(2);

                    b.Property<int>("IdPessoaFisica")
                        .HasColumnType("int");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("varchar(15) CHARACTER SET utf8mb4")
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.HasIndex("IdPessoaFisica");

                    b.ToTable("Telefones");
                });

            modelBuilder.Entity("Core.Entities.Telefone", b =>
                {
                    b.HasOne("Core.Entities.PessoaFisica", "PessoaFisica")
                        .WithMany("Telefones")
                        .HasForeignKey("IdPessoaFisica")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
