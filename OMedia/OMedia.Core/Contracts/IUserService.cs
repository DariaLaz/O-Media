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
        Task Create(
            string userId, 
            string name, 
            int TeamId,
            int ageGroupId);
        Task<ProfileViewModel> GetCompetitor(int id);

    }
}
