using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UITask.Common;

namespace UITask.Test
{
    [TestFixture]
    public class EmployeeDataProviderTest
    {
        [TestCaseSource("TestData")]
        public void ShouldSerializeAndDeserializeEmployeeProperly(Employee oneToTest)
        {
            var dataProvider = new EmployeeDataProvider();
            dataProvider.SaveEmployee(oneToTest);
            var firstSavedEmployee = dataProvider.LoadEmployees().ToList()[0];
            //Could override equals and ==/!= so then we would simply use firstSavedEmployee == oneToTest
            Assert.True(firstSavedEmployee.FirstName == oneToTest.FirstName);
            Assert.True(firstSavedEmployee.LastName == oneToTest.LastName);
            Assert.True(firstSavedEmployee.Salary == oneToTest.Salary);
            Assert.True(firstSavedEmployee.IsDeveloper == oneToTest.IsDeveloper);
            Assert.True(firstSavedEmployee.Sex == oneToTest.Sex);
        }

        public static IEnumerable<Employee> TestData
        {
            get
            {
                yield return new Employee { FirstName = "John", LastName = "Smith", Salary = 10000, IsDeveloper = true, Sex = Sex.Male };
                yield return new Employee { FirstName = "Janet", LastName = "Pesci", Salary = 333, IsDeveloper = false, Sex = Sex.Female };
                yield return new Employee { FirstName = "", LastName = "", Salary = -100, IsDeveloper = false, Sex = Sex.Female };
                yield return new Employee { FirstName = "One", LastName = "Two", Salary = uint.MaxValue, IsDeveloper = false, Sex = Sex.Female };
            }
        }
    }
}