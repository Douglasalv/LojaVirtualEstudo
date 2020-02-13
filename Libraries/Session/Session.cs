using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace LojaVirtual.Libraries.Session
{
    public class Session
    {
        //CRUD - Cadastrar/Atualizar/Consultar/Remover - RemoverTodos/Existe
        private readonly IHttpContextAccessor _contextSession;

        public Session(IHttpContextAccessor context)
        {
            _contextSession = context;
        }

        public void Cadastrar(string key, string valor)
        {
            _contextSession.HttpContext.Session.SetString(key,valor);
        }

        public void Atualizar(string key, string valor)
        {
            if(Existe(key)) _contextSession.HttpContext.Session.Remove(key);
            
            _contextSession.HttpContext.Session.SetString(key, valor);
        }

        public void Remover(string key)
        {
            _contextSession.HttpContext.Session.Remove(key);
        }

        public string Consultar(string key)
        {
            return _contextSession.HttpContext.Session.GetString(key);
        }

        public bool Existe(string key)
        {
            if (_contextSession.HttpContext.Session.GetString(key) != null)
                return true;
            else return false;
        }

        public void RemoverTodos()
        {
            _contextSession.HttpContext.Session.Clear();
        }
    }
}
