using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dulich.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class thongtin1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ThongTinPhuongTien",
                table: "ThongTinPhuongTien");

            migrationBuilder.RenameTable(
                name: "ThongTinPhuongTien",
                newName: "PhuongTien");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhuongTien",
                table: "PhuongTien",
                column: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PhuongTien",
                table: "PhuongTien");

            migrationBuilder.RenameTable(
                name: "PhuongTien",
                newName: "ThongTinPhuongTien");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ThongTinPhuongTien",
                table: "ThongTinPhuongTien",
                column: "ID");
        }
    }
}
