using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using System.Diagnostics;

namespace Infrastructure.Services
{
    public class EmployeeAttendancesService : IEmployeeAttendancesService
    {
        private readonly IUnitOfWork _unitOfWork;
        IGenericRepository<EmployeeAttendance> _employeeAttendanceRepo;

        public EmployeeAttendancesService(IUnitOfWork unitOfWork, IGenericRepository<EmployeeAttendance> employeeAttendanceRepo)
        {
            _unitOfWork = unitOfWork;
            _employeeAttendanceRepo = employeeAttendanceRepo;
        }
        public async Task<EmployeeAttendance> CreateOrUpdateEmployeeAttendanceAsync(EmployeeAttendance entity)
        {
            entity.Employee = null;
            if (entity.Id == 0)
            {
                _unitOfWork.Repository<EmployeeAttendance>().Add(entity);
            }
            else
            {
                _unitOfWork.Repository<EmployeeAttendance>().Update(entity);
            }
            var result = await _unitOfWork.Complete();
            if (result <= 0) return null;
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _unitOfWork.Repository<EmployeeAttendance>().GetByIdAsync(id);
            if (entity != null)
                _unitOfWork.Repository<EmployeeAttendance>().Delete(entity);
            else return false;
            var result = await _unitOfWork.Complete();
            if (result <= 0) return false;
            return true;
        }

        public async Task<IReadOnlyList<EmployeeAttendance>> GetEmployeeAttendancesDetails(int employeeId)
        {
            var spec = new EmployeeAttendanceOrderingSpecification(employeeId);

            var result = await _unitOfWork.Repository<EmployeeAttendance>().ListAsync(spec);
            if (result != null && result.Count > 0)
                return result;
            return null;
        }
    }
}
