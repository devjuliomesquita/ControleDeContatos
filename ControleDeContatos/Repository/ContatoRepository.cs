using ControleDeContatos.Data;
using ControleDeContatos.Models;

namespace ControleDeContatos.Repository
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly BancoContext _bancoContext;
        public ContatoRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public ContatoModel Adicionar(ContatoModel contato)
        {
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();
            return contato;

        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDb = ListarPorId(contato.Id);
            if (contatoDb == null) throw new Exception("Houve um erro na atualização do cadastro!!");
            
            contatoDb.Nome = contato.Nome;
            contatoDb.Email = contato.Email;
            contatoDb.Celular = contato.Celular;

            _bancoContext.Contatos.Update(contatoDb);
            _bancoContext.SaveChanges();

            return contatoDb;
        }

        public List<ContatoModel> BuscarTodos()
        {
            return _bancoContext.Contatos.ToList();
        }

        public bool Deletar(int id)
        {
            ContatoModel contatoDb = ListarPorId(id);
            if (contatoDb == null) throw new Exception("Houve um erro ao deletar o contato!!");
            
            _bancoContext.Contatos.Remove(contatoDb);
            _bancoContext.SaveChanges();
            return true;
        }

        public ContatoModel ListarPorId(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(p => p.Id == id);
        }
    }
}
