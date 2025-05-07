using Microsoft.EntityFrameworkCore;
using abse.works.Domain.Models;

namespace abse.works.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Profession> Professions { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<JobOffer> JobOffers { get; set; }
        public DbSet<JobOfferSkill> JobOfferSkills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Skill>()
                .HasOne(s => s.Profession)
                .WithMany(p => p.Skills)
                .HasForeignKey(s => s.ProfessionId);

            modelBuilder.Entity<JobOffer>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne(e => e.Country)
                      .WithMany()
                      .HasForeignKey(e => e.CountryId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.Metadata
                      .FindNavigation(nameof(JobOffer.Skills))
                      .SetPropertyAccessMode(PropertyAccessMode.Field);

                entity.HasMany<JobOfferSkill>("_skills")
                      .WithOne()
                      .HasForeignKey("JobOfferId")
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<JobOfferSkill>(entity =>
            {
                entity.HasKey(e => new { e.JobOfferId, e.SkillId });

                entity.HasOne(e => e.JobOffer)
                      .WithMany(j => j.Skills)
                      .HasForeignKey(e => e.JobOfferId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Skill)
                      .WithMany()
                      .HasForeignKey(e => e.SkillId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
