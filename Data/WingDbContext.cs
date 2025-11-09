using Microsoft.EntityFrameworkCore;
using Wing_Fleet_Manager.Models;

namespace Wing_Fleet_Manager.Data
{
    public class WingDbContext : DbContext
    {
        public WingDbContext(DbContextOptions<WingDbContext> options) : base(options) { }
        
        public DbSet<User> Users {  get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
            modelBuilder.Entity<User>()
                .HasIndex(u => u.NickName)
                .IsUnique();
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Phone)
                .IsUnique();
            modelBuilder.Entity<Role>()
                .HasIndex(r => r.Name)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);
                

        }
    }
}
