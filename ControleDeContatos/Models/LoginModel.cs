using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Digite um Login de usuário.")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite a senha do usuário.")]
        public string Password { get; set; }
    }
}
