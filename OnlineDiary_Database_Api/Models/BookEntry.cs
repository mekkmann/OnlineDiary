using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineDiary_Database_Api.Models;
public class BookEntry 
{
    public int Id { get; set; }
    public string? Title { get; set;}
    public DateTime CreationDate { get; set; }
    public string? Text { get; set; }
    public int TodaysRating { get; set;}
    
    
    [ForeignKey("Book")]
    public int BookId { get; set; }
    public Book? Book { get; set; }
    
}