using MultiProjectStructure.Database.Entities;

namespace MultiProjectStructure.Database.Repositories
{
    public interface IBookRepository
    {
        Book Add(Book book);
        bool BookExists(Guid id);
        void Delete(Guid id);
        Book Get(Guid id, Book book, string reason, DateTime date);
        IEnumerable<Book> GetBooks();
        void Update(Book book);
    }
}