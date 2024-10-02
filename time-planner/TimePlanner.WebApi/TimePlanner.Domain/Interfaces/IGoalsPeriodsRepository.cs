using Timeplanner.Core.Interfaces;
using TimePlanner.Domain.Models;

namespace TimePlanner.Domain.Interfaces
{
    /// <summary>
    /// Интерфейс для репозитория периодов
    /// </summary>
    public interface IGoalsPeriodsRepository
    {
        /// <summary>
        /// Возвращает список периодов по их id
        /// </summary>
        /// <param name="ids">Id периодов, которые необходимо вернуть</param>
        Task<IOperationResult<IEnumerable<TrackingPeriod>>> GetPeriodsByIdsAsync(params Guid[] ids);

        /// <summary>
        /// Возвращает полный список периодов
        /// </summary>
        Task<IOperationResult<IEnumerable<TrackingPeriod>>> GetPeriodsAsync();
    }
}
