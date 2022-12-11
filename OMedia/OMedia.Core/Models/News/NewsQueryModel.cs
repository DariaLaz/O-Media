using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMedia.Core.Models.News
{
    public class NewsQueryModel
    {
        public int TotalNewsCount { get; set; }

        public List<NewsViewModel> News { get; set; }
            = new List<NewsViewModel>();
    }
}
