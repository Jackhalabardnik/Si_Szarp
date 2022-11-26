using System.ComponentModel.DataAnnotations;

namespace L5.Models;

public class Movie
{
    [Key] public int Id { get; set; }
    [Required(ErrorMessage = "Pole jest wymagane")][Range(1, 5, ErrorMessage = "Ocena filmu musi być liczbą pomiędzy 1 a 5")] [UIHint("Stars")] 
    public int Rating { get; set; }
    
    [Required(ErrorMessage = "To pole jest wymagane")] public Genre? Genre { get; set; }
    [Required(ErrorMessage = "Pole jest wymagane")] [MaxLength(50, ErrorMessage = "Tytuł ma mieć maksimum 50 znaków")] public String Title { get; set; }
    [Required(ErrorMessage = "Pole jest wymagane")] [UIHint("LongText")] public String Description { get; set; }
    [UIHint("Link")] public String? TrailerLink { get; set; }
}