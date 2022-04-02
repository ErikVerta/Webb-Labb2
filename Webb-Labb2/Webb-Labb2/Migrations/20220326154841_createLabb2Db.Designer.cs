﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Webb_Labb2.DAL;

#nullable disable

namespace Webb_Labb2.Migrations
{
    [DbContext(typeof(Labb2Context))]
    [Migration("20220326154841_createLabb2Db")]
    partial class createLabb2Db
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Webb_Labb2.DAL.Models.Course", b =>
                {
                    b.Property<int>("CourseNumber")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DifficultyId")
                        .HasColumnType("int");

                    b.Property<string>("Length")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourseNumber");

                    b.HasIndex("DifficultyId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Webb_Labb2.DAL.Models.Difficulty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Difficulties");
                });

            modelBuilder.Entity("Webb_Labb2.DAL.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Webb_Labb2.DAL.Models.UserCourse", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("CourseNumber")
                        .HasColumnType("int");

                    b.HasKey("UserId", "CourseNumber");

                    b.HasIndex("CourseNumber");

                    b.ToTable("UserCourses");
                });

            modelBuilder.Entity("Webb_Labb2.DAL.Models.Course", b =>
                {
                    b.HasOne("Webb_Labb2.DAL.Models.Difficulty", "Difficulty")
                        .WithMany()
                        .HasForeignKey("DifficultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Difficulty");
                });

            modelBuilder.Entity("Webb_Labb2.DAL.Models.UserCourse", b =>
                {
                    b.HasOne("Webb_Labb2.DAL.Models.Course", "Course")
                        .WithMany("UserCourses")
                        .HasForeignKey("CourseNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Webb_Labb2.DAL.Models.User", "User")
                        .WithMany("UserCourses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Webb_Labb2.DAL.Models.Course", b =>
                {
                    b.Navigation("UserCourses");
                });

            modelBuilder.Entity("Webb_Labb2.DAL.Models.User", b =>
                {
                    b.Navigation("UserCourses");
                });
#pragma warning restore 612, 618
        }
    }
}