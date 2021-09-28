using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace net_car_ASPNETCORE.Models
{
    public class sp_relatorio_gastos
    {
        [Key]
        public string Cliente { get; set; }
        public int Numero_Chamados { get; set; }
        public double Custo_Total { get; set; }
    }
}
