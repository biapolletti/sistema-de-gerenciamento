using System.ComponentModel.DataAnnotations;

namespace Pim_Web.Models
{
    public class FornecedorDto
    {
        [MaxLength(100)]
        [Required(ErrorMessage = "Digite o nome do fornecedor")]
        public string Nome { get; set; } = "";

        [MaxLength(100)]
        [Required(ErrorMessage = "Digite o e-mail do fornecedor")]
        public string Email { get; set; } = "";

        [MaxLength(100)]
        [Required(ErrorMessage = "Digite o CPF do fornecedor")]
        public string Cpf { get; set; } = "";

        [MaxLength(100)]
        [Required(ErrorMessage = "Digite o telefone do fornecedor")]
        public string Telefone { get; set; } = "";

        [MaxLength(100)]
        [Required(ErrorMessage = "Digite o endereço do fornecedor")]
        public string Endereco { get; set; } = "";
    }
}
