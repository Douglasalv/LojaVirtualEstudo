

using Microsoft.EntityFrameworkCore;
using LojaVirtual.Models;

namespace LojaVirtual.Database
{
    public class LojaVirtualContext : DbContext
    {
        public LojaVirtualContext(DbContextOptions<LojaVirtualContext> options) : base(options)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<NewsletterEmail> newsletterEmails { get; set; }
    }
}
