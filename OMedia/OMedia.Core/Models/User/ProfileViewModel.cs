using Microsoft.AspNetCore.Http;
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
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public List<CompetitionViewModel> CompetitionsOrganized { get; set; }
        public List<CompetitionViewModel> Competitions { get; set; }

        public List<NewsViewModel> News { get; set; }
        public UserAgeGroupViewModel AgeGroup { get; set; }
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public IFormFile ProfilePicture { get; set; }
        public bool IsActive { get; set; }
    }
}
