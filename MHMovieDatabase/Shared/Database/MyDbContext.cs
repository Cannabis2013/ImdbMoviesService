using Microsoft.EntityFrameworkCore;

namespace MHMovieDatabase.Shared.Database;

public class MyDbContext<TEntity> : DbContext where TEntity : class
{
    protected DbSet<TEntity> Entities { get; set; } = null!;
    protected MyDbContext(IDbConnectionDetails dbDetails) => _connectionString = dbDetails.ConnectionString();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(_connectionString,ServerVersion.AutoDetect(_connectionString));
        optionsBuilder.EnableSensitiveDataLogging();
        base.OnConfiguring(optionsBuilder);
    }
    
    private readonly string _connectionString;
}