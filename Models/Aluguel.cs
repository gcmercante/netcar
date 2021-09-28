using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace net_car_ASPNETCORE.Models
{
    public class Aluguel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [ForeignKey("Veiculo")]
        [DisplayName("Veiculo")]
        public string veiculo { get; set; }
        [ForeignKey("Cliente")]
        [DisplayName("Cliente")]
        public string cliente { get; set; }
        [DisplayName("Valor do Aluguel")]
        public float valor_aluguel { get; set; }
        [DisplayName("Data do Aluguel")]
        public string data_aluguel { get; set; }
        [DisplayName("Data de Devolução")]
        public string data_devolucao { get; set; }
        [DisplayName("Duração do Aluguel")]
        public int duracao { get; set; } 
        [DisplayName("Status")]
        public string status { get; set; }
    }
}
