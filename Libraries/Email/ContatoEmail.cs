using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaVirtual.Models;
using System.Net.Mail;
using System.Net;

namespace LojaVirtual.Libraries.Email
{
    public class ContatoEmail
    {
        public static void EnviarContatoPorEmail(Contato contato)
        {
            string corpoMsg = string.Format("<h2>Contato - Loja Virtual</h2>" +
                  "<b>Nome: </b> {0} <br/>" +
                  "<b>E-mail: </b> {1} <br/>" +
                  "<b>Texto: </b> {2}" +
                  "<br/> Email enviado automaticamente.", contato.Nome, contato.Email, contato.Texto);
            /*
             * SMTP -> Servidor de saida de mensagens           
             */
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("douglasalvrodrigues@gmail.com", "google1280%");
            smtp.EnableSsl = true;


            /*
             * MailMessage -> Construir a mensagem a ser enviada
             */
            MailMessage msgEmail = new MailMessage();
            msgEmail.From = new MailAddress("douglasalvrodrigues@gmail.com");
            msgEmail.To.Add("douglasalvrodrigues@gmail.com");
            msgEmail.Subject = "Contato - Loja Virtual - Email: " + contato.Email;
            msgEmail.Body = corpoMsg;
            msgEmail.IsBodyHtml = true;

            //Enviar mensagem via SMTP
            smtp.Send(msgEmail);
            
        }
    }
}
