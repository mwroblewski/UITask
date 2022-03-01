using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UITask.DataProvider
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
