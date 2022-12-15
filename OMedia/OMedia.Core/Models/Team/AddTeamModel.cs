using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMedia.Core.Models.Team
{
    public class AddTeamModel
    {
        public string Name { get; set; } = null!;
        public string? Details { get; set; }
    }
}
