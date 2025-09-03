using Microsoft.AspNetCore.Mvc;
using SalaDigitalApi.Models;
using SalaDigitalApi.Services;

namespace SalaDigitalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentsController(IStudentService service)
        {
            _service = service;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            try
            {
                var students = await _service.GetStudents();
                return Ok(students);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            try
            {
                var student = await _service.GetStudent(id);

                if (student == null)
                    return NotFound($"Aluno com ID {id} não encontrado.");

                return Ok(student);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        // GET: api/Students/nome
        [HttpGet("StudentsByName")]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudentsByName([FromQuery] string name)
        {
            try
            {
                var students = await _service.GetStudentsByName(name);
                return Ok(students);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        // PUT: api/Students/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {
            if (id != student.Id)
                return BadRequest("ID informado não corresponde ao aluno enviado.");

            try
            {
                await _service.UpdateStudent(student);
                return NoContent(); // Melhor que Ok() para update
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Aluno com ID {id} não encontrado.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        // POST: api/Students
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            try
            {
                var created = await _service.CreateStudent(student);

                // Retorna 201 Created com a rota do recurso criado
                return CreatedAtAction(nameof(GetStudent), new { id = created.Id }, created);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            try
            {
                var student = await _service.GetStudent(id);
                if (student == null)
                    return NotFound($"Aluno com ID {id} não encontrado.");

                await _service.DeleteStudent(student);

                return NoContent(); // Melhor que Ok() para delete
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }
    }
}
