﻿using Microsoft.EntityFrameworkCore;
using OMedia.Core.Contracts;
using OMedia.Core.Models.AgeGroup;
using OMedia.Infrastructure.Data;
using OMedia.Infrastructure.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMedia.Core.Services
{
    public class AgeGroupService : IAgeGroupService
    {
        private readonly IRepository repo;
        public AgeGroupService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<IEnumerable<AgeGroupViewModel>> All()
        {
            return await repo.AllReadonly<AgeGroup>()
                   .Select(g => new AgeGroupViewModel()
                   {
                       Id = g.Id,
                       Gender = g.Gender,
                       Age = g.Age
                   }).ToListAsync();
        }

        public async Task<int> Create(AgeGroupViewModel model)
        {
            var ageGroup = new AgeGroup()
            {
                Gender = model.Gender,
                Age = model.Age
            };
            await repo.AddAsync(ageGroup);
            await repo.SaveChangesAsync();

            return ageGroup.Id;
        }

        public async Task<bool> Exists(AgeGroupViewModel model)
        {
            return await repo.AllReadonly<AgeGroup>()
                .AnyAsync(g => g.Gender == model.Gender && g.Age == model.Age);
        }
    }
}
