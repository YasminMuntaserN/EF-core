using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using study_center_ef.StudyCenterBusiness.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace study_center_ef.StudyCenter_Business.Base
{
    /// <summary>
    /// Provides a generic, reusable service for performing basic CRUD operations on entities.
    /// Implements the IBaseService interface.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity this service operates on.</typeparam>
    public abstract class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;
        //ILogger<T> is part of the Microsoft.Extensions.Logging namespace and provides logging capabilities.
        protected readonly ILogger<BaseService<TEntity>> _logger;

        protected BaseService(
            AppDbContext context,
            ILogger<BaseService<TEntity>> logger)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
            _logger = logger;
        }

        public virtual async Task<TEntity?> GetByIdAsync(int id)
        {
            try
            {
                return await _dbSet.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving entity by id: {Id}", id);
                throw;
            }
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            try
            {
                return await _dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving all entities");
                throw;
            }
        }

        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating entity");
                throw;
            }
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            try
            {
                _dbSet.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating entity");
                throw;
            }
        }

        public virtual async Task SoftDeleteAsync(int id)
        {
            try
            {
                await _dbSet
                .ExecuteUpdateAsync(set => set
                    .SetProperty(e => EF.Property<bool>(e, "IsActive"), false));

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while soft-deleting entity");
                throw;
            }
        }

        public virtual async Task HardDeleteAsync(int id)
        {
            try
            {
                var entity = await GetByIdAsync(id);
                if (entity != null)
                {
                    _dbSet.Remove(entity);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting entity with id: {Id}", id);
                throw;
            }
        }

        public virtual async Task<bool> ExistsAsync(int id)
        {
            try
            {
                return await _dbSet.FindAsync(id) != null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error checking existence of entity with id: {Id}", id);
                throw;
            }
        }

    }

}
