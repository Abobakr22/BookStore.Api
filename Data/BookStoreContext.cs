using Microsoft.EntityFrameworkCore;

namespace BookStore.Api.Data
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options)
        : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    //optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB;Database= BookStoreApi ;Integrated Security=True;");
            
        //}

        public DbSet<Book> Books { get; set; }
    }
}
