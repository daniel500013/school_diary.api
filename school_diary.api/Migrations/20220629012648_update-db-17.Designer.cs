﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using school_diary.api;

#nullable disable

namespace school_diary.api.Migrations
{
    [DbContext(typeof(DiaryDbContext))]
    [Migration("20220629012648_update-db-17")]
    partial class updatedb17
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("school_diary.api.Model.Approve", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LessonId")
                        .HasColumnType("int");

                    b.Property<bool>("Positive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("LessonId");

                    b.ToTable("approves");
                });

            modelBuilder.Entity("school_diary.api.Model.Grade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LessonId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserClassId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LessonId");

                    b.HasIndex("UserClassId");

                    b.ToTable("grades");
                });

            modelBuilder.Entity("school_diary.api.Model.Lesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("lesson");
                });

            modelBuilder.Entity("school_diary.api.Model.Marks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("LessonId")
                        .HasColumnType("int");

                    b.Property<bool>("Present")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("LessonId");

                    b.ToTable("marks");
                });

            modelBuilder.Entity("school_diary.api.Model.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("role");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Student"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Teacher"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Tutor"
                        },
                        new
                        {
                            Id = 4,
                            Name = "LocalAdmin"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Admin"
                        });
                });

            modelBuilder.Entity("school_diary.api.Model.User", b =>
                {
                    b.Property<Guid>("uuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("city")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("hashPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.Property<string>("state")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("userClassId")
                        .HasColumnType("int");

                    b.Property<string>("zipCode")
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.HasKey("uuid");

                    b.HasIndex("RoleId");

                    b.HasIndex("userClassId");

                    b.ToTable("user");

                    b.HasData(
                        new
                        {
                            uuid = new Guid("217d96bb-cdbc-44e7-ac40-5b6ff97a7d40"),
                            RoleId = 5,
                            email = "admin@admin.com",
                            hashPassword = "AQAAAAEAACcQAAAAEFvY2W0hbidymRwUuDJrnyJ0QgZDGZFyUA/UbjsmJoj2bJC90u0MI+p78tTQU8cSMg==",
                            password = "",
                            userClassId = 1
                        });
                });

            modelBuilder.Entity("school_diary.api.Model.UserClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("userClass")
                        .HasColumnType("int");

                    b.Property<string>("userClassProfile")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("userClass");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            userClass = 1,
                            userClassProfile = ""
                        });
                });

            modelBuilder.Entity("school_diary.api.Model.Approve", b =>
                {
                    b.HasOne("school_diary.api.Model.Lesson", "Lesson")
                        .WithMany()
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");
                });

            modelBuilder.Entity("school_diary.api.Model.Grade", b =>
                {
                    b.HasOne("school_diary.api.Model.Lesson", "Lesson")
                        .WithMany()
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("school_diary.api.Model.UserClass", "UserClass")
                        .WithMany()
                        .HasForeignKey("UserClassId");

                    b.Navigation("Lesson");

                    b.Navigation("UserClass");
                });

            modelBuilder.Entity("school_diary.api.Model.Lesson", b =>
                {
                    b.HasOne("school_diary.api.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("school_diary.api.Model.Marks", b =>
                {
                    b.HasOne("school_diary.api.Model.Lesson", "Lesson")
                        .WithMany()
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");
                });

            modelBuilder.Entity("school_diary.api.Model.User", b =>
                {
                    b.HasOne("school_diary.api.Model.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("school_diary.api.Model.UserClass", "userClass")
                        .WithMany()
                        .HasForeignKey("userClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("userClass");
                });
#pragma warning restore 612, 618
        }
    }
}