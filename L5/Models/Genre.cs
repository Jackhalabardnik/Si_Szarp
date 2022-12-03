using System.ComponentModel.DataAnnotations;

namespace L5.Models;

public class Genre
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }
}