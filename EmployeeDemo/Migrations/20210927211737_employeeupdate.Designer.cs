﻿// <auto-generated />
using System;
using EmployeeDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmployeeDemo.Migrations
{
    [DbContext(typeof(EmployeeContext))]
    [Migration("20210927211737_employeeupdate")]
    partial class employeeupdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EmployeeDemo.Models.Department", b =>
                {
                    b.Property<int>("DepartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DepartmentName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartId");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            DepartId = 1,
                            DepartmentName = "HR"
                        },
                        new
                        {
                            DepartId = 2,
                            DepartmentName = "Fiance"
                        },
                        new
                        {
                            DepartId = 3,
                            DepartmentName = "IT"
                        },
                        new
                        {
                            DepartId = 4,
                            DepartmentName = "QA"
                        });
                });

            modelBuilder.Entity("EmployeeDemo.Models.Employee", b =>
                {
                    b.Property<int>("Eid")
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("Department")
                        .HasColumnType("int");

                    b.Property<int>("DeptId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ename")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("departmentDepartId")
                        .HasColumnType("int");

                    b.HasKey("Eid");

                    b.HasIndex("departmentDepartId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Eid = 101,
                            Age = 0,
                            Department = 3,
                            DeptId = 3,
                            Email = "s@gmail.com",
                            Ename = "Sarah"
                        },
                        new
                        {
                            Eid = 102,
                            Age = 0,
                            Department = 1,
                            DeptId = 1,
                            Email = "m@gmail.com",
                            Ename = "Michael"
                        });
                });

            modelBuilder.Entity("EmployeeDemo.Models.Employee", b =>
                {
                    b.HasOne("EmployeeDemo.Models.Department", "department")
                        .WithMany("Employees")
                        .HasForeignKey("departmentDepartId");

                    b.Navigation("department");
                });

            modelBuilder.Entity("EmployeeDemo.Models.Department", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
