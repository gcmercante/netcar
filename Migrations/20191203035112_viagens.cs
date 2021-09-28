using Microsoft.EntityFrameworkCore.Migrations;

namespace net_car_ASPNETCORE.Migrations
{
    public partial class viagens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Viagem",
                columns: table => new
                {
                    numero_chamado = table.Column<string>(nullable: false),
                    cnh_motorista = table.Column<string>(nullable: false),
                    cnpj_cliente = table.Column<string>(nullable: false),
                    documento_veiculo = table.Column<string>(nullable: false),
                    status = table.Column<string>(nullable: false),
                    destino = table.Column<string>(nullable: false),
                    distancia = table.Column<string>(nullable: true),
                    abastecimento = table.Column<string>(nullable: true),
                    multa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viagem", x => x.numero_chamado);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Viagem");
        }
    }
}
