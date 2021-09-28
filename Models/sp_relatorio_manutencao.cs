using System.ComponentModel.DataAnnotations;

namespace net_car_ASPNETCORE.Models
{
    public class sp_relatorio_manutencao
    {
        [Key]
        public string Ordem_Servico { get; set; }
        public string Veiculo { get; set; }
        public string Cliente { get; set; }
        public string Tipo_Manutencao { get; set; }
        public string Custo_Manutencao { get; set; }
        public string Data_Manutencao { get; set; }
    }
}
