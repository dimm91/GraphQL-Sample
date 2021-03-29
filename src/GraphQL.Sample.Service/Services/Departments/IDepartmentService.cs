using GraphQL.Sample.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Sample.Service.Services.Departments
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetDepartmentsBySchoolId(IEnumerable<int> schoolIds);
        Task<IEnumerable<Department>> GetDepartmentsByIds(IEnumerable<int> departmentIds);
        Task<Department> InsertDepartment(string name, int schoolId, int administratorId);
    }
}
