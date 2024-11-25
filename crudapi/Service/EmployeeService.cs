using crudapi.Models;
using crudapi.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace crudapi.Services
{
    public class EmployeeService
    {
        private readonly EmployeeRepository _repository;

        public EmployeeService(EmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<EmpTable>> GetAllEmployees()
        {
            return await _repository.GetAllEmployees();
        }

        public async Task<EmpTable> GetEmployeeById(int id)
        {
            return await _repository.GetEmployeeById(id);
        }

        public async Task AddEmployee(EmpTable employee)
        {
            await _repository.AddEmployee(employee);
        }

        public async Task UpdateEmployee(EmpTable employee)
        {
            await _repository.UpdateEmployee(employee);
        }

        public async Task DeleteEmployee(int id)
        {
            var employee = await _repository.GetEmployeeById(id);
            if (employee != null)
            {
                await _repository.DeleteEmployee(employee);
            }
        }

        public bool EmployeeExists(int id)
        {
            return _repository.EmployeeExists(id);
        }
    }
}

