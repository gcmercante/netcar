using Microsoft.EntityFrameworkCore.Migrations;

namespace net_car_ASPNETCORE.Migrations
{
    public partial class clienteveiculo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "cliente",
                table: "Veiculo",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Relatorio_Cliente_x_Motorista",
                columns: table => new
                {
                    Cliente = table.Column<string>(nullable: false),
                    Motorista = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relatorio_Cliente_x_Motorista", x => x.Cliente);
                });

            migrationBuilder.CreateTable(
                name: "Relatorio_Custo_Viagens",
                columns: table => new
                {
                    Chamado = table.Column<string>(nullable: false),
                    Cliente = table.Column<string>(nullable: true),
                    Custo_Total = table.Column<float>(nullable: false),
                    Data_Viagem = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relatorio_Custo_Viagens", x => x.Chamado);
                });

            migrationBuilder.CreateTable(
                name: "Relatorio_Gastos",
                columns: table => new
                {
                    Cliente = table.Column<string>(nullable: false),
                    Numero_Chamados = table.Column<int>(nullable: false),
                    Custo_Total = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relatorio_Gastos", x => x.Cliente);
                });

            migrationBuilder.CreateTable(
                name: "Relatorio_Viagens",
                columns: table => new
                {
                    Chamado = table.Column<string>(nullable: false),
                    Cliente = table.Column<string>(nullable: true),
                    Motorista = table.Column<string>(nullable: true),
                    Placa_Veiculo = table.Column<string>(nullable: true),
                    Destino = table.Column<string>(nullable: true),
                    Custo_Total = table.Column<float>(nullable: false),
                    Data_Viagem = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relatorio_Viagens", x => x.Chamado);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Relatorio_Cliente_x_Motorista");

            migrationBuilder.DropTable(
                name: "Relatorio_Custo_Viagens");

            migrationBuilder.DropTable(
                name: "Relatorio_Gastos");

            migrationBuilder.DropTable(
                name: "Relatorio_Viagens");

            migrationBuilder.DropColumn(
                name: "cliente",
                table: "Veiculo");
        }
    }
}
