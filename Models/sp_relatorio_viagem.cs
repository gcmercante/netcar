using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace net_car_ASPNETCORE.Models
{
    public class sp_relatorio_viagem
    {
        [Key]
        [DisplayName("Chamado")]
        public string Chamado { get; set; }
        [DisplayName("Cliente")]
        public string Cliente { get; set; }
        [DisplayName("Motorista")]
        public string Motorista { get; set; }
        [DisplayName("Placa_Veiculo")]
        public string Placa_Veiculo { get; set; }
        [DisplayName("Destino")]
        public string Destino { get; set; }
        [DisplayName("Custo_Total")]
        public float Custo_Total { get; set; }
        [DisplayName("Data_Viagem")]
        public string Data_Viagem { get; set; }
        [DisplayName("Status")]
        public string Status { get; set; }
    }
}
