using GraphQL.DataLoader;
using GraphQL.Sample.Domain.Models;
using GraphQL.Sample.Service.Services.Persons;
using GraphQL.Sample.Service.Services.SchoolPeriodCourses;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.DotNet.Sample.GraphQL.Types
{
    public class CourseStudentGraphType : ObjectGraphType<CourseStudent>
    {
        public CourseStudentGraphType(IDataLoaderContextAccessor accessor, IPersonService personService)
        {
            Name = "CourseStudent";

            Field(x => x.StudentId);
            Field(x => x.SchoolPeriodCourseId);
            Field<PersonGraphType>()
                .Name("Student")
                .Resolve(c => CourseStudentResolvers.GetStudentById(accessor, c, personService));
        }
        private static class CourseStudentResolvers
        {
            public static IDataLoaderResult<Person> GetStudentById(IDataLoaderContextAccessor accessor, IResolveFieldContext<CourseStudent> context, IPersonService personService)
            {
                var loader = accessor.Context.GetOrAddBatchLoader<int, Person>("GetStudentById", async x =>
                {
                    var administrators = await personService.GetPersons(x);
                    return administrators.ToDictionary(d => d.PersonId, g => g);
                });

                return loader.LoadAsync(context.Source.StudentId);
            }
        }
    }
}
