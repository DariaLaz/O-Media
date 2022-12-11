using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMedia.Infrastructure.Data
{
    public class AgeGroupsCompetitions
    {
        public int AgeGroupId { get; set; }
        public int CompetitionId { get; set; }
        [ForeignKey(nameof(AgeGroupId))]
        public AgeGroup AgeGroup { get; set; }

        [ForeignKey(nameof(CompetitionId))]
        public Competition Competition { get; set; }
    }
}
