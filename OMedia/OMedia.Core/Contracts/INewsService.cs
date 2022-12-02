using OMedia.Core.Models.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMedia.Core.Contracts
{
    public interface INewsService
    {
        Task<IEnumerable<NewsViewModel>> GetAllNewsSortedByDate();
        Task<int> Create(AddNewViewModel model, int userId);
    }
}
