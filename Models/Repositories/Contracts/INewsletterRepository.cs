using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Models.Repositories.Contracts
{
    public interface INewsletterRepository
    {
        public void Cadastrar(NewsletterEmail newsletterEmail);
        public IEnumerable<NewsletterEmail> ObterTodasNewsletter();
    }
}
