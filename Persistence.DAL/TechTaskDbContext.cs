using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Persistence.DAL.Entities;

namespace Persistence.DAL;

public class TechTaskDbContext : DbContext
{
    public DbSet<Node> Nodes { get; set; }
    public DbSet<Log> Logs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = (new ConfigurationBuilder()).AddJsonFile("appSettings.json").Build();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("Db"));

        base.OnConfiguring(optionsBuilder);
    }
}
