using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimePlanner.Infrastructure.EFCore;

namespace TimePlanner.Infrastructure.Base
{
    internal abstract class EfRepositoryBase<TDto, TModel, TMapper>
        where TDto : DtoBase
        where TModel : class, new()
        where TMapper : class
    {
        protected GoalsContext context;

        protected EfRepositoryBase()
        {
            this.context = new GoalsContext();
        }

        /// <summary>
        /// Асинхронно возвращает элементы указанного класса-dto. Должен быть описан в репозитории.
        /// </summary>
        /// <param name="selectFunc">Функция отбора</param>
        /// <param name="pageSize">Размер страницы</param>
        /// <param name="currentPage">Номер текущей страницы (с 0)</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns></returns>
        protected abstract IQueryable<TDto> GetDataInternalAsync(Func<TDto, bool> selectFunc,
            int pageSize,
            int currentPage,
            CancellationToken cancellationToken);
    }
}
