using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Pim_Web.Models
{
    public class Ofertas
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Nome { get; set; } = "";

        [MaxLength(100)]
        public string Conteudo { get; set; } = "";

        [Precision(16, 2)]
        public decimal Valor { get; set; }

    }
}
