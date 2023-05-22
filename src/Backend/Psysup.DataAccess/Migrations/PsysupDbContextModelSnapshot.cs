﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Psysup.DataAccess.Data;

#nullable disable

namespace Psysup.DataAccess.Migrations
{
    [DbContext(typeof(PsysupDbContext))]
    partial class PsysupDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Psysup.DataAccess.Models.Application", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreationDateTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTimeOffset?>("EditionDateTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("Psysup.DataAccess.Models.ApplicationCategory", b =>
                {
                    b.Property<Guid>("ApplicationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ApplicationId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("ApplicationCategories");
                });

            modelBuilder.Entity("Psysup.DataAccess.Models.AppliedDoctorApplication", b =>
                {
                    b.Property<Guid>("DoctorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ApplicationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Approved")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<bool>("AsDoctor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.HasKey("DoctorId", "ApplicationId");

                    b.HasIndex("ApplicationId");

                    b.ToTable("AppliedDoctorApplications");
                });

            modelBuilder.Entity("Psysup.DataAccess.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Psysup.DataAccess.Models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("86a8803f-569d-4f6e-9433-7dfccbf79ec2"),
                            Name = "Admin"
                        },
                        new
                        {
                            Id = new Guid("05aab560-b9c7-4458-9642-2ba1a3a83237"),
                            Name = "User"
                        },
                        new
                        {
                            Id = new Guid("28cd0a64-9c83-45d9-8fc3-bd7883fb7376"),
                            Name = "Doctor"
                        });
                });

            modelBuilder.Entity("Psysup.DataAccess.Models.RoleUser", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleUsers");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("fda48c05-48b8-4655-b1e5-f0d707568ee3"),
                            RoleId = new Guid("86a8803f-569d-4f6e-9433-7dfccbf79ec2")
                        });
                });

            modelBuilder.Entity("Psysup.DataAccess.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ImagePath")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    SqlServerIndexBuilderExtensions.IncludeProperties(b.HasIndex("Email"), new[] { "PasswordHash", "ImagePath" });

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("fda48c05-48b8-4655-b1e5-f0d707568ee3"),
                            Email = "psysadmin@gmail.com",
                            FirstName = "",
                            LastName = "",
                            PasswordHash = "$2b$10$u9qwtAmulUGnGH3fWiH3/ujpTuQYbOcJUj0EDvd/xYW8nueUjwdAK"
                        });
                });

            modelBuilder.Entity("Psysup.DataAccess.Models.Application", b =>
                {
                    b.HasOne("Psysup.DataAccess.Models.User", "User")
                        .WithMany("Applications")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Psysup.DataAccess.Models.ApplicationCategory", b =>
                {
                    b.HasOne("Psysup.DataAccess.Models.Application", "Application")
                        .WithMany()
                        .HasForeignKey("ApplicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Psysup.DataAccess.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Application");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Psysup.DataAccess.Models.AppliedDoctorApplication", b =>
                {
                    b.HasOne("Psysup.DataAccess.Models.Application", "Application")
                        .WithMany("AppliedDoctorApplications")
                        .HasForeignKey("ApplicationId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Psysup.DataAccess.Models.User", "Doctor")
                        .WithMany("DoctorApplications")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Application");

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("Psysup.DataAccess.Models.RoleUser", b =>
                {
                    b.HasOne("Psysup.DataAccess.Models.Role", "Role")
                        .WithMany("RoleUsers")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Psysup.DataAccess.Models.User", "User")
                        .WithMany("RoleUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Psysup.DataAccess.Models.Application", b =>
                {
                    b.Navigation("AppliedDoctorApplications");
                });

            modelBuilder.Entity("Psysup.DataAccess.Models.Role", b =>
                {
                    b.Navigation("RoleUsers");
                });

            modelBuilder.Entity("Psysup.DataAccess.Models.User", b =>
                {
                    b.Navigation("Applications");

                    b.Navigation("DoctorApplications");

                    b.Navigation("RoleUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
