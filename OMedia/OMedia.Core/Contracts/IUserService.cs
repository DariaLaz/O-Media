using Microsoft.AspNetCore.Identity;
using OMedia.Core.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMedia.Core.Contracts
{
    public interface IUserService
    {
        Task<bool> isCompetitorById(string userId);
        Task<int> GetCompetitorId(string userId);
        
        Task<ProfileViewModel> GetCompetitor(int id);
        Task<IEnumerable<UserViewModel>> All();
        Task<bool> Forget(IdentityUser user);
        Task<IdentityUser> GetUser(string id);
        Task<bool> RemoveAdmin(string id);
        Task<bool> AddAdmin(string id);
        Task<bool> IsTheLastAdmin();
        Task<UserViewModel> GetInfo(string id);
    }
}
