using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMedia.Infrastructure.Data.EntityConfigurations
{
    internal class DistanceTypesConfiguration : IEntityTypeConfiguration<DistanceType>
    {
        public void Configure(EntityTypeBuilder<DistanceType> builder)
        {
            builder.HasData(CreateDistances());
        }
        private List<DistanceType> CreateDistances()
        {
            List<DistanceType> distances = new List<DistanceType>()
            {
                new DistanceType()
                {
                    Id = 1,
                    TypeName = "Sprint"
                },
                new DistanceType()
                {
                    Id = 2,
                    TypeName = "Middle"
                },
                new DistanceType()
                {
                    Id = 3,
                    TypeName = "Long"
                },
                new DistanceType()
                {
                    Id = 4,
                    TypeName = "Relay"
                },
                new DistanceType()
                {
                    Id = 5,
                    TypeName = "Sky"
                },
                new DistanceType()
                {
                    Id = 6,
                    TypeName = "O-Bike"
                },
             };

            return distances;
        }
    }
}
