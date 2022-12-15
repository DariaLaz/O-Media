using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMedia.Core.Contracts
{
    public interface ICompetitorService
    {
        Task Create(
            string userId,
            string name,
            int TeamId,
            int ageGroupId);
        Task Edit(int id, string name, int teamId, int ageGroupId);
        Task<int> GetAgeGroupId(int id);
    }
}
