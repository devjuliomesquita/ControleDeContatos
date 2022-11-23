using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Digite o nome do contato!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o E-mail do contato!")]
        [EmailAddress(ErrorMessage ="E-mail digitado inválido!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite o celutar/telefone do contato!")]
        [Phone(ErrorMessage = "Número para contato inválido!")]
        public string Celular { get; set; }
    }
}
