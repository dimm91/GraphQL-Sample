using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GraphQL.Server;
using GraphQL.Types;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using GraphQL.Sample.Infrastructure.Data.Ef.Repositories;
using GraphQL.Sample.Domain.Interfaces;
using GraphQL.Sample.Service.Services.Schools;
using GraphQL.Sample.Infrastructure.Data.Ef;
using Microsoft.EntityFrameworkCore;
using GraphQL.Sample.Service.Services.Departments;
using GraphQL.DotNet.Sample.GraphQL.Queries;
using GraphQL.DotNet.Sample.GraphQL.Schemas;
using GraphQL.Sample.Service.Services.SchoolPeriods;
using GraphQL.Sample.Service.Services.SchoolPeriodCourses;
using GraphQL.Sample.Service.Services.Courses;
using Microsoft.Extensions.Logging;
using GraphQL.Sample.Service.Services.Persons;
using GraphQL.Sample.Service.Services.CourseStudents;
using GraphQL.Sample.Service.Services.CourseTeachers;

namespace GraphQL.DotNet.Sample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region GraphQL
            services.AddScoped<RootQuery>();
            services.AddScoped<ISchema, RootSchema>();

            services.AddGraphQL(options => options.EnableMetrics = false)
                .AddErrorInfoProvider(options => options.ExposeExceptionStackTrace = true)
                .AddNewtonsoftJson()
                .AddDataLoader()
                .AddGraphTypes(typeof(RootSchema), ServiceLifetime.Scoped);
            #endregion

            #region Services
            services.AddScoped<ISchoolRepository, SchoolRepository>();
            services.AddScoped<ISchoolService, SchoolService>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<ISchoolPeriodRepository, SchoolPeriodRepository>();
            services.AddScoped<ISchoolPeriodService, SchoolPeriodService>();
            services.AddScoped<ISchoolPeriodCourseRepository, SchoolPeriodCourseRepository>();
            services.AddScoped<ISchoolPeriodCourseService, SchoolPeriodCourseService>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<ICourseStudentsRepository, CourseStudentsRepository>();
            services.AddScoped<ICourseStudentService, CourseStudentService>();
            services.AddScoped<ICourseTeacherRepository, CourseTeacherRepository>();
            services.AddScoped<ICourseTeacherService, CourseTeacherService>();
            #endregion

            services.AddControllers();
            services.AddHttpContextAccessor();

            // Since with GraphQL we can have multiple asynchronous call to the DB with the "AddDbContext" this is not possible.
            // Threfore instead of creating a new instance every time, the code will first check if there is an instance available in the pool.
            services.AddPooledDbContextFactory<SchoolDbContext>(options =>
            {
                options.EnableSensitiveDataLogging(true);
                options.UseSqlServer("Server=.,1433;Database=NewDb;User Id=sa;Password=[InsertYourPasswordHere]");
                options.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
            });

            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseGraphQL<ISchema>();

            app.UseGraphQLPlayground();

            // use Voyager middleware at default path /ui/voyager with default options
            app.UseGraphQLVoyager();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
