using CleanArchitecture.Domain.Common;
using System.Linq.Expressions;

namespace CleanArchitecture.Application.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T : BaseDomainModel
    {
        // --Metodos para la obtencion de datos--
        Task<IReadOnlyCollection<T>> GetAllAsync();
        Task<IReadOnlyCollection<T>> GetAsync(Expression<Func<T, bool>> expression);
        //Para listar por orden 
        Task<IReadOnlyCollection<T>> GetAsync(Expression<Func<T, bool>> expression = null,
                                       Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                       string includeString = null,
                                       bool disableTracking = true);
        //Para paginación, relacion de tablas, joins
        Task<IReadOnlyCollection<T>> GetAsync(Expression<Func<T, bool>> expression = null,
                                      Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                      List<Expression<Func<T, object>>> includes = null,
                                      bool disableTracking = true);
        Task<T> GetByIdAsync(int id);

        // --Metodos para la manipulación de datos--

        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
