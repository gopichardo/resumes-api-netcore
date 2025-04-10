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
            modelBuilder.Entity<Resume>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Skill>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<User>().Property(x => x.Id).HasDefaultValueSql("NEWID()");

            // Configure many-to-many relationship between Resume and Skill
            modelBuilder.Entity<ResumeSkill>()
                .HasKey(rs => new { rs.ResumeId, rs.SkillId }); // Composite key

            modelBuilder.Entity<ResumeSkill>()
                .HasOne(rs => rs.Resume)
                .WithMany(r => r.ResumeSkills)
                .HasForeignKey(rs => rs.ResumeId);

            modelBuilder.Entity<ResumeSkill>()
                .HasOne(rs => rs.Skill)
                .WithMany(s => s.ResumeSkills)
                .HasForeignKey(rs => rs.SkillId);
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