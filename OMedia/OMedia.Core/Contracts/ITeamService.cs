using OMedia.Core.Models.Team;
using OMedia.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMedia.Core.Contracts
{
    public interface ITeamService
    {
        Task<IEnumerable<TeamsViewModel>> GetAllTeams();
        Task<List<Competitor>> GetTeamsMembersById(int id);
        Task<List<Competition>> GetTeamsCompetitionsId(int id);

        Task<bool> Exists(int id);
        Task<Team> GetTeamById(int id);
        Task<TeamDetailsModel> TeamDetailsById(int id);
    }
}
