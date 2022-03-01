using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace UITask.Common
{
    public class EmployeeDataProvider : IEmployeeDataProvider
    {
        private List<Employee> _employees = new();
        private static readonly string fileName = "employees.json";
        private readonly string path;
        public EmployeeDataProvider()
        {
            path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), fileName);
            if (File.Exists(path) == false)
            {
                File.Create(path).Close();
            }
        }
        public IEnumerable<Employee> LoadEmployees()
        {
            try
            {
                var fileContent = File.ReadAllText(path);
                if (string.IsNullOrEmpty(fileContent) == false)
                {
                    var deserializedEmployees = JsonSerializer.Deserialize(fileContent, typeof(List<Employee>));
                    _employees = deserializedEmployees as List<Employee>; //could append employees to the list instead of reassigning field (and then _employees could be marked as readonly)
                }
                else
                {
                    _employees = new List<Employee>();
                }
                return _employees;
            }
            catch
            {
                //could use some log here
                return new List<Employee>(); // or rethrow
            }
        }

        public void SaveEmployee(Employee who)
        {
            _employees.Add(who);
            var serializedEmployees = JsonSerializer.SerializeToUtf8Bytes(_employees);
            try
            {
                File.WriteAllBytes(path, serializedEmployees); //could append text instead of overwriting the whole file
            }
            catch
            {
                //could use some log here
                //and could rethrow
            }
        }
    }
}
