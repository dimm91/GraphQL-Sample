using GraphQL.Sample.Domain.Interfaces;
using GraphQL.Sample.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Sample.Service.Services.Departments
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<IEnumerable<Department>> GetDepartmentsByIds(IEnumerable<int> departmentIds)
        {
            return await _departmentRepository.GetListAsync(x => departmentIds.Any(y => y == x.DepartmentId));
        }

        public async Task<IEnumerable<Department>> GetDepartmentsBySchoolId(IEnumerable<int> schoolIds)
        {
            return await _departmentRepository.GetListAsync(x => schoolIds.Any(y => y == x.SchoolId));
        }

        public async Task<Department> InsertDepartment(string name, int schoolId, int administratorId)
        {
            var department = new Department(name, administratorId, schoolId);
            await _departmentRepository.CreateAsync(department);
            return department;

        }
    }
}
