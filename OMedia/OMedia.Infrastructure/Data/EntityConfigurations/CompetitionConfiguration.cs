using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMedia.Infrastructure.Data.EntityConfigurations
{
    internal class CompetitionConfiguration : IEntityTypeConfiguration<Competition>
    {
        public void Configure(EntityTypeBuilder<Competition> builder)
        {
            builder.HasData(CreateCompetitions());
        }
        private List<Competition> CreateCompetitions()
        {
            List<Competition> competitions = new List<Competition>()
            {
                new Competition()
                {
                    Id = 1,
                    Name = "CoolRace",
                    Location = "CoolPlace",
                    Date = DateTime.Now,
                    Details = "Details Details Details Details Details Details Details Details Details Details Details Details Details Details Details Details Details Details ",

                }

             };

            return competitions;
        }
    }
}
