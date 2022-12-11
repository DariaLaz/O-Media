using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMedia.Core.Models.Team
{
    public class TeamDetailsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TeamMemberView> Competitors { get; set; }
        public List<TeamCompetitionModel> Competitions { get; set; }
    }
}
