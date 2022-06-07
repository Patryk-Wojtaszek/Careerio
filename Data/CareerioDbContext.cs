using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Careerio.Models;
using Careerio.Authentication;

namespace Careerio.Data
{
    public class CareerioDbContext : DbContext
    {
        public CareerioDbContext(DbContextOptions<CareerioDbContext> options) : base(options)
        {

        }


        public DbSet<Company> Companies { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Benefit> Benefits { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<RelatedIndustry> RelatedIndustries { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<ExperienceLevel> ExperienceLevels { get; set; }
        public DbSet<JobOffer> JobOffers { get; set; }
        public DbSet<RemoteRecruitment> RemoteRecruitments { get; set; }
        public DbSet<Requirement> Requirements { get; set; }
        public DbSet<Responsibility> Responsibilities { get; set; }
        public DbSet<TypeOfContract> TypeOfContracts { get; set; }
        public DbSet<WorkingHours> WorkingHours { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        
        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .Property(p => p.Name)
                .IsRequired();
            modelBuilder.Entity<Address>()
                .Property(p => p.City)
                .IsRequired();

            modelBuilder.Entity<Technology>()
                 .Property(e => e.Technologies)
                 .HasConversion(
                   v => string.Join(';', v),
                    v => v.Split(';', StringSplitOptions.RemoveEmptyEntries));

            modelBuilder.Entity<Benefit>()
                .Property(e => e.Benefits)
                .HasConversion(
                v => string.Join(';', v),
                v => v.Split(';', StringSplitOptions.RemoveEmptyEntries));


            modelBuilder.Entity<Gallery>()
                .Property(e => e.Photos)
                .HasConversion(
                v => string.Join(';', v),
                v => v.Split(';', StringSplitOptions.RemoveEmptyEntries));


            modelBuilder.Entity<RelatedIndustry>()
                .Property(e => e.RelatedIndustries)
                .HasConversion(
                v => string.Join(';', v),
                v => v.Split(';', StringSplitOptions.RemoveEmptyEntries));

            modelBuilder.Entity<Requirement>()
            .Property(e => e.Requirements)
            .HasConversion(
            v => string.Join(';', v),
            v => v.Split(';', StringSplitOptions.RemoveEmptyEntries));

            modelBuilder.Entity<Responsibility>()
            .Property(e => e.Responsibilities)
            .HasConversion(
            v => string.Join(';', v),
            v => v.Split(';', StringSplitOptions.RemoveEmptyEntries));

            modelBuilder.Entity<JobOffer>()
                .Property(e => e.JobTitle)
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsRequired();
            modelBuilder.Entity<Role>()
                  .Property(e => e.Name)
                  .IsRequired();
        }
    }
}
