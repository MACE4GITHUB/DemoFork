﻿using BulbaCourses.DiscountAggregator.Logic.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Logic.Services
{
    public interface IDomainServices
    {
        Task<IEnumerable<Domain>> GetAllAsync();
        Task<Domain> GetByIdAsync(string id);
        Task<Result<Domain>> AddAsync(Domain domain);
        Task<Result> DeleteByIdAsync(string id);
        Task<Result<Domain>> UpdateAsync(Domain domain);
    }
}