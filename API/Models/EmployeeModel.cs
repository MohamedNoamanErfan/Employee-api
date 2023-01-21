using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class EmployeeModel : BaseModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "The Email address is not valid")]
        public string Email { get; set; }
        [Required]
        [Phone(ErrorMessage = "The Phone number is not valid")]
        public string PhoneNo { get; set; }
        public List<EmployeeAttendanceModel>? EmployeeAttendanceModels { get; set; }
    }
}
