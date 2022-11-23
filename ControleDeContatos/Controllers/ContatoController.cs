using ControleDeContatos.Filters;
using ControleDeContatos.Models;
using ControleDeContatos.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers
{
    [PaginaParaUsuarioLogado]
    public class ContatoController : Controller
    {
        private readonly IContatoRepository _contatoRepository;
        public ContatoController(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }
        public IActionResult Index()
        {
            List<ContatoModel> contatos = _contatoRepository.BuscarTodos();
            return View(contatos);
        }
        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar(int id)
        {
            ContatoModel contato = _contatoRepository.ListarPorId(id);
            return View(contato);
        }
        public IActionResult DeleteConfirmation(int id)
        {
            ContatoModel contato = _contatoRepository.ListarPorId(id);
            return View(contato);
        }
        public IActionResult Delete(int id)
        {
            try
            {
                bool delete = _contatoRepository.Deletar(id);
                if(delete)
                {
                    TempData["MensagemSucesso"] = "Contato apagado com sucesso!";
                }
                else
                {
                    TempData["MensagemError"] = "Ops, não foi possível apagar o contato.";
                }
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemError"] = $"Ops, não foi possível apagar o contato, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepository.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View(contato);
            }
            catch (Exception erro)
            {

                TempData["MensagemError"] = $"Ops, não foi possível realizar o cadastro do seu contato, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
            
        }
        [HttpPost]
        public IActionResult Alterar (ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepository.Atualizar(contato);
                    TempData["MensagemSucesso"] = "Contato Atualizado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View("Editar", contato);
            }
            catch (Exception erro)
            {
                TempData["MensagemError"] = $"Ops, não foi possível alterar o cadastro do seu contato, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
