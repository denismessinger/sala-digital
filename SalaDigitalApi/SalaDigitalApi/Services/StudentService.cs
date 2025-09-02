using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using SalaDigitalApi.Context;
using SalaDigitalApi.Models;

namespace SalaDigitalApi.Services
{
    public class StudentService : IStudentService
    {
        private readonly AppDbContext _context;

        public StudentService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Student>> GetAlunos()
        {
            try
            {
                return await _context.Students.ToListAsync();
            }
            catch
            {
                throw;
            }
            
        }
        public async Task<IEnumerable<Student>> GetAlunosByName(string name)
        {
            try
            {
                IEnumerable<Student> students;
                if (!string.IsNullOrWhiteSpace(name)
                {
                    students = await _context.Students.Where(n => n.Name == name).ToListAsync();
                }
                else
                {
                    students = await GetAlunos();
                }
                return students;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Student> GetAluno(int id)
        {
            try
            {
                var student = await _context.Students.FindAsync(id);
                return student;
            }
            catch
            {
                throw;
            }
        }

        public async Task CreateStudent(Student student)
        {
            try
            {
                _context.Students.Add(student);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task UpdateStudent(Student student)
        {
            try
            {
                _context.Entry(student).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteStudent(Student student)
        {
            try
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
