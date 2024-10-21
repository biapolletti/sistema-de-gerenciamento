using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Pim_Web.Models
{
    public class OfertasDto
    {
        [MaxLength(100)]
        [Required(ErrorMessage = "Digite o nome da oferta")]
        public string Nome { get; set; } = "";

        [MaxLength(100)]
        [Required(ErrorMessage = "Digite o conteúdo da oferta")]
        public string Conteudo { get; set; } = "";

        [Precision(16, 2)]
        [Required(ErrorMessage = "Digite o valor da oferta")]
        public decimal Valor { get; set; }
    }
}
