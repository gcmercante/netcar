using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace net_car_ASPNETCORE.Models
{
    public class Veiculo
    {
        [DisplayName("Documento do Veículo")]
        [ForeignKey("DocumentoVeiculo")]
        [Key]
        public string documento_veiculo { get; set; }
        [DisplayName("Marca")]
        public string marca { get; set; }
        [DisplayName("Cor")]
        public string cor { get; set; }
        [DisplayName("Modelo")]
        public string modelo { get; set; }
        [DisplayName("Placa")]
        public string placa { get; set; }
        [DisplayName("Quilometragem")]
        public string quilometragem { get; set; }
        [DisplayName("Seguro")]
        [ForeignKey("Seguro")]
        public string seguro { get; set; }
        [DisplayName("IPVA")]
        public string ipva { get; set; }
        [DisplayName("Status")]
        public string status { get; set; }
        [DisplayName("Cliente")]
        public string cliente { get; set; }
    }
}
