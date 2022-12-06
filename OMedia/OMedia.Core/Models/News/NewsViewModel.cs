using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMedia.Core.Models.News
{
    public class NewsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public string WriterId { get; set; } = null!;
        public string WriterName { get; set; } = null!;
        public string Date { get; set; } = null!;
    }
}
