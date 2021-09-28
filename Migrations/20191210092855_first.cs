using Microsoft.EntityFrameworkCore.Migrations;

namespace net_car_ASPNETCORE.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aluguel",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    veiculo = table.Column<string>(nullable: true),
                    cliente = table.Column<string>(nullable: true),
                    valor_aluguel = table.Column<float>(nullable: false),
                    data_aluguel = table.Column<string>(nullable: true),
                    data_devolucao = table.Column<string>(nullable: true),
                    duracao = table.Column<int>(nullable: false),
                    status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluguel", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    cnpj = table.Column<string>(nullable: false),
                    nome = table.Column<string>(nullable: true),
                    segmento = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    user = table.Column<string>(nullable: true),
                    senha = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.cnpj);
                });

            migrationBuilder.CreateTable(
                name: "DocumentoVeiculo",
                columns: table => new
                {
                    documento_veiculo = table.Column<string>(nullable: false),
                    veiculo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentoVeiculo", x => x.documento_veiculo);
                });

            migrationBuilder.CreateTable(
                name: "Manutencao",
                columns: table => new
                {
                    ordem_servico = table.Column<string>(nullable: false),
                    veiculo = table.Column<string>(nullable: true),
                    tipo_manutencao = table.Column<string>(nullable: true),
                    custo_manutencao = table.Column<float>(nullable: false),
                    status = table.Column<string>(nullable: true),
                    data_manutencao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manutencao", x => x.ordem_servico);
                });

            migrationBuilder.CreateTable(
                name: "Motorista",
                columns: table => new
                {
                    cnh = table.Column<string>(nullable: false),
                    nome = table.Column<string>(nullable: true),
                    cpf = table.Column<string>(nullable: true),
                    cnpj_cliente = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motorista", x => x.cnh);
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
                    ipva = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: true),
                    cliente = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculo", x => x.documento_veiculo);
                });

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
                    distancia = table.Column<float>(nullable: false),
                    abastecimento = table.Column<float>(nullable: false),
                    multa = table.Column<float>(nullable: false),
                    estacionamento = table.Column<float>(nullable: false),
                    data_viagem = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viagem", x => x.numero_chamado);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aluguel");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "DocumentoVeiculo");

            migrationBuilder.DropTable(
                name: "Manutencao");

            migrationBuilder.DropTable(
                name: "Motorista");

            migrationBuilder.DropTable(
                name: "Relatorio_Cliente_x_Motorista");

            migrationBuilder.DropTable(
                name: "Relatorio_Cliente_x_Veiculo");

            migrationBuilder.DropTable(
                name: "Relatorio_Custo_Viagens");

            migrationBuilder.DropTable(
                name: "Relatorio_Gastos");

            migrationBuilder.DropTable(
                name: "Relatorio_Manutencao");

            migrationBuilder.DropTable(
                name: "Relatorio_Viagens");

            migrationBuilder.DropTable(
                name: "Seguro");

            migrationBuilder.DropTable(
                name: "Veiculo");

            migrationBuilder.DropTable(
                name: "Viagem");
        }
    }
}
