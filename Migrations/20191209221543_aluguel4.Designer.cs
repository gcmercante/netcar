﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using net_car_ASPNETCORE.Models;

namespace net_car_ASPNETCORE.Migrations
{
    [DbContext(typeof(net_car_ASPNETCOREContext))]
    [Migration("20191209221543_aluguel4")]
    partial class aluguel4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("net_car_ASPNETCORE.Models.Aluguel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("cliente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("data_aluguel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("data_devolucao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("duracao")
                        .HasColumnType("int");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("valor_aluguel")
                        .HasColumnType("real");

                    b.Property<string>("veiculo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Aluguel");
                });

            modelBuilder.Entity("net_car_ASPNETCORE.Models.Cliente", b =>
                {
                    b.Property<string>("cnpj")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("segmento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("senha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("user")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("cnpj");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("net_car_ASPNETCORE.Models.DocumentoVeiculo", b =>
                {
                    b.Property<string>("documento_veiculo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("veiculo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("documento_veiculo");

                    b.ToTable("DocumentoVeiculo");
                });

            modelBuilder.Entity("net_car_ASPNETCORE.Models.Manutencao", b =>
                {
                    b.Property<string>("ordem_servico")
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("custo_manutencao")
                        .HasColumnType("real");

                    b.Property<string>("data_manutencao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tipo_manutencao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("veiculo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ordem_servico");

                    b.ToTable("Manutencao");
                });

            modelBuilder.Entity("net_car_ASPNETCORE.Models.Motorista", b =>
                {
                    b.Property<string>("cnh")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("cnpj_cliente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cpf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("cnh");

                    b.ToTable("Motorista");
                });

            modelBuilder.Entity("net_car_ASPNETCORE.Models.Seguro", b =>
                {
                    b.Property<string>("contrato_seguro")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("tipo_seguro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("valor")
                        .HasColumnType("float");

                    b.HasKey("contrato_seguro");

                    b.ToTable("Seguro");
                });

            modelBuilder.Entity("net_car_ASPNETCORE.Models.Veiculo", b =>
                {
                    b.Property<string>("documento_veiculo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("cliente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ipva")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("marca")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("modelo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("placa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("quilometragem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("seguro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("documento_veiculo");

                    b.ToTable("Veiculo");
                });

            modelBuilder.Entity("net_car_ASPNETCORE.Models.Viagem", b =>
                {
                    b.Property<string>("numero_chamado")
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("abastecimento")
                        .HasColumnType("real");

                    b.Property<string>("cnh_motorista")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cnpj_cliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("data_viagem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("destino")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("distancia")
                        .HasColumnType("real");

                    b.Property<string>("documento_veiculo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("estacionamento")
                        .HasColumnType("real");

                    b.Property<float>("multa")
                        .HasColumnType("real");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("numero_chamado");

                    b.ToTable("Viagem");
                });

            modelBuilder.Entity("net_car_ASPNETCORE.Models.sp_relatorio_cliente_x_motorista", b =>
                {
                    b.Property<string>("Cliente")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Motorista")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Cliente");

                    b.ToTable("Relatorio_Cliente_x_Motorista");
                });

            modelBuilder.Entity("net_car_ASPNETCORE.Models.sp_relatorio_cliente_x_veiculo", b =>
                {
                    b.Property<string>("Cliente")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Status_Veiculo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Veiculo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Cliente");

                    b.ToTable("Relatorio_Cliente_x_Veiculo");
                });

            modelBuilder.Entity("net_car_ASPNETCORE.Models.sp_relatorio_custo_viagem", b =>
                {
                    b.Property<string>("Chamado")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Cliente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Custo_Total")
                        .HasColumnType("real");

                    b.Property<string>("Data_Viagem")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Chamado");

                    b.ToTable("Relatorio_Custo_Viagens");
                });

            modelBuilder.Entity("net_car_ASPNETCORE.Models.sp_relatorio_gastos", b =>
                {
                    b.Property<string>("Cliente")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Custo_Total")
                        .HasColumnType("float");

                    b.Property<int>("Numero_Chamados")
                        .HasColumnType("int");

                    b.HasKey("Cliente");

                    b.ToTable("Relatorio_Gastos");
                });

            modelBuilder.Entity("net_car_ASPNETCORE.Models.sp_relatorio_manutencao", b =>
                {
                    b.Property<string>("Ordem_Servico")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Cliente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Custo_Manutencao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Data_Manutencao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo_Manutencao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Veiculo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Ordem_Servico");

                    b.ToTable("Relatorio_Manutencao");
                });

            modelBuilder.Entity("net_car_ASPNETCORE.Models.sp_relatorio_viagem", b =>
                {
                    b.Property<string>("Chamado")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Cliente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Custo_Total")
                        .HasColumnType("real");

                    b.Property<string>("Data_Viagem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Destino")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Motorista")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Placa_Veiculo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Chamado");

                    b.ToTable("Relatorio_Viagens");
                });
#pragma warning restore 612, 618
        }
    }
}
