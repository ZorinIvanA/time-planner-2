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
    /// Бизнес-логика работы с целями
    /// </summary>
    public interface IGoalsService
    {
        /// <summary>
        /// Помечает цель как выполненную
        /// </summary>
        /// <param name="goal">Цель, которую надо выполнить</param>
        Task<IOperationResult> CompleteAsync(Goal goal);
    }
}
