using MultiProjectStructure.Database.Entities;

namespace MultiProjectStructure.BussinesLogic.Services
{
    public interface IBookService
    {
        Book Add(Book book);
        IEnumerable<Book> GetAll();
    }
}