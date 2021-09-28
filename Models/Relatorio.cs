using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace net_car_ASPNETCORE.Models
{
    public class Relatorio
    {
        public string tipo_relatorio { get; set; }
        [DisplayName("E-mail")]
        public string email { get; set; }
    }
}
