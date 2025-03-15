using Microsoft.EntityFrameworkCore;
namespace MandMWorldBank.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Transaction> Transactions { get; set; }
    }
}
