using BookAPI.DTOs;
using BookAPI.Model;
using BookAPI.Persistence.Interface;
using Microsoft.AspNetCore.Mvc;


namespace BookAPI.Controller;

[ApiController]
[Route("api/[controller]")]

public class BookController : ControllerBase
{
    private readonly IBookRepository _bookRepository;

    public BookController(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    [HttpGet]

    public IActionResult GetAllBooks()
    {
        return Ok(_bookRepository.GetAll());
    }

    [HttpGet("{id}")]

    public IActionResult GetBookById(Guid id)
    {
        var book = _bookRepository.GetById(id);
        if (book == null)
        {
            return NotFound();
        }
        return Ok(book);
    }

    [HttpPost]

    public IActionResult CreateBook(CreateBookRequestDTO request)
    {
        var book = new Book
        {
            Title = request.Title,
            Author = request.Author,
            Year_Published = request.Year_Published,
            Is_Read = request.Is_Read
        };

        _bookRepository.Add(book);
        return Ok(book);
    }

    [HttpPut("{id}")]

    public IActionResult UpdateBookById(Guid id, [FromBody] Book updateBook)
    {
        if (updateBook == null)
        {
            return BadRequest("Book details or data are required. ");
        }

        var updated = _bookRepository.Update(id, updateBook);
        if(updated == null)
        {
            return NotFound();
        }

        return Ok(updated);
    }

    [HttpDelete]
    
    public IActionResult DeleteAllBook()
    {
        _bookRepository.Clear();
        return NoContent();
    }
}