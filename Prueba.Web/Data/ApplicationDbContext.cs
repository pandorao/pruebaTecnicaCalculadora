using Microsoft.EntityFrameworkCore;
using Prueba.Web.Models;

namespace Prueba.Web.Data
{
    public class ApplicationDbContext : DbContext       
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Operation> Operations { get; set; }
        public DbSet<FibonacciNumber> FibonacciNumbers { get; set; }
    }
}
