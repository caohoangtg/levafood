using Catalog.Domain.Common;
using System.Linq.Expressions;

namespace Catalog.Infrastructure.Contracts.IRepositories
{
	public interface IAsyncRepository<T> where T : EntityBase
	{
		Task<IReadOnlyList<T>> GetAllAsync();
		Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);
		Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>>? predicate = null,
										Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
										string? includeString = null,
										bool disableTracking = true);
		Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>>? predicate = null,
									   Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
									   List<Expression<Func<T, object>>>? includes = null,
									   bool disableTracking = true);
		Task<T> GetByIdAsync(Guid id);
		Task<T> GetByIdAsync(Guid id, Expression<Func<T, bool>>? predicate = null, List<string>? includeStrings = null);
		Task<T> GetByIdAsync(Guid id, Expression<Func<T, bool>>? predicate = null, List<Expression<Func<T, object>>>? includes = null);
		Task<T> AddAsync(T entity);
		Task<int> UpdateAsync(T entity);
		Task<int> DeleteAsync(T entity);
		IQueryable<T> GetAsQueryable(Expression<Func<T, bool>>? predicate = null, List<Expression<Func<T, object>>>? includes = null, bool disableTracking = true);
	}
}
