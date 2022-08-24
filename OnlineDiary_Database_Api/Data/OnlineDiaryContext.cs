using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineDiary_Database_Api.Models;

public class OnlineDiaryContext : DbContext
{
    public OnlineDiaryContext (DbContextOptions<OnlineDiaryContext> options)
        : base(options)
    {
    }

    public DbSet<Book> Books { get; set; } = default!;
    public DbSet<BookEntry> BookEntries { get; set; } = default!;

}