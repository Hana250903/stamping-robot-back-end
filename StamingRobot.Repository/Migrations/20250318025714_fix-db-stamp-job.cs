using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StamingRobot.Repository.Migrations
{
    /// <inheritdoc />
    public partial class fixdbstampjob : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Parameters",
                table: "StampingJob");

            migrationBuilder.AddColumn<string>(
                name: "Action",
                table: "StampingJob",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Action",
                table: "StampingJob");

            migrationBuilder.AddColumn<string>(
                name: "Parameters",
                table: "StampingJob",
                type: "jsonb",
                nullable: false,
                defaultValue: "");
        }
    }
}
