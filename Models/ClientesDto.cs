using System.ComponentModel.DataAnnotations;

namespace Pim_Web.Models
{
    public class ClientesDto
    {
        [MaxLength(100)]
        [Required(ErrorMessage = "Digite o nome do cliente")]
        public string Nome { get; set; } = "";

        [MaxLength(100)]
        [Required(ErrorMessage = "Digite o e-mail do cliente")]
        public string Email { get; set; } = "";

        [MaxLength(100)]
        [Required(ErrorMessage = "Digite o CPF do cliente")]
        public string Cpf { get; set; } = "";

        [MaxLength(100)]
        [Required(ErrorMessage = "Digite o telefone do cliente")]
        public string Telefone { get; set; } = "";

        [MaxLength(100)]
        [Required(ErrorMessage = "Digite o endereço do cliente")]
        public string Endereco { get; set; } = "";
    }
}
