using OMedia.Core.Models.Competition;
using OMedia.Core.Models.Team;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMedia.Core.Models.Competitor
{
    public class CompetitorViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int TeamId { get; set; }
        [Required]
        public int AgeGroupId { get; set; }
        public IEnumerable<CompetitionAgeGroupModel> AgeGroups { get; set; } = new List<CompetitionAgeGroupModel>();
        public IEnumerable<TeamsViewModel> Teams { get; set; } = new List<TeamsViewModel>();

    }
}