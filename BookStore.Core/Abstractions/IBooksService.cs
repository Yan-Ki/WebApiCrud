using BookStore.Core.Models;

namespace BookStore.Application.Services
{
    public interface IBooksService
    {
        Task<Guid> CreateBook(Book book);
        Task<Guid> DeleteBook(Guid id);
        Task<List<Book>> GetAllBoks();
        Task<Guid> UpdateBook(Guid id, string title, string description, decimal price);
    }
}