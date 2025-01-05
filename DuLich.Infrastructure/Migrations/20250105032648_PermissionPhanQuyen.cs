using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Travel.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PermissionPhanQuyen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Permission",
                table: "Permission");

            migrationBuilder.DropColumn(
                name: "MaChucNang",
                table: "PhanQuyen");

            migrationBuilder.DropColumn(
                name: "MaChucNang",
                table: "Permission");

            migrationBuilder.DropColumn(
                name: "NhomChucNang",
                table: "Permission");

            migrationBuilder.RenameColumn(
                name: "TenChucNang",
                table: "Permission",
                newName: "Describe");

            migrationBuilder.AddColumn<int>(
                name: "Permission_id",
                table: "PhanQuyen",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Permission",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Permission",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Permission",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Module_type",
                table: "Permission",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Permission",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Permission_type",
                table: "Permission",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "Permission",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Permission",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Group_permission_id",
                table: "Account",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Permission",
                table: "Permission",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Group_Permission",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Describe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group_Permission", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Group_permission_rel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Permission_id = table.Column<int>(type: "int", nullable: false),
                    Group_permission_id = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group_permission_rel", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Group_Permission");

            migrationBuilder.DropTable(
                name: "Group_permission_rel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Permission",
                table: "Permission");

            migrationBuilder.DropColumn(
                name: "Permission_id",
                table: "PhanQuyen");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Permission");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Permission");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Permission");

            migrationBuilder.DropColumn(
                name: "Module_type",
                table: "Permission");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Permission");

            migrationBuilder.DropColumn(
                name: "Permission_type",
                table: "Permission");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Permission");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Permission");

            migrationBuilder.DropColumn(
                name: "Group_permission_id",
                table: "Account");

            migrationBuilder.RenameColumn(
                name: "Describe",
                table: "Permission",
                newName: "TenChucNang");

            migrationBuilder.AddColumn<string>(
                name: "MaChucNang",
                table: "PhanQuyen",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MaChucNang",
                table: "Permission",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NhomChucNang",
                table: "Permission",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Permission",
                table: "Permission",
                column: "MaChucNang");
        }
    }
}
