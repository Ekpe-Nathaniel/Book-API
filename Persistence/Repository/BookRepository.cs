using BookAPI.Model;
using BookAPI.Persistence.Interface;

namespace BookAPI.Persistence.Repository;

public class BookRepository : IBookRepository
{
    private static readonly List<Book> _bookList = new List<Book>();
    public Book Add(Book book)
    {
        _bookList.Add(book);
        return book; 
    }


    public Book? DeleteById(Guid id)
    {
        var book = _bookList.FirstOrDefault(b => b.Id == id);
        if (book == null)
        {
            return null;
        }

        book.DeletedAt = DateTime.UtcNow.ToString();
        return book;
        
    }

    public IEnumerable<Book> GetAll()
    {
        return _bookList.Where(b => b.DeletedAt == null);
    }

    public Book? GetById(Guid id)
    {
        var book = _bookList.FirstOrDefault(b => b.Id == id && b.DeletedAt == null);
        if (book == null)
        {
            return null;
        }
        return book;
    }

    public Book? Update(Guid id, Book book)
    {
        var targetBook = _bookList.FirstOrDefault(b => b.Id == id && b.DeletedAt == null);
        if (targetBook == null)
        {
            return null;
        }

        return book;
    }
    
        public void Clear()
    {
        _bookList.Clear();
    }

}