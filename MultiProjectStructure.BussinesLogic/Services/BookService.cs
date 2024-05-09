using MultiProjectStructure.Database.Entities;
using MultiProjectStructure.Database.Repositories;

namespace MultiProjectStructure.BussinesLogic.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public Book Add(Book book)
        {
            _bookRepository.Add(book);
            return book;
        }
        public IEnumerable<Book> GetAll()
        {
            return _bookRepository.GetBooks();
        }

    }
}
