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

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _context.Students.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Student>> GetStudentsByName(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                return await _context.Students
                    .AsNoTracking()
                    .Where(n => n.Name.Contains(name))
                    .ToListAsync();
            }

            return await GetStudents();
        }

        public async Task<Student?> GetStudent(int id)
        {
            return await _context.Students.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Student> CreateStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task UpdateStudent(Student student)
        {
            var exists = await _context.Students.AnyAsync(s => s.Id == student.Id);
            if (!exists)
            {
                throw new KeyNotFoundException($"Aluno com ID {student.Id} não encontrado.");
            }

            _context.Entry(student).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStudent(Student student)
        {
            var exists = await _context.Students.AnyAsync(s => s.Id == student.Id);
            if (!exists)
            {
                throw new KeyNotFoundException($"Aluno com ID {student.Id} não encontrado.");
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }
    }
}
