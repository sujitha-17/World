using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using World.Api.Data;
using World.Api.DTO.Students;
using World.Api.Model;

namespace World.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        IMapper _mapper;
        public StudentController(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateStudentDto createStudentDto)
        {
            var student = _mapper.Map<Students>(createStudentDto);
            _db.Add(student);
            _db.SaveChanges();
            return Ok(student);
        }

        [HttpPut]
        public IActionResult Edit(int id, [FromBody] UpdateStudentDto updateStudentDto)
        {
           if(updateStudentDto == null || id!= updateStudentDto.Id)
            {
                return BadRequest(ModelState);
            }
            var student = _mapper.Map<Students>(updateStudentDto);
            _db.Update(student);
            _db.SaveChanges();
            return Ok(student);

        }

        [HttpGet("{id:int}")]

        public IActionResult Get(int id)
        {
            Students student = _db.students.FirstOrDefault(x => x.Id == id);
            return Ok(student);
        }

        [HttpGet]

        public IActionResult Get()
        {
            List<Students> students = new List<Students>();
            students = _db.students.ToList();
            return Ok(students);
        }

        [HttpDelete("{id:int}")]

        public IActionResult Delete(int id)
        {
            if(id == null)
            {
                return BadRequest(ModelState);
            }
            var student = _db.students.FirstOrDefault(y => y.Id == id);
            _db.Remove(student);
            _db.SaveChanges();
            return Ok();

        }

    }
}
