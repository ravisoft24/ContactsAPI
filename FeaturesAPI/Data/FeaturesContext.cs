using Microsoft.EntityFrameworkCore;

namespace FeaturesAPI.Data
{
    public class FeaturesContext : DbContext
    {
        public FeaturesContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Features> Features { get; set; }

    }
}
