using Microsoft.EntityFrameworkCore;
using gaming.Models;

namespace gaming.Data
{
  // Inherit from DbContext to get all the database mapping features
  public class AppDbContext : DbContext
  {
    // The constructor passes configuration options up to the base class
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // A DbSet represents a table in your database. 
    // This line creates a "Users" table based on your Users model.
    public DbSet<Users> Users { get; set; }
  }
}
