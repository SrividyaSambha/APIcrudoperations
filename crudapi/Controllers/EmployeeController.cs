using crudapi.Models;
using crudapi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace crudapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _service;

        public EmployeeController(EmployeeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _service.GetAllEmployees();

            if (employees == null )
            {
                return NotFound("No employees found in the system.");
            }

            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var employee = await _service.GetEmployeeById(id);

            if (employee == null)
            {
                return NotFound($"Employee with ID {id} was not found.");
            }

            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> PostEmployee(EmpTable employee)
        {
            if (employee == null)
            {
                return BadRequest("Invalid employee data. Please provide valid details.");
            }

            try
            {
                await _service.AddEmployee(employee);
                return CreatedAtAction(nameof(GetEmployee), new { id = employee.Eid }, employee);
            }
            catch
            {
                return StatusCode(500, "An error occurred while adding the employee.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, EmpTable employee)
        {
            if (id != employee.Eid)
            {
                return BadRequest("The employee ID in the request does not match the provided data.");
            }

            if (!_service.EmployeeExists(id))
            {
                return NotFound($"Employee with ID {id} was not found.");
            }

            try
            {
                await _service.UpdateEmployee(employee);
                return Ok("Employee updated successfully.");
            }
            catch
            {
                return StatusCode(500, "An error occurred while updating the employee.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            if (!_service.EmployeeExists(id))
            {
                return NotFound($"Employee with ID {id} was not found.");
            }

            try
            {
                await _service.DeleteEmployee(id);
                return Ok("Employee deleted successfully.");
            }
            catch
            {
                return StatusCode(500, "An error occurred while deleting the employee.");
            }
        }
    }
}
