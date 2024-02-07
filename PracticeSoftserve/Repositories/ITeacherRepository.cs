using PracticeSoftserve.Models;

namespace PracticeSoftserve.Repositories
{
    public interface ITeacherRepository
    {
        Task<IEnumerable<Teacher>> GetAllTeachers();
        Task<Teacher> GetTeacherById(int teacherId);
        Task AddTeacher(Teacher teacher);
        Task UpdateTeacher(Teacher teacher);
        Task DeleteTeacher(int teacherId);
    }

}
