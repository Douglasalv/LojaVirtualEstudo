using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaVirtual.Models;
using Newtonsoft.Json;

namespace LojaVirtual.Libraries.Login
{
    public class LoginCliente
    {
        private string key = "Login.Cliente";
        private readonly Session.Session _session;
        public LoginCliente(Session.Session session)
        {
            _session = session;
        }

        public void Login(Cliente cliente)
        {
            //Armazenar na sessão
            string clienteString = JsonConvert.SerializeObject(cliente);
            _session.Cadastrar(key, clienteString);
        }

        public Cliente GetClient()
        {
            string clienteString = _session.Consultar(key);
            return JsonConvert.DeserializeObject<Cliente>(clienteString);
        }

        public void Logout()
        {
            _session.RemoverTodos();
        }
    }
}
