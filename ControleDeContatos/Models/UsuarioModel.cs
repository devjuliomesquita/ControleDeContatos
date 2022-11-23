using ControleDeContatos.Enum;
using ControleDeContatos.Helper;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace ControleDeContatos.Models
{
    public class UsuarioModel
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
        [Required(ErrorMessage = "Digite uma senha válida para o usuário!")]
        public string Password { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public bool SenhaValida(string password)
        {
            return Password == password.GerarHash();
        }
        public void SetSenhaHash()
        {
            Password = Password.GerarHash();
        }
        public void SetNovaSenha(string novaSenha)
        {
            Password = novaSenha.GerarHash();
        }
        public string GerarNovaSenha()
        {
            string novaSenha = Guid.NewGuid().ToString().Substring(0, 8);
            Password = novaSenha.GerarHash();
            return novaSenha;
        }
    }
}
