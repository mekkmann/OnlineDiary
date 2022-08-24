using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineDiary_Database_Api.Models;

namespace OnlineDiary_Database_Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookEntryController : Controller
{
    private readonly OnlineDiaryContext _context;

    public BookEntryController(OnlineDiaryContext context)
    {
        _context = context;
    }

    //GET all
    [HttpGet("{bookId}")]
    [Authorize]
    public async Task<ActionResult<IEnumerable<BookEntry>>> GetBookEntries(int bookId)
    {
        if (_context.BookEntries == null)
        {
            return NotFound();
        }
        return await _context.BookEntries.Where(entry => entry.BookId == bookId).OrderByDescending(e => e.CreationDate).ToListAsync();
    }

    //GET one

    //DELETE
    [HttpDelete("{entryId}")]
    [Authorize]
    public async Task<IActionResult> DeleteEntry(int entryId)
    {
        if (_context.BookEntries == null) return NotFound();

        var entry = await _context.BookEntries.FirstOrDefaultAsync(x => x.Id == entryId);

        if (entry == null) return NotFound();

        _context.BookEntries.Remove(entry);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    //UPDATE

    //CREATE
    [HttpPost]
    [Authorize]
    public async Task<ActionResult> PostEntry(BookEntry entry)
    {
        if (!string.IsNullOrEmpty(entry.Text) || !string.IsNullOrEmpty(entry.Title))
        {
            entry.CreationDate = DateTime.Now;
            _context.BookEntries.Add(entry);
            await _context.SaveChangesAsync();
        }
        return Ok();
    }
}