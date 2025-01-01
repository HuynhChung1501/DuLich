using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Travel.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class permission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    MaChucNang = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenChucNang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NhomChucNang = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.MaChucNang);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.CreateTable(
                name: "ChucNang",
                columns: table => new
                {
                    MaChucNang = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NhomChucNang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenChucNang = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChucNang", x => x.MaChucNang);
                });
        }
    }
}
