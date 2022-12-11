using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMedia.Core.Models.News
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string AuthorId { get; set; } = null!;
        public string AuthorName { get; set; } = null!;
        public bool IsChanged { get; set; }
        public string  Date { get; set; }
        public int NewsId { get; set; }
    }
}
