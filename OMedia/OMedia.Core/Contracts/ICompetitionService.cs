﻿using OMedia.Core.Models.Competition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMedia.Core.Contracts
{
    public interface ICompetitionService
    {
        Task<IEnumerable<CompetitionViewModel>> GetAllPreviousCompetitionsSortedByDate();
        Task<IEnumerable<CompetitionViewModel>> GetAllComingCompetitionsSortedByDate();
        Task<IEnumerable<CompetitionAgeGroupModel>> GetAllAgeGroups();
        Task<int> Create(AddCompetitionViewModel model, int userId);
    }
}