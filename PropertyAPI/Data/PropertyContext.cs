using Microsoft.EntityFrameworkCore;

namespace PropertyAPI.Data
{
    public class PropertyContext : DbContext
    {
        public PropertyContext(DbContextOptions<PropertyContext> options) : base(options)
        {
        }

        public DbSet<Property> Property { get; set; } 
    }
}
