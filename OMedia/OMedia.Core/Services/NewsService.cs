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
                Date = DateTime.Now,
                IsActive = true
            };
            await repo.AddAsync(news);
            await repo.SaveChangesAsync();

            return news.Id;
        }

        public async Task Edit(int newsId, AddNewViewModel model)
        {
            var news = await repo.GetByIdAsync<News>(newsId);
            news.Title = model.Title;
            news.Content = model.Content;

            news.Date = DateTime.Now;
            news.IsChanged = true;

            await repo.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            return await repo.AllReadonly<News>()
                .AnyAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<NewsViewModel>> GetAllNewsSortedByDate()
        {
            return await repo.AllReadonly<News>()
                .Where(n => n.IsActive)
               .OrderByDescending(h => h.Id)
               .Select(n => new NewsViewModel()
               {
                   Id = n.Id,
                   Title = n.Title,
                   Content = n.Content,
                   WriterId = n.Writer.UserId,
                   WriterName = n.Writer.Name,
                   Date = n.Date.ToString("dd-MM-yyyy")
               })
               .ToListAsync();
        }

        public async Task<NewsViewModel> GetNewsById(int id)
        {
            var news = await repo.AllReadonly<News>()
                .Include(x => x.Writer)
                .Where(n => n.IsActive)
                .FirstOrDefaultAsync(x => x.Id == id);
            return new NewsViewModel()
            {
                Id = news.Id,
                Title = news.Title,
                Content = news.Content,
                WriterId = news.Writer.UserId,
                Date = news.Date.ToString("dd/MM/yyyy")
            };
            
        }

        public async Task<string> GetWriterUserId(int id)
        {
            var news = await repo.AllReadonly<News>()
                .Include(x => x.Writer)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (news == null)
            {
                return null;
            }
            return news.Writer.UserId;
        }
        public async Task Delete(int id)
        {
            var news = await repo.GetByIdAsync<News>(id);

            news.IsActive = false;

            await repo.SaveChangesAsync();
        }
    }
}
