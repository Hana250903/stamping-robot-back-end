using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace StamingRobot.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Initialdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:Role", "Admin,Employee");

            migrationBuilder.CreateTable(
                name: "Stamp",
                columns: table => new
                {
                    StampID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Tyoe = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Size = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    InkColor = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stamp", x => x.StampID);
                });

            migrationBuilder.CreateTable(
                name: "TaskAssignment",
                columns: table => new
                {
                    TaskAssignmentID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TimeStamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Action = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Details = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskAssignment", x => x.TaskAssignmentID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FullName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Phone = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    UserName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CodeOTPEmail = table.Column<int>(type: "integer", nullable: true),
                    Role = table.Column<int>(type: "integer", maxLength: 20, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Dimensions = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Material = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    StampID = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Product_StampID",
                        column: x => x.StampID,
                        principalTable: "Stamp",
                        principalColumn: "StampID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Robot",
                columns: table => new
                {
                    RobotID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Model = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Status = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Position = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    UserID = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Robot", x => x.RobotID);
                    table.ForeignKey(
                        name: "FK_Robot_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StampingSession",
                columns: table => new
                {
                    SessionID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserID = table.Column<int>(type: "integer", nullable: false),
                    RobotID = table.Column<int>(type: "integer", nullable: false),
                    ProductID = table.Column<int>(type: "integer", nullable: false),
                    TaskAssignmentID = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StampingSession", x => x.SessionID);
                    table.ForeignKey(
                        name: "FK_StampingSession_Product",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StampingSession_Robot",
                        column: x => x.RobotID,
                        principalTable: "Robot",
                        principalColumn: "RobotID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StampingSession_TaskAssignment",
                        column: x => x.TaskAssignmentID,
                        principalTable: "TaskAssignment",
                        principalColumn: "TaskAssignmentID");
                    table.ForeignKey(
                        name: "FK_StampingSession_User",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StampingProcess",
                columns: table => new
                {
                    ProcessID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StepNumber = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    SessionID = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
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
                    Status = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ImageCaptured = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    RobotID = table.Column<int>(type: "integer", nullable: false),
                    ProcessID = table.Column<int>(type: "integer", nullable: false),
                    TaskAssignmentID = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
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
                name: "IX_Product_StampID",
                table: "Product",
                column: "StampID");

            migrationBuilder.CreateIndex(
                name: "IX_Robot_UserID",
                table: "Robot",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_StampingProcess_SessionID",
                table: "StampingProcess",
                column: "SessionID");

            migrationBuilder.CreateIndex(
                name: "IX_StampingSession_ProductID",
                table: "StampingSession",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_StampingSession_RobotID",
                table: "StampingSession",
                column: "RobotID");

            migrationBuilder.CreateIndex(
                name: "IX_StampingSession_TaskAssignmentID",
                table: "StampingSession",
                column: "TaskAssignmentID");

            migrationBuilder.CreateIndex(
                name: "IX_StampingSession_UserID",
                table: "StampingSession",
                column: "UserID");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StampingTask");

            migrationBuilder.DropTable(
                name: "StampingProcess");

            migrationBuilder.DropTable(
                name: "StampingSession");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Robot");

            migrationBuilder.DropTable(
                name: "TaskAssignment");

            migrationBuilder.DropTable(
                name: "Stamp");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
