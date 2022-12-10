using OMedia.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMedia.Core.Models.Competition
{
    public class CompetitionViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Date { get; set; }
        public IEnumerable<CompetitionAgeGroupModel> AgeGroups { get; set; }
        public bool IsCurrUserTakingPart { get; set; }
    }
}
