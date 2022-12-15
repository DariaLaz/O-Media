using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMedia.Core.Models.Competition
{
    public class MyCompetitionsQueryModel
    {
        public const int CompetitionsPerPage = 5;
        public string? SearchTerm { get; set; }
        public CompetitionSorting Sorting { get; set; }
        public int CurrentPage { get; set; }
        public int TotalCompetitionsCount { get; set; }
        public IEnumerable<CompetitionViewModel> Competitions { get; set; } =
            new List<CompetitionViewModel>();
        public IEnumerable<int> Years { get; set; } = new List<int>();

        //Organizer, Participant
        public IEnumerable<string> Roles { get; set; } = new List<string>();
        public string Role { get; set; }
        public int Year { get; set; }
    }
}
