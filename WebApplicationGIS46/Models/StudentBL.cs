namespace WebApplicationGIS46.Models
{
    public class StudentBL
    {
        List<Student> students;
        public StudentBL()
        {
            students = new List<Student>() { 
                new Student(){ Id=1,Name="ahmed1",Address="alex",ImageURL="m.png"},
                new Student(){ Id=2,Name="ahmed2",Address="alex",ImageURL="m.png"},
                new Student(){ Id=3,Name="ahmed3",Address="alex",ImageURL="m.png"},
                new Student(){ Id=4,Name="ahmed4",Address="alex",ImageURL="m.png"},
                new Student(){ Id=5,Name="mona4",Address="alex",ImageURL="2.jpg"}
            };
        }
        public List<Student> GetAll()
        {
            return students;
        }
        public Student GetById(int id)
        {
            return students.FirstOrDefault(s => s.Id == id);
        }
    }
}
