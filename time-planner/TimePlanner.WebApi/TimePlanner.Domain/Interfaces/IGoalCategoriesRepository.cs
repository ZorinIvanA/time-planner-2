using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timeplanner.Core.Interfaces;
using TimePlanner.Domain.Models;

namespace TimePlanner.Domain.Interfaces
{
    /// <summary>
    /// Репозиторий категорий цели
    /// </summary>
    public interface IGoalCategoriesRepository
    {
        /// <summary>
        /// Возвращает список всех категорий, соответствующих условию, заданному функцией
        /// </summary>
        Task<IOperationResult<IEnumerable<GoalCategory>>> GetAllAsync(Func<GoalCategory, bool> selectFunc = null);
        /// <summary>
        /// Добавляет категорию цели из переданного параметра
        /// </summary>
        /// <param name="category">Категория цели</param>
        Task<IOperationResult<Guid>> AddCategory(GoalCategory category);

        /// <summary>
        /// Изменяет категорию цели данными из переданного параметра
        /// </summary>
        /// <param name="category">Данные для изменения категории цели</param>
        Task<IOperationResult>EditCategory(GoalCategory category);

        /// <summary>
        /// Удаляет категорию цели с переданным id
        /// </summary>
        /// <param name="id">Id категории цели, которую надо удалить</param>
        Task<IOperationResult> DeleteCategory(Guid id);
    }
}
