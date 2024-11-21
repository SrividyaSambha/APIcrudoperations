using crudapi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace crudapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeContext _context;

        public EmployeeController(EmployeeContext context)
        {
            _context = context;        }
        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpTable>>> GetEmployees()
        {
            return await _context.EmpTables.ToListAsync();
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmpTable>> GetEmployee(int id)
        {
            var employee = await _context.EmpTables.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }
        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<ActionResult<EmpTable>> PostEmployee(EmpTable employee)
        {
            _context.EmpTables.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmployee), new { id = employee.Eid }, employee);
        }


        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, EmpTable employee)
        {
            if (id != employee.Eid)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;


            return NoContent();
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.EmpTables.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.EmpTables.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeExists(int id)
        {
            return _context.EmpTables.Any(e => e.Eid == id);
        }
    }
}

