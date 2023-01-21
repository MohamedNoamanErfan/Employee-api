using Core.Entities;

namespace Core.Specifications
{
    public class EmployeeemployeeAttendanceCountSpecification : BaseSpecifcation<EmployeeAttendance>
    {
        public EmployeeemployeeAttendanceCountSpecification(EmployeeAttendanceSpecParams employeeParams) : base(x =>
           string.IsNullOrEmpty(employeeParams.Search)
       || x.EmployeeId == Convert.ToInt16(employeeParams.Search))
        {

        }
    }
}
