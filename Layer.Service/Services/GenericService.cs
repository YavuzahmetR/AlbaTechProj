using Layer.Core.Repositories;
using Layer.Core.Services;
using Layer.Core.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Layer.Service.Services
{
    public class GenericService<T> : IService<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;
        private readonly IUnitOfWork _unitofwork;

        public GenericService(IGenericRepository<T> repository, IUnitOfWork unitofwork)
        {
            _repository = repository;
            _unitofwork = unitofwork;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _repository.AddAsync(entity);
            await _unitofwork.CommitAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unitofwork.CommitAsync();
            return entities;
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _repository.AnyAsync(expression);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            await _repository.GetAll().ToListAsync();
            await _unitofwork.CommitAsync();
            return _repository.GetAll();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _repository.GetById(id);

        }

        public async Task RemoveAsync(T entity)
        {
            _repository.Remove(entity);
            await _unitofwork.CommitAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<T> entities)
        {
            _repository.RemoveRange(entities);
            await _unitofwork.CommitAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _repository.Update(entity);
            await _unitofwork.CommitAsync();

        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _repository.Where(expression);
        }
    }
}
