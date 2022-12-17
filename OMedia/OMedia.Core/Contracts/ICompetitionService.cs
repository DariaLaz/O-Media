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
        //Task<IEnumerable<CompetitionViewModel>> GetAllCompetitions(string? teamId = null, DateTime date, int currentPage = 1, int housesPerPage = 1);
        Task<CompetitionQueryModel> GetAll(
                string? searchTerm = null,
                int year = 0,
                CompetitionSorting sorting = CompetitionSorting.Newest,
                int currentPage = 1,
                int compsPerPage = 1,
                int userId = 0);
        Task<CompetitionQueryModel> Mine(
            string? searchTerm = null,
            int year = 0,
            CompetitionSorting sorting = CompetitionSorting.Newest,
            int currentPage = 1,
            int compPerPage = 1,
            int userId = 0,
            string role = "Organizer");


        Task<IEnumerable<CompetitionAgeGroupModel>> GetAllAgeGroups();
        Task<IEnumerable<TeamsViewModel>> GetAllTeams();
        Task<Competition?> GetCompetitionById(int id);
        Task<AgeGroup> GetAgeGroupsById(int id);
        Task<int> Create(AddCompetitionViewModel model, int userId);
        Task<CompetitionDetailsModel> CompetitionDetailsById(int id, string userId);
        Task<bool> Exists(int id);
        Task<string> GetCompetitionOrganizerUserId(int compId);
        Task Edit(int compId, AddCompetitionViewModel model);
        Task RemoveAgeGroup(int compId, int AgeGroupId);
        Task Delete(int id);
        Task<List<int>> GetAllCompetitionYears(IEnumerable<CompetitionViewModel> competitions);
        Task<IEnumerable<CompetitionAgeGroupModel>> GetCompetitionAgeGroups(int compId);
        Task<bool> IsAlreadyParticipant(int competitionId, string competitorId);
        Task TakePart(int competitionId, int competitorId);
        Task Cancel(int competitionId, int competitorId);
    }
}
