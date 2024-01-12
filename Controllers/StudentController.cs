using API_Database.Models;
using API_Database.Services.Students;
using Microsoft.AspNetCore.Mvc;

namespace API_Database.Controllers;

[ApiController] 
[Route("[controller]")] 

public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService; 

    public StudentController(IStudentService studentService) 
    
    {
        
        _studentService = studentService;
    }

    [HttpGet] 
    [Route("Read")] 
    public List<Student> GetStudents()
    {
        
        return _studentService.GetStudents();
    }

    [HttpPost] 
    [Route("CreateStudent/{firstName}/{lastName}/{hobby}")] 
    public List<Student> AddStudent(string firstName, string lastName, string hobby)
    {
        return _studentService.AddStudent(firstName,lastName,hobby);
    }

    [HttpDelete] 
    [Route("DeleteStudent/{firstName}")]
    public List<Student> DeleteStudent(string firstName)
    {
        return _studentService.DeleteStudent(firstName);
    }

}
