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

    public virtual DbSet<StampingProcess> StampingProcesses { get; set; }

    public virtual DbSet<StampingSession> StampingSessions { get; set; }

    public virtual DbSet<StampingTask> StampingTasks { get; set; }

    public virtual DbSet<TaskAssignment> TaskAssignments { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresEnum("Role", new[] { "Admin", "Employee" });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Product");

            entity.ToTable("Product");

            entity.Property(e => e.Id).HasColumnName("ProductID");
            entity.Property(e => e.Dimensions)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("Dimensions");
            entity.Property(e => e.IsDeleted)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("IsDeleted");
            entity.Property(e => e.Material)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("Material");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("Name");
            entity.Property(e => e.StampId).HasColumnName("StampID");

            entity.HasOne(d => d.Stamp).WithMany(p => p.Products)
                .HasForeignKey(d => d.StampId)
                .HasConstraintName("FK_Product_StampID");
        });

        modelBuilder.Entity<Robot>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Robot");

            entity.ToTable("Robot");

            entity.Property(e => e.Id).HasColumnName("RobotID");
            entity.Property(e => e.IsDeleted)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("IsDeleted");
            entity.Property(e => e.Model)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("Model");
            entity.Property(e => e.Position)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("Position");
            entity.Property(e => e.Status)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("Status");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Robots)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Robot_UserID");
        });

        modelBuilder.Entity<Stamp>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Stamp");

            entity.ToTable("Stamp");

            entity.Property(e => e.Id).HasColumnName("StampID");
            entity.Property(e => e.InkColor)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("InkColor");
            entity.Property(e => e.IsDeleted)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("IsDeleted");
            entity.Property(e => e.Size)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("Size");
            entity.Property(e => e.Type)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("Tyoe");
        });

        modelBuilder.Entity<StampingProcess>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_StampingProcess");

            entity.ToTable("StampingProcess");

            entity.Property(e => e.Id).HasColumnName("ProcessID");
            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("Description");
            entity.Property(e => e.SessionId).HasColumnName("SessionID");
            entity.Property(e => e.StepNumber)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("StepNumber");

            entity.HasOne(d => d.Session).WithMany(p => p.StampingProcesses)
                .HasForeignKey(d => d.SessionId)
                .HasConstraintName("FK_StampingProcess_StampingSession");
        });

        modelBuilder.Entity<StampingSession>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_StampingSession");

            entity.ToTable("StampingSession");

            entity.Property(e => e.Id).HasColumnName("SessionID");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp with time zone")
                .HasColumnName("CreatedAt");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.RobotId).HasColumnName("RobotID");
            entity.Property(e => e.Status)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("Status");
            entity.Property(e => e.TaskAssignmentId).HasColumnName("TaskAssignmentID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Product).WithMany(p => p.StampingSessions)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_StampingSession_Product");

            entity.HasOne(d => d.Robot).WithMany(p => p.StampingSessions)
                .HasForeignKey(d => d.RobotId)
                .HasConstraintName("FK_StampingSession_Robot");

            entity.HasOne(d => d.TaskAssignment).WithMany(p => p.StampingSessions)
                .HasForeignKey(d => d.TaskAssignmentId)
                .HasConstraintName("FK_StampingSession_TaskAssignment");

            entity.HasOne(d => d.User).WithMany(p => p.StampingSessions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_StampingSession_User");
        });

        modelBuilder.Entity<StampingTask>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_StampingTask");

            entity.ToTable("StampingTask");

            entity.Property(e => e.Id).HasColumnName("TaskID");
            entity.Property(e => e.ImageCaptured)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("ImageCaptured");
            entity.Property(e => e.ProcessId).HasColumnName("ProcessID");
            entity.Property(e => e.RobotId).HasColumnName("RobotID");
            entity.Property(e => e.Status)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("Status");
            entity.Property(e => e.TaskAssignmentId).HasColumnName("TaskAssignmentID");

            entity.HasOne(d => d.Process).WithMany(p => p.StampingTasks)
                .HasForeignKey(d => d.ProcessId)
                .HasConstraintName("FK_StampingTask_Process");

            entity.HasOne(d => d.Robot).WithMany(p => p.StampingTasks)
                .HasForeignKey(d => d.RobotId)
                .HasConstraintName("FK_StampingTask_Robot");

            entity.HasOne(d => d.TaskAssignment).WithMany(p => p.StampingTasks)
                .HasForeignKey(d => d.TaskAssignmentId)
                .HasConstraintName("FK_StampingTask_TaskAssignment");
        });

        modelBuilder.Entity<TaskAssignment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_TaskAssignment");

            entity.ToTable("TaskAssignment");

            entity.Property(e => e.Id).HasColumnName("TaskAssignmentID");
            entity.Property(e => e.Action)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("Action");
            entity.Property(e => e.Details)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("Details");
            entity.Property(e => e.IsDeleted)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("IsDeleted");
            entity.Property(e => e.TimeStamp)
                .HasColumnType("timestamp with time zone")
                .HasColumnName("TimeStamp");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Users");

            entity.Property(e => e.Id).HasColumnName("UserID");
            entity.Property(e => e.CodeOtpEmail).HasColumnName("CodeOTPEmail");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("Email");
            entity.Property(e => e.FullName)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("FullName");
            entity.Property(e => e.IsDeleted)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("IsDeleted");
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("Password");
            entity.Property(e => e.Phone)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("Phone");
            entity.Property(e => e.Role)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("Role");
            entity.Property(e => e.GoogleId)
                .HasColumnName("GoogleId");
            entity.Property(e => e.RefreshToken)
                .HasColumnName("RefreshToken");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}