using Microsoft.EntityFrameworkCore;
using OMedia.Core.Contracts;
using OMedia.Core.Models.Competition;
using OMedia.Core.Models.User;
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

        public async Task<ProfileViewModel> GetCompetitor(int id)
        {
            var competitior = (await repo.AllReadonly<Competitor>()
                .Include(x => x.Team)
                .Include(x => x.Competitions)
                .ThenInclude(x => x.Competition)
                .FirstOrDefaultAsync(a => a.Id == id));
            var competitions = competitior.Competitions
                .Where(x => x.Role != "Organizer" && x.Competitor.Id == id)
                .Select(c => new CompetitionViewModel()
                {
                    Id = c.CompetitionId,
                    Name = c.Competition.Name,
                    Location = c.Competition.Location,
                    Date = c.Competition.Date.ToString("dd-MM-yyyy"),
                    AgeGroups = c.Competition.AgeGroups.Select(g => new CompetitionAgeGroupModel
                    {
                        Id = g.AgeGroupId
                    })
                }).ToList();
            var competitionsOrganized = competitior.Competitions
                .Where(x => x.Role == "Organizer" && x.Competitor.Id == id)
                .Select(c => new CompetitionViewModel()
                {
                    Id = c.CompetitionId,
                    Name = c.Competition.Name,
                    Location = c.Competition.Location,
                    Date = c.Competition.Date.ToString("dd-MM-yyyy"),
                    AgeGroups = c.Competition.AgeGroups.Select(g => new CompetitionAgeGroupModel
                    {
                        Id = g.AgeGroupId
                    })
                }).ToList();
            return new ProfileViewModel()
            {
                Name = competitior.Name,
                TeamId = competitior.TeamId,
                TeamName = competitior.Team.Name,
                Competitions = competitions,
                CompetitionsOrganized = competitionsOrganized
            };
        }
    }
}
