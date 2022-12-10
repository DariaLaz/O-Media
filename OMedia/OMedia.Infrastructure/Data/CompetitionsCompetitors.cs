using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMedia.Infrastructure.Data
{
    public class CompetitionsCompetitors
    {
        
        public int CompetitionId { get; set; }
        public int CompetitorId { get; set; }
        public string Role { get; set; } = "Participant";
        [ForeignKey(nameof(CompetitionId))]
        public Competition Competition { get; set; } = null!;
        [ForeignKey(nameof(CompetitorId))]
        public Competitor Competitor { get; set; } = null!;
        public bool IsActive { get; set; } = true;
    }
}