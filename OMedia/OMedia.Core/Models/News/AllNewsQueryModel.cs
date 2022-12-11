using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMedia.Core.Models.News
{
    public class AllNewsQueryModel
    {
        public const int NewsPerPage = 5;
        public string? SearchTerm { get; set; }
        public int CurrentPage { get; set; }
        public int TotalNewsCount { get; set; }
        public IEnumerable<NewsViewModel> News { get; set; } =
            new List<NewsViewModel>();
        public IEnumerable<int> Years { get; set; } = new List<int>();
        public int Year { get; set; }
    }
}
