using Microsoft.EntityFrameworkCore;
using OMedia.Core.Contracts;
using OMedia.Core.Models.News;
using OMedia.Infrastructure.Data;
using OMedia.Infrastructure.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMedia.Core.Services
{
    public class NewsService : INewsService
    {
        private readonly IRepository repo;
        public NewsService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<int> Create(AddNewViewModel model, int userId)
        {
            var news = new News()
            {
                Title = model.Title,
                Content = model.Content,
                WriterId = userId,
                Date = DateTime.Now
            };
            await repo.AddAsync(news);
            await repo.SaveChangesAsync();

            return news.Id;
        }

        public async Task<IEnumerable<NewsViewModel>> GetAllNewsSortedByDate()
        {
            return await repo.AllReadonly<News>()
               .OrderByDescending(h => h.Id)
               .Select(n => new NewsViewModel()
               {
                   Id = n.Id,
                   Title = n.Title,
                   Content = n.Content,
                   WriterName = n.Writer.Name,
                   Date = n.Date.ToString("dd-MM-yyyy")
               })
               .ToListAsync();
        }
    }
}
