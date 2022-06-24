using Microsoft.EntityFrameworkCore;
using school_diary.api.Model;

namespace school_diary.api
{
    public class DiaryDbContext : DbContext
    {
        public DiaryDbContext(DbContextOptions<DiaryDbContext> options) : base(options)
        {

        }

        public DbSet<User> user { get; set; }
        public DbSet<Role> role { get; set; }
        public DbSet<UserClass> userClass { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(x => x.email)
                .IsRequired();

            modelBuilder.Entity<Role>()
                .Property(x => x.Name)
                .IsRequired();

            modelBuilder.Entity<UserClass>()
                .Property(x => x.userClass)
                .IsRequired();

            modelBuilder.Entity<UserClass>()
                .Property(x => x.userClassProfile)
                .IsRequired();

            modelBuilder.Entity<Role>()
                .HasData(new Role()
                {
                    Id = 1,
                    Name = "User"
                },
                new Role()
                {
                    Id = 2,
                    Name = "Teacher"
                },
                new Role()
                {
                    Id = 3,
                    Name = "LocalAdmin"
                },
                new Role()
                {
                    Id = 4,
                    Name = "Admin"
                });
        }
    }
}
