using MealPlanner.Data.Interfaces.DTO;
using System.Linq.Expressions;

namespace MealPlanner.Data.Interfaces.Repositories
{
    public interface IBaseActionRepository<TDTO, TCreateDTO> 
        where TDTO : BaseDTO
        where TCreateDTO : BaseCreateDTO
    {
        #region Read

        Task<List<TDTO>> GetAllAsync();

        Task<TDTO> GetByIdAsync(string id);

        Task<List<TDTO>> GetAsync(Expression<Func<TDTO, bool>> filterExpression);

        Task<TDTO> GetFirstAsync(Expression<Func<TDTO, bool>> filterExpression);

        #endregion

        #region Create

        Task<string> CreateAsync(TCreateDTO item);

        Task CreateManyAsync(IEnumerable<TCreateDTO> items);

        #endregion

        #region Replace
        
        Task<bool> ReplaceAsync(TDTO item);

        #endregion

        #region Delete
        
        Task<bool> DeleteOneAsync(string id);
        
        Task<bool> DeleteManyAsync(Expression<Func<TDTO, bool>> filterExpression);

        #endregion
    }
}
