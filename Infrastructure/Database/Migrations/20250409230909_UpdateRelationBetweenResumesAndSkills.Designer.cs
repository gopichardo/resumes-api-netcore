﻿// <auto-generated />
using System;
using Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Database.Migrations
{
    [DbContext(typeof(ResumeDbContext))]
    [Migration("20250409230909_UpdateRelationBetweenResumesAndSkills")]
    partial class UpdateRelationBetweenResumesAndSkills
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Core.Entity.Proffesion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ResumeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ResumeId");

                    b.ToTable("Proffesion");
                });

            modelBuilder.Entity("Core.Entity.Resume", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Resume");
                });

            modelBuilder.Entity("Core.Entity.ResumeSkill", b =>
                {
                    b.Property<Guid>("ResumeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SkillId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ResumeId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("ResumeSkill");
                });

            modelBuilder.Entity("Core.Entity.Skill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ProffesionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ResumeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProffesionId");

                    b.HasIndex("ResumeId");

                    b.ToTable("Skill");
                });

            modelBuilder.Entity("Core.Entity.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Core.Entity.Proffesion", b =>
                {
                    b.HasOne("Core.Entity.Resume", null)
                        .WithMany("Professions")
                        .HasForeignKey("ResumeId");
                });

            modelBuilder.Entity("Core.Entity.Resume", b =>
                {
                    b.HasOne("Core.Entity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Core.Entity.ResumeSkill", b =>
                {
                    b.HasOne("Core.Entity.Resume", "Resume")
                        .WithMany("SkillLink")
                        .HasForeignKey("ResumeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entity.Skill", "Skill")
                        .WithMany("ResumeLink")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Resume");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("Core.Entity.Skill", b =>
                {
                    b.HasOne("Core.Entity.Proffesion", null)
                        .WithMany("Skills")
                        .HasForeignKey("ProffesionId");

                    b.HasOne("Core.Entity.Resume", null)
                        .WithMany("MainSkills")
                        .HasForeignKey("ResumeId");
                });

            modelBuilder.Entity("Core.Entity.Proffesion", b =>
                {
                    b.Navigation("Skills");
                });

            modelBuilder.Entity("Core.Entity.Resume", b =>
                {
                    b.Navigation("MainSkills");

                    b.Navigation("Professions");

                    b.Navigation("SkillLink");
                });

            modelBuilder.Entity("Core.Entity.Skill", b =>
                {
                    b.Navigation("ResumeLink");
                });
#pragma warning restore 612, 618
        }
    }
}
