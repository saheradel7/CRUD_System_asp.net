using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        List<Students> _oStudents = new List<Students>() {
            new Students { Id = 1,Name = "name1" , Roll=101},
            new Students { Id = 2,Name = "name2" , Roll=102},
            new Students { Id = 3,Name = "name3" , Roll=103},
            new Students { Id = 4,Name = "name4" , Roll=104},
            new Students { Id = 5,Name = "name5" , Roll=105},
            new Students { Id = 6,Name = "name6" , Roll=106},
        };

        [HttpGet]
        public IActionResult Gets()
        { 
            if (_oStudents.Count()==0)
            { 
                return NotFound("no students found"); 
            };

            return Ok( _oStudents );
        }

        [HttpGet("GetStudent")]

        public IActionResult Get(int id)
        {
            var SingelStudent = _oStudents.SingleOrDefault(x => x.Id == id);
            if (SingelStudent == null) {
                return NotFound("id not found");
            }
            return Ok(_oStudents[id]);
        }

        [HttpPost]

        public IActionResult Save(Students AddedStudent)
        {
            _oStudents.Add(AddedStudent);
            if (_oStudents.Count()==0)
            {
                return NotFound("list not found");
            }
            return Ok(AddedStudent);

        }

        [HttpDelete]

        public IActionResult Delete(int id)
        {
            var DeletedStudent = _oStudents.SingleOrDefault(x => x.Id == id);
            if (DeletedStudent == null)
            {
                return BadRequest("not found");
            }
            _oStudents.Remove(DeletedStudent);
            if (_oStudents.Count == 0) { 
                return NotFound("not found");
            }
            return Ok(_oStudents);
        }
    }
}
