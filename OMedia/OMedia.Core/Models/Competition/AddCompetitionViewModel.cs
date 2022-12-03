using OMedia.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMedia.Core.Models.Competition
{
    public class AddCompetitionViewModel
    {
        public string Name { get; set; } 
        public string Location { get; set; } 
        public DateTime Date { get; set; }
        public string Details { get; set; } = null!;
        public List<CheckBoxOptions> AgeGroupsCheckBoxes { get; set; }
        public List<CompetitionAgeGroupModel> AgeGroups { get; set; }
        public List<string> AgeGroupString { get; set; }


    }
}
