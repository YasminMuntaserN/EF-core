using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study_center_ef.StudyCenterBusiness.Interfaces
{
    /// <summary>
    /// Defines a generic service interface for basic CRUD operations.
    /// </summary>
    /// <typeparam name="TEntity">The entity type the service operates on.</typeparam>
    public interface IBaseService<TEntity> where TEntity : class
    {
        Task<TEntity?> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task HardDeleteAsync(int id);
        Task SoftDeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
