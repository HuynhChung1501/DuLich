using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Travel.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addcolumnActivetableACount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Active",
                table: "Account",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Account");
        }
    }
}
