using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace StamingRobot.Repository.Migrations
{
    /// <inheritdoc />
    public partial class fix_all_db : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_StampID",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Robot_UserID",
                table: "Robot");

            migrationBuilder.DropForeignKey(
                name: "FK_StampingSession_Product",
                table: "StampingSession");

            migrationBuilder.DropForeignKey(
                name: "FK_StampingSession_Robot",
                table: "StampingSession");

            migrationBuilder.DropForeignKey(
                name: "FK_StampingSession_TaskAssignment",
                table: "StampingSession");

            migrationBuilder.DropForeignKey(
                name: "FK_StampingSession_User",
                table: "StampingSession");

            migrationBuilder.DropTable(
                name: "StampingTask");

            migrationBuilder.DropTable(
                name: "StampingProcess");

            migrationBuilder.DropIndex(
                name: "IX_StampingSession_TaskAssignmentID",
                table: "StampingSession");

            migrationBuilder.DropColumn(
                name: "TaskAssignmentID",
                table: "StampingSession");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Robot");

            migrationBuilder.RenameColumn(
                name: "TimeStamp",
                table: "TaskAssignment",
                newName: "CreateAt");

            migrationBuilder.RenameColumn(
                name: "Action",
                table: "TaskAssignment",
                newName: "ImageCaptured");

            migrationBuilder.RenameColumn(
                name: "Tyoe",
                table: "Stamp",
                newName: "Type");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Users",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Users",
                type: "character varying(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Users",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JobID",
                table: "TaskAssignment",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "TaskAssignment",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "TaskAssignment",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "StampingSession",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "StampingSession",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<int>(
                name: "RobotID",
                table: "StampingSession",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                table: "StampingSession",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "StampingSession",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Size",
                table: "Stamp",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "InkColor",
                table: "Stamp",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Stamp",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Stamp",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Stamp",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Robot",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Robot",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Robot",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Robot",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Robot",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StampID",
                table: "Product",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Product",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Material",
                table: "Product",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Product",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Product",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StampingJob",
                columns: table => new
                {
                    JobID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StepNumber = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    SessionID = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StampingJob", x => x.JobID);
                    table.ForeignKey(
                        name: "FK_StampingSession_StampingJob",
                        column: x => x.SessionID,
                        principalTable: "StampingSession",
                        principalColumn: "SessionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StampingJobParameters",
                columns: table => new
                {
                    JobParameterID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    JobId = table.Column<int>(type: "integer", nullable: false),
                    Base = table.Column<float>(type: "real", nullable: false),
                    Upperarm = table.Column<float>(type: "real", nullable: false),
                    Forearm = table.Column<float>(type: "real", nullable: false),
                    Wrist = table.Column<float>(type: "real", nullable: false),
                    RotationWrist = table.Column<float>(type: "real", nullable: false),
                    Gripper = table.Column<float>(type: "real", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
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
                name: "IX_TaskAssignment_JobID",
                table: "TaskAssignment",
                column: "JobID");

            migrationBuilder.CreateIndex(
                name: "IX_StampingJob_SessionID",
                table: "StampingJob",
                column: "SessionID");

            migrationBuilder.CreateIndex(
                name: "IX_StampingJobParameters_JobId",
                table: "StampingJobParameters",
                column: "JobId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Stamp_Product",
                table: "Product",
                column: "StampID",
                principalTable: "Stamp",
                principalColumn: "StampID");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Robot",
                table: "Robot",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_StampingSession",
                table: "StampingSession",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_Robot_StampingSession",
                table: "StampingSession",
                column: "RobotID",
                principalTable: "Robot",
                principalColumn: "RobotID");

            migrationBuilder.AddForeignKey(
                name: "FK_StampingSession_User",
                table: "StampingSession",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_StampingJob_TaskAssignment",
                table: "TaskAssignment",
                column: "JobID",
                principalTable: "StampingJob",
                principalColumn: "JobID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stamp_Product",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Robot",
                table: "Robot");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_StampingSession",
                table: "StampingSession");

            migrationBuilder.DropForeignKey(
                name: "FK_Robot_StampingSession",
                table: "StampingSession");

            migrationBuilder.DropForeignKey(
                name: "FK_StampingSession_User",
                table: "StampingSession");

            migrationBuilder.DropForeignKey(
                name: "FK_StampingJob_TaskAssignment",
                table: "TaskAssignment");

            migrationBuilder.DropTable(
                name: "StampingJobParameters");

            migrationBuilder.DropTable(
                name: "StampingJob");

            migrationBuilder.DropIndex(
                name: "IX_TaskAssignment_JobID",
                table: "TaskAssignment");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "JobID",
                table: "TaskAssignment");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "TaskAssignment");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "TaskAssignment");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "StampingSession");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Stamp");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Stamp");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Robot");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Robot");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Robot");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "ImageCaptured",
                table: "TaskAssignment",
                newName: "Action");

            migrationBuilder.RenameColumn(
                name: "CreateAt",
                table: "TaskAssignment",
                newName: "TimeStamp");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Stamp",
                newName: "Tyoe");

            migrationBuilder.AlterColumn<int>(
                name: "Role",
                table: "Users",
                type: "integer",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Users",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Users",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "StampingSession",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "StampingSession",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "RobotID",
                table: "StampingSession",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                table: "StampingSession",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TaskAssignmentID",
                table: "StampingSession",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Size",
                table: "Stamp",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "InkColor",
                table: "Stamp",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Tyoe",
                table: "Stamp",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Robot",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Robot",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Robot",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "StampID",
                table: "Product",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Product",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Material",
                table: "Product",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateTable(
                name: "StampingProcess",
                columns: table => new
                {
                    ProcessID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SessionID = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    StepNumber = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StampingProcess", x => x.ProcessID);
                    table.ForeignKey(
                        name: "FK_StampingProcess_StampingSession",
                        column: x => x.SessionID,
                        principalTable: "StampingSession",
                        principalColumn: "SessionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StampingTask",
                columns: table => new
                {
                    TaskID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProcessID = table.Column<int>(type: "integer", nullable: false),
                    RobotID = table.Column<int>(type: "integer", nullable: false),
                    TaskAssignmentID = table.Column<int>(type: "integer", nullable: true),
                    ImageCaptured = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Status = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StampingTask", x => x.TaskID);
                    table.ForeignKey(
                        name: "FK_StampingTask_Process",
                        column: x => x.ProcessID,
                        principalTable: "StampingProcess",
                        principalColumn: "ProcessID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StampingTask_Robot",
                        column: x => x.RobotID,
                        principalTable: "Robot",
                        principalColumn: "RobotID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StampingTask_TaskAssignment",
                        column: x => x.TaskAssignmentID,
                        principalTable: "TaskAssignment",
                        principalColumn: "TaskAssignmentID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_StampingSession_TaskAssignmentID",
                table: "StampingSession",
                column: "TaskAssignmentID");

            migrationBuilder.CreateIndex(
                name: "IX_StampingProcess_SessionID",
                table: "StampingProcess",
                column: "SessionID");

            migrationBuilder.CreateIndex(
                name: "IX_StampingTask_ProcessID",
                table: "StampingTask",
                column: "ProcessID");

            migrationBuilder.CreateIndex(
                name: "IX_StampingTask_RobotID",
                table: "StampingTask",
                column: "RobotID");

            migrationBuilder.CreateIndex(
                name: "IX_StampingTask_TaskAssignmentID",
                table: "StampingTask",
                column: "TaskAssignmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_StampID",
                table: "Product",
                column: "StampID",
                principalTable: "Stamp",
                principalColumn: "StampID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Robot_UserID",
                table: "Robot",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_StampingSession_Product",
                table: "StampingSession",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StampingSession_Robot",
                table: "StampingSession",
                column: "RobotID",
                principalTable: "Robot",
                principalColumn: "RobotID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StampingSession_TaskAssignment",
                table: "StampingSession",
                column: "TaskAssignmentID",
                principalTable: "TaskAssignment",
                principalColumn: "TaskAssignmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_StampingSession_User",
                table: "StampingSession",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
