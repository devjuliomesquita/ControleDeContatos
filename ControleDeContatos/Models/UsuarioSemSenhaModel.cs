using ControleDeContatos.Enum;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace ControleDeContatos.Models
{
    public class UsuarioSemSenhaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do usuário!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o Login do usuário!")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite o E-mail do usuário!")]
        [EmailAddress(ErrorMessage = "E-mail digitado inválido!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Escolha o perfil do usuário!")]
        public PerfilEnum? Perfil { get; set; }
        
    }
}
