using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMedia.Infrastructure.Data.EntityConfigurations
{
    internal class CompetitorConfiguration : IEntityTypeConfiguration<Competitor>
    {
        public void Configure(EntityTypeBuilder<Competitor> builder)
        {
            builder.HasData(CreateCompetitors());

        }
        private List<Competitor> CreateCompetitors()
        {
            List<Competitor> competitors = new List<Competitor>()
            {
                new Competitor()
                {
                    Id = 1,
                    TeamId = 1,
                    Name = "CoolName",
                    UserId = "dea12856-c198-4129-b3f3-b893d8395082",
                    AgeGroupId = 1
                }
             };

            return competitors;
        }
    }
}
