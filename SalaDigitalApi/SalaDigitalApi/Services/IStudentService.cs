using SalaDigitalApi.Models;

namespace SalaDigitalApi.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAlunos();
        Task<Student> GetAluno(int id);
        Task<IEnumerable<Student>> GetAlunosByName(string name);
        Task CreateStudent(Student student);
        Task UpdateStudent(Student student);
        Task DeleteStudent(Student student);

    }
}
