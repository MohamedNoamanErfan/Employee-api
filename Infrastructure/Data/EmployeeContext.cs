using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Data
{
    public class EmployeeContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public EmployeeContext([NotNullAttribute] DbContextOptions<EmployeeContext> options,
            IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeAttendance> EmployeeAttendances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            if (Database.ProviderName == "Microsoft.EntityFrameworkCore.SqlServer")
            {
                foreach (var entityType in modelBuilder.Model.GetEntityTypes())
                {
                    var properties = entityType.ClrType.GetProperties().Where(p => p.PropertyType == typeof(decimal));
                    var dateTimeProperties = entityType.ClrType.GetProperties()
                        .Where(p => p.PropertyType == typeof(DateTimeOffset));

                    foreach (var property in properties)
                    {
                        modelBuilder.Entity(entityType.Name).Property(property.Name).HasConversion<double>();
                    }

                    foreach (var property in dateTimeProperties)
                    {
                        modelBuilder.Entity(entityType.Name).Property(property.Name)
                            .HasConversion(new DateTimeOffsetToBinaryConverter());
                    }
                }
            }
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken
            = new CancellationToken())
        {
            var modifiedRows = ChangeTracker.Entries()
                .Where(a => a.Entity is BaseEntity && (a.State == EntityState.Added || a.State == EntityState.Modified));
            foreach (var entry in modifiedRows)
            {
                if (entry.Entity is BaseEntity general)
                {
                    var userName = _httpContextAccessor?.HttpContext?.User?.Identity?.Name;

                    if (entry.State == EntityState.Added)
                    {
                        general.CreatedON = DateTime.Now;
                    }
                    else
                    {
                        Entry(general).Property(a => a.CreatedON).IsModified = false;
                        Entry(general).Property(a => a.CreatedON).IsModified = false;
                        general.UpdatedON = DateTime.Now;
                    }
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
        public override int SaveChanges()
        {
            var modifiedRows = ChangeTracker.Entries()
                .Where(a => a.Entity is BaseEntity && (a.State == EntityState.Added || a.State == EntityState.Modified));
            foreach (var entry in modifiedRows)
            {
                if (entry.Entity is BaseEntity general)
                {
                    var userName = _httpContextAccessor?.HttpContext?.User?.Identity?.Name;
                    if (entry.State == EntityState.Added)
                    {
                        general.CreatedON = DateTime.Now;
                    }
                    else
                    {
                        Entry(general).Property(a => a.CreatedON).IsModified = false;
                        Entry(general).Property(a => a.CreatedON).IsModified = false;
                        general.UpdatedON = DateTime.Now;
                    }
                }
            }
            return base.SaveChanges();
        }
    }
}
