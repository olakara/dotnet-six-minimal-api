using DotNetSixMinimalApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetSixMinimalApi.Data;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
    {
            
    }

    public DbSet<Car> Cars => Set<Car>();
}