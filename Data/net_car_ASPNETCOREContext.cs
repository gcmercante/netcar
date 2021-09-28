using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using net_car_ASPNETCORE.Models;

namespace net_car_ASPNETCORE.Models
{
    public class net_car_ASPNETCOREContext : DbContext
    {
        public net_car_ASPNETCOREContext (DbContextOptions<net_car_ASPNETCOREContext> options)
            : base(options)
        {
        }

        public DbSet<net_car_ASPNETCORE.Models.Cliente> Cliente { get; set; }

        public DbSet<net_car_ASPNETCORE.Models.Motorista> Motorista { get; set; }

        public DbSet<net_car_ASPNETCORE.Models.Veiculo> Veiculo { get; set; }

        public DbSet<net_car_ASPNETCORE.Models.DocumentoVeiculo> DocumentoVeiculo { get; set; }

        public DbSet<net_car_ASPNETCORE.Models.Seguro> Seguro { get; set; }

        public DbSet<net_car_ASPNETCORE.Models.Viagem> Viagem { get; set; }
        public virtual DbSet<net_car_ASPNETCORE.Models.sp_relatorio_viagem> Relatorio_Viagens { get; set; }
        public virtual DbSet<net_car_ASPNETCORE.Models.sp_relatorio_custo_viagem> Relatorio_Custo_Viagens { get; set; }
        public virtual DbSet<net_car_ASPNETCORE.Models.sp_relatorio_gastos> Relatorio_Gastos { get; set; }
        public virtual DbSet<net_car_ASPNETCORE.Models.sp_relatorio_cliente_x_motorista> Relatorio_Cliente_x_Motorista { get; set; }
        public virtual DbSet<net_car_ASPNETCORE.Models.sp_relatorio_cliente_x_veiculo> Relatorio_Cliente_x_Veiculo { get; set; }
        public virtual DbSet<net_car_ASPNETCORE.Models.sp_relatorio_manutencao> Relatorio_Manutencao { get; set; }
        public DbSet<net_car_ASPNETCORE.Models.Manutencao> Manutencao { get; set; }
        public DbSet<net_car_ASPNETCORE.Models.Aluguel> Aluguel { get; set; }
    }
}
