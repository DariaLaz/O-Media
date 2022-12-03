
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OMedia.Infrastructure.Data.EntityConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMedia.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new AgeGroupConfiguration());
            builder.ApplyConfiguration(new CompetitionConfiguration());
            builder.ApplyConfiguration(new CompetitionsCompetitorsConfiguration());
            builder.ApplyConfiguration(new CompetitorConfiguration());
            builder.ApplyConfiguration(new DistanceTypesConfiguration());
            builder.ApplyConfiguration(new NewsConfiguration());
            builder.ApplyConfiguration(new TeamConfiguration());
            builder.ApplyConfiguration(new AgeGroupsCompetitionsConfiguration());

            base.OnModelCreating(builder);
        }
        public DbSet<AgeGroup> AgeGroups { get; set; } = null!;
        public DbSet<Competition> Competitions { get; set; } = null!;
        public DbSet<Competitor> Competitors { get; set; } = null!;
        public DbSet<DistanceType> DistanceTypes { get; set; } = null!;
        public DbSet<News> News { get; set; } = null!;
        public DbSet<Team> Teams { get; set; } = null!;



    }

}
