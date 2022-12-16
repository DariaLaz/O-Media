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
    public class CompetitorService : ICompetitorService
    {
        private readonly IRepository repo;

        public CompetitorService(IRepository _repo)
        {
            repo = _repo;
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
        public async Task Edit(int id, string name, int teamId, int ageGroupId)
        {
            var competitor = await repo.GetByIdAsync<Competitor>(id);

            competitor.Name = name;
            competitor.TeamId = teamId;
            competitor.AgeGroupId = ageGroupId;

            await repo.SaveChangesAsync();
        }
       
    }
}
