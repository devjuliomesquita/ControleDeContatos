using ControleDeContatos.Helper;
using ControleDeContatos.Models;
using ControleDeContatos.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ISessao _sessao;
        private readonly IEmail _email;
        public LoginController(IUsuarioRepository usuarioRepository, ISessao sessao, IEmail email)
        {
            _usuarioRepository = usuarioRepository;
            _sessao = sessao;
            _email = email;
        }
        public IActionResult Index()
        {
            if(_sessao.BuscarSessaoDoUsuario() != null) return RedirectToAction("Index","Home");

            return View();
        }
        public IActionResult RedefinirSenha()
        {
            return View();
        }
        public IActionResult Sair() 
        {
            _sessao.RemoverSessaoUsuario();
            return RedirectToAction("Index", "login");
        }
        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    UsuarioModel usuarioModel = _usuarioRepository.BuscarPorLogin(loginModel.Login);

                    if(usuarioModel != null)
                    {
                        if(usuarioModel.SenhaValida(loginModel.Password))
                        {
                            _sessao.CriarSessaoDoUsuario(usuarioModel);
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            TempData["MensagemError"] = "Senha do usuário é inválida. Por favor, tente novamente.";
                        }
                    }

                    TempData["MensagemError"] = "Usuário e/ou Senha inválido(s). Por favor, tente novamente.";
                }

                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemError"] = $"Ops, não foi possível realizar o login do usuário, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult LinkRedefinirSenha(RedefinirSenhaModel redefinirSenhaModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuarioModel = _usuarioRepository.BuscarPorEmailELogin(redefinirSenhaModel.Email, redefinirSenhaModel.Login);

                    if (usuarioModel != null)
                    {
                        string novaSenha = usuarioModel.GerarNovaSenha();
                        string msg = $"Sua nova senha é {novaSenha}";
                        bool emailEnviado = _email.Enviar(usuarioModel.Email, "Oliveira Trade - Redefinição de senha.", msg);
                        if(emailEnviado)
                        {
                            _usuarioRepository.Atualizar(usuarioModel);
                            TempData["MensagemSucesso"] = "Enviamos para seu e-mail cadastrado uma nova senha.";
                        }
                        else
                        {
                            TempData["MensagemError"] = "Não foi enviar o e-mail. Por favor, tente novamente.";
                        }
                        return RedirectToAction("Index", "Login");
                    }

                    TempData["MensagemError"] = "Não foi possível redefinir sua senha. Por favor, verifique os dados informados.";
                }

                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemError"] = $"Ops, não foi possível redefinir sua senha, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

    }
}
