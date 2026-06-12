using Microsoft.EntityFrameworkCore;
using gaming.Models;

namespace gaming.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(
        DbContextOptions<AppDbContext> options
    ) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
}
