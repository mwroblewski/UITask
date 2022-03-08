namespace UITask.Common
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; } //For this task this could simply be uint/ulong
        public bool IsDeveloper { get; set; }
        public Sex Sex { get; set; }
    }

    public enum Sex
    {
        Male,
        Female
    }
}