using BookStore.Core.Models;
using BookStore.DataAccess.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repositories
{
    public class BookRepositories
    {
        private readonly BookStoreDbContext _context;
        public BookRepositories(BookStoreDbContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetBooks()
        {
            var bookEntityes = await _context.Books.AsNoTracking().ToListAsync();

            var books = bookEntityes
                .Select(b=>Book.Cteate(b.Id,b.Titel, b.Description,b.Price).book)
                .ToList();
            return books;
        }
    }
}
