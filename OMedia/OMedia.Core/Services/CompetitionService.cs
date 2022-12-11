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
using System.Text.RegularExpressions;
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
                Date = Convert.ToDateTime(model.Date),
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
            competition.Date = Convert.ToDateTime(model.Date);
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
        public async Task<List<int>> GetAllCompetitionYears()
        {
            return await repo.AllReadonly<Competition>()
                .Select(x => x.Date.Year)
                .Distinct().ToListAsync();
        }
        public async Task<CompetitionQueryModel> GetAll(
            string? searchTerm = null,
            int year = 0,
            CompetitionSorting sorting = CompetitionSorting.Newest,
            int currentPage = 1, 
            int compPerPage = 1,
            int userId = 0)
        {
            var competitions = await repo.AllReadonly<Competition>()
                .Include(c => c.Competitors)
                .ToListAsync();
            var result = new CompetitionQueryModel();

            if (year != 0)
            {
                competitions = competitions.Where(x => (x.Date.Year) == year).ToList();
            }

            if (string.IsNullOrEmpty(searchTerm) == false)
            {
                competitions = competitions.Where(x =>
                   (x.Name.ToLower()).Split(" ").Contains(searchTerm.ToLower()) ||
                   (x.Details.ToLower()).Split(" ").Contains(searchTerm.ToLower()))
                   .ToList();
            }

            switch (sorting)
            {
                case CompetitionSorting.Oldest:
                    competitions = competitions.OrderBy(c => c.Date).ToList();
                    break;
                case CompetitionSorting.Newest:
                    competitions = competitions.OrderByDescending(c => c.Date).ToList();
                    break;
                default:
                    competitions = competitions.OrderByDescending(h => h.Id).ToList();
                    break;
            }

            result.Competitions = competitions
                .Skip((currentPage - 1) * compPerPage)
                .Take(compPerPage)
                .Select(c => new CompetitionViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Location = c.Location,
                    Date = c.Date.ToString("dd-MM-yyyy"),
                    AgeGroups = c.AgeGroups.Select(g => new CompetitionAgeGroupModel
                    {
                        Id = g.AgeGroupId
                    }),
                    IsCurrUserTakingPart = c.Competitors.Any(x => x.CompetitorId == userId && x.IsActive)
                }).ToList();

            result.TotalCompetitionsCount = competitions.Count();

            return result;
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

        public async Task<bool> IsAlreadyParticipant(int competitionId, string competitorId)
        {
            var cc = await repo.All<CompetitionsCompetitors>()
                .Include(c => c.Competitor)
                .FirstOrDefaultAsync(x => x.CompetitionId == competitionId && 
                                x.Competitor.UserId == competitorId &&
                                !x.IsActive);
            return (cc != null);
        }

        public async Task TakePart(int competitionId, int competitorId)
        {
            var cc = await repo.All<CompetitionsCompetitors>()
                .FirstOrDefaultAsync(x => x.CompetitionId == competitionId &&
                                    x.CompetitorId == competitorId);
            if (cc != null)
            {
                cc.IsActive = true;
            }
            else
            {
                var newCc = new CompetitionsCompetitors();
                newCc.CompetitionId = competitionId;
                newCc.CompetitorId = competitorId;

                await repo.AddAsync(newCc);
            }
            await repo.SaveChangesAsync();
        }

        public async Task Cancel(int competitionId, int competitorId)
        {
            var cc = await repo.All<CompetitionsCompetitors>()
                .FirstOrDefaultAsync(x => x.CompetitionId == competitionId &&
                                    x.CompetitorId == competitorId);
            if (cc != null)
            {
                cc.IsActive = false;
                await repo.SaveChangesAsync();
            }
        }
    }
}
