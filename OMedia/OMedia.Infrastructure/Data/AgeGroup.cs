using OMedia.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMedia.Infrastructure.Data
{
    public class AgeGroup
    {
        [Key]
        public int Id { get; set; }
        [StringLength(6)]
        public string Gender { get; set; }
        public int Age { get; set; }
    }
}
