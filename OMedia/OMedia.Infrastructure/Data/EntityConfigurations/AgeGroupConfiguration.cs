using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMedia.Infrastructure.Data.EntityConfigurations
{
    internal class AgeGroupConfiguration : IEntityTypeConfiguration<AgeGroup>
    {
        public void Configure(EntityTypeBuilder<AgeGroup> builder)
        {
            builder.HasData(CreateAgeGroups());

        }
        private List<AgeGroup> CreateAgeGroups()
        {
            List<AgeGroup> ageGroups = new List<AgeGroup>()
            {
                new AgeGroup()
                {
                    Id = 1,
                    Gender = "Male",
                    Age = 10
                },
                new AgeGroup()
                {
                    Id = 2,
                    Gender = "Male",
                    Age = 12
                },

                new AgeGroup()
                {
                    Id = 3,
                    Gender = "Male",
                    Age = 14
                },

                new AgeGroup()
                {
                    Id = 4,
                    Gender = "Male",
                    Age = 16
                },
                new AgeGroup()
                {
                    Id = 5,
                    Gender = "Male",
                    Age = 18
                },
                new AgeGroup()
                {
                    Id = 6,
                    Gender = "Male",
                    Age = 21
                },
                new AgeGroup()
                {
                    Id = 7,
                    Gender = "Male",
                    Age = 35
                },
                new AgeGroup()
                {
                    Id = 8,
                    Gender = "Male",
                    Age = 40
                },
                new AgeGroup()
                {
                    Id = 9,
                    Gender = "Male",
                    Age = 45
                },
                new AgeGroup()
                {
                    Id = 10,
                    Gender = "Male",
                    Age = 50
                },
                new AgeGroup()
                {
                    Id = 11,
                    Gender = "Male",
                    Age = 55
                },
                 new AgeGroup()
                {
                     Id = 12,
                    Gender = "Male",
                    Age =60
                },
                  new AgeGroup()
                {
                     Id = 13,
                    Gender = "Male",
                    Age =65
                },
                new AgeGroup()
                {
                    Id = 14,
                    Gender = "Female",
                    Age = 12
                },

                new AgeGroup()
                {
                    Id = 15,
                    Gender = "Female",
                    Age = 14
                },

                new AgeGroup()
                {
                    Id = 16,
                    Gender = "Female",
                    Age = 16
                },
                new AgeGroup()
                {
                    Id = 17,
                    Gender = "Female",
                    Age = 18
                },
                new AgeGroup()
                {
                    Id = 18,
                    Gender = "Female",
                    Age = 21
                },
                new AgeGroup()
                {
                    Id = 19,
                    Gender = "Female",
                    Age = 35
                },
                new AgeGroup()
                {
                    Id = 20,
                    Gender = "Female",
                    Age = 40
                },
                new AgeGroup()
                {
                    Id = 21,
                    Gender = "Female",
                    Age = 45
                },
                new AgeGroup()
                {
                    Id = 22,
                    Gender = "Female",
                    Age = 50
                },
                new AgeGroup()
                {
                    Id = 23,
                    Gender = "Female",
                    Age = 55
                },
                new AgeGroup()
                {
                    Id = 24,
                    Gender = "Female",
                    Age = 60
                },
                new AgeGroup()
                {
                    Id = 25,
                    Gender = "Female",
                    Age = 65
                }
             };

            return ageGroups;
        }
    }
}
