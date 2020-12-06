namespace PowerSystemMonitoring.Data
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using PowerSystemMonitoring.Data.Common.Models;
    using PowerSystemMonitoring.Data.Models;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        private static readonly MethodInfo SetIsDeletedQueryFilterMethod =
            typeof(ApplicationDbContext).GetMethod(
                nameof(SetIsDeletedQueryFilter),
                BindingFlags.NonPublic | BindingFlags.Static);

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Setting> Settings { get; set; }

        public DbSet<Area> Areas { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Conductor> Conductors { get; set; }

        public DbSet<CurrentSensor> CurrentSensors { get; set; }

        public DbSet<CurrentSensorsEvents> CurrentSensorsEvents { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<GeographicalCoordinates> GeographicalCoordinates { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<PowerLine> PowerLines { get; set; }

        public DbSet<PowerLinesAreas> PowerLinesAreas { get; set; }

        public DbSet<PowerLinesEvents> PowerLinesEvents { get; set; }

        public DbSet<WeatherStation> WeatherStations { get; set; }

        public DbSet<WeatherStationsImages> WeatherStationsImages { get; set; }

        public DbSet<ConductorsImages> ConductorsImages { get; set; }

        public DbSet<CurrentSensorsImages> CurrentSensorsImages { get; set; }

        public override int SaveChanges() => this.SaveChanges(true);

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
            this.SaveChangesAsync(true, cancellationToken);

        public override Task<int> SaveChangesAsync(
            bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Needed for Identity models configuration
            base.OnModelCreating(builder);

            this.ConfigureUserIdentityRelations(builder);

            EntityIndexesConfiguration.Configure(builder);

            var entityTypes = builder.Model.GetEntityTypes().ToList();

            builder.Entity<CurrentSensorsEvents>().HasKey(x => new { x.CurrentSensorId, x.EventId });
            builder.Entity<PowerLinesAreas>().HasKey(x => new { x.PowerLineId, x.AreaId });
            builder.Entity<PowerLinesEvents>().HasKey(x => new { x.PowerLineId, x.EventId });
            builder.Entity<ConductorsImages>().HasKey(x => new { x.ConductorId, x.ImageId });
            builder.Entity<WeatherStationsImages>().HasKey(x => new { x.WeatherStationId, x.ImageId });
            builder.Entity<CurrentSensorsImages>().HasKey(x => new { x.CurrentSensorId, x.ImageId });

            // Set global query filter for not deleted entities only
            var deletableEntityTypes = entityTypes
                .Where(et => et.ClrType != null && typeof(IDeletableEntity).IsAssignableFrom(et.ClrType));
            foreach (var deletableEntityType in deletableEntityTypes)
            {
                var method = SetIsDeletedQueryFilterMethod.MakeGenericMethod(deletableEntityType.ClrType);
                method.Invoke(null, new object[] { builder });
            }

            // Disable cascade delete
            var foreignKeys = entityTypes
                .SelectMany(e => e.GetForeignKeys().Where(f => f.DeleteBehavior == DeleteBehavior.Cascade));
            foreach (var foreignKey in foreignKeys)
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        private static void SetIsDeletedQueryFilter<T>(ModelBuilder builder)
            where T : class, IDeletableEntity
        {
            builder.Entity<T>().HasQueryFilter(e => !e.IsDeleted);
        }

        // Applies configurations
        private void ConfigureUserIdentityRelations(ModelBuilder builder)
             => builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

        private void ApplyAuditInfoRules()
        {
            var changedEntries = this.ChangeTracker
                .Entries()
                .Where(e =>
                    e.Entity is IAuditInfo &&
                    (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in changedEntries)
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default)
                {
                    entity.CreatedOn = DateTime.UtcNow;
                }
                else
                {
                    entity.ModifiedOn = DateTime.UtcNow;
                }
            }
        }
    }
}
