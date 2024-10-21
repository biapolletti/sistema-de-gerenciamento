using System.ComponentModel.DataAnnotations;

namespace Pim_Web.Models
{
    public class Fornecedor
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Nome { get; set; } = "";

        [MaxLength(100)]
        public string Email { get; set; } = "";

        [MaxLength(100)]
        public string Cpf { get; set; } = "";

        [MaxLength(100)]
        public string Telefone { get; set; } = "";

        [MaxLength(100)]
        public string Endereco { get; set; } = "";
    }
}
