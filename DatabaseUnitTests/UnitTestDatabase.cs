using Microsoft.EntityFrameworkCore;
using MultiProjectStructure.Database;
using MultiProjectStructure.Database.Entities;
using MultiProjectStructure.Database.Repositories;

namespace DatabaseUnitTests
{
    public class UnitTestDatabase
    {
        private BookContext _context;
        private IBookRepository _bookRepository;

        public UnitTestDatabase()
        {
            var options = new DbContextOptionsBuilder<BookContext>()
            .UseInMemoryDatabase(databaseName: "TestDB")
            .Options;


            _context = new BookContext(options);
            _bookRepository = new BookRepository(_context);

            _bookRepository.Add(new Book() { Name = "No name" });
        }

        [Fact]
        public void GetBooks_GetSucesfull()
        {
            var books = _bookRepository.GetBooks();
            Assert.NotNull(books);
            Assert.True(books.Any(x => x.Name == "No name"));

        }
    }
}