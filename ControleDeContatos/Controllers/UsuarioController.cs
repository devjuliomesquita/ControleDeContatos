using ControleDeContatos.Filters;
using ControleDeContatos.Helper;
using ControleDeContatos.Models;
using ControleDeContatos.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers
{
    [PaginaParaUsuarioAdmin]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IEmail _email;

        public UsuarioController(IUsuarioRepository usuarioRepository, IEmail email)
        {
            _usuarioRepository = usuarioRepository;
            _email= email;
        }
        public IActionResult Index()
        {
            List<UsuarioModel> usuarios = _usuarioRepository.BuscarTodos();
            return View(usuarios);
        }
        public IActionResult Criar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    
                    string msg = $"Olá {usuario.Nome}. Seu cadastro foi realizado com sucesso!!!";
                    bool emailEnviado = _email.Enviar(usuario.Email, "Oliveira Trade - Bem Vindo!!.", msg);
                    if (emailEnviado)
                    {
                        _usuarioRepository.Adicionar(usuario);
                        TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso! E-mail de confirmação enviado!";
                    }
                    else
                    {
                        TempData["MensagemError"] = "Ops, não foi possível realizar o cadastro do seu usuário, tente novamente.";
                    }
                    
                    return RedirectToAction("Index");
                }
                return View(usuario);
            }
            catch (Exception erro)
            {

                TempData["MensagemError"] = $"Ops, não foi possível realizar o cadastro do seu usuário, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }

        }
        public IActionResult DeleteConfirmation(int id)
        {
            UsuarioModel usuario = _usuarioRepository.ListarPorId(id);
            return View(usuario);
        }
        public IActionResult Delete(int id)
        {
            try
            {
                bool delete = _usuarioRepository.Deletar(id);
                if (delete)
                {
                    TempData["MensagemSucesso"] = "Usuário apagado com sucesso!";
                }
                else
                {
                    TempData["MensagemError"] = "Ops, não foi possível apagar o usuário.";
                }
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemError"] = $"Ops, não foi possível apagar o usuário, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
        public IActionResult Editar(int id)
        {
            UsuarioModel usuario = _usuarioRepository.ListarPorId(id);
            return View(usuario);
        }
        [HttpPost]
        public IActionResult Alterar(UsuarioSemSenhaModel usuarioSemSenhaModel)
        {
            try
            {
                UsuarioModel usuario = null;
                if (ModelState.IsValid)
                {
                    usuario = new UsuarioModel()
                    {
                        Id = usuarioSemSenhaModel.Id,
                        Nome = usuarioSemSenhaModel.Nome,
                        Login = usuarioSemSenhaModel.Login,
                        Email = usuarioSemSenhaModel.Email,
                        Perfil = usuarioSemSenhaModel.Perfil,
                    };
                    _usuarioRepository.Atualizar(usuario);
                    TempData["MensagemSucesso"] = "Usuário Atualizado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View("Editar", usuario);
            }
            catch (Exception erro)
            {
                TempData["MensagemError"] = $"Ops, não foi possível alterar o cadastro do seu usuário, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
