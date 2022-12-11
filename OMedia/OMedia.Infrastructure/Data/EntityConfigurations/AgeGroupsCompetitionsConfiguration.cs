using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMedia.Infrastructure.Data.EntityConfigurations
{
    public class AgeGroupsCompetitionsConfiguration : IEntityTypeConfiguration<AgeGroupsCompetitions>
    {
        public void Configure(EntityTypeBuilder<AgeGroupsCompetitions> builder)
        {
            builder.HasKey(cc => new { cc.AgeGroupId, cc.CompetitionId });
        }
    }
}
