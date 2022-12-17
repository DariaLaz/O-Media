using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMedia.Infrastructure.Data.EntityConfigurations
{
    internal class NewsConfiguration : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder.HasData(CreateNews());
        }
        private List<News> CreateNews()
        {
            List<News> news = new List<News>()
            {
                new News()
                {
                    Id = 1,
                    Title = "A wonderful year",
                    Content = "This year was very nice for me. I have taken part in more than 15 competitions and met a lof of new people from the community",
                    WriterId = 1,
                    Date = DateTime.Parse("12/15/2022")
                },
             };

            return news;
        }
    }
}
