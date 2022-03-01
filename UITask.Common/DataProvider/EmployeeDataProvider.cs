using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace UITask.Common
{
    public class EmployeeDataProvider : IEmployeeDataProvider
    {
        private readonly List<Employee> _employees = new();
        private static readonly string fileName = "employees.json";
        private readonly string path;
        public EmployeeDataProvider()
        {
            path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), fileName);
            if (File.Exists(path) == false)
            {
                File.Create(path).Close();
            }
            var fileContent = File.ReadAllText(path);
            if (string.IsNullOrEmpty(fileContent) == false)
            {
                var deserializedEmployees = JsonSerializer.Deserialize(File.ReadAllText(path), typeof(List<Employee>));
                _employees = deserializedEmployees as List<Employee>;
            }
        }
        public IEnumerable<Employee> LoadEmployees()
        {
            return _employees;
        }

        public void SaveEmployee(Employee who)
        {
            _employees.Add(who);
            var serializedEmployees = JsonSerializer.SerializeToUtf8Bytes(_employees);
            try
            {
                File.WriteAllBytes(path, serializedEmployees);
            }
            catch (Exception error)
            {
                //could use some log here
            }
        }
    }
}
