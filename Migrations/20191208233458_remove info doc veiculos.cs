using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace net_car_ASPNETCORE.Migrations
{
    public partial class removeinfodocveiculos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "data_documento",
                table: "DocumentoVeiculo");

            migrationBuilder.DropColumn(
                name: "status",
                table: "DocumentoVeiculo");

            migrationBuilder.DropColumn(
                name: "valor_renovacao",
                table: "DocumentoVeiculo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "data_documento",
                table: "DocumentoVeiculo",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "DocumentoVeiculo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "valor_renovacao",
                table: "DocumentoVeiculo",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
