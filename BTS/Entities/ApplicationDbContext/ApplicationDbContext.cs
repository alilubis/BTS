using Microsoft.EntityFrameworkCore;

namespace BTS.Entities.ApplicationDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions option) : base(option) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Checklist> Checklists { get; set; }
    }
}
