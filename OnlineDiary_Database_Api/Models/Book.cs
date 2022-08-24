using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineDiary_Database_Api.Models;
[Table("Books")]
public class Book 
{
    public int Id { get; set; }
    public string? Title { get; set;}
    public DateTime CreationDate { get; set; }
    public string? Description { get; set; }
    public string? UserId { get; set; }
    
}