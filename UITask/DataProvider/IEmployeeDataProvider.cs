using System.Collections.Generic;

namespace UITask.DataProvider
{
    public interface IEmployeeDataProvider
    {
        IEnumerable<Employee> LoadEmployees();
        void SaveEmployee(Employee who);
    }
}
