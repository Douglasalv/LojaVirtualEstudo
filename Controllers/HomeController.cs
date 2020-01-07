using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contato()
        {
            return View();
        }

        public IActionResult ContatoSubmit()
        {
            string nome = HttpContext.Request.Form["nome"];
            string email = HttpContext.Request.Form["email"];
            string texto = HttpContext.Request.Form["texto"];
            return new ContentResult(){ Content = "Dados recebidos com sucesso: </br> Nome{} </br> Email{} </br> Texto{}", ContentType="text/html" };
        }
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult CadastroCliente()
        {
            return View();
        }

        public IActionResult CarrinhoCompras()
        {
            return View();
        }
    }
}