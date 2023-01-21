using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class EmployeeAttendanceOrderingSpecification : BaseSpecifcation<EmployeeAttendance>
    {
        public EmployeeAttendanceOrderingSpecification(EmployeeAttendanceSpecParams employeeParams) : base(x =>
          string.IsNullOrEmpty(employeeParams.Search)
        || x.EmployeeId == Convert.ToInt32(employeeParams.Search))
        {
            AddInclude(x => x.Employee);
            AddOrderBy(x => x.CreatedON);
            ApplyPaging(employeeParams.PageSize * (employeeParams.PageIndex - 1), employeeParams.PageSize);
        }

        public EmployeeAttendanceOrderingSpecification(int id) : base(x => id == 0 || x.EmployeeId == id)
        {
            AddInclude(x => x.Employee);
        }
    }
}
