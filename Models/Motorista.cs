using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace net_car_ASPNETCORE.Models
{
    public class Motorista
    {
        [DisplayName("CNH")]
        [Key]
        public string cnh { get; set; }
        [DisplayName("Nome")]
        public string nome { get; set; }
        [DisplayName("CPF")]
        public string cpf { get; set; }
        [DisplayName("CNPJ Cliente")]
        [ForeignKey("Cliente")]
        public string cnpj_cliente { get; set; }
        [DisplayName("Status")]
        public string status { get; set; }
    }
}
