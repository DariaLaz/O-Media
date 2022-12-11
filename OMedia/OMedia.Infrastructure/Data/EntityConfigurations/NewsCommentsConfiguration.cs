using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMedia.Infrastructure.Data.EntityConfigurations
{
    internal class NewsCommentsConfiguration : IEntityTypeConfiguration<NewsComments>
    {
        public void Configure(EntityTypeBuilder<NewsComments> builder)
        {
           // builder.HasKey(cn => new { cn.NewsId, cn.CommentId });
        }
    }
}
