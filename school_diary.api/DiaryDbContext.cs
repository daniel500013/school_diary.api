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
        public DbSet<Lesson> lesson { get; set; }
        public DbSet<Marks> marks { get; set; }
        public DbSet<Grade> grades { get; set; }
        public DbSet<Approve> approves { get; set; }
        public DbSet<UserRole> userRole { get; set; }

        public Guid Guid = Guid.NewGuid();

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
                .IsRequired(false);

            modelBuilder.Entity<Lesson>()
                .Property(x => x.Name)
                .IsRequired();

            modelBuilder.Entity<Marks>()
                .Property(x => x.Present);

            modelBuilder.Entity<Grade>()
                .Property(x => x.Name);

            modelBuilder.Entity<Approve>()
                .Property(x => x.Positive)
                .IsRequired();

            modelBuilder.Entity<UserRole>();

            modelBuilder.Entity<UserClass>()
                .HasData(new UserClass()
                {
                    Id = 1,
                    userClass = 1,
                    userClassProfile = ""
                });

            modelBuilder.Entity<Role>()
                .HasData(new Role()
                {
                    Id = 1,
                    Name = "Student"
                },
                new Role()
                {
                    Id = 2,
                    Name = "Teacher"
                },
                new Role()
                {
                    Id = 3,
                    Name = "Tutor"
                },
                new Role()
                {
                    Id = 4,
                    Name = "LocalAdmin"
                },
                new Role()
                {
                    Id = 5,
                    Name = "Admin"
                });

            modelBuilder.Entity<UserRole>()
                .HasData(new UserRole()
                {
                    Id = 1,
                    FK_RoleId = 1,
                    FK_UserId = Guid
                });

            modelBuilder.Entity<User>()
                .HasData(new User()
                {
                    uuid = Guid,
                    email = "admin@admin.com",
                    password = "",
                    firstName = null,
                    lastName = null,
                    hashPassword = "AQAAAAEAACcQAAAAEFvY2W0hbidymRwUuDJrnyJ0QgZDGZFyUA/UbjsmJoj2bJC90u0MI+p78tTQU8cSMg==",
                    phone = null,
                    state = null,
                    city = null,
                    zipCode = null,
                    address = null,
                    FK_userClassId = 1
                });
        }
    }
}
