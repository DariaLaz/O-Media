using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMedia.Infrastructure.Data
{
    public class Team
    {
        public Team()
        {
            this.Competitors = new List<Competitor>();
        }
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Details { get; set; }
        public List<Competitor> Competitors { get; set; }
    }
}
