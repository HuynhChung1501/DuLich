using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Travel.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class phuongtin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "ThongTinChuyenDi",
                newName: "GioKhoiHanh");

            migrationBuilder.RenameColumn(
                name: "Seating",
                table: "ThongTinChuyenDi",
                newName: "ChoNgoi");

            migrationBuilder.RenameColumn(
                name: "PickupLocation",
                table: "ThongTinChuyenDi",
                newName: "DiemTraKhach");

            migrationBuilder.RenameColumn(
                name: "IDTransport",
                table: "ThongTinChuyenDi",
                newName: "DiemDon");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "ThongTinChuyenDi",
                newName: "MoTa");

            migrationBuilder.AddColumn<DateTime>(
                name: "GioTraKhach",
                table: "ThongTinChuyenDi",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IDPhuongTien",
                table: "ThongTinChuyenDi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsActive",
                table: "ThongTinChuyenDi",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GioTraKhach",
                table: "ThongTinChuyenDi");

            migrationBuilder.DropColumn(
                name: "IDPhuongTien",
                table: "ThongTinChuyenDi");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ThongTinChuyenDi");

            migrationBuilder.RenameColumn(
                name: "MoTa",
                table: "ThongTinChuyenDi",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "GioKhoiHanh",
                table: "ThongTinChuyenDi",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "DiemTraKhach",
                table: "ThongTinChuyenDi",
                newName: "PickupLocation");

            migrationBuilder.RenameColumn(
                name: "DiemDon",
                table: "ThongTinChuyenDi",
                newName: "IDTransport");

            migrationBuilder.RenameColumn(
                name: "ChoNgoi",
                table: "ThongTinChuyenDi",
                newName: "Seating");
        }
    }
}
