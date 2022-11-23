using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class RedefinirSenhaModel
    {
        [Required(ErrorMessage = "Digite um Login de cadastro do usuário.")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite o email de cadastro do usuário.")]
        [EmailAddress(ErrorMessage ="Digite uma e-mail válido.")]
        public string Email { get; set; }
    }
}
