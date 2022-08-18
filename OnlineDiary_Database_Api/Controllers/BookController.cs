using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineDiary_Database_Api.Models;

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

    //GET all
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
    {
        if (_context.Book == null)
        {
            return NotFound();
        }
        return await _context.Book.ToListAsync();
    }

    //GET one

    //DELETE one

    //UPDATE one

    //CREATE one
}