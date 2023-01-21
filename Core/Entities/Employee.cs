using Microsoft.AspNetCore.Identity;

namespace Core.Entities
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public IList<EmployeeAttendance> EmployeeAttendance { get; set; }
    }
}
