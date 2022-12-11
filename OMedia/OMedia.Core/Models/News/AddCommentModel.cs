using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMedia.Core.Models.News
{
    public class AddCommentModel
    {
        public string Content { get; set; }
        public int AuthorId { get; set; }
        public int NewsId { get; set; }
        public bool IsChanged { get; set; }
        public string Date { get; set; }
    }
}
