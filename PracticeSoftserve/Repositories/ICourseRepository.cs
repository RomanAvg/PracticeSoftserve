using PracticeSoftserve.Controllers;
using PracticeSoftserve.Models;

namespace PracticeSoftserve.Repositories
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAllCourses();
        Task<Course> GetCourseById(int courseId);
        Task AddCourse(Course course);
        Task UpdateCourse(Course course);
        Task DeleteCourse(int courseId);
    }

}
