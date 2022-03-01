namespace UITask.Common
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public bool IsDeveloper { get; set; }
        public Sex Sex { get; set; } = Sex.Male;
    }

    public enum Sex
    {
        Male,
        Female
    }
}