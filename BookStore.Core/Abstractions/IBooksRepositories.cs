using BookStore.Core.Models;

namespace BookStore.DataAccess.Repositories
{
    public interface IBooksRepositories
    {
        Task<Guid> Create(Book book);
        Task<Guid> Delete(Guid id);
        Task<List<Book>> Get();
        Task<Guid> Update(Guid Id, string Title, string Description, decimal Price);
    }
}