using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudLondrisoft.Models;
using CrudLondrisoft.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudLondrisoft.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentController : Controller
    {

        private IService<Student, Student> StudentService;

        public StudentController(IService<Student, Student> _StudentService)
        {
            StudentService = _StudentService;
        }


        [HttpGet]
        [ProducesResponseType(typeof(List<Student>), 200)]
        public IActionResult Get() => Ok(StudentService.FindAll());


        // GET
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Student), 200)]
        public IActionResult Get(int id)
        {
            var student = StudentService.FindByID(id);
            if (student == null) return NotFound();
            return Ok(student);
        }

        // POST
        [HttpPost]
        public IActionResult Post([FromBody] Student student)
        {
            if (student == null) return BadRequest();
            return new ObjectResult(StudentService.Create(student));
        }

        // PUT
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Student student)
        {
            if (student == null) return BadRequest();//corpo do ooj vazio
            var updatedStudent = StudentService.Update(student);
            if (updatedStudent == null) return BadRequest();//obj nao existe no banco de dados
            return new ObjectResult(updatedStudent);
        }

        // DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            StudentService.Delete(id);
            return NoContent();
        }
    }
}
