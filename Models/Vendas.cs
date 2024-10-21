using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Pim_Web.Models
{
    public class Vendas
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string DataVe { get; set; } = "";

        [MaxLength(100)]
        public string DataEn { get; set; } = "";

        [Precision(16, 2)]
        public decimal Valor { get; set; }

        public int QuantidadeItens { get; set; }

        [MaxLength(100)]
        public string Vendedor { get; set; } = "";
    }
}
