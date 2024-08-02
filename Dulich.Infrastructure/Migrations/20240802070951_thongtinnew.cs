using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dulich.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class thongtinnew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "icon",
                table: "Menu",
                newName: "Icon");

            migrationBuilder.AlterColumn<int>(
                name: "IDParent",
                table: "Menu",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Icon",
                table: "Menu",
                newName: "icon");

            migrationBuilder.AlterColumn<int>(
                name: "IDParent",
                table: "Menu",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);
        }
    }
}
