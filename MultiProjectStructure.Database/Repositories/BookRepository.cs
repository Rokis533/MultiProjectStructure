using MultiProjectStructure.Database.Entities;

namespace MultiProjectStructure.Database.Repositories
{
    //public interface IBookRepository
    //{
    //    public IEnumerable<Book> GetBooks();
    //    public Book Get(Guid id);
    //    public void Update(Book book);
    //    public bool BookExists(Guid id);
    //    public void Delete(Guid id);
    //    public Book Add(Book book);
    //}

    // CTRL + .    (Ctrl+dot)
    public class BookRepository : IBookRepository
    //: IBookRepository
    {
        private readonly BookContext _context;
        public BookRepository(BookContext bookContext)
        {
            _context = bookContext;
        }
        public Book Add(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return book;
        }

        public bool BookExists(Guid id)
        {
            return _context.Books.Any(e => e.Id == id);
        }

        public void Delete(Guid id)
        {
            var book = _context.Books.Find(id);
            _context.Books.Remove(book);





        }

        public Book Get(Guid id, Book book, string reason, DateTime date)
        {
            return _context.Books.Find(id);
        }

        public IEnumerable<Book> GetBooks()
        {
            return _context.Books.ToList();
        }

        public void Update(Book book)
        {
            _context.Books.Update(book);
        }

    }
}
