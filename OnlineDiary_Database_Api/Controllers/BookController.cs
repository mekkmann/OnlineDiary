using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineDiary_Database_Api.Models;
using System.Linq;

namespace OnlineDiary_Database_Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController : Controller
{
    private readonly OnlineDiaryContext _context;

    public BookController(OnlineDiaryContext context)
    {
        _context = context;
    }

    [HttpGet("public-OnlyGivesYouOne")]
    public async Task<ActionResult<Book>> GetBooksPublic()
    {
        if (_context.Books == null)
        {
            return NotFound();
        }
        var items =  await _context.Books.ToListAsync();
        var itemToReturn = items.FirstOrDefault();

        if (itemToReturn != null)
        {
            return itemToReturn;
        }

        return NotFound();
    }

    // [HttpGet("privateGivesYouTwo")]
    // [Authorize]
    // public async Task<ActionResult<IEnumerable<Book>>> GetBooksPrivateScoped()
    // {
    //     if (_context.Book == null)
    //     {
    //         return NotFound();
    //     }

    //     var items = _context.Book.Take(2);

    //     var itemToReturn = await items.ToListAsync();

    //     return itemToReturn;

    // }
    [HttpGet("{userId}")]
    [Authorize]
    public async Task<ActionResult<IEnumerable<Book>>> GetBooksPrivateScoped(string userId)
    {
        if (_context.Books == null)
        {
            return NotFound();
        }

        var items = _context.Books.Where(b => b.UserId == userId);

        var itemToReturn = await items.ToListAsync();

        return itemToReturn;

    }
    
    
    
    
        // TODO: FIX THE PERMISSIONS/RBAC
    // [HttpGet("private-scopedGivesYouAll")]
    // [Authorize("read:books")]
    // public async Task<ActionResult<IEnumerable<Book>>> GetBooksPrivate()
    // {
    //     if (_context.Books == null)
    //     {
    //         return NotFound();
    //     }

    //     return await _context.Books.ToListAsync();

    // }

    //GET one

    //DELETE one
    [HttpDelete("{bookId}")]
    [Authorize]
    public async Task<IActionResult> DeleteBook(int bookId)
    {
        if (_context.Books == null) return NotFound();

        var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == bookId);

        if (book == null) return NotFound();

        _context.Books.Remove(book);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    //UPDATE one

    //CREATE one
      [HttpPost]
      [Authorize]
        public async Task<ActionResult<Book>> PostProject(Book book)
        {
          if (String.IsNullOrEmpty(book.Title)) return BadRequest("Please choose a unique title for the project.");

          var tick = await _context.Books.FirstOrDefaultAsync(x => x.Title == book.Title);

          if (tick != null) return BadRequest("Please choose a unique title for the project.");


            book.CreationDate = DateTime.Today;
            _context.Books.Add(book);
              await _context.SaveChangesAsync();
          

          return Ok();
        }
}