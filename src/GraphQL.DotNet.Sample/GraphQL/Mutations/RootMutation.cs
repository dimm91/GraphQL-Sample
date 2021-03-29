using GraphQL.Sample.Service.Services.Courses;
using GraphQL.Sample.Service.Services.CourseStudents;
using GraphQL.Sample.Service.Services.CourseTeachers;
using GraphQL.Sample.Service.Services.Departments;
using GraphQL.Sample.Service.Services.Persons;
using GraphQL.Sample.Service.Services.SchoolPeriodCourses;
using GraphQL.Sample.Service.Services.SchoolPeriods;
using GraphQL.Sample.Service.Services.Schools;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.DotNet.Sample.GraphQL.Mutations
{
    internal partial class RootMutation : ObjectGraphType
    {
        private readonly ISchoolService _schoolService;
        private readonly IDepartmentService _departmentService;
        private readonly IPersonService _personService;
        private readonly ICourseService _courseService;
        private readonly ISchoolPeriodCourseService _schoolPeriodCourseService;
        private readonly ICourseStudentService _courseStudentService;
        private readonly ICourseTeacherService _courseTeacherService;
        private readonly ISchoolPeriodService _schoolPeriodService;
        public RootMutation(ISchoolService schoolService, IDepartmentService departmentService, IPersonService personService,
            ICourseService courseService, ISchoolPeriodCourseService schoolPeriodCourseService, ICourseStudentService courseStudentService,
            ICourseTeacherService courseTeacherService, ISchoolPeriodService schoolPeriodService)
        {
            Name = "RootMutation";
            _schoolService = schoolService;
            _departmentService = departmentService;
            _personService = personService;
            _courseService = courseService;
            _schoolPeriodCourseService = schoolPeriodCourseService;
            _courseStudentService = courseStudentService;
            _courseTeacherService = courseTeacherService;
            _schoolPeriodService = schoolPeriodService;

            SetSchoolMutations();
            SetDepartmentMutations();
            SetCourseMutations();
            SetPersonMutations();
        }
    }
}
