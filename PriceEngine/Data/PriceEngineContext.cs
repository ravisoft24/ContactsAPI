using Microsoft.EntityFrameworkCore;

namespace PriceEngine.Data
{
    public class PriceEngineContext : DbContext
    {
        public PriceEngineContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<PriceEngines>PriceEngine { get; set; }
    }
}
