using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Core.Entities;

namespace Blog.Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
    }
}