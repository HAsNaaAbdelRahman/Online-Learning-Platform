using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Learning_Platform.Core.Repositories.Contract
{
    public interface IGenericRepository<T> where T : class
    {
        public Task<IReadOnlyList<T>> GetAllAsync();
        public Task<T> GetByIdAsync(string id);

        public void addAsync(T entity);
        public void updateAsync(T entity);
        public void deleteAsync(T entity);

    }
}
