using OnlineDiary_Database_Api.Models;

public class BookEntryDto
{
  public BookEntryDto(BookEntry entry)
  {
    BookId = 0;
    Book = entry.Book;
    Title = entry.Title;
    CreationDate = DateTime.Now;
    Text = entry.Text;
    TodaysRating = entry.TodaysRating;
  }
  public BookEntryDto() {} // THIS DOESNT WORK AT ALL
    public string? Title { get; set;}

    public DateTime CreationDate { get; set; }
    public string? Text { get; set; }
    public int TodaysRating { get; set;}
    
    public int BookId { get; set; }
    public Book? Book { get; set; }
}