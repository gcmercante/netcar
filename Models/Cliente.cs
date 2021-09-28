using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace net_car_ASPNETCORE.Models
{
    public class Cliente
    {
        [DisplayName("CNPJ")]
        [Key]
        public string cnpj { get; set; }
        [DisplayName("Nome")]
        public string nome { get; set; }
        [DisplayName("Segmento")]
        public string segmento { get; set; }
        [DisplayName("E-mail")]
        public string email { get; set; }
        [DisplayName("Usuário")]
        public string user { get; set; }
        [DisplayName("Senha")]
        public string senha { get; set; }
        [DisplayName("Status")]
        public string status { get; set; }
    }
}
