using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMedia.Infrastructure.Data
{
    public class News
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; } = null!;
        [Required]
        [StringLength(800)]
        public string Content { get; set; } = null!;
        [Required]
        [StringLength(50)]
        public int WriterId { get; set; }
        [ForeignKey(nameof(WriterId))]
        public Competitor Writer { get; set; } = null!;
        public DateTime Date { get; set; }
    }
}
