using API_Database.Data;
using API_Database.Models;
namespace API_Database.Services.Students;

public class StudentService : IStudentService
{
    private readonly DataContext _db;

    public StudentService(DataContext db)
    {
        _db = db;
    }

    public List<Student> AddStudent(string firstName, string lastName, string hobby)
    {
        Student newStudent = new();


        newStudent.FirstName = firstName;
        newStudent.LastName = lastName;
        newStudent.Hobby = hobby;

        _db.Students.Add(newStudent);
        _db.SaveChanges();

        return _db.Students.ToList();
    }

    public List<Student> DeleteStudent(string firstName)
    {


        var foundStudent = _db.Students.FirstOrDefault(student => student.FirstName.ToUpper() == firstName.ToUpper());
        if (foundStudent != null)
        {
            _db.Students.Remove(foundStudent);
            _db.SaveChanges();
        }
        return _db.Students.ToList();
    }

    public List<Student> GetStudents()
    {
        return _db.Students.ToList();
    }
}