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
using LojaVirtual.Models.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using LojaVirtual.Libraries.Login;

namespace LojaVirtual.Controllers
{
    public class HomeController : Controller
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly INewsletterRepository _newsletterRepository;
        private readonly LoginCliente _loginCliente;
        public HomeController(IClienteRepository repository, INewsletterRepository newsletterRepository, LoginCliente loginCliente)
        {
            _clienteRepository = repository;
            _newsletterRepository = newsletterRepository;
            _loginCliente = loginCliente;
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
                _newsletterRepository.Cadastrar(newsletter);
                TempData["MSG_S"] = "Cadastro de Email efetuado com sucesso!";
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

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Painel()
        {
            Cliente cliente = _loginCliente.GetClient();
            if(cliente != null)
            {
                return new ContentResult() {Content = "Usuário " + cliente.Id + ". Email " + cliente.Email + ". Logado"};
            }
            {
                return new ContentResult() { Content = "Acesso Negado." };
            }
        }

        [HttpPost]
        public IActionResult Login([FromForm]Cliente cliente)
        {
            var clienteResult = _clienteRepository.Login(cliente.Email, cliente.Senha);
            
            if (clienteResult != null)
            {
                /*
                 * Criação da sessão
                 */
                _loginCliente.Login(clienteResult);

                return new RedirectResult(Url.Action(nameof(Painel)));

            }
            else
            {
                ViewData["MSG_E"] = "Usuario não encontrado, verifique o email e senha digitados!";
                return View();
            }
            
        }

        [HttpGet]
        public IActionResult CadastroCliente(){
            
            return View();
        }

        [HttpPost]
        public IActionResult CadastroCliente([FromForm]Cliente cliente)
        {
            if (ModelState.IsValid)
            {

                if (_clienteRepository.Cadastrar(cliente))
                {
                    TempData["MSG_S"] = "Cadastro efetuado com sucesso!";
                }
                
                else
                {
                    TempData["MSG_S"] = "Erro!";
                }

                return RedirectToAction(nameof(CadastroCliente));
            }
            return View();
        }

        public IActionResult CarrinhoCompras()
        {
            return View();
        }
    }
}