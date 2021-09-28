using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace net_car_ASPNETCORE.Models
{
    public class sp_relatorio_cliente_x_motorista
    {
        [Key]
        public string Cliente { get; set; }
        public string Motorista { get; set; }
    }
}
