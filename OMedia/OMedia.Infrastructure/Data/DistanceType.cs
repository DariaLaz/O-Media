using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMedia.Infrastructure.Data
{
    public class DistanceType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string TypeName { get; set; } = null!;
    }
}
