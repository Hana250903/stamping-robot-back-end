﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using StamingRobot.Repository.Entities;

#nullable disable

namespace StamingRobot.Repository.Migrations
{
    [DbContext(typeof(StampingRobotContext))]
    partial class StampingRobotContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "Role", new[] { "Admin", "Employee" });
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("StamingRobot.Repository.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("ProductID");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Dimensions")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("Dimensions");

                    b.Property<bool>("IsDeleted")
                        .HasMaxLength(255)
                        .HasColumnType("boolean")
                        .HasColumnName("IsDeleted");

                    b.Property<string>("Material")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("Material");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("Name");

                    b.Property<int>("StampId")
                        .HasColumnType("integer")
                        .HasColumnName("StampID");

                    b.HasKey("Id")
                        .HasName("PK_Product");

                    b.HasIndex("StampId");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("StamingRobot.Repository.Entities.Robot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("RobotID");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .HasMaxLength(255)
                        .HasColumnType("boolean")
                        .HasColumnName("IsDeleted");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("Model");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("Position");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("Status");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("UserID");

                    b.HasKey("Id")
                        .HasName("PK_Robot");

                    b.HasIndex("UserId");

                    b.ToTable("Robot", (string)null);
                });

            modelBuilder.Entity("StamingRobot.Repository.Entities.Stamp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("StampID");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("InkColor")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("InkColor");

                    b.Property<bool>("IsDeleted")
                        .HasMaxLength(255)
                        .HasColumnType("boolean")
                        .HasColumnName("IsDeleted");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("Size");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("Tyoe");

                    b.HasKey("Id")
                        .HasName("PK_Stamp");

                    b.ToTable("Stamp", (string)null);
                });

            modelBuilder.Entity("StamingRobot.Repository.Entities.StampingProcess", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("ProcessID");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("Description");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int>("SessionId")
                        .HasColumnType("integer")
                        .HasColumnName("SessionID");

                    b.Property<string>("StepNumber")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("StepNumber");

                    b.HasKey("Id")
                        .HasName("PK_StampingProcess");

                    b.HasIndex("SessionId");

                    b.ToTable("StampingProcess", (string)null);
                });

            modelBuilder.Entity("StamingRobot.Repository.Entities.StampingSession", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("SessionID");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("CreatedAt");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer")
                        .HasColumnName("ProductID");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<int>("RobotId")
                        .HasColumnType("integer")
                        .HasColumnName("RobotID");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("Status");

                    b.Property<int?>("TaskAssignmentId")
                        .HasColumnType("integer")
                        .HasColumnName("TaskAssignmentID");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("UserID");

                    b.HasKey("Id")
                        .HasName("PK_StampingSession");

                    b.HasIndex("ProductId");

                    b.HasIndex("RobotId");

                    b.HasIndex("TaskAssignmentId");

                    b.HasIndex("UserId");

                    b.ToTable("StampingSession", (string)null);
                });

            modelBuilder.Entity("StamingRobot.Repository.Entities.StampingTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("TaskID");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageCaptured")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("ImageCaptured");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int>("ProcessId")
                        .HasColumnType("integer")
                        .HasColumnName("ProcessID");

                    b.Property<int>("RobotId")
                        .HasColumnType("integer")
                        .HasColumnName("RobotID");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("Status");

                    b.Property<int?>("TaskAssignmentId")
                        .HasColumnType("integer")
                        .HasColumnName("TaskAssignmentID");

                    b.HasKey("Id")
                        .HasName("PK_StampingTask");

                    b.HasIndex("ProcessId");

                    b.HasIndex("RobotId");

                    b.HasIndex("TaskAssignmentId");

                    b.ToTable("StampingTask", (string)null);
                });

            modelBuilder.Entity("StamingRobot.Repository.Entities.TaskAssignment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("TaskAssignmentID");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("Action");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("Details");

                    b.Property<bool>("IsDeleted")
                        .HasMaxLength(255)
                        .HasColumnType("boolean")
                        .HasColumnName("IsDeleted");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("TimeStamp");

                    b.HasKey("Id")
                        .HasName("PK_TaskAssignment");

                    b.ToTable("TaskAssignment", (string)null);
                });

            modelBuilder.Entity("StamingRobot.Repository.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("UserID");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CodeOtpemail")
                        .HasColumnType("integer")
                        .HasColumnName("CodeOTPEmail");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("Email");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("FullName");

                    b.Property<bool>("IsDeleted")
                        .HasMaxLength(255)
                        .HasColumnType("boolean")
                        .HasColumnName("IsDeleted");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("Password");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("Phone");

                    b.Property<int>("Role")
                        .HasMaxLength(20)
                        .HasColumnType("integer")
                        .HasColumnName("Role");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("UserName");

                    b.HasKey("Id")
                        .HasName("PK_Users");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("StamingRobot.Repository.Entities.Product", b =>
                {
                    b.HasOne("StamingRobot.Repository.Entities.Stamp", "Stamp")
                        .WithMany("Products")
                        .HasForeignKey("StampId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Product_StampID");

                    b.Navigation("Stamp");
                });

            modelBuilder.Entity("StamingRobot.Repository.Entities.Robot", b =>
                {
                    b.HasOne("StamingRobot.Repository.Entities.User", "User")
                        .WithMany("Robots")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Robot_UserID");

                    b.Navigation("User");
                });

            modelBuilder.Entity("StamingRobot.Repository.Entities.StampingProcess", b =>
                {
                    b.HasOne("StamingRobot.Repository.Entities.StampingSession", "Session")
                        .WithMany("StampingProcesses")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_StampingProcess_StampingSession");

                    b.Navigation("Session");
                });

            modelBuilder.Entity("StamingRobot.Repository.Entities.StampingSession", b =>
                {
                    b.HasOne("StamingRobot.Repository.Entities.Product", "Product")
                        .WithMany("StampingSessions")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_StampingSession_Product");

                    b.HasOne("StamingRobot.Repository.Entities.Robot", "Robot")
                        .WithMany("StampingSessions")
                        .HasForeignKey("RobotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_StampingSession_Robot");

                    b.HasOne("StamingRobot.Repository.Entities.TaskAssignment", "TaskAssignment")
                        .WithMany("StampingSessions")
                        .HasForeignKey("TaskAssignmentId")
                        .HasConstraintName("FK_StampingSession_TaskAssignment");

                    b.HasOne("StamingRobot.Repository.Entities.User", "User")
                        .WithMany("StampingSessions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_StampingSession_User");

                    b.Navigation("Product");

                    b.Navigation("Robot");

                    b.Navigation("TaskAssignment");

                    b.Navigation("User");
                });

            modelBuilder.Entity("StamingRobot.Repository.Entities.StampingTask", b =>
                {
                    b.HasOne("StamingRobot.Repository.Entities.StampingProcess", "Process")
                        .WithMany("StampingTasks")
                        .HasForeignKey("ProcessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_StampingTask_Process");

                    b.HasOne("StamingRobot.Repository.Entities.Robot", "Robot")
                        .WithMany("StampingTasks")
                        .HasForeignKey("RobotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_StampingTask_Robot");

                    b.HasOne("StamingRobot.Repository.Entities.TaskAssignment", "TaskAssignment")
                        .WithMany("StampingTasks")
                        .HasForeignKey("TaskAssignmentId")
                        .HasConstraintName("FK_StampingTask_TaskAssignment");

                    b.Navigation("Process");

                    b.Navigation("Robot");

                    b.Navigation("TaskAssignment");
                });

            modelBuilder.Entity("StamingRobot.Repository.Entities.Product", b =>
                {
                    b.Navigation("StampingSessions");
                });

            modelBuilder.Entity("StamingRobot.Repository.Entities.Robot", b =>
                {
                    b.Navigation("StampingSessions");

                    b.Navigation("StampingTasks");
                });

            modelBuilder.Entity("StamingRobot.Repository.Entities.Stamp", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("StamingRobot.Repository.Entities.StampingProcess", b =>
                {
                    b.Navigation("StampingTasks");
                });

            modelBuilder.Entity("StamingRobot.Repository.Entities.StampingSession", b =>
                {
                    b.Navigation("StampingProcesses");
                });

            modelBuilder.Entity("StamingRobot.Repository.Entities.TaskAssignment", b =>
                {
                    b.Navigation("StampingSessions");

                    b.Navigation("StampingTasks");
                });

            modelBuilder.Entity("StamingRobot.Repository.Entities.User", b =>
                {
                    b.Navigation("Robots");

                    b.Navigation("StampingSessions");
                });
#pragma warning restore 612, 618
        }
    }
}
