using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class AlterarSenhaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Digite a sua senha atual de usuário.")]
        public string SenhaAtual { get; set; }
        [Required(ErrorMessage = "Digite a nova senha de usuário.")]
        public string NovaSenha { get; set; }
        [Required(ErrorMessage = "Confirme sua nova senha.")]
        [Compare("NovaSenha", ErrorMessage ="Senhas Não conferem.")]
        public string ConfirmarNovaSenha { get; set; }
    }
}
