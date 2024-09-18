using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Travel.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addFullName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Account",
                newName: "UsereName");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Account",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Gender",
                table: "Account",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Account");

            migrationBuilder.RenameColumn(
                name: "UsereName",
                table: "Account",
                newName: "Name");
        }
    }
}
