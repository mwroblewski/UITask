using System.Collections.Generic;

namespace UITask.Common
{
    internal class EmployeeDataProvider : IEmployeeDataProvider
    {
        readonly List<Employee> _employees = new();

        public EmployeeDataProvider()
        {

        }
        public IEnumerable<Employee> LoadEmployees()
        {
            return null;
        }

        public void SaveEmployee(Employee who)
        {
            _employees.Add(who);
        }
    }
}
