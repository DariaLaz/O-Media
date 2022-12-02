using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMedia.Infrastructure.Data.EntityConfigurations
{
    internal class CompetitionsCompetitorsConfiguration : IEntityTypeConfiguration<CompetitionsCompetitors>
    {
        public void Configure(EntityTypeBuilder<CompetitionsCompetitors> builder)
        {
            builder.HasKey(cc => new { cc.CompetitorId, cc.CompetitionId });
            builder.HasData(CreateCompetitorsCompetitions());
        }
        private List<CompetitionsCompetitors> CreateCompetitorsCompetitions()
        {
            List<CompetitionsCompetitors> competitionsCompetitors = new List<CompetitionsCompetitors>()
            {
                new CompetitionsCompetitors()
                {
                    CompetitorId = 1,
                    CompetitionId = 1
                }
             };

            return competitionsCompetitors;
        }
    }
}