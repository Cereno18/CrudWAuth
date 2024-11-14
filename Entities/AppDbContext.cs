using Microsoft.EntityFrameworkCore;

namespace CrudWAuth.Entities
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { 
        
        }
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<Cellphone> Cellphones { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
