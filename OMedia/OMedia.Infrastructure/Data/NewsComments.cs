using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMedia.Infrastructure.Data
{
    public class NewsComments
    {
        public int Id { get; set; }
        //public int NewsId { get; set; }
        //public int CommentId { get; set; }

        //[ForeignKey(nameof(NewsId))]
        //public News News { get; set; }

        //[ForeignKey(nameof(CommentId))]
        //public Comment Comment { get; set; }
    }
}
