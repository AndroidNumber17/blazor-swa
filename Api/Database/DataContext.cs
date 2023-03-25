using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Database;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }

    public DbSet<Poster> Posters { get; set; }
}