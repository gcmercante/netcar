using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace net_car_ASPNETCORE.Models
{
    public class Manutencao
    {
        [Key]
        [DisplayName("Ordem de Serviço")]
        public string ordem_servico { get; set; }
        [ForeignKey("Veiculo")]
        [DisplayName("Veículo")]
        public string veiculo { get; set; }
        [DisplayName("Tipo da Manutenção")]
        public string tipo_manutencao { get; set; }
        [DisplayName("Custo Manutenção")]
        public float custo_manutencao { get; set; }
        [DisplayName("Status")]
        public string status { get; set; }
        [DisplayName("Data Manutenção")]
        public string data_manutencao { get; set; }
    }
}
