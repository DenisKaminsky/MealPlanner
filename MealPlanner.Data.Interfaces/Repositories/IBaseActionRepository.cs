using MealPlanner.Data.Interfaces.DTO;
using System.Linq.Expressions;

namespace MealPlanner.Data.Interfaces.Repositories
{
    public interface IBaseActionRepository<T> where T : BaseDTO
    {
        #region Read

        Task<List<T>> GetAllAsync();

        Task<T> GetByIdAsync(string id);

        Task<List<T>> GetAsync(Expression<Func<T, bool>> filterExpression);

        Task<T> GetFirstAsync(Expression<Func<T, bool>> filterExpression);

        #endregion

        #region Create

        Task<string> CreateAsync(T item);

        Task CreateManyAsync(IEnumerable<T> items);

        #endregion

        #region Replace
        
        Task<bool> ReplaceAsync(T item);

        #endregion

        #region Delete
        
        Task<bool> DeleteOneAsync(string id);
        
        Task<bool> DeleteManyAsync(Expression<Func<T, bool>> filterExpression);

        #endregion
    }
}
