using System.Collections.Generic;

namespace UITask.Common
{
    //This could be split into two independent interfaces but seems to be an overkill for this task
    public interface IEmployeeDataProvider
    {
        IEnumerable<Employee> LoadEmployees();
        void SaveEmployee(Employee who);
    }
}
