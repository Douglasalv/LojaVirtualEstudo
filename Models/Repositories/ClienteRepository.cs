using LojaVirtual.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaVirtual.Models.Repositories.Contracts;

namespace LojaVirtual.Models.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly LojaVirtualContext _bdContext;
        public ClienteRepository(LojaVirtualContext bdContext)
        {
            _bdContext = bdContext;
        }
        public void Atualizar(Cliente cliente)
        {
            _bdContext.Update(cliente);
            _bdContext.SaveChanges();
            throw new NotImplementedException();
        }

        public bool Cadastrar(Cliente cliente)
        {
            _bdContext.Add(cliente);
            try
            {
                _bdContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }            
        }

        public void Excluir(int Id)
        {
            _bdContext.Remove(this.ObterCliente(Id));
            _bdContext.SaveChanges();

        }

        public Cliente Login(string Email, string senha)
        {
            return _bdContext.Clientes.Where(x => x.Email == Email && x.Senha == senha).Single();
        }

        public Cliente ObterCliente(int Id)
        {
            return _bdContext.Clientes.Find(Id);
        }

        public IEnumerable<Cliente> ObterTodosClientes()
        {
            return _bdContext.Clientes.ToList();
        }
    }
}
