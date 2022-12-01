using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMedia.Infrastructure.Data.EntityConfigurations
{
    internal class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasData(CreateTeams());
        }
        private List<Team> CreateTeams()
        {
            List<Team> teams = new List<Team>()
            {
                new Team()
                {
                    Id = 1,
                    Name = "CoolTeam"
                },
             };

            return teams;
        }
    }
}
