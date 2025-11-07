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
    public class BooksRepositories : IBooksRepositories
    {
        private readonly BookStoreDbContext _context;
        public BooksRepositories(BookStoreDbContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> Get()
        {
            var bookEntityes = await _context.Books.AsNoTracking().ToListAsync();

            var books = bookEntityes
                .Select(b => Book.Create(b.Id, b.Titel, b.Description, b.Price).book)
                .ToList();
            return books;
        }

        public async Task<Guid> Create(Book book)
        {
            BookEntity bookEntity = new BookEntity()
            {
                Id = book.Id,
                Titel = book.Titel,
                Description = book.Description,
                Price = book.Price
            };
            await _context.Books.AddAsync(bookEntity);
            await _context.SaveChangesAsync();
            return bookEntity.Id;
        }
        public async Task<Guid> Update(Guid Id, string Title, string Description, decimal Price)
        {
            await _context.Books
                .Where(b => b.Id == Id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(b => b.Description, b => Description)
                .SetProperty(b => b.Titel, b => Title)
                .SetProperty(b => b.Price, b => Price)
                );
            return Id;
        }
        public async Task<Guid> Delete(Guid id)
        {
            await _context.Books
                .Where(b => b.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}
