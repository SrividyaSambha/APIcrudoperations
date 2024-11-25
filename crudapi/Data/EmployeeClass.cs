using crudapi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crudapi.Data
{
    public class EmployeeRepository
    {
        private readonly EmployeeContext _context;

        public EmployeeRepository(EmployeeContext context)
        {
            _context = context; 
        }

        public async Task<IEnumerable<EmpTable>> GetAllEmployees()
        {
            return await _context.EmpTables.ToListAsync(); 
        }

        public async Task<EmpTable> GetEmployeeById(int id)
        {
            return await _context.EmpTables.FindAsync(id); 
        }

        public async Task AddEmployee(EmpTable employee)
        {
            _context.EmpTables.Add(employee); 
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEmployee(EmpTable employee)
        {
            _context.Entry(employee).State = EntityState.Modified; 
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEmployee(EmpTable employee)
        {
            _context.EmpTables.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public bool EmployeeExists(int id)
        {
            return _context.EmpTables.Any(e => e.Eid == id);
        }
    }
}

