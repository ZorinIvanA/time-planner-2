using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimePlanner.Infrastructure.Interfaces
{
    /// <summary>
    /// Интерфейс для мапперов между DTO и доменной сущностью
    /// </summary>
    public interface IMapper<TDto, TEntity>
        where TEntity : class, new()
        where TDto : class, new()
    {
        /// <summary>
        /// Возвращает DTO, полученную из сущности
        /// </summary>
        /// <param name="entity">Доменная сущность</param>
        TDto ToDto(TEntity entity);

        /// <summary>
        /// Возвращает сущность, полученную из DTO
        /// </summary>
        /// <param name="dto">Исходная DTO</param>
        TEntity FromDto(TDto dto);
    }
}
