using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace net_car_ASPNETCORE.Models
{
    public class Seguro
    {
        [DisplayName("Contrato do Seguro")]
        [Key]
        public string contrato_seguro { get; set; }
        [DisplayName("Tipo do Seguro")]
        public string tipo_seguro { get; set; }
        [DisplayName("Valor do Seguro")]
        public double valor { get; set; }
    }
}
