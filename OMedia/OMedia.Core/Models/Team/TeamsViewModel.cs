using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMedia.Core.Models.Team
{
    public class TeamsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountOfMembers { get; set; }
        public int CountOfCompetitions { get; set; }
    }
}
