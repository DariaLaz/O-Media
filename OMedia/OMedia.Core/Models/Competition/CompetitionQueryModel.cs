using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMedia.Core.Models.Competition

{
    public class CompetitionQueryModel
    {
        public int TotalCompetitionsCount { get; set; }

        public List<CompetitionViewModel> Competitions { get; set; }
            = new List<CompetitionViewModel>();
    }
}
