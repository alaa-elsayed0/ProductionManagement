using Microsoft.EntityFrameworkCore;
using Production.Core.Entities;
using System.Reflection;

namespace Production.Reprository.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPlanning> Planning { get; set; }
        public DbSet<Tracking> Tracking { get; set; }
        public DbSet<ProductionOperation> Operation { get; set; }
        public DbSet<StopRecords> StopRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


            //modelBuilder.Entity<Tracking>().
            //    HasMany(t => t.ProductPlannings).
            //    WithOne(p=> p.Tracking);

            //modelBuilder.Entity<StopRecords>().
            //    HasMany(s => s.ProductPlannings).
            //    WithOne(p => p.Records);

            //modelBuilder.Entity<ProductionOperation>().
            //    HasMany(o => o.ProductPlannings).
            //    WithOne(P => P.Operation);

            //modelBuilder.Entity<ProductPlanning>().
            //    HasMany(pp => pp.Products).
            //    WithOne(p=>p.Planning);
               


        }
    }
}
