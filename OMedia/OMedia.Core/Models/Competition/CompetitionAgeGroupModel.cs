using OMedia.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMedia.Core.Models.Competition
{
    public class CompetitionAgeGroupModel
    {
        public int Id { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
    }
}
