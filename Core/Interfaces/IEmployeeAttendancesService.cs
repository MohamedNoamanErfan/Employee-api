using Core.Entities;

namespace Core.Interfaces
{
    public interface IEmployeeAttendancesService
    {
        Task<EmployeeAttendance> CreateOrUpdateEmployeeAttendanceAsync(EmployeeAttendance entity);
        Task<bool> DeleteAsync(int id);
        Task<IReadOnlyList<EmployeeAttendance>> GetEmployeeAttendancesDetails(int employeeId);
    }
}
