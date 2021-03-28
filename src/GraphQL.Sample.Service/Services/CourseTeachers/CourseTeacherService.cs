﻿using GraphQL.Sample.Domain.Interfaces;
using GraphQL.Sample.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Sample.Service.Services.CourseTeachers
{
    public class CourseTeacherService : ICourseTeacherService
    {
        private readonly ICourseTeacherRepository _courseTeacherRepository;
        public CourseTeacherService(ICourseTeacherRepository courseTeacherRepository)
        {
            _courseTeacherRepository = courseTeacherRepository;
        }

        public async Task<IEnumerable<CourseTeacher>> GetCourseTeachersByPeriodCourseId(IEnumerable<int> schoolPeriodCourseIds)
        {
            return await _courseTeacherRepository.GetListAsync(x => schoolPeriodCourseIds.Any(y => y == x.SchoolPeriodCourseId)); ;
        }
    }
}