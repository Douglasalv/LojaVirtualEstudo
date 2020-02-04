using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LojaVirtual.Models;
using LojaVirtual.Libraries.Email;
using System.ComponentModel.DataAnnotations;
using System.Text;
using LojaVirtual.Database;

namespace LojaVirtual.Controllers
{
    public class HomeController : Controller
    {
        private readonly LojaVirtualContext _bdContext;
        public HomeController(LojaVirtualContext bdContext)
        {
            _bdContext = bdContext;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        /*
         * FromForm já atribui os dados vindo da requisição POST para o 
         * objeto do tipo NewsletterEmail 
         */
        [HttpPost]
        public IActionResult Index([FromForm] NewsletterEmail newsletter)
        {
            if (ModelState.IsValid)
            {

                _bdContext.newsletterEmails.Add(newsletter);
                _bdContext.SaveChanges();

                TempData["MSG_S"] = "E-mail cadastrado com sucesso.";
                return RedirectToAction(nameof(Index));

            }
            else
            {
                return View();
            }
        }
        public IActionResult Contato()
        {
            return View();
        }

        public IActionResult ContatoSubmit()
        {
            try
            {
                Contato contato = new Contato
                {
                    Nome = HttpContext.Request.Form["nome"],
                    Email = HttpContext.Request.Form["email"],
                    Texto = HttpContext.Request.Form["texto"]
                };

                var listaMensagens = new List<ValidationResult>();
                var contexto = new ValidationContext(contato);
                bool isValid = Validator.TryValidateObject(contato, contexto, listaMensagens, true);

                if (isValid)
                {
                    ContatoEmail.EnviarContatoPorEmail(contato);

                    ViewData["MSG_S"] = "Mensagem de contato enviado com sucesso!";
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var texto in listaMensagens)
                    {
                        sb.Append(texto.ErrorMessage + "<br />");
                    }

                    ViewData["MSG_E"] = sb.ToString();
                    ViewData["CONTATO"] = contato;
                }


            }
            catch (Exception e)
            {
                ViewData["MSG_E"] = "Opps! Tivemos um erro, tente novamente mais tarde!";

                //TODO - Implementar Log
            }


            return View("Contato");
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CadastroCliente(){

            return View();
        }

        [HttpPost]
        public IActionResult CadastroCliente([FromForm]Cliente cliente)
        {
            return View();
        }

        public IActionResult CarrinhoCompras()
        {
            return View();
        }
    }
}