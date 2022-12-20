using Microsoft.EntityFrameworkCore;
using VehicleAlcoholSensor.Domain.Entities.Base;
using VehicleAlcoholSensor.Domain.Entities.MultiDimension;
using VehicleAlcoholSensor.Domain.Entities.Security;
using VehicleAlcoholSensor.EF.SchemaConfiguration;

namespace VehicleAlcoholSensor.EF
{
    public class DataContext : DbContext
    {
        public string ConnectionString { get; set; }

        public DataContext() { }

        public DataContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public DataContext(DbContextOptions<DataContext> optionsBuilder) : base(optionsBuilder)
        {

        }

        #region Tables Properties
        public DbSet<User> Users { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Metric> Metrics { get; set; }
        public DbSet<VehicleDriver> VehicleDrivers { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new VehicleConfig());
            modelBuilder.ApplyConfiguration(new MetricConfig());

            // PostgreSQL
            modelBuilder.HasDefaultSchema("public");

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (string.IsNullOrEmpty(ConnectionString))
                ConnectionString = @"Host=vehicle-alcohol-sensor.ctbz3xfbtw99.eu-central-1.rds.amazonaws.com;Username=saalcohol;Password=Xd396#AjZQeM;Database=alcoholdb";

            optionsBuilder.UseNpgsql(ConnectionString, options =>
            {
                //Some migrations are taking a looong time.
                options.CommandTimeout(18000);
            });
        }
    }
}
