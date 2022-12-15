using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMedia.Infrastructure.Data
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public int AuthorId { get; set; }
        [ForeignKey(nameof(AuthorId))]
        public Competitor Author { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public bool IsActive { get; set; }
        public bool IsChanged { get; set; }
       // public int NewsId { get; set; }
       // public News News { get; set; } = null!;
    }
}
