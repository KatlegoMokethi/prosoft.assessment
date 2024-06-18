﻿// <auto-generated />
using System;
using FeedbackSystem.Persistence.Postgres;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FeedbackSystem.Persistence.Postgres.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240618220222_RemoveCreatedByColumn")]
    partial class RemoveCreatedByColumn
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FeedbackSystem.Persistence.Postgres.Entities.FeedbackEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDatetime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_datetime");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Service")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("service");

                    b.HasKey("Id");

                    b.ToTable("feedback");
                });
#pragma warning restore 612, 618
        }
    }
}
