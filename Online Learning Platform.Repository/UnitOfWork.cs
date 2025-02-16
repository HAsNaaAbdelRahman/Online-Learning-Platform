using Online_Learning_Platform.Core.Models;
using Online_Learning_Platform.Core.Repositories.Contract;
using Online_Learning_Platform.Repository.Data;
using Online_Learning_Platform.Repository.Repositories;

namespace Online_Learning_Platform.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IGenericRepository<User> Users { get; private set; }
        public IGenericRepository<Course> Courses { get; private set; }
        public IGenericRepository<Enrollment> Enrollments { get; private set; }
        public IGenericRepository<Module> Modules { get; private set; }
        public IGenericRepository<Lesson> Lessons { get; private set; }


        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Users = new GenericRepository<User>(_context);
            Courses = new GenericRepository<Course>(_context);
            Enrollments = new GenericRepository<Enrollment>(_context);
            Modules = new GenericRepository<Module>(_context);
            Lessons = new GenericRepository<Lesson>(_context);
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
             _context.Dispose();
        }

    }
}
