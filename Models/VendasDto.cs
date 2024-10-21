using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Pim_Web.Models
{
    public class VendasDto
    {
        [MaxLength(100)]
        [Required(ErrorMessage = "Digite a data de venda")]
        public string DataVe { get; set; } = "";

        [MaxLength(100)]
        [Required(ErrorMessage = "Digite a data de entrega")]
        public string DataEn { get; set; } = "";

        [Precision(16, 2)]
        [Required(ErrorMessage = "Digite o valor da venda")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "Digite a quantidade de itens da venda")]
        public int QuantidadeItens { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage = "Digite o nome do vendedor")]
        public string Vendedor { get; set; } = "";
    }
}
