using Microsoft.AspNetCore.Http;
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
        [ProducesResponseType(typeof(List<Student>),StatusCodes.Status200OK)]
        public IActionResult Get() => Ok(StudentService.FindAll());


        // GET
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Student), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            var student = StudentService.FindByID(id);
            if (student == null) return NotFound();
            return Ok(student);
        }

        // POST
        [HttpPost]
        [ProducesResponseType(typeof(Student), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] Student student)
        {
            if (student == null) return BadRequest();
            student = StudentService.Create(student);
            return CreatedAtAction(nameof(GetById),new { id = student.StundentId },student);
        }

        // PUT
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Student), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Put([FromBody] Student student)
        {
            if (student == null) return BadRequest();//corpo vazio
            var updatedStudent = StudentService.Update(student);
            if (updatedStudent == null) return BadRequest();//obj nao existe no banco de dados
            return new ObjectResult(updatedStudent);
        }

        // DELETE
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            var result = StudentService.Delete(id);
            if(result == null)
                return NotFound();
            return NoContent();
        }
    }
}
