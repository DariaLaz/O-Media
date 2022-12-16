using OMedia.Core.Models.AgeGroup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMedia.Core.Contracts
{
    public interface IAgeGroupService
    {
        Task<IEnumerable<AgeGroupViewModel>> All();
        Task<int> Create(AgeGroupViewModel model);
        Task<bool> Exists(AgeGroupViewModel model);
        Task<int> GetAgeGroupId(int id);

    }
}
