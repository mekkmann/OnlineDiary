using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineDiary_Database_Api.Models;

[Table("BookEntries")]
public class BookEntry 
{
    [Key]
    public int Id { get; set; }
    public string? Title { get; set;}

    [DataType(DataType.Date)]
    public DateTime CreationDate { get; set; }
    public string? Text { get; set; }
    public int TodaysRating { get; set;}
    
    [ForeignKey("Book")]
    public int BookId { get; set; }
    public Book? Book { get; set; }
    
}