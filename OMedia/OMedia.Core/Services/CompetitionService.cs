using Microsoft.EntityFrameworkCore;
using OMedia.Core.Contracts;
using OMedia.Core.Models.Competition;
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
        public async Task<int> Create(AddCompetitionViewModel model, int userId)
        {
           
            var competition = new Competition()
            {
                Name = model.Name,
                Location = model.Location,
                Date = model.Date,
                Details = model.Details
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
        public async Task<AgeGroup> GetAgeGroupsById(int id)
        {
            return await repo.AllReadonly<AgeGroup>().FirstOrDefaultAsync(ag => ag.Id == id);
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
                .Where(c => c.Date < DateTime.Now)
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
                .Where(c => c.Date < DateTime.Now)
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
    }
}
