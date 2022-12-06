using OMedia.Core.Models.Competition;
using OMedia.Core.Models.Team;
using OMedia.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMedia.Core.Contracts
{
    public interface ICompetitionService
    {
        Task<IEnumerable<CompetitionViewModel>> GetAllPreviousCompetitionsSortedByDate();
        Task<IEnumerable<CompetitionViewModel>> GetAllComingCompetitionsSortedByDate();
        Task<IEnumerable<CompetitionAgeGroupModel>> GetAllAgeGroups();
        Task<IEnumerable<TeamsViewModel>> GetAllTeams();
        Task<Competition?> GetCompetitionById(int id);
        Task<AgeGroup> GetAgeGroupsById(int id);
        Task<int> Create(AddCompetitionViewModel model, int userId);
        Task<CompetitionDetailsModel> CompetitionDetailsById(int id);
        Task<bool> Exists(int id);
        Task<string> GetCompetitionOrganizerUserId(int compId);
        Task Edit(int compId, AddCompetitionViewModel model);
        Task RemoveAgeGroup(int compId, int AgeGroupId);
        Task Delete(int id);
        Task<IEnumerable<CompetitionAgeGroupModel>> GetCompetitionAgeGroups(int compId);

    } 
}
