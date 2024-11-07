﻿// <auto-generated />
using System;
using Coursework.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Coursework.DataAccess.Migrations
{
    [DbContext(typeof(PechDbContext))]
    [Migration("20240616135102_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Coursework.DataAccess.Entites.PechEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<float>("diametr")
                        .HasColumnType("real");

                    b.Property<float>("kPer")
                        .HasColumnType("real");

                    b.Property<float>("kTeplo")
                        .HasColumnType("real");

                    b.Property<float>("p")
                        .HasColumnType("real");

                    b.Property<float>("tNach")
                        .HasColumnType("real");

                    b.Property<float>("tPech")
                        .HasColumnType("real");

                    b.Property<float>("tPov")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Pech");
                });
#pragma warning restore 612, 618
        }
    }
}
