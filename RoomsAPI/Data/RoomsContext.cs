using Microsoft.EntityFrameworkCore;

namespace RoomsAPI.Data
{
    public class RoomsContext : DbContext
    {
        public RoomsContext(DbContextOptions<RoomsContext> options) 
            : base(options)
        {
        }
        public DbSet<Rooms> Rooms { get; set; }
        public DbSet<Features> Features { get; set; }
        public DbSet<RoomFeatures> RoomFeatures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoomFeatures>().HasKey(RF => new { RF.RoomId, RF.FeaturesId });
    
        }
    }
}
