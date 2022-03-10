using Microsoft.EntityFrameworkCore;

namespace ContactsAPI.Data
{
    public class ContactsContext : DbContext
    {
        public ContactsContext(DbContextOptions<ContactsContext> options)
            :base(options)
        {
        }

        public DbSet<Contacts> Contacts { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server*;Dtatabase=ContactsAPI;Integrated Security=True");
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
