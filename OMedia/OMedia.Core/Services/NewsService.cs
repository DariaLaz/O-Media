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
               .Include(n => n.Comments)
               .Where(n => n.IsActive)
               .OrderByDescending(h => h.Id)
               .Select(n => new NewsViewModel()
               {
                   Id = n.Id,
                   Title = n.Title,
                   Content = n.Content,
                   WriterId = n.Writer.UserId,
                   WriterName = n.Writer.Name,
                   Date = n.Date.ToString("dd-MM-yyyy"),
                   Comments = n.Comments.Where(c => c.IsActive)
                       .Select(x => new CommentViewModel()
                       {
                           Id = x.Id,
                           AuthorId = x.Author.UserId,
                           AuthorName = x.Author.Name,
                           Content = x.Content,
                           IsChanged = x.IsChanged
                       }).ToList()
               })
               .ToListAsync();
        }
        public async Task<NewsViewModel> GetNewsById(int id)
        {
            var news = await repo.AllReadonly<News>()
                .Include(x => x.Writer)
                .Include(x => x.Comments)
                .ThenInclude(x => x.Author)
                .Where(n => n.IsActive)
                .FirstOrDefaultAsync(x => x.Id == id);
            return new NewsViewModel()
            {
                Id = news.Id,
                Title = news.Title,
                Content = news.Content,
                WriterId = news.Writer.UserId,
                Date = news.Date.ToString("dd/MM/yyyy"),
                Comments = news.Comments
                       .Where(c => c.IsActive)
                       .Select(x => new CommentViewModel()
                       {
                           Id = x.Id,
                           AuthorId = x.Author.UserId,
                           AuthorName = x.Author.Name,
                           Content = x.Content,
                           IsChanged = x.IsChanged
                       }).ToList()
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
        public async Task<IEnumerable<CommentViewModel>?> GetCommentsById(int id)
        {
            var current = await repo.AllReadonly<News>()
               .Include(n => n.Comments)
               .Where(n => n.IsActive && n.Id == id)
               .FirstOrDefaultAsync();
            return current == null 
                ? null
                : current.Comments.Where(c => c.IsActive)
                       .Select(x => new CommentViewModel()
                       {
                           AuthorId = x.Author.UserId,
                           AuthorName = x.Author.Name,
                           Content = x.Content,
                           IsChanged = x.IsChanged
                       }).ToList();

        }
        public async Task<int> CreateComment(AddCommentModel model, int authorId, int newsId)
        {
            var comment = new Comment()
            {
                Content = model.Content,
                AuthorId = authorId,
                Date = DateTime.Now,
                IsActive = true,
                IsChanged = false
            };
            var news = await repo.GetByIdAsync<News>(newsId);
            news.Comments.Add(comment);

            await repo.AddAsync(comment);
            await repo.SaveChangesAsync();

            return comment.Id;
        }
        public async Task<bool> ExistsComment(int id)
        {
            return await repo.AllReadonly<Comment>()
               .AnyAsync(x => x.Id == id);
        }
        public async Task<CommentViewModel> GetCommentById(int id)
        {
            var comment = await repo.AllReadonly<Comment>()
               .Include(x => x.Author)
               .Where(n => n.IsActive)
               .FirstOrDefaultAsync(x => x.Id == id);
            return new CommentViewModel()
            {
               Id = id,
               Content = comment.Content,
               Date = comment.Date.ToString("dd/MM/yyyy"),
               AuthorId = comment.Author.UserId,
               AuthorName = comment.Author.Name,
               IsChanged = comment.IsChanged
            };
        }
        public async Task<string> GetCommentAuthorUserId(int id)
        {
            var comment = await repo.AllReadonly<Comment>()
                .Include(x => x.Author)
               .Where(n => n.IsActive)
               .FirstOrDefaultAsync(x => x.Id == id);
            return comment.Author.UserId;
        }
        public async Task DeleteComment(int id)
        {
            var comment = await repo.GetByIdAsync<Comment>(id);

            comment.IsActive = false;

            await repo.SaveChangesAsync();
        }
        public async Task EditComment(int commentId, EditCommentModel model)
        {
            var comment = await repo.GetByIdAsync<Comment>(commentId);
           // comment.Id = model.Id;
            comment.Content = model.Content;
            comment.Date = DateTime.Now;
            comment.IsChanged = true;

            await repo.SaveChangesAsync();
        }

        public async Task<NewsQueryModel> GetAll(
            string? searchTerm = null, 
            int year = 0, 
            int currentPage = 1, 
            int newsPerPage = 1)
        {
            var news = await repo.AllReadonly<News>()
                .Include(n => n.Writer)
                .Include(n => n.Comments)
                .ThenInclude(c => c.Author)
                .ToListAsync();
            var result = new NewsQueryModel();

            if (year != 0)
            {
                news = news.Where(x => (x.Date.Year) == year).ToList();
            }

            if (string.IsNullOrEmpty(searchTerm) == false)
            {
                news = news.Where(x =>
                   (x.Title.ToLower()).Split(" ").Contains(searchTerm.ToLower()) ||
                   (x.Content.ToLower()).Split(" ").Contains(searchTerm.ToLower()))
                   .ToList();
            }

            result.News = news
                .Skip((currentPage - 1) * newsPerPage)
                .Take(newsPerPage)
                .Select(c => new NewsViewModel()
                {
                    Id = c.Id,
                    Title = c.Title,
                    Content = c.Content,
                    WriterId = c.Writer.UserId,
                    WriterName = c.Writer.Name,
                    Date = c.Date.ToString("dd/MM/yyyy"),
                    Comments = c.Comments
                       .Where(x => x.IsActive)
                       .Select(x => new CommentViewModel()
                       {
                           Id = x.Id,
                           AuthorId = x.Author.UserId,
                           AuthorName = x.Author.Name,
                           Content = x.Content,
                           IsChanged = x.IsChanged
                       }).ToList()
                }).ToList();

            result.TotalNewsCount = news.Count();

            return result; 
        }

        public async Task<List<int>> GetAllNewsYears()
        {
            return await repo.AllReadonly<News>()
                .Select(x => x.Date.Year)
                .Distinct().ToListAsync();
        }

        public async Task<IEnumerable<NewsViewModel>> GetNewsByUserId(string id)
        {
            var news = await repo.AllReadonly<News>()
                .Include(n => n.Writer)
                .Include(n => n.Comments)
                .ThenInclude(c => c.Author)
                .Where(x => x.Writer.UserId == id && x.IsActive)
                .ToListAsync();

            return news.Select(x => new NewsViewModel()
                    {
                        Id = x.Id,
                        Comments = x.Comments
                           .Where(x => x.IsActive)
                           .Select(x => new CommentViewModel()
                           {
                               Id = x.Id,
                               AuthorId = x.Author.UserId,
                               AuthorName = x.Author.Name,
                               Content = x.Content,
                               IsChanged = x.IsChanged
                           }).ToList(),
                        Content = x.Content,
                        Date = x.Date.ToString("dd/MM/yyyy"),
                        Title = x.Title,
                        WriterId = x.Writer.UserId,
                        WriterName = x.Writer.Name
                    }).ToList();
        }
    }
}
