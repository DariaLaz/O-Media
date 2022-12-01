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
                    Title = "Title",
                    Content = "Content Content Content Content Content Content Content Content Content Content Content Content Content",
                    WriterId = 1,
                    Date = DateTime.Now
                },
             };

            return news;
        }
    }
}
