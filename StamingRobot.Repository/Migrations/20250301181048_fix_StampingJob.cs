using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using StamingRobot.Repository.Entities;

#nullable disable

namespace StamingRobot.Repository.Migrations
{
    /// <inheritdoc />
    public partial class fix_StampingJob : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StampingJobParameters");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Parameters",
                table: "StampingJob");

            migrationBuilder.CreateTable(
                name: "StampingJobParameters",
                columns: table => new
                {
                    JobParameterID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    JobId = table.Column<int>(type: "integer", nullable: false),
                    Base = table.Column<float>(type: "real", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Forearm = table.Column<float>(type: "real", nullable: false),
                    Gripper = table.Column<float>(type: "real", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    RotationWrist = table.Column<float>(type: "real", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Upperarm = table.Column<float>(type: "real", nullable: false),
                    Wrist = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StampingJobParameter", x => x.JobParameterID);
                    table.ForeignKey(
                        name: "FK_StampingJob_StampingJobParameters",
                        column: x => x.JobId,
                        principalTable: "StampingJob",
                        principalColumn: "JobID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_StampingJobParameters_JobId",
                table: "StampingJobParameters",
                column: "JobId",
                unique: true);
        }
    }
}
