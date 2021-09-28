using System;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace net_car_ASPNETCORE.Models
{
    public class DocumentoVeiculo
    {
        [DisplayName("Documento Veículo")]
        [Key]
        public string documento_veiculo { get; set; }
        [DisplayName("Veículo")]
        public string veiculo { get; set; }
    }
}
