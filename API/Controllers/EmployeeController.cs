using API.Errors;
using API.Helpers;
using API.Models;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    public class EmployeeController : BaseController
    {
        private readonly IEmployeeService _employeeSrvice;
        private readonly IGenericRepository<Employee> _employeeRepo;

        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService employeeSrvice, IMapper mapper, IGenericRepository<Employee> employeeRepo)
        {
            _mapper = mapper;
            _employeeSrvice = employeeSrvice;
            _employeeRepo = employeeRepo;

        }
        [HttpPost]
        public async Task<ActionResult<EmployeeModel>> Post(EmployeeModel model)
        {
            var entity = _mapper.Map<EmployeeModel, Employee>(model);
            var result = await _employeeSrvice.CreateOrUpdateEmployeeAsync(entity);
            if (result == null) return BadRequest(new ApiResponse(400, "Problem creating Employee"));
            return Ok(_mapper.Map<Employee, EmployeeModel>(result));
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<EmployeeModel>>> Get([FromQuery] EmployeeSpecParams EmployeeParams)
        {
            var spec = new EmployeeOrderingSpecification(EmployeeParams);
            var countSpec = new EmployeeWithFiltersForCountSpecification(EmployeeParams);

            var employees = await _employeeRepo.ListAsync(spec);
            var totalItems = await _employeeRepo.CountAsync(countSpec);
            var data = _mapper.Map<IReadOnlyList<Employee>, IReadOnlyList<EmployeeModel>>(employees);
            return Ok(new Pagination<EmployeeModel>(EmployeeParams.PageIndex,
                EmployeeParams.PageSize, totalItems, data));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeModel>> GetEmployee(int id)
        {
            var spec = new EmployeeOrderingSpecification(id);
            var employee = await _employeeRepo.GetEntityWithSpec(spec);

            return Ok(_mapper.Map<Employee,EmployeeModel>(employee));
        }

        [HttpGet("getlookup")]
        public async Task<ActionResult<LookupsModel>> GetEmployeeLookup()
        {
            var result = await _employeeSrvice.GetALL();
            if (result != null && result.Count > 0)
            {
                return Ok(result.Select(a => new LookupsModel
                {
                    ID = a.Id,
                    Name = a.Name
                }));
            }
            return Ok();
        }


        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteAsync(int id)
        {
            var deleted = await _employeeSrvice.DeleteAsync(id);
            if (deleted)
                return Ok();
            return BadRequest(new ApiResponse(404));
            
        }
    }
}
