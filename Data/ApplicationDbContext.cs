using API_Practice.Models;
using Microsoft.EntityFrameworkCore;


namespace API_Practice.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {


        }


        public DbSet<Emp> emps { get; set; }

        public DbSet<Manager> manager { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Emp>(e =>
            {
                e.HasOne(x => x.manager)
                .WithMany(x => x.emp)
                .HasForeignKey(x => x.mid)
                .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
