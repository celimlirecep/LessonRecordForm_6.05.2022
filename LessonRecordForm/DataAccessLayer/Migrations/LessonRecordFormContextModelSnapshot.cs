﻿// <auto-generated />
using System;
using DataAccessLayer.Concreate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(LessonRecordFormContext))]
    partial class LessonRecordFormContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.16");

            modelBuilder.Entity("EntityLayer.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DepartmentBoss")
                        .HasColumnType("TEXT");

                    b.Property<string>("DepartmentName")
                        .HasColumnType("TEXT");

                    b.HasKey("DepartmentId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("EntityLayer.Lesson", b =>
                {
                    b.Property<int>("LessonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("LessonBos")
                        .HasColumnType("TEXT");

                    b.Property<int>("LessonCredit")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LessonName")
                        .HasColumnType("TEXT");

                    b.Property<char>("LessonTerm")
                        .HasColumnType("TEXT");

                    b.HasKey("LessonId");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("EntityLayer.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StudentBirthDay")
                        .HasColumnType("TEXT");

                    b.Property<int>("StudentDepartmentId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("StudentName")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StudentRecortDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("StudentSurname")
                        .HasColumnType("TEXT");

                    b.Property<char>("StudentTerm")
                        .HasColumnType("TEXT");

                    b.HasKey("StudentId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("EntityLayer.StudentLesson", b =>
                {
                    b.Property<int>("LessonId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StudentId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StudentLessonId")
                        .HasColumnType("INTEGER");

                    b.HasKey("LessonId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentLessons");
                });

            modelBuilder.Entity("EntityLayer.Student", b =>
                {
                    b.HasOne("EntityLayer.Department", "Department")
                        .WithMany("Students")
                        .HasForeignKey("DepartmentId");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("EntityLayer.StudentLesson", b =>
                {
                    b.HasOne("EntityLayer.Lesson", "Lesson")
                        .WithMany("StudentLessons")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Student", "Student")
                        .WithMany("StudentLessons")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("EntityLayer.Department", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("EntityLayer.Lesson", b =>
                {
                    b.Navigation("StudentLessons");
                });

            modelBuilder.Entity("EntityLayer.Student", b =>
                {
                    b.Navigation("StudentLessons");
                });
#pragma warning restore 612, 618
        }
    }
}
