using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Pim_Web.Models
{
    public class InsumosDto
    {
        [MaxLength(100)]
        [Required(ErrorMessage = "Digite o nome do insumo")]
        public string Nome { get; set; } = "";

        [MaxLength(100)]
        [Required(ErrorMessage = "Digite o fornecedor do insumo")]
        public string Fornecedor { get; set; } = "";

        [MaxLength(100)]
        [Required(ErrorMessage = "Digite o tipo do insumo")]
        public string Tipo { get; set; } = "";

        [Required(ErrorMessage = "Digite a quantidade do insumo")]
        public int Quantidade { get; set; }

        [Precision(16, 2)]
        [Required(ErrorMessage = "Digite o valor unitário do insumo")]
        public decimal ValorUni { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage = "Digite a data de validade do insumo")]
        public string DataVal { get; set; } = "";
    }
}
