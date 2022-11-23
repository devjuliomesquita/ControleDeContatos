using ControleDeContatos.Data;
using ControleDeContatos.Models;

namespace ControleDeContatos.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly BancoContext _bancoContext;
        public UsuarioRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            usuario.DataCadastro = DateTime.Now;
            usuario.SetSenhaHash();
            _bancoContext.Usuarios.Add(usuario);
            _bancoContext.SaveChanges();
            return usuario;

        }

        public UsuarioModel AlterarSenha(AlterarSenhaModel alterarSenhaModel)
        {
            UsuarioModel usuarioDb = ListarPorId(alterarSenhaModel.Id);

            if (usuarioDb == null) throw new Exception("Houve um erro na atualização da senha, usuário não encontrado.");
            if (!usuarioDb.SenhaValida(alterarSenhaModel.SenhaAtual)) throw new Exception("Senha atual não confere.");
            if (usuarioDb.SenhaValida(alterarSenhaModel.NovaSenha)) throw new Exception("Nova senha deve ser diferente da senha atual.");

            usuarioDb.SetNovaSenha(alterarSenhaModel.NovaSenha);
            usuarioDb.DataAtualizacao= DateTime.Now;
            _bancoContext.Usuarios.Update(usuarioDb);
            _bancoContext.SaveChanges();

            return usuarioDb;
        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            UsuarioModel usuarioDb = ListarPorId(usuario.Id);
            if (usuarioDb == null) throw new Exception("Houve um erro na atualização do usuário!!");

            usuarioDb.Nome = usuario.Nome;
            usuarioDb.Email = usuario.Email;
            usuarioDb.Login = usuario.Login;
            usuarioDb.Perfil = usuario.Perfil;
            usuarioDb.DataAtualizacao = DateTime.Now;

            _bancoContext.Usuarios.Update(usuarioDb);
            _bancoContext.SaveChanges();

            return usuarioDb;
        }

        public UsuarioModel BuscarPorEmailELogin(string email, string login)
        {
            return _bancoContext.Usuarios
                    .FirstOrDefault(x => x.Email.ToUpper() == email.ToUpper() && x.Login.ToUpper() == login.ToUpper());
        }

        public UsuarioModel BuscarPorLogin(string login)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
        }

        public List<UsuarioModel> BuscarTodos()
        {
            return _bancoContext.Usuarios.ToList();
        }

        public bool Deletar(int id)
        {
            UsuarioModel usuarioDb = ListarPorId(id);
            if (usuarioDb == null) throw new Exception("Houve um erro ao deletar o usuário!!");
            
            _bancoContext.Usuarios.Remove(usuarioDb);
            _bancoContext.SaveChanges();
            return true;
        }

        public UsuarioModel ListarPorId(int id)
        {
            return _bancoContext.Usuarios.FirstOrDefault(p => p.Id == id);
        }
    }
}
