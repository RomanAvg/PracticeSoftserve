using Microsoft.EntityFrameworkCore;
using PracticeSoftserve.Data;
using PracticeSoftserve.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PracticeSoftserve.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly SchoolContext _context;

        public TeacherRepository(SchoolContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Teacher>> GetAllTeachers()
        {
            return await _context.Teachers.ToListAsync();
        }

        public async Task<Teacher> GetTeacherById(int teacherId)
        {
            return await _context.Teachers.FindAsync(teacherId);
        }

        public async Task AddTeacher(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTeacher(Teacher teacher)
        {
            _context.Entry(teacher).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTeacher(int teacherId)
        {
            var teacher = await _context.Teachers.FindAsync(teacherId);
            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();
        }
    }


}
