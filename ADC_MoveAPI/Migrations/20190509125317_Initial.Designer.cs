﻿// <auto-generated />
using System;
using ADC_MoveAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ADC_MoveAPI.Migrations
{
    [DbContext(typeof(ADC_MoveAPIContext))]
    [Migration("20190509125317_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ADC_Movie.Domain.Entity.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Rua");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("ADC_Movie.Domain.Entity.Movie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AddressId");

                    b.Property<string>("Cpf");

                    b.Property<string>("Genre");

                    b.Property<DateTime>("ReleaseDate");

                    b.Property<string>("Senha");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Movie");
                });

            modelBuilder.Entity("ADC_Movie.Domain.Entity.Movie", b =>
                {
                    b.HasOne("ADC_Movie.Domain.Entity.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");
                });
#pragma warning restore 612, 618
        }
    }
}