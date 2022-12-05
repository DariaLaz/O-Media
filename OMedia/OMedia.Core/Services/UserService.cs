using Microsoft.EntityFrameworkCore;
using OMedia.Core.Contracts;
using OMedia.Infrastructure.Data;
using OMedia.Infrastructure.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMedia.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository repo;

        public UserService(IRepository _repo)
        {
            repo = _repo;
        }
        public async Task<bool> isCompetitorById(string userId)
        {
            return await repo.All<Competitor>()
                .AnyAsync(a => a.UserId == userId);
        }

        public async Task<int> GetCompetitorId(string userId)
        {
            return (await repo.AllReadonly<Competitor>()
               .FirstOrDefaultAsync(a => a.UserId == userId))?.Id ?? 0;
        }

        public async Task Create(string userId, string name, int teamId, int ageGroupId)
        {
            var competitor = new Competitor()
            {
                UserId = userId,
                Name = name,
                TeamId = teamId,
                AgeGroupId = ageGroupId
            };
            await repo.AddAsync(competitor);
            await repo.SaveChangesAsync();
        }
    }
}
