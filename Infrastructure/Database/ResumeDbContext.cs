using Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Database
{
    public class ResumeDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ResumeDbContext(DbContextOptions options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Proffesion>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Resume>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Skill>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<User>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = _configuration.GetConnectionString("ResumesDB");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        public DbSet<User> User { get; set; }

    }
}