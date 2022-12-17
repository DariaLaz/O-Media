using OMedia.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OMedia.Core.Constants.AgeGroups;

namespace OMedia.Core.Models.AgeGroup
{
    public class AgeGroupViewModel
    {
        public int Id { get; set; }

        public Gender Gender { get; set; }
        [Range(0, 100, ErrorMessage = AgeRangeError)]
        public int Age { get; set; }
    }
}
