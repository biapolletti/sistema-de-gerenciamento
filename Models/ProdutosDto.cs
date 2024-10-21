using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Pim_Web.Models
{
    public class ProdutosDto
    {
        [MaxLength(100)]
        [Required(ErrorMessage = "Digite o nome do produto")]
        public string Nome { get; set; } = "";

        [MaxLength(100)]
        [Required(ErrorMessage = "Digite o tipo do produto")]
        public string Tipo { get; set; } = "";

        [Required(ErrorMessage = "Digite a quantidade do produto")]
        public int Quantidade { get; set; }
        [Precision(16, 2)]
        [Required(ErrorMessage = "Digite o valor unitário do produto")]
        public decimal ValorUni { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage = "Digite a data de validade do produto")]
        public string DataVal { get; set; } = "";
    }
}
