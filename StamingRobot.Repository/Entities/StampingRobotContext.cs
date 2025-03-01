using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StamingRobot.Repository.Entities;

public partial class StampingRobotContext : DbContext
{
    public StampingRobotContext(DbContextOptions<StampingRobotContext> options)
        : base(options)
    {
    }

    public StampingRobotContext()
    {

    }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Robot> Robots { get; set; }

    public virtual DbSet<Stamp> Stamps { get; set; }

    public virtual DbSet<StampingJob> StampingJobs { get; set; }

    public virtual DbSet<StampingSession> StampingSessions { get; set; }

    public virtual DbSet<TaskAssignment> TaskAssignments { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresEnum("Role", new[] { "Admin", "Employee" });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Product");

            entity.ToTable("Product");

            entity.Property(e => e.Id).HasColumnName("ProductID").ValueGeneratedOnAdd();
            entity.Property(e => e.Dimensions)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("Dimensions");
            entity.Property(e => e.IsDeleted)
                .IsRequired()
                .HasColumnName("IsDeleted");
            entity.Property(e => e.Material)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Material");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Name");
            entity.Property(e => e.StampId).HasColumnName("StampID");
            entity.Property(e => e.CreatedAt)
                .IsRequired()
                .HasColumnType("timestamp with time zone")
                .HasColumnName("CreatedAt");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp with time zone")
                .HasColumnName("UpdatedAt");

            entity.HasOne(d => d.Stamp).WithMany(p => p.Products)
                .HasForeignKey(d => d.StampId)
                .HasConstraintName("FK_Stamp_Product");
        });

        modelBuilder.Entity<Robot>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Robot");

            entity.ToTable("Robot");

            entity.Property(e => e.Id).HasColumnName("RobotID").ValueGeneratedOnAdd();
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Name");
            entity.Property(e => e.Model)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("Model");
            entity.Property(e => e.Status)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Status");
            entity.Property(e => e.CreatedAt)
                .IsRequired()
                .HasColumnType("timestamp with time zone")
                .HasColumnName("CreatedAt");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp with time zone")
                .HasColumnName("UpdatedAt");
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.IsDeleted)
                .IsRequired()
                .HasColumnName("IsDeleted");

            entity.HasOne(d => d.User).WithMany(p => p.Robots)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_User_Robot");
        });

        modelBuilder.Entity<Stamp>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Stamp");

            entity.ToTable("Stamp");

            entity.Property(e => e.Id).HasColumnName("StampID").ValueGeneratedOnAdd();
            entity.Property(e => e.InkColor)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("InkColor");
            entity.Property(e => e.IsDeleted)
                .IsRequired()
                .HasColumnName("IsDeleted");
            entity.Property(e => e.Size)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("Size");
            entity.Property(e => e.Type)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("Type");
            entity.Property(e => e.CreatedAt)
                .IsRequired()
                .HasColumnType("timestamp with time zone")
                .HasColumnName("CreatedAt");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp with time zone")
                .HasColumnName("UpdatedAt");
        });

        modelBuilder.Entity<StampingJob>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_StampingJob");

            entity.ToTable("StampingJob");

            entity.Property(e => e.Id).HasColumnName("JobID").ValueGeneratedOnAdd();
            entity.Property(e => e.StepNumber)
                .IsRequired()
                .HasColumnName("StepNumber");
            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("Description");
            entity.Property(e => e.SessionId).HasColumnName("SessionID");
            entity.Property(e => e.Status)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Status");
            entity.Property(e => e.IsDeleted)
                .IsRequired()
                .HasColumnName("IsDeleted");
            entity.Property(e => e.CreatedAt)
                .IsRequired()
                .HasColumnType("timestamp with time zone")
                .HasColumnName("CreatedAt");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp with time zone")
                .HasColumnName("UpdatedAt");
            entity.Property(e => e.Parameters)
                .HasColumnType("jsonb")
                .HasColumnName("Parameters");

            entity.HasOne(d => d.Session).WithMany(p => p.StampingJobs)
                .HasForeignKey(d => d.SessionId)
                .HasConstraintName("FK_StampingSession_StampingJob");
        });

        modelBuilder.Entity<StampingSession>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_StampingSession");

            entity.ToTable("StampingSession");

            entity.Property(e => e.Id).HasColumnName("SessionID").ValueGeneratedOnAdd();
            entity.Property(e => e.Quantity)
                .IsRequired()
                .HasColumnName("Quantity");
            entity.Property(e => e.Status)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Status");
            entity.Property(e => e.CreatedAt)
                .IsRequired()
                .HasColumnType("timestamp with time zone")
                .HasColumnName("CreatedAt");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp with time zone")
                .HasColumnName("UpdatedAt");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.RobotId).HasColumnName("RobotID");
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.IsDeleted)
                .IsRequired()
                .HasColumnName("IsDeleted");

            entity.HasOne(d => d.Product).WithMany(p => p.StampingSessions)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_Product_StampingSession");

            entity.HasOne(d => d.Robot).WithMany(p => p.StampingSessions)
                .HasForeignKey(d => d.RobotId)
                .HasConstraintName("FK_Robot_StampingSession");

            entity.HasOne(d => d.User).WithMany(p => p.StampingSessions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_StampingSession_User");
        });

        modelBuilder.Entity<TaskAssignment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_TaskAssignment");

            entity.ToTable("TaskAssignment");

            entity.Property(e => e.Id).HasColumnName("TaskAssignmentID").ValueGeneratedOnAdd();
            entity.Property(e => e.JobId).HasColumnName("JobID");
            entity.Property(e => e.Details)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("Details");
            entity.Property(e => e.Status)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Status");
            entity.Property(e => e.CreatedAt)
                .IsRequired()
                .HasColumnType("timestamp with time zone")
                .HasColumnName("CreateAt");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp with time zone")
                .HasColumnName("UpdatedAt");
            entity.Property(e => e.ImageCaptured)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("ImageCaptured");
            entity.Property(e => e.IsDeleted)
                .IsRequired()
                .HasColumnName("IsDeleted");

            entity.HasOne(d => d.StampingJob).WithMany(p => p.TaskAssignments)
                .HasForeignKey(d => d.JobId)
                .HasConstraintName("FK_StampingJob_TaskAssignment");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Users");

            entity.Property(e => e.Id).HasColumnName("UserID").ValueGeneratedOnAdd();
            entity.Property(e => e.CodeOtpEmail).HasColumnName("CodeOTPEmail");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Email");
            entity.Property(e => e.FullName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("FullName");
            entity.Property(e => e.IsDeleted)
                .IsRequired()
                .HasColumnName("IsDeleted");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasColumnName("Password");
            entity.Property(e => e.Phone)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("Phone");
            entity.Property(e => e.Role)
                .IsRequired()
                .HasColumnName("Role")
                .HasConversion<string>();
            entity.Property(e => e.GoogleId)
                .HasColumnName("GoogleId");
            entity.Property(e => e.RefreshToken)
                .HasColumnName("RefreshToken");
            entity.Property(e => e.CreatedAt)
                .IsRequired()
                .HasColumnType("timestamp with time zone")
                .HasColumnName("CreatedAt");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp with time zone")
                .HasColumnName("UpdatedAt");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}