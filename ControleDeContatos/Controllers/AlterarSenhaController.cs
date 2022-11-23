using ControleDeContatos.Helper;
using ControleDeContatos.Models;
using ControleDeContatos.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers
{
    public class AlterarSenhaController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ISessao _sessao;
        public AlterarSenhaController(IUsuarioRepository usuarioRepository, ISessao sessao)
        {
            _usuarioRepository = usuarioRepository;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Alterar(AlterarSenhaModel alterarSenhaModel)
        {
            try
            {
                UsuarioModel usuarioLogado = _sessao.BuscarSessaoDoUsuario();
                alterarSenhaModel.Id= usuarioLogado.Id;
                if(ModelState.IsValid)
                {
                    _usuarioRepository.AlterarSenha(alterarSenhaModel);
                    TempData["MensagemSucesso"] = "Alterada com sucesso!";
                    return View("Index", alterarSenhaModel);
                }

                return View("Index", alterarSenhaModel);
            }
            catch (Exception erro)
            {
                TempData["MensagemError"] = $"Ops, não foi possível alterar a senha do seu usuário, tente novamente, detalhe do erro: {erro.Message}";
                return View("Index", alterarSenhaModel);
            }
        }
    }
}
