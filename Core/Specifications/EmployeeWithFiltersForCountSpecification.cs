using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class EmployeeWithFiltersForCountSpecification : BaseSpecifcation<Employee>
    {
        public EmployeeWithFiltersForCountSpecification(EmployeeSpecParams employeeParams) : base(x =>
            (string.IsNullOrEmpty(employeeParams.Search)
        || x.Name.ToLower().Contains(employeeParams.Search)))
        {

        }

    }
}
