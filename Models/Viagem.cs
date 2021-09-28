using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System;

namespace net_car_ASPNETCORE.Models
{
    public class Viagem
    {
        [DisplayName("Número do chamado")]
        [Key]
        public string numero_chamado { get; set; }
        [DisplayName("Motorista")]
        [ForeignKey("Motorista")]
        [Required]
        public string cnh_motorista { get; set; }
        [DisplayName("Cliente")]
        [ForeignKey("Cliente")]
        [Required]
        public string cnpj_cliente { get; set; }
        [DisplayName("Veiculo")]
        [ForeignKey("Veiculo")]
        [Required]
        public string documento_veiculo { get; set; }
        [DisplayName("Status")]
        [Required]
        public string status { get; set; }
        [DisplayName("Destino")]
        [Required]
        public string destino { get; set; }
        [DisplayName("Distância percorrida")]
        [DefaultValue(0)]
        public float distancia { get; set; }
        [DisplayName("Abastecimento")]
        [DefaultValue(0.00)]
        public float abastecimento { get; set; }
        [DisplayName("Multa")]
        [DefaultValue(0.00)]
        public float multa { get; set; }
        [DisplayName("Estacionamento")]
        [DefaultValue(0.00)]
        public float estacionamento { get; set; }
        [DisplayName("Data da Viagem")]
        public string data_viagem { get; set; }
    }
}
