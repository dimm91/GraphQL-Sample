using GraphQL.Sample.Domain.Models;
using GraphQL.Sample.Service.Services.Courses;
using GraphQL.Sample.Service.Services.Departments;
using GraphQL.Sample.Service.Services.Persons;
using GraphQL.Sample.Service.Services.Schools;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.DotNet.Sample.GraphQL.Queries
{
    /// <summary>
    /// Partial class, since from the root we can have extend it to multiple queries (if desired)
    /// </summary>
    internal partial class RootQuery : ObjectGraphType
    {
        private readonly ISchoolService _schoolService;
        private readonly IDepartmentService _departmentService;
        private readonly IPersonService _personService;
        private readonly ICourseService _courseService;

        public RootQuery(ISchoolService schoolService, IDepartmentService departmentService, IPersonService personService,
            ICourseService courseService)
        {
            Name = "RootQuery";
            _schoolService = schoolService;
            _departmentService = departmentService;
            _personService = personService;
            _courseService = courseService;

            //Set querys on the root
            SetSchoolQuery();
            SetDepartmentQuery();
            SetPersonQuery();
            SetCourseQuery();
        }
    }
}
