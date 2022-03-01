using System.Collections.Generic;
using UITask.Common;

namespace UITask.Common
{
    public interface IEmployeeDataProvider
    {
        IEnumerable<Employee> LoadEmployees();
        void SaveEmployee(Employee who);
    }
}
