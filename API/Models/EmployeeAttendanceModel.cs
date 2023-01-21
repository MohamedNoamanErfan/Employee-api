using Core.Entities;

namespace API.Models
{
    public class EmployeeAttendanceModel : BaseModel
    {
        public DateTime SRVDT { get; set; }
        public double DEVDT { get; set; }
        public double DEVUID { get; set; }
        public int EmployeeId { get; set; }
        public string? EmpolyeeName { get; set; }
    }
}
