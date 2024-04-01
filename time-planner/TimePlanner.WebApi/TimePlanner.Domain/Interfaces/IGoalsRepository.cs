using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimePlanner.Domain.Models;

namespace TimePlanner.Domain.Interfaces
{
    /// <summary>
    /// Репозиторий целей
    /// </summary>
    public interface IGoalsRepository
    {
        /// <summary>
        /// Возвращает список целей по предикату
        /// </summary>
        /// <param name="ids"></param>        
        Task<IEnumerable<Goal>> GetGoalsById(Func<Goal, bool> selectFunc);

        /// <summary>
        /// Изменяет заданную цель
        /// </summary>
        /// <param name="goal">Цель, содержащая все изменения и id изменяемой цели в БД</param>
        Task UpdateGoal(Goal goal);
    }
}
