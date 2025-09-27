namespace EF_Core_Beispiele
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public List<Course> Courses { get; set; } = new();
    }
}
