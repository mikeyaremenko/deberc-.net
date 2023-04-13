using debercApi.Models;

namespace debercApi.Data;

public class DataContext : DbContext
{
    private readonly IConfiguration _configuration;

    public DbSet<Card> Cards { get; set; }
    public DbSet<Combination> Combinations { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<Player> Rounds { get; set; }
    public DbSet<Player> Teams { get; set; }
    public DbSet<Player> Tricks { get; set; }

    public DataContext(DbContextOptions<DataContext> options, IConfiguration configuration) : base(options)
    {
             _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
    }
}
