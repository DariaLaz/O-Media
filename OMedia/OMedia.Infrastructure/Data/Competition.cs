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
    public class Competition
    {
        public Competition()
        {
            this.AgeGroups = new List<AgeGroupsCompetitions>();
            this.Competitors = new List<CompetitionsCompetitors>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;
        [Required]
        [StringLength(100)]
        public string Location { get; set; } = null!;
        [Required]
        public DateTime Date { get; set; }
        [Required]
        [StringLength(500)]
        public string Details { get; set; } = null!;
        public List<AgeGroupsCompetitions> AgeGroups { get; set; }
        public List<CompetitionsCompetitors> Competitors { get; set; }
        public bool IsChanged { get; set; } = false;
        public bool IsActive { get; set; }

    }
}
