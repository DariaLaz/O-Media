﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMedia.Core.Contracts
{
    public interface IUserService
    {
        Task<bool> ExistsById(string userId);
        Task<int> GetUserId(string userId);
    }
}
