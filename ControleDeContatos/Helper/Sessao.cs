using ControleDeContatos.Models;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ControleDeContatos.Helper
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _httpContext;
        public Sessao(IHttpContextAccessor httpContext) 
        {
            _httpContext = httpContext;
        }

        public UsuarioModel BuscarSessaoDoUsuario()
        {
            string sessaoUsuario = _httpContext.HttpContext.Session.GetString("sessaoUsuarioLogado");
            if(string.IsNullOrEmpty(sessaoUsuario)) return null; 

            return JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);
        }

        public void CriarSessaoDoUsuario(UsuarioModel usuario)
        {
            string valueObject = JsonConvert.SerializeObject(usuario);
            
            _httpContext.HttpContext.Session.SetString("sessaoUsuarioLogado",valueObject);
        }

        public void RemoverSessaoUsuario()
        {
            _httpContext.HttpContext.Session.Remove("sessaoUsuarioLogado");
        }
    }
}
