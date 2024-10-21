using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Pim_Web.Models
{
    public class Insumos
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Nome { get; set; } = "";

        [MaxLength(100)]
        public string Fornecedor { get; set; } = "";

        [MaxLength(100)]
        public string Tipo { get; set; } = "";

        public int Quantidade { get; set; }

        [Precision(16, 2)]
        public decimal ValorUni { get; set; }

        [MaxLength(100)]
        public string DataVal { get; set; } = "";
    }
}
