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
        Task<string> GetWriterUserId(int id);
        Task<bool> Exists(int id);
        Task<NewsViewModel> GetNewsById(int id);
        Task Edit(int newsId, AddNewViewModel model);
        Task Delete(int id);
        Task<int> CreateComment(AddCommentModel model, int authorId, int newsId);
        Task EditComment(int commentId, EditCommentModel model);
        Task<bool> ExistsComment(int id);
        Task<CommentViewModel> GetCommentById(int id);
        Task<string> GetCommentAuthorUserId(int id);
        Task DeleteComment(int id);
    }
}
