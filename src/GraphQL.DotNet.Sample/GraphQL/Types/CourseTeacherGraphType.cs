using GraphQL.DataLoader;
using GraphQL.Sample.Domain.Models;
using GraphQL.Sample.Service.Services.Persons;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.DotNet.Sample.GraphQL.Types
{
    public class CourseTeacherGraphType : ObjectGraphType<CourseTeacher>
    {
        public CourseTeacherGraphType(IDataLoaderContextAccessor accessor, IPersonService personService)
        {

            Name = "CourseTeacher";

            Field(x => x.TeacherId);
            Field(x => x.SchoolPeriodCourseId);
            Field<PersonGraphType>()
                .Name("Teacher")
                .Resolve(c => CourseTeacherResolvers.GetTeacherById(accessor, c, personService));
        }

        private static class CourseTeacherResolvers
        {
            public static IDataLoaderResult<Person> GetTeacherById(IDataLoaderContextAccessor accessor, IResolveFieldContext<CourseTeacher> context, IPersonService personService)
            {
                var loader = accessor.Context.GetOrAddBatchLoader<int, Person>("GetTeacherById", async x =>
                {
                    var administrators = await personService.GetPersons(x);
                    return administrators.ToDictionary(d => d.PersonId, g => g);
                });

                return loader.LoadAsync(context.Source.TeacherId);
            }
        }
    }
}
