using Microsoft.EntityFrameworkCore;
using ClassicLibraryMVC.Models;

namespace ClassicLibraryMVC.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<PublishingHouse> PublishingHouses { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
