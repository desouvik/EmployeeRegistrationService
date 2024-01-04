﻿// <auto-generated />
using EmployeeRegistrationService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmployeeRegistrationService.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240103174910_SeedEmployeeTable")]
    partial class SeedEmployeeTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EmployeeRegistrationService.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
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

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "New York",
                            Email = "spiderman@avengers.com",
                            FirstName = "Peter",
                            LastName = "Parker"
                        },
                        new
                        {
                            Id = 2,
                            City = "New York",
                            Email = "batman@avengers.com",
                            FirstName = "Bruce",
                            LastName = "Wayne"
                        },
                        new
                        {
                            Id = 3,
                            City = "New York",
                            Email = "ironman@avengers.com",
                            FirstName = "Tony",
                            LastName = "Stark"
                        },
                        new
                        {
                            Id = 4,
                            City = "New York",
                            Email = "thor@avengers.com",
                            FirstName = "Thor",
                            LastName = "Odinson"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
