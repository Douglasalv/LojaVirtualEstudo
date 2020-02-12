using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaVirtual.Models.Repositories.Contracts;
using LojaVirtual.Database;

namespace LojaVirtual.Models.Repositories
{
    public class NewsletterRepository : INewsletterRepository
    {
        private readonly LojaVirtualContext _dbContext;

        public NewsletterRepository(LojaVirtualContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Cadastrar(NewsletterEmail newsletterEmail)
        {
            _dbContext.newsletterEmails.Add(newsletterEmail);
            _dbContext.SaveChanges();
        }

        public IEnumerable<NewsletterEmail> ObterTodasNewsletter()
        {
            return _dbContext.newsletterEmails.ToList();
        }
    }
}
