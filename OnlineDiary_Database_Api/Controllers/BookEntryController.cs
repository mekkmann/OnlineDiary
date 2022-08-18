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
    // [HttpGet]
    // public async Task<ActionResult<IEnumerable<BookEntry>>> GetBooks()
    // {
    //     if (_context.BookEntry == null)
    //     {
    //         return NotFound();
    //     }
    //     return await _context.BookEntry.ToListAsync();
    // }

    //GET one

    //DELETE one

    //UPDATE one

    //CREATE one
}