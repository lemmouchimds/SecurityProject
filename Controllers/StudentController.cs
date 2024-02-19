using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SecurityAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class StudentController : Controller
    {

        [HttpGet(Name = "GetStudents")]
        public Student GetStudents(string name)
        {
            return new Student
            {
                Name = name,
                Age = 20,
                Grade = "A"
            };
        }
    }
}
