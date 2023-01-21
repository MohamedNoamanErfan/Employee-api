using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IEmployeeService
    {
        Task<Employee> CreateOrUpdateEmployeeAsync(Employee entity);
        Task<bool> DeleteAsync(int id);

        Task<IReadOnlyList<Employee>> GetALL();
    }
}
