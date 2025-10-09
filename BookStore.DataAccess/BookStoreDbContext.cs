using BookStore.DataAccess.Entites;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace BookStore.DataAccess
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
        {

        }

        public DbSet<BookEntity> Books { get; set; }
    }
}
