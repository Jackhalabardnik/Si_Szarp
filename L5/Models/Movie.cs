using System.ComponentModel.DataAnnotations;

namespace L5.Models;

public class Movie
{
    [Key] public int Id { get; set; }
    [UIHint("Stars")] public int Rating { get; set; }
    public String Title { get; set; }
    [UIHint("LongText")] public String Description { get; set; }
    [UIHint("Link")] public String TrailerLink { get; set; }
}