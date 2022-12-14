using Microsoft.EntityFrameworkCore;
using OMedia.Core.Contracts;
using OMedia.Core.Models.Team;
using OMedia.Infrastructure.Data;
using OMedia.Infrastructure.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMedia.Core.Services
{
    public class TeamService : ITeamService
    {
        private readonly IRepository repo;

        public TeamService(IRepository _repo)
        {
            repo = _repo;
        }
        public async Task<bool> Exists(int id)
        {
            return await repo.AllReadonly<Team>()
               .AnyAsync(h => h.Id == id);
        }
        public async Task<IEnumerable<TeamsViewModel>> GetAllTeams()
        {
            var teams = await repo.AllReadonly<Team>()
               .Include(t => t.Competitors)
               .ThenInclude(c => c.Competitions)
               .Select(c => new TeamsViewModel()
               {
                   Id = c.Id,
                   Name = c.Name,
                   CountOfMembers = c.Competitors.Count,
               })
               .ToListAsync();

            foreach (var team in teams)
            {
                team.CountOfCompetitions = (await GetTeamsCompetitionsId(team.Id)).Count();
            }

            return teams;
        }
        public async Task<Team> GetTeamById(int id)
        {
            return await repo.AllReadonly<Team>()
                .FirstOrDefaultAsync(t => t.Id == id);
        }
        public async Task<List<Competitor>> GetTeamsMembersById(int id)
        {
            var team = await repo.AllReadonly<Team>()
                 .Include(x => x.Competitors)
                 .ThenInclude(x => x.Competitions)
                 .ThenInclude(x => x.Competition)
                 .FirstAsync(t => t.Id == id);
            return team.Competitors.Where(x => x.IsActive).ToList();
        }
        public async Task<List<Competition>> GetTeamsCompetitionsId(int id)
        {
            var competitors = (await GetTeamsMembersById(id));

            var competitions = new List<Competition>();
            foreach (var c in competitors)
            {
                foreach (var comp in c.Competitions.Where(x => x.IsActive))
                {
                    if (comp.Role == "Organizer")
                    {
                        competitions.Add(comp.Competition);
                    }
                }
            }
            return competitions;
            
        }
        public async Task<TeamDetailsModel> TeamDetailsById(int id)
        {
            var team = await repo.AllReadonly<Team>()
                .Include(x => x.Competitors)
                .FirstOrDefaultAsync(t => t.Id == id);

            return new TeamDetailsModel()
            {
                Id = team.Id,
                Name = team.Name,
                Competitors = (await GetTeamsMembersById(id)).Select(c => new TeamMemberView()
                {
                    Id = c.Id,
                    Name = c.Name,
                    UserId = c.UserId
                }).ToList(),
                Competitions = (await GetTeamsCompetitionsId(id)).Select(x => new TeamCompetitionModel()
                {
                    Id = x.Id,
                    Date = x.Date.ToString("dd/MM/yyyy"),
                    IsPassed = (x.Date < DateTime.Now),
                    Name = x.Name
                }).ToList()
            };
        }
        public async Task<int> Create(AddTeamModel model)
        {
            var team = new Team()
            {
                Details = model.Details,
                Name = model.Name
            };
            await repo.AddAsync(team);
            await repo.SaveChangesAsync();

            return team.Id;
        }
        public async Task<bool> Exists(AddTeamModel model)
        {
            return await repo.AllReadonly<Team>().AnyAsync(t => t.Name == model.Name);
        }
    }
}