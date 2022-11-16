namespace Lab3.Models;
using Microsoft.EntityFrameworkCore;

public class RecContext : DbContext
{
    public RecContext(DbContextOptions<RecContext> options)
        : base(options)
    {
    }

    public DbSet<Doctor> Doctors { get; set; } = null!;
    public DbSet<Reception> Receptions { get; set; }
}
