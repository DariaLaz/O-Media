using OMedia.Core.Models.Competition;
using OMedia.Core.Models.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMedia.Core.Models.User
{
    public class ProfileViewModel
    {
        public string Name { get; set; }
        public List<CompetitionViewModel> CompetitionsOrganized { get; set; }
        public List<CompetitionViewModel> Competitions { get; set; }

        public List<NewsViewModel> News { get; set; }
        public AgeGroupViewModel AgeGroup { get; set; }
        public int TeamId { get; set; }
        public string TeamName { get; set; }
    }
}
