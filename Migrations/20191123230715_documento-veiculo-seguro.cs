using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace net_car_ASPNETCORE.Migrations
{
    public partial class documentoveiculoseguro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DocumentoVeiculo",
                columns: table => new
                {
                    documento_veiculo = table.Column<string>(nullable: false),
                    veiculo = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: true),
                    data_documento = table.Column<DateTime>(nullable: false),
                    valor_renovacao = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentoVeiculo", x => x.documento_veiculo);
                });

            migrationBuilder.CreateTable(
                name: "Seguro",
                columns: table => new
                {
                    contrato_seguro = table.Column<string>(nullable: false),
                    tipo_seguro = table.Column<string>(nullable: true),
                    valor = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seguro", x => x.contrato_seguro);
                });

            migrationBuilder.CreateTable(
                name: "Veiculo",
                columns: table => new
                {
                    documento_veiculo = table.Column<string>(nullable: false),
                    marca = table.Column<string>(nullable: true),
                    cor = table.Column<string>(nullable: true),
                    modelo = table.Column<string>(nullable: true),
                    placa = table.Column<string>(nullable: true),
                    quilometragem = table.Column<string>(nullable: true),
                    seguro = table.Column<string>(nullable: true),
                    dpvat = table.Column<string>(nullable: true),
                    ipva = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculo", x => x.documento_veiculo);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentoVeiculo");

            migrationBuilder.DropTable(
                name: "Seguro");

            migrationBuilder.DropTable(
                name: "Veiculo");
        }
    }
}
