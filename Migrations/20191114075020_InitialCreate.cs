using Microsoft.EntityFrameworkCore.Migrations;

namespace net_car_ASPNETCORE.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Motorista",
                columns: table => new
                {
                    cnh = table.Column<string>(nullable: false),
                    nome = table.Column<string>(nullable: true),
                    cpf = table.Column<string>(nullable: true),
                    cnpj_cliente = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motorista", x => x.cnh);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Motorista");
        }
    }
}
