namespace Pim_Web.ViewModels
{
    public class UsuariosVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string Telefone { get; set; } = "";
        public string Adress { get; set; } = "";
        public string Cpf { get; set; } = "";
        public string DataNasc { get; set; } = "";
        public string Password { get; set; } = "";
        public string ConPassword { get; set; } = "";
    }
}
