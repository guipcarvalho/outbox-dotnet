using Ordering.Model.Entities;

namespace Ordering.Data.Repositories.Contracts;

public interface ICourseRepository
{
    Task<IEnumerable<Course>> GetCoursesAsync(bool includeReviews = false);
    
    Task<Course?> GetCourseByIdAsync(int id, bool includeReviews = false);
    Task<Course> AddCourseAsync(Course course);
    
    Task<Course> UpdateCourseAsync(Course course);
    
    Task<bool> DeleteCourseAsync(int idCourse);
}