using Aggregation.Domain;
using Microsoft.EntityFrameworkCore;

namespace Aggregation.Repository
{
    public class AggregationDbContext : DbContext
    {
        public AggregationDbContext(DbContextOptions options) : base(options)
        {
                
        }
        public DbSet<AggregateData> AggregateData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {  
            base.OnModelCreating(modelBuilder);
        }
    }
}