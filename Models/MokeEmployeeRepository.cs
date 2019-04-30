using System.Collections.Generic;
using System.Linq;

namespace core_tutorial.Models
{
    public class MokeEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;
        public MokeEmployeeRepository()
        {
            _employeeList = new List<Employee>(){
                new Employee(){Id=1, Name="Jone Doe", Email="Jone@gmail.com", Department=Dept.Payroll},
                new Employee(){Id=2, Name="Mary", Email="mary@gmail.com", Department=Dept.IT},
                new Employee(){Id=3, Name="Sara", Email="satra@gmail.com", Department=Dept.HR}
            };
        }

        public Employee Add(Employee employee)
        {
            employee.Id = _employeeList.Max(e => e.Id) + 1;
            _employeeList.Add(employee);

            return employee;
        }

        public Employee Delete(int Id)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.Id == Id);
            if(employee != null){
                _employeeList.Remove(employee);
            }
            return employee;
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int Id)
        {
            return _employeeList.FirstOrDefault(e => e.Id == Id);
        }

        public Employee Update(Employee employeeChanges)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.Id == employeeChanges.Id);
            if(employee != null){
                employee.Name = employeeChanges.Name;
                employee.Email = employeeChanges.Email;
                employee.Department = employeeChanges.Department;
            }
            return employee;
        }
    }
}