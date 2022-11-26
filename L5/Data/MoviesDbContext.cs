using L5.Models;
using Microsoft.EntityFrameworkCore;

namespace L5.Data;

public class MoviesDbContext : DbContext
{
    public DbSet<Movie?> Movies { get; set; } = null!;

    public DbSet<Genre?> Genres { get; set; }
    
    public MoviesDbContext(DbContextOptions options) : base(options)
    {

    }
}