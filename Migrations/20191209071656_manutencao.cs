using Microsoft.EntityFrameworkCore.Migrations;

namespace net_car_ASPNETCORE.Migrations
{
    public partial class manutencao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Manutencao",
                columns: table => new
                {
                    ordem_servico = table.Column<string>(nullable: false),
                    veiculo = table.Column<string>(nullable: true),
                    tipo_manutencao = table.Column<string>(nullable: true),
                    custo_manutencao = table.Column<float>(nullable: false),
                    status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manutencao", x => x.ordem_servico);
                });

            migrationBuilder.CreateTable(
                name: "Relatorio_Cliente_x_Veiculo",
                columns: table => new
                {
                    Cliente = table.Column<string>(nullable: false),
                    Veiculo = table.Column<string>(nullable: true),
                    Status_Veiculo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relatorio_Cliente_x_Veiculo", x => x.Cliente);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Manutencao");

            migrationBuilder.DropTable(
                name: "Relatorio_Cliente_x_Veiculo");
        }
    }
}
