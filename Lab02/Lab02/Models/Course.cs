namespace Lab02.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int Credit { get; set; }
        public int TheoryHours { get; set; }
        public int PracticeHours => (Credit * 15 - TheoryHours)*2;
        public int TotalHours => TheoryHours + PracticeHours;
    }
}
