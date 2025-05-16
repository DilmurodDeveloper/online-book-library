using Microsoft.EntityFrameworkCore;
using OnlineBookLibrary.Server.Models;

namespace OnlineBookLibrary.Server.Data
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options)
            :base(options)
        {
        }

        public DbSet<Book>? Books { get; set; }
        public DbSet<Category>? Categories { get; set; }
    }
}
