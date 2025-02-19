using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StamingRobot.Repository.Migrations
{
    /// <inheritdoc />
    public partial class fix_robot_entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Robot_UserID",
                table: "Robot");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Robot",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Robot_UserID",
                table: "Robot",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Robot_UserID",
                table: "Robot");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Robot",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Robot_UserID",
                table: "Robot",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
