using Core.Entities;
using Core.Interfaces;
using Core.Specifications;

namespace Infrastructure.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        IGenericRepository<Employee> _employeeRepo;

        public EmployeeService(IUnitOfWork unitOfWork, IGenericRepository<Employee> employeeRepo)
        {
            _unitOfWork = unitOfWork;
            _employeeRepo = employeeRepo;
        }

        public async Task<Employee> CreateOrUpdateEmployeeAsync(Employee entity)
        {
            if (entity.Id == 0)
            {
                _unitOfWork.Repository<Employee>().Add(entity);
            }
            else
            {
                _unitOfWork.Repository<Employee>().Update(entity);
            }
            var result = await _unitOfWork.Complete();
            if (result <= 0) return null;
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {

            var spec = new EmployeeOrderingSpecification(id);
            var employee = await _employeeRepo.GetEntityWithSpec(spec);
            if (employee == null) return false;
            // first ==> remove EmployeeAtt
            if (employee.EmployeeAttendance != null &&
                employee.EmployeeAttendance.Any())
            {
                _unitOfWork.Repository<EmployeeAttendance>().DeleteRange(employee.EmployeeAttendance.ToList());
            }
            _employeeRepo.Delete(employee);

            //_unitOfWork.Repository<Employee>().Delete(employee);
            var result = await _unitOfWork.Complete();
            if (result <= 0) return false;
            return true;
        }

        public async Task<IReadOnlyList<Employee>> GetALL()
        {
            return await _unitOfWork.Repository<Employee>().ListAllAsync();
        }

    }
}
