using GraphQL.Sample.Service.Services.Courses;
using GraphQL.Sample.Service.Services.Departments;
using GraphQL.Sample.Service.Services.Persons;
using GraphQL.Sample.Service.Services.Schools;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.DotNet.Sample.GraphQL.Mutations
{
    partial class RootMutation : ObjectGraphType
    {
        private readonly ISchoolService _schoolService;
        private readonly IDepartmentService _departmentService;
        private readonly IPersonService _personService;
        private readonly ICourseService _courseService;
        public RootMutation(ISchoolService schoolService, IDepartmentService departmentService, IPersonService personService,
            ICourseService courseService)
        {

            Name = "RootMutation";
            _schoolService = schoolService;
            _departmentService = departmentService;
            _personService = personService;
            _courseService = courseService;
            SetSchoolMutations();
        }
    }
}
