using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using VehicleAlcoholSensor.EF;

static DataContext CreateDbContext(string[] args)
{
    var configurationBuilder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

    var configuration = configurationBuilder.Build();
    var connectionString = configuration.GetConnectionString("PostgreSQL");

    DbContextOptionsBuilder<DataContext> optionsBuilder = new DbContextOptionsBuilder<DataContext>()
        .UseNpgsql(connectionString);

    return new DataContext(optionsBuilder.Options);
}

using var dataContext = CreateDbContext(null);
dataContext.Database.Migrate();