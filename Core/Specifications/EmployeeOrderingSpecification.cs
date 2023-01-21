using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class EmployeeOrderingSpecification : BaseSpecifcation<Employee>
    {
        public EmployeeOrderingSpecification(EmployeeSpecParams employeeParams) : base(x =>
           string.IsNullOrEmpty(employeeParams.Search) || x.Name.ToLower().Contains(employeeParams.Search))
        {
            
            AddInclude(x => x.EmployeeAttendance);
            AddOrderBy(x => x.Name);
            ApplyPaging(employeeParams.PageSize * (employeeParams.PageIndex - 1), employeeParams.PageSize);

            if (!string.IsNullOrEmpty(employeeParams.Sort))
            {
                switch (employeeParams.Sort)
                {
                    case "asc":
                        AddOrderBy(p => p.Name);
                        break;
                    case "desc":
                        AddOrderByDescending(p => p.Name);
                        break;
                    default:
                        AddOrderBy(n => n.Name);
                        break;
                }
            }
        }

        public EmployeeOrderingSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.EmployeeAttendance);
        }
    }
}
