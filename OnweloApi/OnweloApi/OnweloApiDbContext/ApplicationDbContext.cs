using Microsoft.EntityFrameworkCore;
using OnweloApi.Models;

namespace OnweloApi.OnweloApiDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Voter> Voters { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Candidate>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Candidate>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Voter>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Voter>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Candidate>()
                .HasMany<Voter>(c => c.Voters)
                .WithOne(v => v.CandidateVotedOn);

            modelBuilder.Entity<Candidate>()
                .HasData(new Candidate
                {
                    Id = 1,
                    Name = "Candidate 1"
                }, new Candidate
                {
                    Id = 2,
                    Name = "Candidate 2"
                }, new Candidate
                {
                    Id = 3,
                    Name = "Candidate 3"
                });
            
            modelBuilder.Entity<Voter>()
                .HasData(new Voter
                {
                    Id = 1,
                    Name = "Voter 1"
                }, new Voter
                {
                    Id = 2,
                    Name = "Voter 2"
                });
        }
    }
}