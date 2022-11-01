using Itstep.Delivery.GlobalDictionary.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Itstep.Delivery.GlobalDictionary.Api.Persistance;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }

    public DbSet<City> Cities { get; set; }
    public DbSet<Country> Countries { get; set; }
}
