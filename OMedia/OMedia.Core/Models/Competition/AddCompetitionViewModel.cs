using OMedia.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OMedia.Core.Constants.Competitions;


namespace OMedia.Core.Models.Competition
{
    public class AddCompetitionViewModel
    {
        [Required]
        [MaxLength(50, ErrorMessage =NameLenRangeError)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = LocationLenRangeError)]
        public string Location { get; set; } 
        public string Date { get; set; }
        [Required]
        [MaxLength(500, ErrorMessage = DetailsLenRangeError)]
        public string Details { get; set; } = null!;
        public List<CheckBoxOptions> AgeGroupsCheckBoxes { get; set; }
        public List<CompetitionAgeGroupModel> AgeGroups { get; set; }
        public List<string> AgeGroupString { get; set; }


    }
}
