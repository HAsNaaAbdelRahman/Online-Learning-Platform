using Online_Learning_Platform.Core.Models;
using System;
using System.Threading.Tasks;

namespace Online_Learning_Platform.Core.Repositories.Contract
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<User> Users { get; }
        IGenericRepository<Course> Courses { get; }
        IGenericRepository<Enrollment> Enrollments { get; }
        IGenericRepository<Module> Modules { get; }
        IGenericRepository<Lesson> Lessons { get; }

        Task<int> CompleteAsync();
    }
}
