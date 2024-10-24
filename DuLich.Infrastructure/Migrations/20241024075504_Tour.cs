using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Travel.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Tour : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Khuyenmai",
                table: "DatTour",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "DienThoai",
                table: "DatTour",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "DatTour",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Hoten",
                table: "DatTour",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TinhTrang",
                table: "DatTour",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ĐiaChi",
                table: "DatTour",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tour",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IDThongtinChuyenDi = table.Column<int>(type: "int", nullable: false),
                    LichTrinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThongTinLuuY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayDi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TongGia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Khuyenmai = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ThoiGian = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KhoiHanh = table.Column<int>(type: "int", nullable: false),
                    ChoNgoi = table.Column<int>(type: "int", nullable: false),
                    Album = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tour", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tour");

            migrationBuilder.DropColumn(
                name: "DienThoai",
                table: "DatTour");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "DatTour");

            migrationBuilder.DropColumn(
                name: "Hoten",
                table: "DatTour");

            migrationBuilder.DropColumn(
                name: "TinhTrang",
                table: "DatTour");

            migrationBuilder.DropColumn(
                name: "ĐiaChi",
                table: "DatTour");

            migrationBuilder.AlterColumn<int>(
                name: "Khuyenmai",
                table: "DatTour",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
