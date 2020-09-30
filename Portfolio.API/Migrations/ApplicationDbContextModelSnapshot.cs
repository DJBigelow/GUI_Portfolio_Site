﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Portfolio.Shared.Data;

namespace Portfolio.API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Portfolio.Shared.Models.Framework", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Frameworks");
                });

            modelBuilder.Entity("Portfolio.Shared.Models.Language", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("Portfolio.Shared.Models.Platform", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Platforms");
                });

            modelBuilder.Entity("Portfolio.Shared.Models.Project", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CompletionDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Design")
                        .HasColumnType("text");

                    b.Property<string>("Requirement")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Portfolio.Shared.Models.ProjectFramework", b =>
                {
                    b.Property<int>("ProjectID")
                        .HasColumnType("integer");

                    b.Property<int>("FrameworkID")
                        .HasColumnType("integer");

                    b.HasKey("ProjectID", "FrameworkID");

                    b.HasIndex("FrameworkID");

                    b.ToTable("ProjectFrameworks");
                });

            modelBuilder.Entity("Portfolio.Shared.Models.ProjectLanguage", b =>
                {
                    b.Property<int>("ProjectID")
                        .HasColumnType("integer");

                    b.Property<int>("LanguageID")
                        .HasColumnType("integer");

                    b.HasKey("ProjectID", "LanguageID");

                    b.HasIndex("LanguageID");

                    b.ToTable("ProjectLanguages");
                });

            modelBuilder.Entity("Portfolio.Shared.Models.ProjectPlatform", b =>
                {
                    b.Property<int>("ProjectID")
                        .HasColumnType("integer");

                    b.Property<int>("PlatformID")
                        .HasColumnType("integer");

                    b.HasKey("ProjectID", "PlatformID");

                    b.HasIndex("PlatformID");

                    b.ToTable("ProjectPlatforms");
                });

            modelBuilder.Entity("Portfolio.Shared.Models.ProjectFramework", b =>
                {
                    b.HasOne("Portfolio.Shared.Models.Framework", "Framework")
                        .WithMany()
                        .HasForeignKey("FrameworkID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Portfolio.Shared.Models.Project", "Project")
                        .WithMany("ProjectFrameworks")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Portfolio.Shared.Models.ProjectLanguage", b =>
                {
                    b.HasOne("Portfolio.Shared.Models.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Portfolio.Shared.Models.Project", "Project")
                        .WithMany("ProjectLanguages")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Portfolio.Shared.Models.ProjectPlatform", b =>
                {
                    b.HasOne("Portfolio.Shared.Models.Platform", "Platform")
                        .WithMany()
                        .HasForeignKey("PlatformID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Portfolio.Shared.Models.Project", "Project")
                        .WithMany("ProjectPlatforms")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
