namespace PowerSystemMonitoring.Data
{
    using System;
    using System.IO;
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

        public DbSet<Area> Areas { get; set; }

        public DbSet<Conductor> Conductors { get; set; }

        public DbSet<CurrentSensor> CurrentSensors { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<GeographicalCoordinates> GeographicalCoordinates { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<PowerLine> PowerLines { get; set; }

        public DbSet<WeatherStation> WeatherStations { get; set; }

        public DbSet<PowerLinesAreas> PowerLinesAreas { get; set; }

        public DbSet<RealTimeValues> RealTimeValues { get; set; }

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

            builder.Entity<Conductor>()
                .HasOne(i => i.Image)
                .WithOne(c => c.Conductor)
                .HasForeignKey<Image>(b => b.ConductorId);

            builder.Entity<Area>()
   .HasOne(i => i.Image)
   .WithOne(c => c.Area)
   .HasForeignKey<Image>(b => b.AreaId);

            builder.Entity<CurrentSensor>()
   .HasOne(i => i.Image)
   .WithOne(c => c.CurrentSensor)
   .HasForeignKey<Image>(b => b.CurrentSensorId);

            builder.Entity<CurrentSensor>()
   .HasOne(i => i.GeographicalCoordinates)
   .WithOne(c => c.CurrentSensor)
   .HasForeignKey<GeographicalCoordinates>(b => b.CurrentSensorId);

         

            builder.Entity<PowerLine>()
  .HasOne(i => i.Image)
  .WithOne(c => c.PowerLine)
  .HasForeignKey<Image>(b => b.PowerLineId);

            builder.Entity<PowerLinesAreas>().HasKey(x => new { x.PowerLineId, x.AreaId });

            this.ConfigureUserIdentityRelations(builder);

            EntityIndexesConfiguration.Configure(builder);

            var entityTypes = builder.Model.GetEntityTypes().ToList();

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
