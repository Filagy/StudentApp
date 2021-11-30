﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentASP.DataAccess.MSSQL;

namespace StudentASP.DataAccess.MSSQL.Migrations
{
    [DbContext(typeof(DiaryAppDbContext))]
    [Migration("20211122073019_InitGroups")]
    partial class InitGroups
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StudentASP.DataAccess.MSSQL.Entities.Group", b =>
                {
                    b.Property<int>("NumberGroup")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("TeacherClassroomId")
                        .HasColumnType("int");

                    b.HasKey("NumberGroup");

                    b.HasIndex("TeacherClassroomId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("StudentASP.DataAccess.MSSQL.Entities.Score", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Scores");
                });

            modelBuilder.Entity("StudentASP.DataAccess.MSSQL.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberGroup")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NumberGroup");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("StudentASP.DataAccess.MSSQL.Entities.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.Property<int>("Title")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("StudentASP.DataAccess.MSSQL.Entities.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("StudentASP.DataAccess.MSSQL.Entities.Group", b =>
                {
                    b.HasOne("StudentASP.DataAccess.MSSQL.Entities.Teacher", "TeacherClassroom")
                        .WithMany("Groups")
                        .HasForeignKey("TeacherClassroomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TeacherClassroom");
                });

            modelBuilder.Entity("StudentASP.DataAccess.MSSQL.Entities.Score", b =>
                {
                    b.HasOne("StudentASP.DataAccess.MSSQL.Entities.Student", "Student")
                        .WithMany("Scores")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentASP.DataAccess.MSSQL.Entities.Subject", "Subject")
                        .WithMany("Scores")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("StudentASP.DataAccess.MSSQL.Entities.Student", b =>
                {
                    b.HasOne("StudentASP.DataAccess.MSSQL.Entities.Group", "Group")
                        .WithMany("Students")
                        .HasForeignKey("NumberGroup")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("StudentASP.DataAccess.MSSQL.Entities.Subject", b =>
                {
                    b.HasOne("StudentASP.DataAccess.MSSQL.Entities.Student", null)
                        .WithMany("Subjects")
                        .HasForeignKey("StudentId");

                    b.HasOne("StudentASP.DataAccess.MSSQL.Entities.Teacher", "Teacher")
                        .WithMany("Subjects")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("StudentASP.DataAccess.MSSQL.Entities.Group", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("StudentASP.DataAccess.MSSQL.Entities.Student", b =>
                {
                    b.Navigation("Scores");

                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("StudentASP.DataAccess.MSSQL.Entities.Subject", b =>
                {
                    b.Navigation("Scores");
                });

            modelBuilder.Entity("StudentASP.DataAccess.MSSQL.Entities.Teacher", b =>
                {
                    b.Navigation("Groups");

                    b.Navigation("Subjects");
                });
#pragma warning restore 612, 618
        }
    }
}
