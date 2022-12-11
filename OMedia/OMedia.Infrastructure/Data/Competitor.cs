using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMedia.Infrastructure.Data
{
    public class Competitor
    {
        public Competitor()
        {
            this.Competitions = new List<CompetitionsCompetitors>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public int TeamId { get; set; }

        [ForeignKey(nameof(TeamId))]
        public Team Team { get; set; } = null!;
        public List<CompetitionsCompetitors> Competitions { get; set; }

        [Required]
        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;
        public int AgeGroupId { get; set; }
        [ForeignKey(nameof(AgeGroupId))]
        public AgeGroup AgeGroup { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
