using Microsoft.AspNetCore.Identity;
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
            builder.HasKey(e => e.Id);
            builder.HasData(CreateCompetitions());
        }
        private List<Competition> CreateCompetitions()
        {
            List<Competition> competitions = new List<Competition>()
            {
                new Competition()
                {
                    Id = 1,
                    Name = "Christmas run",
                    Location = "Vitosha",
                    Date = DateTime.Parse("12/24/2022"),
                    Details = "This is the last competition of the year.",
                }
             };

            return competitions;
        }
    }
}
