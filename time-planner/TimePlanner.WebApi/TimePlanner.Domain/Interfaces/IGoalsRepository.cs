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
    /// Репозиторий целей
    /// </summary>
    public interface IGoalsRepository
    {
        /// <summary>
        /// Возвращает список целей по списку Id
        /// </summary>
        /// <param name="ids"></param>        
        Task<IOperationResult<IQueryable<Goal>>> GetGoalsByIdsAsync(params Guid[] ids);

        /// <summary>
        /// Изменяет заданную цель
        /// </summary>
        /// <param name="goal">Цель, содержащая все изменения и id изменяемой цели в БД</param>
        Task<IOperationResult> UpdateGoalAsync(Goal goal);
    }
}
