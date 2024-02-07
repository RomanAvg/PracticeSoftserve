using Microsoft.EntityFrameworkCore;
using PracticeSoftserve.Data;
using PracticeSoftserve.Models;

namespace PracticeSoftserve.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolContext _context;

        public StudentRepository(SchoolContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> GetStudentById(int studentId)
        {
            return await _context.Students.FindAsync(studentId);
        }

        public async Task AddStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStudent(Student student)
        {
            _context.Entry(student).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStudent(int studentId)
        {
            var student = await _context.Students.FindAsync(studentId);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }
    }


}
