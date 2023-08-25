using Microsoft.EntityFrameworkCore;

namespace RichDomain.API.Business.Insfrastructure.ORM.Context;
public sealed class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> dbContext)
         : base(dbContext)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellation = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType
            ().GetProperty("CreateDate") != null))
        {
            if (entry.State == EntityState.Added)
            {
                entry.Property("CreateDate").CurrentValue = DateTime.Now;
            }

            if (entry.State == EntityState.Modified)
            {
                entry.Property("CreateDate").IsModified = false;
            }
        }

        return base.SaveChangesAsync(cancellation);
    }
}
