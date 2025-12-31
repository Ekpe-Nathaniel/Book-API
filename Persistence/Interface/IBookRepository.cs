using BookAPI.Model;

namespace BookAPI.Persistence.Interface;

public interface IBookRepository
{
    Book Add(Book book);
    Book? GetById(Guid id);
    IEnumerable<Book> GetAll();
    Book? Update(Guid id, Book book);
    Book? DeleteById(Guid id);

    void Clear();
}