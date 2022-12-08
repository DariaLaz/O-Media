using Microsoft.EntityFrameworkCore;
using OMedia.Core.Contracts;
using OMedia.Core.Models.Competition;
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
    public class CompetitionService : ICompetitionService
    {
        private readonly IRepository repo;

        public CompetitionService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<CompetitionDetailsModel> CompetitionDetailsById(int id)
        {
            return await repo.AllReadonly<Competition>()
                .Where(h => h.Id == id)
                .Select(h => new CompetitionDetailsModel()
                {
                    Id = h.Id,
                    Name = h.Name,
                    Location = h.Location,
                    Date = h.Date.ToString("dd/MM/yyyy"),
                    Details = h.Details,
                    AgeGroups = h.AgeGroups.Select(g => g.AgeGroup.Gender == null ? "Open" : $"{g.AgeGroup.Gender[0]}{g.AgeGroup.Age}").ToList(),
                    CompetitorsNames = h.Competitors.Select(c => c.Competitor.Name).ToList(),
                    OrganizerName = h.Competitors
                        .Where(c => c.Role == "Organizer")
                        .First().Competitor.Name,
                    OrganizerTeamName = h.Competitors
                        .Where(c => c.Role == "Organizer")
                        .First().Competitor.Team.Name,
                    OrganizerId = h.Competitors
                        .Where(c => c.Role == "Organizer")
                        .First().CompetitorId,
                    OrganizerUserId = h.Competitors
                        .Where(c => c.Role == "Organizer")
                        .First().Competitor.UserId
                })
                .FirstAsync();
        }
        public async Task<int> Create(AddCompetitionViewModel model, int userId)
        {
           
            var competition = new Competition()
            {
                Name = model.Name,
                Location = model.Location,
                Date = model.Date,
                Details = model.Details,
                IsActive = true
            };
            foreach (var ag in model.AgeGroups)
            {
                if ((await GetAgeGroupsById(ag.Id)) != null)
                {
                    competition.AgeGroups.Add(new AgeGroupsCompetitions
                    {
                        AgeGroupId = ag.Id
                    });
                }
            }
            var relation = new CompetitionsCompetitors()
            {
                Competition = competition,
                CompetitorId = userId,
                Role = "Organizer"
            };
            await repo.AddAsync(competition);
            await repo.AddAsync(relation);
            await repo.SaveChangesAsync();

            return competition.Id;
        }
        public async Task Delete(int id)
        {
            var competition = await repo.GetByIdAsync<Competition>(id);

            competition.IsActive = false;

            await repo.SaveChangesAsync();
        }
        public async Task Edit(int compId, AddCompetitionViewModel model)
        {
            var competition = await repo.GetByIdAsync<Competition>(compId);

            competition.Name = model.Name;
            competition.Location = model.Location;
            competition.Date = model.Date;
            competition.Details = model.Details;
            competition.AgeGroups = new List<AgeGroupsCompetitions>();
            foreach (var ag in model.AgeGroups)
            {
                if ((await GetAgeGroupsById(ag.Id)) != null)
                {
                    competition.AgeGroups.Add(new AgeGroupsCompetitions
                    {
                        AgeGroupId = ag.Id
                    });
                }
            }
            competition.IsChanged = true;
            await repo.SaveChangesAsync();
        }
        public async Task<bool> Exists(int id)
        {
            return await repo.AllReadonly<Competition>()
               .AnyAsync(h => h.Id == id);
        }
        public async Task<AgeGroup> GetAgeGroupsById(int id)
        {
            return await repo.AllReadonly<AgeGroup>()
                .FirstOrDefaultAsync(ag => ag.Id == id);
        }
        public async Task<IEnumerable<CompetitionAgeGroupModel>> GetAllAgeGroups()
        {
            return await repo.AllReadonly<AgeGroup>()
                .Select(g => new CompetitionAgeGroupModel()
                {
                    Id = g.Id,
                    Gender = g.Gender?? "Open",
                    Age = g.Age?? -1
                })
                .ToListAsync();
        }
        public async Task<IEnumerable<CompetitionViewModel>> GetAllComingCompetitionsSortedByDate()
        {
            return await repo.AllReadonly<Competition>()
                .Include(c => c.AgeGroups)
                .OrderByDescending(c => c.Date)
                .Where(c => c.Date < DateTime.Now && c.IsActive)
                .Select(c => new CompetitionViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Location = c.Location,
                    Date = c.Date.ToString("dd-MM-yyyy"),
                    AgeGroups = c.AgeGroups.Select(g => new CompetitionAgeGroupModel
                    {
                        Id = g.AgeGroupId
                    })
                })
                .ToListAsync();
                
        }
        public async Task<IEnumerable<CompetitionViewModel>> GetAllPreviousCompetitionsSortedByDate()
        {
            return await repo.AllReadonly<Competition>()
                .Include(c => c.AgeGroups)
                .OrderByDescending(c => c.Date)
                .Where(c => c.Date < DateTime.Now && c.IsActive)
                .Select(c => new CompetitionViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Location = c.Location,
                    Date = c.Date.ToString("dd-MM-yyyy"),
                    AgeGroups = c.AgeGroups.Select((g) => new CompetitionAgeGroupModel
                    {
                        Id = g.AgeGroupId
                    })
                })
                .ToListAsync();
        }
        public async Task<IEnumerable<TeamsViewModel>> GetAllTeams()
        { 
            return await repo.AllReadonly<Team>()
               .Select(t => new TeamsViewModel()
               {
                   Id = t.Id,
                   Name = t.Name
               })
               .ToListAsync();
        }
        public async Task<IEnumerable<CompetitionAgeGroupModel>> GetCompetitionAgeGroups(int compId)
        {
            var comp = await repo.AllReadonly<Competition>()
                .Include(c => c.AgeGroups)
                .FirstAsync(x => x.Id == compId);
            return comp.AgeGroups.Select(g => new CompetitionAgeGroupModel()
            { 
                Id = g.AgeGroupId,
                Gender = g.AgeGroup.Gender,
                Age = g.AgeGroup.Age
            }).ToList();
        }
        public async Task<Competition?> GetCompetitionById(int id)
        {
            return await repo.AllReadonly<Competition>()
               .Include(c => c.AgeGroups)
               .Where(h => h.Id == id && h.IsActive)
               .FirstOrDefaultAsync();

        }
        public async Task<string> GetCompetitionOrganizerUserId(int compId)
        {
            return await repo.AllReadonly<Competition>()
                .Where(h => h.Id == compId)
                .Select(h => h.Competitors
                    .Where(h => h.Role == "Organizer")
                    .First().Competitor.UserId)
                .FirstAsync();
        }
        public async Task RemoveAgeGroup(int compId, int AgeGroupId)
        {
            var competition = await repo.All<AgeGroupsCompetitions>()
                .Where(x => x.AgeGroupId == AgeGroupId && x.CompetitionId == compId)
                .FirstAsync();
            await repo.DeleteAsync<AgeGroupsCompetitions>(competition);
            await repo.SaveChangesAsync();
        }
    }
}
