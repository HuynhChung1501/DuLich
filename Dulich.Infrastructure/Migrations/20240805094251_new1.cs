using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dulich.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class new1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DatPhong",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDHotel = table.Column<int>(type: "int", nullable: false),
                    IDRoom = table.Column<int>(type: "int", nullable: false),
                    CountGuest = table.Column<int>(type: "int", nullable: true),
                    PriceOld = table.Column<int>(type: "int", nullable: true),
                    PriceNew = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatPhong", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "KhachSan",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Segment = table.Column<int>(type: "int", nullable: true),
                    Rating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vote = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalRoom = table.Column<int>(type: "int", nullable: true),
                    Album = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceOld = table.Column<int>(type: "int", nullable: true),
                    PriceNew = table.Column<int>(type: "int", nullable: true),
                    IDUtilities = table.Column<int>(type: "int", nullable: true),
                    Descrition = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Active = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachSan", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LoaiPhong",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IDHotel = table.Column<int>(type: "int", nullable: false),
                    IDRoom = table.Column<int>(type: "int", nullable: false),
                    IDUtilities = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiPhong", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PhongKS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IDHotel = table.Column<int>(type: "int", nullable: false),
                    IDTypeRoom = table.Column<int>(type: "int", nullable: false),
                    Acreage = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CountGuest = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhongKS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TienIchPhong",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountBed = table.Column<int>(type: "int", nullable: true),
                    NongLanh = table.Column<int>(type: "int", nullable: true),
                    DieuHoa = table.Column<int>(type: "int", nullable: true),
                    TienIchNangCao = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TienIchPhong", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DatPhong");

            migrationBuilder.DropTable(
                name: "KhachSan");

            migrationBuilder.DropTable(
                name: "LoaiPhong");

            migrationBuilder.DropTable(
                name: "PhongKS");

            migrationBuilder.DropTable(
                name: "TienIchPhong");
        }
    }
}
