namespace SSToolkit.Infrastructure.EntityFrameworkCore.Reference
{
    using Microsoft.EntityFrameworkCore;
    using SSToolkit.Infrastructure.EntityFrameworkCore;

    public class MyDbContext : BaseDbContext
    {
        public MyDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.Entity<Student>().HasKey(x => x.Id);
            modelBuilder.Entity<Teacher>().HasKey(x => x.Id);
            modelBuilder.Entity<Teacher>().Property(x => x.Id).ValueGeneratedOnAdd();
        }
    }
}
