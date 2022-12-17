using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMedia.Core.Models.Competition
{
    public class CompetitionDetailsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Date { get; set; }
        public string Details { get; set; }
        public string OrganizerName { get; set; }
        public int? OrganizerId { get; set; }
        public string? OrganizerUserId { get; set; }
        public bool IsCurrUserTakingPart { get; set; }
        public bool IsOrganizer { get; set; }

        public string OrganizerTeamName { get; set; }
        public List<string> AgeGroups { get; set; }
        public List<string> CompetitorsNames { get; set; }
        
    }
}
