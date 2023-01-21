using API.Errors;
using API.Helpers;
using API.Models;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class EmployeeAttendancesController : BaseController
    {
        private readonly IEmployeeAttendancesService _employeeAttendancesSrvice;
        private readonly IGenericRepository<EmployeeAttendance> _employeeAttendanceRepo;

        private readonly IMapper _mapper;

        public EmployeeAttendancesController(IEmployeeAttendancesService employeeAttendancesSrvice, IMapper mapper,
            IGenericRepository<EmployeeAttendance> employeeAttendanceRepo)
        {
            _mapper = mapper;
            _employeeAttendancesSrvice = employeeAttendancesSrvice;
            _employeeAttendanceRepo = employeeAttendanceRepo;

        }
        [HttpPost]
        public async Task<ActionResult<EmployeeAttendanceModel>> Post(EmployeeAttendanceModel model)
        {
            var entity = _mapper.Map<EmployeeAttendanceModel, EmployeeAttendance>(model);
            var result = await _employeeAttendancesSrvice.CreateOrUpdateEmployeeAttendanceAsync(entity);
            if (result == null) return BadRequest(new ApiResponse(400, "Problem creating Employee"));
            return Ok(_mapper.Map<EmployeeAttendance, EmployeeAttendanceModel>(result));
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<EmployeeAttendanceModel>>> Get([FromQuery] EmployeeAttendanceSpecParams employeeAttendanceParams)
        {
            var spec = new EmployeeAttendanceOrderingSpecification(employeeAttendanceParams);

            var countSpec = new EmployeeemployeeAttendanceCountSpecification(employeeAttendanceParams);
            var employeeAttendance = await _employeeAttendanceRepo.ListAsync(spec);

            var totalItems = await _employeeAttendanceRepo.CountAsync(countSpec);

            var data = _mapper.Map<IReadOnlyList<EmployeeAttendance>, IReadOnlyList<EmployeeAttendanceModel>>(employeeAttendance);

            return Ok(new Pagination<EmployeeAttendanceModel>(employeeAttendanceParams.PageIndex,
                employeeAttendanceParams.PageSize, totalItems, data));

            // return Ok(_mapper.Map<IReadOnlyList<EmployeeAttendance>, IReadOnlyList<EmployeeAttendanceModel>>(employeeAttendance));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetEmployeeAttendancesDetails(int id)
        {

            var employeeAttendance = await _employeeAttendancesSrvice.GetEmployeeAttendancesDetails(id);
            var inTime = employeeAttendance
                .GroupBy(e => e.SRVDT.Date.ToString("d")).ToList();
           var result =  inTime.Select(a => new
            {
                day = a.Key,
                time = a.Select(e => new
                {
                    ID = e.Id,
                    e.DEVDT,
                    e.SRVDT,
                    e.DEVUID
                }).ToList()
            }).ToList();
            return Ok(result);
        }


        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteAsync(int id)
        {
            var deleted = await _employeeAttendancesSrvice.DeleteAsync(id);
            if (deleted)
                return Ok();
            return BadRequest(new ApiResponse(404));

        }
    }
}
