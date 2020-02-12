using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Models.Repositories.Contracts
{
    public interface IClienteRepository
    {
        public Cliente Login(string Email, string senha);
        public bool Cadastrar(Cliente cliente);
        public void Atualizar(Cliente cliente);
        public void Excluir(int Id);
        public Cliente ObterCliente(int Id);
        public IEnumerable<Cliente> ObterTodosClientes();


    }
}
