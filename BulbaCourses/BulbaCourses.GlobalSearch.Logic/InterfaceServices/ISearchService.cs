﻿using BulbaCourses.GlobalSearch.Logic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Logic.InterfaceServices
{
    interface ISearchService
    {
        IEnumerable<LearningCourseDTO> Search();
        Task<IEnumerable<LearningCourseDTO>> SearchAsync();
    }
}
