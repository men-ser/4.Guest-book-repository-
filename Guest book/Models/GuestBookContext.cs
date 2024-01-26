using Microsoft.EntityFrameworkCore;
namespace Guest_book.Models
{
    public class GuestBookContext : DbContext
    {
        public GuestBookContext(DbContextOptions<GuestBookContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Messages> Messages { get; set; }
    }
}
