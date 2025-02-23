using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StamingRobot.Repository.Migrations
{
    /// <inheritdoc />
    public partial class add_googleId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GoogleId",
                table: "Users",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GoogleId",
                table: "Users");
        }
    }
}
