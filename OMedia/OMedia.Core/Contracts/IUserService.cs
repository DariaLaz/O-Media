using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMedia.Core.Contracts
{
    public interface IUserService
    {
        Task<bool> ExistsById(string userId);
        Task<int> GetCompetitorId(string userId);
        Task<string> GetUserId(int competitorId);

    }
}
